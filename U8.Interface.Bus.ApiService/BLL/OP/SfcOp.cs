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


        public virtual string SubEntityName
        {
            get;
            set;
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
            ExtensionBusinessEntity extbo = broker.GetExtBoEntity("extbo");
            //extbo.ItemCount = apidata.HeadData.Count; 
            foreach (Model.U8NameValue unv in apidata.HeadData)
            {
                //ExtensionItem newItem = extbo.NewItem();
                //newItem[unv.U8FieldName.ToLower()] = unv.U8FieldValue; 
                extbo[0][unv.U8FieldName] = unv.U8FieldValue; 
                //extbo[0][unv.U8FieldName.ToLower()]=unv.U8FieldValue; 
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
            if (apidata.BodyData.Count == 0)
            {
                return dr;
            }
            if (string.IsNullOrEmpty(SubEntityName))
            {
                return dr;
            }
            ExtensionBusinessEntity WorkhrNoteOpSum = broker.GetExtBoEntity("extbo")[0].SubEntity[SubEntityName];

            WorkhrNoteOpSum.ItemCount = apidata.BodyData.Count;
            int i = 0; 
            foreach (List<Model.U8NameValue> lunv in apidata.BodyData)
            {
                foreach (Model.U8NameValue unv in lunv)
                {
                    //string fieldName = unv.U8FieldName.ToLower();
                    string fieldName = unv.U8FieldName.ToLower();

                    if (unv.U8FieldName.ToLower() == "bgsp")
                    {
                        if (unv.U8FieldValue.ToString() == "是")
                        {
                            WorkhrNoteOpSum[i][unv.U8FieldName] = "1";
                        }
                        else if (unv.U8FieldValue.ToString() == "否")
                        {
                            WorkhrNoteOpSum[i][unv.U8FieldName] = "0";
                        }
                        else
                        {
                            WorkhrNoteOpSum[i][unv.U8FieldName] = unv.U8FieldValue;
                        }
                    }

                    else
                    {
                        int iFieldType = DAL.Common.GetFieldType(apidata.ConnectInfo.Constring, unv.U8FieldName, "FC32");
                        if (iFieldType == 5 && !string.IsNullOrEmpty(unv.U8FieldValue))
                        {
                            WorkhrNoteOpSum[i][unv.U8FieldName] = Convert.ToDateTime(unv.U8FieldValue).ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            WorkhrNoteOpSum[i][unv.U8FieldName] = unv.U8FieldValue;
                        }
                    }
                }
                i++;
            }

            return dr;
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
