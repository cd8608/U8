using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.InteropServices;
using UFIDA.U8.MomServiceCommon;
using UFIDA.U8.U8MOMAPIFramework;
using UFIDA.U8.U8APIFramework;
using UFIDA.U8.U8APIFramework.Meta;
using UFIDA.U8.U8APIFramework.Parameter;

using U8.Interface.Bus.ApiService.Model;

using MSXML2;

namespace U8.Interface.Bus.ApiService.BLL
{
 
    /// <summary>
    /// 供应链单据API操作工厂类
    /// </summary> 
    public abstract class SfcOp :APIOp
    {
        public virtual string SetSubId()
        {
            return "AS";
        }



        /// <summary>
        /// 子表
        /// </summary>
        public virtual string SubEntityName
        {
            get;
            set;
        }

        /// <summary>
        /// 子表下的子表
        /// </summary>
        public virtual string SubChildEntityName
        {
            get;
            set;
        }



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
                    dtdal = new DAL.TaskLogFactory.CQ.TaskDetail();
                    break;
                case 1:
                    dtdal = new DAL.SynergismLogDt();
                    break;
                case 2:
                    dtdal = new DAL.TaskLogFactory.DS.TaskDetail();
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
                u8namevaluebll.SetSfcBodyData(apidata, rdds, rdsds, listfd, dt);

                //设置订单关联    
                DAL.Common.SetInBody(apidata);
                SetNormalValue(apidata, dt);
            }
            return dr;
        }


        public abstract DataSet SetFromTabetsChild(Model.Synergismlogdt dt, Model.Synergismlogdt pdt, Model.APIData apidata); 


        /// <summary>
        /// 设置表头
        /// </summary>
        /// <param name="apidata"></param>
        /// <param name="broker"></param>
        /// <returns></returns>
        public Model.DealResult SetDomHead(Model.APIData apidata, U8ApiBroker broker)
        {
            Model.DealResult dr = new Model.DealResult();
            ExtensionBusinessEntity extbo = broker.GetExtBoEntity("extbo");
            //extbo.ItemCount = apidata.HeadData.Count; 
            foreach (Model.U8NameValue unv in apidata.HeadData)
            { 
                extbo[0][unv.U8FieldName] = unv.U8FieldValue;  
            }
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

            #region //第二层
            if (apidata.SfcBodyData.Count == 0)
            {
                return dr;
            }
            if (string.IsNullOrEmpty(SubEntityName))
            {
                return dr;
            }

            ExtensionBusinessEntity SubEntity = broker.GetExtBoEntity("extbo")[0].SubEntity[SubEntityName];

            SubEntity.ItemCount = apidata.SfcBodyData.Count;
            int i = 0;
            foreach (BodyRow bodyRow in apidata.SfcBodyData)
            {
                // SetUNV(lunv, WorkhrNoteOpSum, apidata, apidata.Synergismlogdt.Cvouchertype);
                SetUNV(bodyRow.BodyCols, SubEntity, apidata, "FC32");

                #region 待删除
                //foreach (Model.U8NameValue unv in lunv)
                //{
                //    //string fieldName = unv.U8FieldName.ToLower();
                //    string fieldName = unv.U8FieldName.ToLower();

                //    if (unv.U8FieldName.ToLower() == "bgsp")
                //    {
                //        if (unv.U8FieldValue.ToString() == "是")
                //        {
                //            WorkhrNoteOpSum[i][unv.U8FieldName] = "1";
                //        }
                //        else if (unv.U8FieldValue.ToString() == "否")
                //        {
                //            WorkhrNoteOpSum[i][unv.U8FieldName] = "0";
                //        }
                //        else
                //        {
                //            WorkhrNoteOpSum[i][unv.U8FieldName] = unv.U8FieldValue;
                //        }
                //    }

                //    else
                //    {
                //        int iFieldType = DAL.Common.GetFieldType(apidata.ConnectInfo.Constring, unv.U8FieldName, "FC32");
                //        if (iFieldType == 5 && !string.IsNullOrEmpty(unv.U8FieldValue))
                //        {
                //            WorkhrNoteOpSum[i][unv.U8FieldName] = Convert.ToDateTime(unv.U8FieldValue).ToString("yyyy-MM-dd");
                //        }
                //        else
                //        {
                //            WorkhrNoteOpSum[i][unv.U8FieldName] = unv.U8FieldValue;
                //        }
                //    }
                //}
                #endregion

            #endregion

                #region  第三层
                if (bodyRow.ChildData.Count == 0)
                {
                    return dr;
                }
                if (string.IsNullOrEmpty(SubChildEntityName))
                {
                    return dr;
                }

                ExtensionBusinessEntity SubChildEntity = SubEntity[i].SubEntity[SubChildEntityName];
                foreach (List<Model.U8NameValue> lunvc in bodyRow.ChildData)
                {
                    SetUNV(lunvc, SubChildEntity, apidata, apidata.Synergismlogdt.Cvouchertype);
                } 
                #endregion


                i++;
            }

            return dr;
        }


        /// <summary>
        /// 字段赋值
        /// 一行数据
        /// </summary>
        /// <param name="lunv"></param>
        /// <param name="subEntity"></param>
        /// <param name="apidata"></param>
        /// <param name="vouchtype"></param>
        public virtual void SetUNV(List<Model.U8NameValue> lunv, ExtensionBusinessEntity subEntity, Model.APIData apidata, string vouchtype)
        {
            int i = 0;
            foreach (Model.U8NameValue unv in lunv)
            {
                string fieldName = unv.U8FieldName.ToLower();

                if (unv.U8FieldName.ToLower() == "bgsp")
                {
                    if (unv.U8FieldValue.ToString() == "是")
                    {
                        subEntity[i][unv.U8FieldName] = "1";
                    }
                    else if (unv.U8FieldValue.ToString() == "否")
                    {
                        subEntity[i][unv.U8FieldName] = "0";
                    }
                    else
                    {
                        subEntity[i][unv.U8FieldName] = unv.U8FieldValue;
                    }
                } 
                else
                {
                    int iFieldType = DAL.Common.GetFieldType(apidata.ConnectInfo.Constring, unv.U8FieldName, vouchtype);
                    if (iFieldType == 5 && !string.IsNullOrEmpty(unv.U8FieldValue))
                    {
                        subEntity[i][unv.U8FieldName] = Convert.ToDateTime(unv.U8FieldValue).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        subEntity[i][unv.U8FieldName] = unv.U8FieldValue;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apidata"></param>
        /// <param name="broker"></param>
        /// <returns></returns>
        public virtual Model.DealResult AssignNormalValues(Model.APIData apidata, UFIDA.U8.U8APIFramework.U8ApiBroker broker)
        {
            Model.DealResult dr = new Model.DealResult();  
            return dr;
        }



        /// <summary>
        /// 激发API操作
        /// </summary>
        /// <param name="broker"></param>
        /// <returns></returns>
        public override Model.DealResult BrokerInvoker(UFIDA.U8.U8APIFramework.U8ApiBroker broker)
        {
            Model.DealResult dr = new Model.DealResult();
            if (!broker.Invoke())
            {
                //错误处理
                Exception apiEx = broker.GetException();
                if (apiEx != null)
                {
                    if (apiEx is MomSysException)
                    {
                        MomSysException sysEx = apiEx as MomSysException;
                        dr.ResultNum = -1;
                        dr.ResultMsg = "系统异常：" + sysEx.Message;
                    }
                    else if (apiEx is MomBizException)
                    {
                        MomBizException bizEx = apiEx as MomBizException;
                        dr.ResultNum = -1;
                        dr.ResultMsg = "API异常：" + bizEx.Message;
                    } 
                    String exReason = broker.GetExceptionString();
                    if (exReason.Length != 0)
                    {
                        dr.ResultNum = -1;
                        dr.ResultMsg = " 异常原因：" + exReason;
                    }
                }

                broker.Release();

                return dr;
            }


            System.Boolean result = Convert.ToBoolean(broker.GetReturnValue());

            ExtensionBusinessEntity extboRet; //   'ExtensionBusinessObject
            extboRet = broker.GetExtBoEntity("extbo");

            string retId = null;
            switch (extboRet.Name.ToLower())
            { 
                case "optransform":
                    retId = Convert.ToString(extboRet[0].GetValue("TransformId"));
                    break;
                case "workhrnote":
                    retId = Convert.ToString(extboRet[0].GetValue("WorkHrId"));
                    break;
                case "mom":
                    retId = Convert.ToString(extboRet[0].GetValue("Mom_OrderId"));
                    //
                    break;
                default:
                    break;
            } 
            dr.VouchIdRet = retId;

            //结束本次调用，释放API资源
            broker.Release();
            return dr;
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

            #region 转换 参数 和 U8ApiBroker
            {
                U8ApiBroker ubOrder = null;
                dr = GetU8ApiBroker(apidata, u8Login, out ubOrder, "add");
                object xmlHead = broker.GetExtBoParam("extbo"); //.ToRSDOM();
                //MSXML2.IXMLDOMDocument2 xmlHead = broker.GetExtBoParam("DomHead"); //.ToRSDOM();
                //MSXML2.IXMLDOMDocument2 xmlBody = broker.GetBoParam("DomBody").ToRSDOM();
                //dr = AssignNormalValues(apidata, ubOrder);

                //MSXML2.IXMLDOMNodeList lstx;
                //MSXML2.IXMLDOMNode xmle;

                #region 行号
                ////行号赋值
                ////lstx = xmlBody.getElementsByTagName("z:row");

                //switch (bd.Synergismlogdt.Cvouchertype)
                //{
                //    case "27":  //采购请购单
                //    case "88":  //采购订单
                //        strRow = "ivouchrowno";
                //        break;
                //    case "01":  //发货、退货单
                //        strRow = "iorderrowno";
                //        break;
                //    case "03":    //退货单  added by liuxzha  2014.11.27
                //        strRow = "iorderrowno";
                //        break;
                //    default:
                //        strRow = "irowno";
                //        break;
                //}
                //for (int i = 0; i < lstx.length; i++)
                //{
                //    xmle = lstx[i].attributes.getNamedItem(strRow);
                //    if (xmle == null)
                //    {
                //        //xmle = xmlBody.createNode(System.Xml.XmlNodeType.Attribute, strRow, null);
                //        xmle.nodeValue = (i + 1).ToString();
                //        lstx[i].attributes.setNamedItem(xmle);
                //    }
                //    else
                //    {
                //        xmle.nodeValue = (i + 1).ToString();
                //    }
                //}
                #endregion

                #region 可用量
                ////销售订单
                //if (bd.Synergismlogdt.Cvouchertype == "17")
                //{   //是否可用量检查
                //    lstx = xmlHead.getElementsByTagName("z:row");
                //    xmle = xmlHead.createNode(System.Xml.XmlNodeType.Attribute, "bcontinue", null);
                //    xmle.nodeValue = "0";
                //    lstx[0].attributes.setNamedItem(xmle);
                //}
                ////销售发货单
                //else if (bd.Synergismlogdt.Cvouchertype == "01")
                //{   //是否可用量检查
                //    lstx = xmlHead.getElementsByTagName("z:row");
                //    xmle = xmlHead.createNode(System.Xml.XmlNodeType.Attribute, "saveafterok", null);
                //    xmle.nodeValue = "0";  //
                //    lstx[0].attributes.setNamedItem(xmle);
                //}
                ////销售退货单  added by liuxzha 2014.11.27
                //else if (bd.Synergismlogdt.Cvouchertype == "03")
                //{   //是否可用量检查
                //    lstx = xmlHead.getElementsByTagName("z:row");
                //    xmle = xmlHead.createNode(System.Xml.XmlNodeType.Attribute, "saveafterok", null);
                //    xmle.nodeValue = "0";
                //    lstx[0].attributes.setNamedItem(xmle);
                //}
                ////销售出库单
                //else if (bd.Synergismlogdt.Cvouchertype == "0303")
                //{   //是否可用量检查
                //    lstx = xmlHead.getElementsByTagName("z:row");
                //    xmle = xmlHead.createNode(System.Xml.XmlNodeType.Attribute, "saveafterok", null);
                //    xmle.nodeValue = "0";
                //    lstx[0].attributes.setNamedItem(xmle);
                //}
                #endregion


                //ubOrder.AssignNormalValue("domHead", xmlHead);
                //ubOrder.AssignNormalValue("domBody", xmlBody);

                //U8.Interface.Bus.Log.WriteFileWithName("DomHead.xml", xmlHead.xml);
                //U8.Interface.Bus.Log.WriteFileWithName("DomBody.xml", xmlBody.xml);
                //dr = BrokerInvoker(ubOrder);
            }

            #endregion

            dr = BrokerInvoker(broker);

            UpdateTeamworkField(bd, dr);
            ClearUATask(bd);
            //if (!DAL.Common.SetCreateDate(bd, dr.VouchIdRet))
            //    U8.Interface.Bus.Log.WriteWinLog("设置单据制单时间失败,Cvouchertype:" + bd.Synergismlogdt.Cvouchertype + ";VouchIdRet:" + dr.VouchIdRet + ".");

            return dr;
        }




        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="bd"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public override Model.DealResult MakeAudit(BaseData bd, Model.Synergismlogdt dt)
        {
            Model.DealResult dr;
            Model.APIData apidata = bd as Model.APIData;
            BusinessObject domHead = null;
            BusinessObject domBody = null;
            LoadVouch(apidata, dt, out domHead, out domBody);
            domHead.NeedFieldsCheck = false;
            domBody.NeedFieldsCheck = false;
            string vouchid = GetCodeorID(dt.Cvoucherno, apidata, "id");
            U8Login.clsLogin u8Login = new U8Login.clsLogin();
            dr = GetU8Login(apidata, u8Login);
            if (dr.ResultNum < 0) return dr;
            U8ApiBroker broker = null;
            dr = GetU8ApiBroker(apidata, u8Login, out broker, "audit");
            if (dr.ResultNum < 0) return dr;
            broker.SetBoParam("domHead", domHead);
            broker.AssignNormalValue("bVerify", true);
            
            if (!broker.Invoke())
            {

                Exception apiEx = broker.GetException();
                if (apiEx != null)
                {
                    if (apiEx is MomSysException)
                    {
                        MomSysException sysEx = apiEx as MomSysException;
                        dr.ResultNum = -1;
                        dr.ResultMsg = "系统异常：" + sysEx.Message;
                    }
                    else if (apiEx is MomBizException)
                    {
                        MomBizException bizEx = apiEx as MomBizException;
                        dr.ResultNum = -1;
                        dr.ResultMsg = "API异常：" + bizEx.Message;
                    }

                    String exReason = broker.GetExceptionString();
                    if (exReason.Length != 0)
                    {
                        dr.ResultNum = -1;
                        dr.ResultMsg = " 异常原因：" + exReason;
                    }
                }
                broker.Release();

                return dr;
            }
            System.String result = broker.GetReturnValue() as System.String;
            broker.Release();
            if (!string.IsNullOrEmpty(result))
            {
                dr.ResultNum = -1;
                dr.ResultMsg = "API错误：" + result;
                throw new Exception(dr.ResultMsg);
            }
            else
            {
                if (!DAL.Common.SetVerifyDate(bd.ConnectInfo, dt))
                    Log.WriteWinLog("设置单据审核日期失败,Cvouchertype:" + dt.Cvouchertype + ";Cvoucherno:" + dt.Cvoucherno + ".");
            }

            return dr;
        }


        /// <summary>
        /// 删除单据
        /// </summary>
        /// <param name="bd"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public override Model.DealResult UndoMake(BaseData bd, Model.Synergismlogdt dt)
        {
            Model.DealResult dr=new Model.DealResult();
            Model.APIData apidata = bd as Model.APIData;
            BusinessObject domHead = null;
            BusinessObject domBody = null;

            string vouchid = GetCodeorID(dt.Cvoucherno, apidata, "id");
            if (string.IsNullOrEmpty(vouchid))
            {
                return dr;
            }

            try
            {
                CancelAudit(apidata, dt);
            }
            catch (Exception ex)
            {
                Log.WriteWinLog("saleop_cancelaudit:" + ex.ToString());
                dr.ResultNum = -1;
                dr.ResultMsg = ex.Message;
                return dr;
            }
            LoadVouch(apidata, dt, out domHead, out domBody);
            domHead.NeedFieldsCheck = false;
            domBody.NeedFieldsCheck = false;
          
            U8Login.clsLogin u8Login = new U8Login.clsLogin();
            dr = GetU8Login(apidata, u8Login);
            if (dr.ResultNum < 0) return dr;
            U8ApiBroker broker = null;
            dr = GetU8ApiBroker(apidata, u8Login, out  broker, "delete");
            if (dr.ResultNum < 0) return dr;
            broker.SetBoParam("domHead", domHead);
            try
            {
                broker.SetBoParam("dombodyforlog", domBody);
            }
            catch { }
            if (!broker.Invoke())
            {
                Exception apiEx = broker.GetException();
                if (apiEx != null)
                {
                    if (apiEx is MomSysException)
                    {
                        MomSysException sysEx = apiEx as MomSysException;
                        dr.ResultNum = -1;
                        dr.ResultMsg = "系统异常：" + sysEx.Message;
                    }
                    else if (apiEx is MomBizException)
                    {
                        MomBizException bizEx = apiEx as MomBizException;
                        dr.ResultNum = -1;
                        dr.ResultMsg = "API异常：" + bizEx.Message;
                    }
                    String exReason = broker.GetExceptionString();
                    if (exReason.Length != 0)
                    {
                        dr.ResultNum = -1;
                        dr.ResultMsg = " 异常原因：" + exReason;
                    }
                }
                broker.Release();

                return dr;
            }
            System.String result = broker.GetReturnValue() as System.String;
            broker.Release();
            if (result != null)
            {
                dr.ResultNum = -1;
                dr.ResultMsg = result;
                throw new Exception(result);
            }
             
            return dr;
        }



        public virtual Model.DealResult LoadVouch(Model.APIData bd, Model.Synergismlogdt dt, out BusinessObject domHead, out BusinessObject domBody)
        {
            domHead = null;
            domBody = null;
            Model.DealResult dr = new Model.DealResult();
            Model.APIData apidata = bd as Model.APIData;
            string vouchid = GetCodeorID(dt.Cvoucherno, apidata, "id");
            string auditaddress = SetApiAddressLoad();
            U8Login.clsLogin u8Login = new U8Login.clsLogin();
            GetU8Login(apidata, u8Login);
            U8ApiBroker broker = null;
            dr = GetU8ApiBroker(apidata, u8Login, out  broker, "load");
            broker.AssignNormalValue("VouchID", vouchid);
            broker.AssignNormalValue("blnAuth", false);
            if (!broker.Invoke())
            {
                //错误处理
                Exception apiEx = broker.GetException();
                if (apiEx != null)
                {
                    if (apiEx is MomSysException)
                    {
                        MomSysException sysEx = apiEx as MomSysException;
                        dr.ResultNum = -1;
                        dr.ResultMsg = "系统异常：" + sysEx.Message;
                    }
                    else if (apiEx is MomBizException)
                    {
                        MomBizException bizEx = apiEx as MomBizException;
                        dr.ResultNum = -1;
                        dr.ResultMsg = "API异常：" + bizEx.Message;
                    }

                    String exReason = broker.GetExceptionString();
                    if (exReason.Length != 0)
                    {
                        dr.ResultNum = -1;
                        dr.ResultMsg = " 异常原因：" + exReason;
                    }
                }
                broker.Release();

                return dr;
            }
            System.String result = broker.GetReturnValue() as System.String;
            if (result != string.Empty)
            {
                domHead = broker.GetBoParam("domHead");
                domBody = broker.GetBoParam("domBody");
                domHead.NeedFieldsCheck = false;
                domBody.NeedFieldsCheck = false;
            }
            else
            {
                dr.ResultMsg = result;
                dr.ResultNum = -1;
                broker.Release();

                BLL.Common.ErrorMsg("", result);
            }
            broker.Release();

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
        /// 单据弃审
        /// </summary>
        /// <param name="bd"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public virtual Model.DealResult CancelAudit(Model.APIData bd, Model.Synergismlogdt dt)
        {
            Model.DealResult dr=new Model.DealResult();
            Model.APIData apidata = bd as Model.APIData;
            BusinessObject domHead = null;
            BusinessObject domBody = null;

            if (CheckAuditStatus(dt.Cvoucherno, apidata.ConnectInfo.Constring) == false)
                return dr;

            LoadVouch(apidata, dt, out domHead, out domBody);
            domHead.NeedFieldsCheck = false;
            domBody.NeedFieldsCheck = false;
            string vouchid = GetCodeorID(dt.Cvoucherno, apidata, "id");
            U8Login.clsLogin u8Login = new U8Login.clsLogin();
            dr = GetU8Login(apidata, u8Login);
            if (dr.ResultNum < 0) return dr;
            U8ApiBroker broker = null;
            dr = GetU8ApiBroker(apidata, u8Login, out broker, "cancelaudit");
            if (dr.ResultNum < 0) return dr;
            broker.SetBoParam("domHead", domHead);
            broker.AssignNormalValue("bVerify", false);
            if (!broker.Invoke())
            {

                Exception apiEx = broker.GetException();
                if (apiEx != null)
                {
                    if (apiEx is MomSysException)
                    {
                        MomSysException sysEx = apiEx as MomSysException;

                        dr.ResultNum = -1;
                        dr.ResultMsg = "系统异常：" + sysEx.Message;
                    }
                    else if (apiEx is MomBizException)
                    {
                        MomBizException bizEx = apiEx as MomBizException;
                        dr.ResultNum = -1;
                        dr.ResultMsg = "API异常：" + bizEx.Message;
                    }

                    String exReason = broker.GetExceptionString();
                    if (exReason.Length != 0)
                    {
                        dr.ResultNum = -1;
                        dr.ResultMsg = " 异常原因：" + exReason;
                    }
                }

                broker.Release();

                return dr;
            }
            System.String result = broker.GetReturnValue() as System.String;
            if (result != null)
            {
                dr.ResultNum = -1;
                dr.ResultMsg = result;
               
            }
            broker.Release();

            return dr;
        }

        public override void SetApiContext(U8EnvContext envContext)
        {  
             
             
        }


    }
}
