using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using UFIDA.U8.MomServiceCommon;
using ADODB;
using MSXML2;
using U8Login;

using UFSoft.U8.U8M.DOSchema.BO;

namespace U8.Interface.Bus.Event.SyncAdapter
{
    public class MoEvent
    {

        static string oldEventIdentity = null;
        static string oldConnStr = null;

        /// <summary>
        /// 审核、弃审事件插口方法
        /// </summary>
        /// <param name="bomid">BomId</param>
        /// <param name="errmsg">用于返回的错误信息</param>
        /// <returns>true=操作成功；false=操作失败</returns>
        public bool DoAPIEvent(int moid,int modid, ref string errmsg)
        { 

            Output.OutputDebugString("moid:" + moid); 
            Output.OutputDebugString("modid:" + modid);
            //System.Diagnostics.Process p = System.Diagnostics.Process.GetCurrentProcess();
            //throw new Exception(p.Id.ToString()); 
            //System.Windows.Forms.MessageBox.Show(p.Id.ToString());

            try
            {
                //获取插件上下文
                MomCallContext context = MomCallContextCache.Instance.CurrentMomCallContext;

                //从上下文获取帐套库连接对象
                ADODB.Connection conn = context.BizDbConnection as ADODB.Connection;

                //从上下文获取U8Login对象
                U8Login.clsLogin login = context.U8Login as U8Login.clsLogin;

                string eventIdentity = context.EventIdentity;
                if (string.IsNullOrEmpty(eventIdentity))
                {
                    eventIdentity = oldEventIdentity;
                }
                else
                {
                    oldEventIdentity = eventIdentity;
                }

                string connStr;
                if (login != null)
                {
                    connStr = login.UFDataConnstringForNet.ToString();
                    oldConnStr = connStr;
                }
                else
                {
                    connStr = oldConnStr;
                }

                //System.Windows.Forms.MessageBox.Show(eventIdentity);
  
                Biz.BizBase oper;
                switch (eventIdentity.ToLower())
                {
                    //审核前
                    case "u8api/morder/audit_before": 
                    //审核后
                    case "u8api/morder/audit_after":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." + "Mom_order", true, System.Reflection.BindingFlags.CreateInstance, null, new object[] { conn, moid, modid, connStr, "a" }, null, null);
                        oper.Insert();
                        break;

                    //弃审前
                    case "u8api/morder/unaudit_before":
                    case "u8api/morder/cancelaudit_before":
                    //弃审后
                    case "u8api/morder/unaudit_after":
                    case "u8api/morder/cancelaudit_after":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." + "Mom_order", true, System.Reflection.BindingFlags.CreateInstance, null, new object[] { conn, moid, modid, connStr, "d" }, null, null);
                        oper.Delete();
 
                        break;
                }
 
                return true;
            }
            catch (Exception ex)
            {
                errmsg = ex.Message;
                return false;
            }

        }

    }

}
