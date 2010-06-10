using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;
using UFIDA.U8.MomServiceCommon;
using UFIDA.U8.U8MOMAPIFramework;
using UFIDA.U8.U8APIFramework;
using UFIDA.U8.U8APIFramework.Meta;
using UFIDA.U8.U8APIFramework.Parameter;
using MSXML2;
using System.Data;
using System.Diagnostics;
using U8.Interface.Bus.ApiService.Model;
using U8.Interface.Bus.DBUtility;

namespace U8.Interface.Bus.ApiService.BLL
{

    /// <summary>
    /// 供应链单据API操作工厂类
    /// </summary>
    public abstract class SupplyChainOp : APIOp
    {


        /// <summary>
        /// 组织数据
        /// </summary>
        /// <param name="dt">当前任务节点信息</param>
        /// <param name="bd">HY_DZ_K7_DLLReflect 中预置的 data类</param>
        /// <returns></returns>
        public override Model.DealResult MakeData(Model.Synergismlogdt dt, BaseData bd)
        { 
            Model.DealResult dr = new Model.DealResult();
            Model.APIData apidata = bd as Model.APIData;         //API实体,包括当前任务节点信息
            DAL.TaskLogFactory.ITaskLogDetail dtdal;
           
            //当前任务节点信息
            switch (apidata.TaskType)
            {
                case 0:
                    dtdal = new DAL.CQTaskDetail();
                    break;
                case 1:
                    dtdal = new DAL.SynergismLogDt();
                    break;
                case 2:
                    dtdal = new DAL.DS.TaskDetail();
                    break;
                default:
                    BLL.Common.ErrorMsg(SysInfo.productName, "tasktype" + apidata.TaskType + "未适配!");
                     dr.Message = "tasktype" + apidata.TaskType + "未适配!";
                     return dr;

            }
  
            Model.Synergismlogdt pdt = dtdal.GetPrevious(dt);      //上一任务节点信息

            apidata.ConnectInfo = dtdal.GetConnectInfo(dt);   //获取当前结点的数据串连接串
            apidata.Synergismlogdt = dt;

            if (!apidata.Dodelete)
            {
                DataSet rdds = SetFromTabet(dt, pdt, apidata);    //上一节点 单据头信息
                DataSet rdsds = SetFromTabets(dt, pdt, apidata);  //上一节点 单据体信息

                DAL.IFieldcmps fieldcmpdal = ClassFactory.GetIFieldcmpsDAL(apidata.TaskType); //new DAL.Fieldcmps();
                List<Model.Fieldcmps> listfd = fieldcmpdal.GetListFieldcmps(dt, pdt);   //字段对照信息
                BLL.U8NameValue u8namevaluebll = new BLL.U8NameValue();  //字段赋值
                u8namevaluebll.SetHeadData(apidata, rdds, rdsds, listfd, dt);
                u8namevaluebll.SetBodyData(apidata, rdds, rdsds, listfd, dt);
 
                //设置订单关联    
                DAL.Common.SetInBody(apidata);
                SetNormalValue(apidata, dt);
            }
            return dr;
        }



        /// <summary>
        /// 设置通用变量
        /// </summary>
        /// <param name="apidata"></param>
        /// <param name="dt"></param>
        public virtual void SetNormalValue(Model.APIData apidata, Model.Synergismlogdt dt)
        {
            DAL.APINormal.SetNormalValue(apidata, dt);
        }


        /// <summary>
        /// 生单
        /// </summary>
        /// <param name="bd"></param>
        /// <returns></returns>
        public override Model.DealResult MakeVouch(BaseData bd)
        {
            Model.DealResult dr;
            Model.APIData apidata = bd as Model.APIData;
            U8Login.clsLogin u8Login = new U8Login.clsLogin();
            
            dr = GetU8Login(apidata, u8Login);

            if (dr.ResultNum < 0) return dr;
            U8ApiBroker broker = null;
            dr = GetU8ApiBroker(apidata, u8Login, out   broker, "add");


            //设置api表头数据
            if (dr.ResultNum < 0) return dr;
            dr = SetDomHead(apidata, broker);


            //设置api表体数据
            if (dr.ResultNum < 0) return dr;
            dr = SetDomBody(apidata, broker);

            //设置其它数据
            if (dr.ResultNum < 0) return dr;
            dr = AssignNormalValues(apidata, broker);

           

            if (dr.ResultNum < 0) return dr; 
            string strRow;
            {
                U8ApiBroker ubOrder = null;
                dr = GetU8ApiBroker(apidata, u8Login, out ubOrder, "add");
                MSXML2.IXMLDOMDocument2 xmlHead = broker.GetBoParam("DomHead").ToRSDOM();
                MSXML2.IXMLDOMDocument2 xmlBody = broker.GetBoParam("DomBody").ToRSDOM();
                dr = AssignNormalValues(apidata, ubOrder);

                MSXML2.IXMLDOMNodeList lstx;
                MSXML2.IXMLDOMNode xmle;

                #region 行号
                //行号赋值
                lstx = xmlBody.getElementsByTagName("z:row");
                
                switch (bd.Synergismlogdt.Cvouchertype)
                {
                    case "27":  //采购请购单
                    case "88":  //采购订单
                        strRow = "ivouchrowno";
                        break;
                    case "01":  //发货、退货单
                        strRow = "iorderrowno";
                        break;
                    case "03":    //退货单  added by liuxzha  2014.11.27
                        strRow = "iorderrowno";
                        break;
                    default:
                        strRow = "irowno";
                        break;
                }
                for (int i = 0; i < lstx.length; i++)
                {
                    xmle = lstx[i].attributes.getNamedItem(strRow);
                    if (xmle == null)
                    {
                        xmle = xmlBody.createNode(System.Xml.XmlNodeType.Attribute, strRow, null);
                        xmle.nodeValue = (i + 1).ToString();
                        lstx[i].attributes.setNamedItem(xmle);
                    }
                    else
                    {
                        xmle.nodeValue = (i + 1).ToString();
                    }
                }
                #endregion

                #region 可用量
                //销售订单
                if (bd.Synergismlogdt.Cvouchertype == "17")
                {   //是否可用量检查
                    lstx = xmlHead.getElementsByTagName("z:row");
                    xmle = xmlHead.createNode(System.Xml.XmlNodeType.Attribute, "bcontinue", null);
                    xmle.nodeValue = "0";
                    lstx[0].attributes.setNamedItem(xmle);
                }
                //销售发货单
                else if (bd.Synergismlogdt.Cvouchertype == "01")
                {   //是否可用量检查
                    lstx = xmlHead.getElementsByTagName("z:row");
                    xmle = xmlHead.createNode(System.Xml.XmlNodeType.Attribute, "saveafterok", null);
                    xmle.nodeValue = "0";  //
                    lstx[0].attributes.setNamedItem(xmle);
                }
                //销售退货单  added by liuxzha 2014.11.27
                else if (bd.Synergismlogdt.Cvouchertype == "03")     
                {   //是否可用量检查
                    lstx = xmlHead.getElementsByTagName("z:row");
                    xmle = xmlHead.createNode(System.Xml.XmlNodeType.Attribute, "saveafterok", null);
                    xmle.nodeValue = "0";
                    lstx[0].attributes.setNamedItem(xmle);
                }
                //销售出库单
                else if (bd.Synergismlogdt.Cvouchertype == "0303")
                {   //是否可用量检查
                    lstx = xmlHead.getElementsByTagName("z:row");
                    xmle = xmlHead.createNode(System.Xml.XmlNodeType.Attribute, "saveafterok", null);
                    xmle.nodeValue = "0";
                    lstx[0].attributes.setNamedItem(xmle);
                }
                #endregion


                ubOrder.AssignNormalValue("domHead", xmlHead);
                ubOrder.AssignNormalValue("domBody", xmlBody);
                
                U8.Interface.Bus.Log.WriteFileWithName("DomHead.xml", xmlHead.xml);
                U8.Interface.Bus.Log.WriteFileWithName("DomBody.xml", xmlBody.xml);
                
                dr = BrokerInvoker(ubOrder);
            }  
            UpdateTeamworkField(bd, dr);
            ClearUATask(bd);
            //if (!DAL.Common.SetCreateDate(bd, dr.VouchIdRet))
            //    U8.Interface.Bus.Log.WriteWinLog("设置单据制单时间失败,Cvouchertype:" + bd.Synergismlogdt.Cvouchertype + ";VouchIdRet:" + dr.VouchIdRet + ".");

            return dr;
        }





        /// <summary>
        /// 设置表头
        /// </summary>
        /// <param name="apidata"></param>
        /// <param name="broker"></param>
        /// <returns></returns>
        public Model.DealResult SetDomHead(Model.APIData apidata, U8ApiBroker broker)
        {
            Model.DealResult dr = new Model.DealResult();
            BusinessObject DomHead = broker.GetBoParam("DomHead");
            DomHead.NeedFieldsCheck = false;
            DomHead.RowCount = 1; //设置BO对象(表头)行数，只能为一行
            foreach (Model.U8NameValue unv in apidata.HeadData)
            {
                DomHead[0][unv.U8FieldName.ToLower()] = unv.U8FieldValue;
            }
            return dr;
        }


        /// <summary>
        /// 用domxml的方法加载数据--表头
        /// </summary>
        /// <param name="apidata"></param>
        /// <param name="broker"></param>
        /// <param name="domheadxml"></param>
        /// <returns></returns>
        public Model.DealResult SetDomHead(Model.APIData apidata, U8ApiBroker broker, MSXML2.DOMDocument domheadxml)
        {
            Model.DealResult dr = new Model.DealResult();
             
            MSXML2.IXMLDOMNode headnode = domheadxml.selectSingleNode("//rs:data");
            MSXML2.IXMLDOMElement element = domheadxml.createElement("z:row");
            foreach (Model.U8NameValue unv in apidata.HeadData)
            {
                element.setAttribute(unv.U8FieldName.ToLower(), unv.U8FieldValue);
            }
            headnode.appendChild(element);
            return dr;
        }

        /// <summary>
        /// 设置表体
        /// </summary>
        /// <param name="apidata"></param>
        /// <param name="broker"></param>
        /// <returns></returns>
        public Model.DealResult SetDomBody(Model.APIData apidata, U8ApiBroker broker)
        {
            Model.DealResult dr = new Model.DealResult();
            BusinessObject domBody = broker.GetBoParam("domBody");
            domBody.RowCount = apidata.BodyData.Count;
            int i = 0;
            domBody.NeedFieldsCheck = false;  
            foreach (List<Model.U8NameValue> lunv in apidata.BodyData)
            {
                foreach (Model.U8NameValue unv in lunv)
                {
                    string fieldName = unv.U8FieldName.ToLower();

                    if (unv.U8FieldName == "bgsp" && domBody.CardNumber == "U870_TRANS_0303")
                    {
                        if (unv.U8FieldValue.ToString() == "是")
                        {
                            domBody[i][unv.U8FieldName.ToLower()] = "1";
                        }
                        else if (unv.U8FieldValue.ToString() == "否")
                        {
                            domBody[i][unv.U8FieldName.ToLower()] = "0";
                        }
                        else
                        {
                            domBody[i][unv.U8FieldName.ToLower()] = unv.U8FieldValue;
                        }
                    } 

                    else
                    {
                        int iFieldType = DAL.Common.GetFieldType(apidata.ConnectInfo.Constring, unv.U8FieldName, domBody.CardNumber);
                        if (iFieldType == 5 && !string.IsNullOrEmpty(unv.U8FieldValue))
                        {
                            domBody[i][unv.U8FieldName.ToLower()] = Convert.ToDateTime(unv.U8FieldValue).ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            domBody[i][unv.U8FieldName.ToLower()] = unv.U8FieldValue;
                        }
                    }
                } 
                i++;
            }

            return dr;
        }


        /// <summary>
        /// domxml的方法加载数据--表体
        /// </summary>
        /// <param name="apidata"></param>
        /// <param name="broker"></param>
        /// <param name="dombodyxml"></param>
        /// <returns></returns>
        public Model.DealResult SetDomBody(Model.APIData apidata, U8ApiBroker broker, MSXML2.DOMDocument dombodyxml)
        {
            Model.DealResult dr = new Model.DealResult();
            MSXML2.IXMLDOMNode node = dombodyxml.selectSingleNode("//rs:data");
            foreach (List<Model.U8NameValue> lunv in apidata.BodyData)
            {
                MSXML2.IXMLDOMElement element = dombodyxml.createElement("z:row");
                foreach (Model.U8NameValue unv in lunv)
                {
                    element.setAttribute(unv.U8FieldName.ToLower(), unv.U8FieldValue);
                }
                node.appendChild(element);
            }
            return dr;
        }



        /// <summary>
        /// 修改单据
        /// </summary>
        /// <param name="bd"></param>
        /// <returns></returns>
        public override Model.DealResult MakeUpdate(BaseData bd)
        {
            Model.DealResult dr;
            Model.APIData apidata = bd as Model.APIData;
            U8Login.clsLogin u8Login = new U8Login.clsLogin();

            dr = GetU8Login(apidata, u8Login);

            if (dr.ResultNum < 0) return dr;
            U8ApiBroker broker = null;
            dr = GetU8ApiBroker(apidata, u8Login, out   broker, "update");


            //设置api表头数据
            if (dr.ResultNum < 0) return dr;
            dr = SetDomHead(apidata, broker);


            //设置api表体数据
            if (dr.ResultNum < 0) return dr;
            dr = SetDomBody(apidata, broker);

            //设置其它数据
            if (dr.ResultNum < 0) return dr;
            dr = AssignNormalValues(apidata, broker);



            if (dr.ResultNum < 0) return dr;
            string strRow;
            {
                U8ApiBroker ubOrder = null;
                dr = GetU8ApiBroker(apidata, u8Login, out ubOrder, "update");
                MSXML2.IXMLDOMDocument2 xmlHead = broker.GetBoParam("DomHead").ToRSDOM();
                MSXML2.IXMLDOMDocument2 xmlBody = broker.GetBoParam("DomBody").ToRSDOM();
                dr = AssignNormalValues(apidata, ubOrder);

                MSXML2.IXMLDOMNodeList lstx;
                MSXML2.IXMLDOMNode xmle;

                #region 行号
                //行号赋值
                lstx = xmlBody.getElementsByTagName("z:row");

                switch (bd.Synergismlogdt.Cvouchertype)
                {
                    case "27":  //采购请购单
                    case "88":  //采购订单
                        strRow = "ivouchrowno";
                        break;
                    case "01":  //发货、退货单
                        strRow = "iorderrowno";
                        break;
                    case "03":    //退货单  added by liuxzha  2014.11.27
                        strRow = "iorderrowno";
                        break;
                    default:
                        strRow = "irowno";
                        break;
                }
                for (int i = 0; i < lstx.length; i++)
                {
                    xmle = lstx[i].attributes.getNamedItem(strRow);
                    if (xmle == null)
                    {
                        xmle = xmlBody.createNode(System.Xml.XmlNodeType.Attribute, strRow, null);
                        xmle.nodeValue = (i + 1).ToString();
                        lstx[i].attributes.setNamedItem(xmle);
                    }
                    else
                    {
                        xmle.nodeValue = (i + 1).ToString();
                    }
                }
                #endregion

                #region 可用量
                //销售订单
                if (bd.Synergismlogdt.Cvouchertype == "17")
                {   //是否可用量检查
                    lstx = xmlHead.getElementsByTagName("z:row");
                    xmle = xmlHead.createNode(System.Xml.XmlNodeType.Attribute, "bcontinue", null);
                    xmle.nodeValue = "0";
                    lstx[0].attributes.setNamedItem(xmle);
                }
                //销售发货单
                else if (bd.Synergismlogdt.Cvouchertype == "01")
                {   //是否可用量检查
                    lstx = xmlHead.getElementsByTagName("z:row");
                    xmle = xmlHead.createNode(System.Xml.XmlNodeType.Attribute, "saveafterok", null);
                    xmle.nodeValue = "0";  //
                    lstx[0].attributes.setNamedItem(xmle);
                }
                //销售退货单  added by liuxzha 2014.11.27
                else if (bd.Synergismlogdt.Cvouchertype == "03")
                {   //是否可用量检查
                    lstx = xmlHead.getElementsByTagName("z:row");
                    xmle = xmlHead.createNode(System.Xml.XmlNodeType.Attribute, "saveafterok", null);
                    xmle.nodeValue = "0";
                    lstx[0].attributes.setNamedItem(xmle);
                }
                //销售出库单
                else if (bd.Synergismlogdt.Cvouchertype == "0303")
                {   //是否可用量检查
                    lstx = xmlHead.getElementsByTagName("z:row");
                    xmle = xmlHead.createNode(System.Xml.XmlNodeType.Attribute, "saveafterok", null);
                    xmle.nodeValue = "0";
                    lstx[0].attributes.setNamedItem(xmle);
                }
                #endregion


                ubOrder.AssignNormalValue("domHead", xmlHead);
                ubOrder.AssignNormalValue("domBody", xmlBody);


                U8.Interface.Bus.Log.WriteFileWithName("DomHead.xml", xmlHead.xml);
                U8.Interface.Bus.Log.WriteFileWithName("DomBody.xml", xmlBody.xml);

                dr = BrokerInvoker(ubOrder);
            }
            UpdateTeamworkField(bd, dr);
            ClearUATask(bd);
            //if (!DAL.Common.SetCreateDate(bd, dr.VouchIdRet))
            //    U8.Interface.Bus.Log.WriteWinLog("设置单据制单时间失败,Cvouchertype:" + bd.Synergismlogdt.Cvouchertype + ";VouchIdRet:" + dr.VouchIdRet + ".");

            return dr;
        }


          



        /// <summary>
        /// 获取apibroker
        /// </summary>
        /// <param name="apidata"></param>
        /// <param name="u8Login"></param>
        /// <param name="broker"></param>
        /// <returns></returns>
        public Model.DealResult GetU8ApiBroker(Model.APIData apidata, U8Login.clsLogin u8Login, out  U8ApiBroker broker, string op)
        {

            Model.DealResult dr = new Model.DealResult();
            dr = base.GetU8ApiBroker(apidata, u8Login, out broker, op); 
            apidata.SVouchType = SetVouchType();
            return dr;
        }





        //
        public abstract Model.DealResult AssignNormalValues(Model.APIData apidata, U8ApiBroker broker);


        //设置单据类型(u8 api 中的单据类型)
        public abstract string SetVouchType();



 

        /// <summary>
        /// 获取subid
        /// </summary>
        /// <returns></returns>
        public abstract string SetSubId();
        public abstract Model.DealResult LoadVouch(Model.APIData bd, Model.Synergismlogdt dt, out BusinessObject domHead, out BusinessObject domBody);
        public abstract Model.DealResult CancelAudit(Model.APIData bd, Model.Synergismlogdt dt);




    }
}
