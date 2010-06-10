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

using U8.Interface.Bus.ApiService.Model;


namespace U8.Interface.Bus.ApiService.BLL
{
    public abstract class PurchaseOp : SupplyChainOp
    {
        public override string SetSubId()
        {
            return "AS";
        }

        public override Model.DealResult AssignNormalValues(Model.APIData apidata, UFIDA.U8.U8APIFramework.U8ApiBroker broker)
        {
            Model.DealResult dr = new Model.DealResult();
            broker.AssignNormalValue("VoucherState", 2);
            MSXML2.IXMLDOMDocument2 CurDom = new MSXML2.DOMDocument();
            broker.AssignNormalValue("CurDom", CurDom);
            broker.AssignNormalValue("UserMode", 0);
            return dr;

        }





        public override Model.DealResult BrokerInvoker(UFIDA.U8.U8APIFramework.U8ApiBroker broker)
        {
            Model.DealResult dr = new Model.DealResult();
            //DAL.Common.WriteWinDebugLog("broker start");
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
            //DAL.Common.WriteWinDebugLog("broker end");
            System.String result = broker.GetReturnValue() as System.String;

            string curIDRet = broker.GetResult("curID") as string;

            MSXML2.IXMLDOMDocument2 CurDomRet = (MSXML2.IXMLDOMDocument2)broker.GetResult("CurDom");

            broker.Release();
            //DAL.Common.WriteWinDebugLog("broker end2");
            if (result != null)
            {
                dr.ResultNum = -1;
                dr.ResultMsg = "API错误：" + result;
                throw new Exception("API错误：" + result);


            }
            dr.VouchIdRet = curIDRet;
            broker.Release();

            return dr;
        }

        public override void SetApiContext(U8EnvContext envContext)
        {
            string strBillType = string.Empty;
            string strVoucherType = string.Empty;
            strVoucherType = SetVouchType();
            switch (strVoucherType)
            {
                case "1":
                    strBillType = "";
                    break;
                case "2":
                    strBillType = "0";
                    break;
                case "0":
                    strBillType = "";
                    break;
                default:
                    strBillType = "";
                    break;
            }
            envContext.SetApiContext("VoucherType", SetVouchType()); //上下文数据类型：int，含义：单据类型，采购请购单 0 
            envContext.SetApiContext("bPositive", true); //上下文数据类型：bool，含义：红蓝标识：True,蓝字
            envContext.SetApiContext("sBillType", strBillType); //上下文数据类型：string，含义：为空串
            envContext.SetApiContext("sBusType", "普通采购");
        }


        public override Model.DealResult UndoMake(BaseData bd, Model.Synergismlogdt dt)
        {


            Model.DealResult dr=new Model.DealResult();
            Model.APIData apidata = bd as Model.APIData;
            try
            {
                CancelAudit(apidata, dt);
            }
            catch (Exception ex)
            {
                Log.WriteWinLog("purchaseop_cancelaudit:" + ex.ToString());
                dr.ResultNum = -1;
                dr.ResultMsg = ex.Message;
                return dr;
            }
            BusinessObject domHead = null;
            BusinessObject domBody = null;
            LoadVouch(apidata, dt, out domHead, out domBody);
            string vouchid = GetCodeorID(dt.Cvoucherno, apidata, "id");
            U8Login.clsLogin u8Login = new U8Login.clsLogin();
            dr = GetU8Login(apidata, u8Login);
            if (dr.ResultNum < 0) return dr;
            U8ApiBroker broker = null;
            dr = GetU8ApiBroker(apidata, u8Login, out broker, "delete");
            if (dr.ResultNum < 0) return dr;
            broker.SetBoParam("domHead", domHead);
            try
            {
                broker.SetBoParam("domBody", domBody);
            }
            catch { }

            MSXML2.IXMLDOMDocument2 CurDom = new MSXML2.DOMDocument();
            broker.AssignNormalValue("CurDom", CurDom);
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
                dr.ResultMsg = "API错误：" + result;
                throw new Exception("API错误：" + result);
            }
            broker.Release();

            DAL.Regist registdal = new DAL.Regist();
            Model.Regist regist = registdal.GetModel(dt.Accid);   //acccode 转 accid 
            return dr;
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="bd"></param>
        /// <param name="vouchid"></param>
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






        public override Model.DealResult LoadVouch(Model.APIData bd, Model.Synergismlogdt dt, out BusinessObject domHead, out BusinessObject domBody)
        {
            domHead = null;
            domBody = null;
            Model.DealResult dr = new Model.DealResult();
            Model.APIData apidata = bd as Model.APIData;
            string vouchid = GetCodeorID(dt.Cvoucherno, apidata, "id");
            string auditaddress = SetApiAddressDelete();
            U8Login.clsLogin u8Login = new U8Login.clsLogin();
            GetU8Login(apidata, u8Login);
            U8ApiBroker broker = null;
            dr = GetU8ApiBroker(apidata, u8Login, out broker, "load");
            broker.AssignNormalValue("strWhere", "");
            broker.AssignNormalValue("varVoucherID", vouchid);
            broker.AssignNormalValue("strLocateWhere", "");
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

                dr.ResultMsg = "API错误：" + result;
                dr.ResultNum = -1;
                broker.Release();

                BLL.Common.ErrorMsg("", result);
            }
            broker.Release();

            return dr;
        }

        public override Model.DealResult CancelAudit(Model.APIData bd, Model.Synergismlogdt dt)
        {
            Model.DealResult dr=new Model.DealResult();
            Model.APIData apidata = bd as Model.APIData;
            BusinessObject domHead = null;
            BusinessObject domBody = null;

            if (CheckAuditStatus(dt.Cvoucherno, apidata.ConnectInfo.Constring) == false)
                return dr;

            LoadVouch(apidata, dt, out domHead, out domBody);
            string vouchid = GetCodeorID(dt.Cvoucherno, apidata, "id");
            U8Login.clsLogin u8Login = new U8Login.clsLogin();
            dr = GetU8Login(apidata, u8Login);
            if (dr.ResultNum < 0) return dr;
            U8ApiBroker broker = null;
            dr = GetU8ApiBroker(apidata, u8Login, out   broker, "cancelaudit");
            if (dr.ResultNum < 0) return dr;
            broker.SetBoParam("domHead", domHead);

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
                dr.ResultMsg = "API错误：" + result;
                throw new Exception("API错误" + result);
            }
            broker.Release();

            return dr;
        }


    }
}
