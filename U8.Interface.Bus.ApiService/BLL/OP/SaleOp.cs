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
    public abstract class SaleOp : SupplyChainOp
    {
        public override string SetSubId()
        {
            return "AS";
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="apidata"></param>
        /// <param name="broker"></param>
        /// <returns></returns>
        public override Model.DealResult AssignNormalValues(Model.APIData apidata, UFIDA.U8.U8APIFramework.U8ApiBroker broker)
        {
            Model.DealResult dr = new Model.DealResult();
            broker.AssignNormalValue("VoucherState", 0);
            string vnewid = string.Empty;
            broker.AssignNormalValue("vNewID", vnewid);
            MSXML2.IXMLDOMDocument2 domMsg = new MSXML2.DOMDocument();
            broker.AssignNormalValue("DomConfig", domMsg);
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
            MSXML2.IXMLDOMDocument2 domResult = new MSXML2.DOMDocument();

            MSXML2.IXMLDOMNodeList lstx;
            string sResult="";
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
            string vNewIDRet = broker.GetResult("vNewID") as string;
            broker.Release();
        

            if (result != null)
            {

                dr.ResultNum = -1;
                dr.ResultMsg = result;
                sResult=result.ToString();
                
                //增加可用量不足的提示,通过读取返回的DOM信息解析可用量不足的信息
                if (sResult.IndexOf("<rs:data")>0)
                {
                    string sInvCode = "";
                    string sInvName = "";
                    string sWhCode = "";
                    string sWhName = "";
                    string sError = "";
                    sResult = sResult.Substring(sResult.IndexOf("<rs:data"));
                    if (domResult.loadXML(sResult) == true)
                    {
                         lstx= domResult.selectNodes("//z:row");
                         foreach (MSXML2.IXMLDOMNode xmle in lstx)
                         {
                             sInvCode = xmle.attributes.getNamedItem("cinvcode").nodeValue.ToString();
                             sInvName = xmle.attributes.getNamedItem("cinvname").nodeValue.ToString();
                             sWhCode=xmle.attributes.getNamedItem("cwhcode").nodeValue.ToString();
                             sWhName = xmle.attributes.getNamedItem("cwhname").nodeValue.ToString();
                            
                             sError = sError + "存货编码[" + sInvCode + "] 存货名称[" + sInvName + "] 仓库[" + sWhName + "]\r\n";
                           
                         }
                         if (sError != "")
                         {
                             sError = sError + "可用量不足";
                             result = sError;
                             dr.ResultMsg = result;
                         }
                    }
                }

                throw new Exception("API错误：" + result);
            }
            dr.VouchIdRet = vNewIDRet;
            return dr;
        }
        public override void SetApiContext(U8EnvContext envContext)
        {
            envContext.SetApiContext("VoucherType", SetVouchType());
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









        public override Model.DealResult LoadVouch(Model.APIData bd, Model.Synergismlogdt dt, out BusinessObject domHead, out BusinessObject domBody)
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
        /// 单据弃审
        /// </summary>
        /// <param name="bd"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public override Model.DealResult CancelAudit(Model.APIData bd, Model.Synergismlogdt dt)
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

    }
}
