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
    public abstract class StockOP : SupplyChainOp
    {

        /// <summary>
        /// 加载单据
        /// </summary>
        /// <param name="vouchID"></param>
        /// <returns></returns>
        public override Model.DealResult LoadVouch(Model.APIData bd, Model.Synergismlogdt dt, out BusinessObject domHead, out BusinessObject domBody)
        {
            domHead = null;
            domBody = null;
            return new Model.DealResult();
        }




        public override Model.DealResult AssignNormalValues(Model.APIData apidata, U8ApiBroker broker)
        {

            Model.DealResult dr = new Model.DealResult();
            broker.AssignNormalValue("sVouchType", SetVouchType());
            broker.AssignNormalValue("domPosition", null);
            broker.AssignNormalValue("cnnFrom", null);
            broker.AssignNormalValue("VouchId", "");
            MSXML2.IXMLDOMDocument2 domMsg = new MSXML2.DOMDocument();
            broker.AssignNormalValue("domMsg", domMsg);
            broker.AssignNormalValue("bCheck", true);
            broker.AssignNormalValue("bBeforCheckStock", true);
            broker.AssignNormalValue("bIsRedVouch", false);
            broker.AssignNormalValue("sAddedState", null);
            broker.AssignNormalValue("bReMote", false);
            return dr;

        }

        public override string SetSubId()
        {
            return "ST";
        }


        public override Model.DealResult BrokerInvoker(U8ApiBroker broker)
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
            System.String errMsgRet =broker.GetResult("errMsg") as System.String;
            if (!result)
            {
                dr.ResultNum = -1;
                dr.ResultMsg = "API错误：" + errMsgRet;
                if (errMsgRet == "" || errMsgRet==null) //如果是空是可用量检查不过
                {
                    throw new Exception("API错误：可用量检查不通过");
                }
                else
                {
                    throw new Exception("API错误：" + errMsgRet);
                }
            }

            try
            {
                System.String VouchIdRet = broker.GetResult("VouchId") as System.String;
                dr.VouchIdRet = VouchIdRet;
            }
            catch { }
            MSXML2.IXMLDOMDocument2 domMsgRet = broker.GetResult("domMsg") as MSXML2.IXMLDOMDocument2;
            broker.Release();

            return dr;
        }



        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="bd"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public override Model.DealResult UndoMake(BaseData bd, Model.Synergismlogdt dt)
        {
            Model.DealResult dr = new Model.DealResult();
            Model.APIData apidata = bd as Model.APIData;
            try
            {
                dr = CancelAudit(apidata, dt);

            }
            catch (Exception ex)
            {
                U8.Interface.Bus.Log.WriteWinLog("stockop_cancelaudit:" + ex.ToString());
                dr.ResultNum = -1;
                dr.ResultMsg = ex.Message;
                return dr;
            }
            string vouchid = GetCodeorID(dt.Cvoucherno, apidata, "id");
            string auditaddress = SetApiAddressDelete();
            U8Login.clsLogin u8Login = new U8Login.clsLogin();
            GetU8Login(apidata, u8Login);
            U8ApiBroker broker = null;
            dr = GetU8ApiBroker(apidata, u8Login, out  broker, "delete");
            broker.AssignNormalValue("sVouchType", apidata.SVouchType);
            broker.AssignNormalValue("VouchId", vouchid);
            broker.AssignNormalValue("cnnFrom", null);
            broker.AssignNormalValue("TimeStamp", DAL.Common.GetUtfsByID(vouchid, SetTableName(), apidata.ConnectInfo.Constring));
            MSXML2.IXMLDOMDocument2 domMsg = new MSXML2.DOMDocument();
            broker.AssignNormalValue("domMsg", domMsg);
            broker.AssignNormalValue("bCheck", false);
            broker.AssignNormalValue("bBeforCheckStock", false);
            broker.AssignNormalValue("bList", null);
            dr = BrokerInvoker(broker); 
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
            Model.DealResult dr = new Model.DealResult();
            Model.APIData apidata = bd as Model.APIData;
            string vouchid = GetCodeorID(dt.Cvoucherno, apidata, "id");
            string auditaddress = SetApiAddressAudit();
            U8Login.clsLogin u8Login = new U8Login.clsLogin();
            GetU8Login(apidata, u8Login);
            U8ApiBroker broker = null;
            dr = GetU8ApiBroker(apidata, u8Login, out broker, "audit");
            broker.AssignNormalValue("sVouchType", apidata.SVouchType);
            broker.AssignNormalValue("VouchId", vouchid);
            broker.AssignNormalValue("cnnFrom", null);
            broker.AssignNormalValue("TimeStamp", DAL.Common.GetUtfsByID(vouchid, SetTableName(), apidata.ConnectInfo.Constring));
            MSXML2.IXMLDOMDocument2 domMsg = new MSXML2.DOMDocument();
            broker.AssignNormalValue("domMsg", domMsg);
            broker.AssignNormalValue("bCheck", false);
            broker.AssignNormalValue("bBeforCheckStock", false);
            broker.AssignNormalValue("bList", null);
            dr = BrokerInvoker(broker);
            if (!DAL.Common.SetVerifyDate(bd.ConnectInfo, dt))
                U8.Interface.Bus.Log.WriteWinLog("设置单据审核日期失败,Cvouchertype:" + dt.Cvouchertype + ";Cvoucherno:" + dt.Cvoucherno + ".");

            return dr;

        }

        /// <summary>
        /// 弃审
        /// </summary>
        /// <param name="bd"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public override Model.DealResult CancelAudit(Model.APIData bd, Model.Synergismlogdt dt)
        {
            Model.DealResult dr = new Model.DealResult();
            Model.APIData apidata = bd as Model.APIData;

            if (CheckAuditStatus(dt.Cvoucherno, apidata.ConnectInfo.Constring) == false)
                return dr;

            string vouchid = GetCodeorID(dt.Cvoucherno, apidata, "id");
            string auditaddress = SetApiAddressCancelAudit();
            U8Login.clsLogin u8Login = new U8Login.clsLogin();
            GetU8Login(apidata, u8Login);
            U8ApiBroker broker = null;
            dr = GetU8ApiBroker(apidata, u8Login, out broker, "cancelaudit");

            broker.AssignNormalValue("sVouchType", apidata.SVouchType);
            broker.AssignNormalValue("VouchId", vouchid);
            broker.AssignNormalValue("cnnFrom", null);
            broker.AssignNormalValue("TimeStamp", DAL.Common.GetUtfsByID(vouchid, SetTableName(), apidata.ConnectInfo.Constring));
            MSXML2.IXMLDOMDocument2 domMsg = new MSXML2.DOMDocument();
            broker.AssignNormalValue("domMsg", domMsg);
            broker.AssignNormalValue("bCheck", false);
            broker.AssignNormalValue("bBeforCheckStock", false);
            broker.AssignNormalValue("bList", null);
            dr = BrokerInvoker(broker);
            return dr;
        }

        public override void SetApiContext(U8EnvContext envContext)
        {

        }


    }

}