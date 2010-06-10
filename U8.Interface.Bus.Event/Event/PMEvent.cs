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
    public class PMEvent
    {

        /// <summary>
        /// 保存、删除事件接口方法
        /// </summary>
        /// <param name="ds">传入的数据集</param>
        /// <param name="errmsg">用于返回的错误信息</param>
        /// <returns>true=操作成功；false=操作失败</returns>
        public bool DoAPI_DataSet(ref DataSet ds, ref string errmsg)
        {
            try
            {
                //获取插件上下文
                MomCallContext context = MomCallContextCache.Instance.CurrentMomCallContext;

                //从上下文获取帐套库连接对象
                ADODB.Connection conn = context.BizDbConnection as ADODB.Connection; 

                //从上下文获取U8Login对象
                U8Login.clsLogin login = context.U8Login as U8Login.clsLogin;

                string eventIdentity = context.EventIdentity;
  
                if (ds is StandardBomDs)
                {
                    //(ds as StandardBomDs).WriteXml("C:\\" + eventIdentity.Replace("/", ".") + ".xml");
                }

                Biz.BizBase oper;
                switch (eventIdentity.ToLower())
                {
                    //删除后
                    case "u8api/bom/delete_after":
                        //DataSet delDs = ds.Copy();
                        //delDs.RejectChanges(); 
                        //oper = new U8.Interface.Bus.Event.SyncAdapter.Biz.StandBom(ref conn,delDs, login.UFDataConnstringForNet.ToString());
                        //oper.LinkDelete();
                        break;
                    //保存前  制造参数设为保存并默认审核时，不会设审核事件。所以在添加保存前事件
                    case "u8api/bom/save_before":  
                    //保存后
                    case "u8api/bom/save_after":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." + "Bom_bom",
                            true, System.Reflection.BindingFlags.CreateInstance, null,
                            new object[] {  conn,   ds, login.UFDataConnstringForNet.ToString() }, null, null); 
                        //oper = new U8.Interface.Bus.Event.SyncAdapter.Biz.Factory.HM.Bom_bom(ref conn, ref ds, login.UFDataConnstringForNet.ToString());
                        using (System.Transactions.TransactionScope tra = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Suppress))
                        {
                            oper.Insert();
                        }
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

        /// <summary>
        /// 审核、弃审事件插口方法
        /// </summary>
        /// <param name="bomid">BomId</param>
        /// <param name="errmsg">用于返回的错误信息</param>
        /// <returns>true=操作成功；false=操作失败</returns>
        public bool DoAPI_BomId(int bomid, ref string errmsg)
        {

            Output.OutputDebugString("bomid:" + bomid);

            //System.Diagnostics.Process p = System.Diagnostics.Process.GetCurrentProcess();
            //throw new Exception(p.Id.ToString());
             
            try
            {
                //获取插件上下文
                MomCallContext context = MomCallContextCache.Instance.CurrentMomCallContext; 

                //从上下文获取帐套库连接对象
                ADODB.Connection conn = context.BizDbConnection as ADODB.Connection;  

                //从上下文获取U8Login对象
                U8Login.clsLogin login = context.U8Login as U8Login.clsLogin; 
                string eventIdentity = context.EventIdentity;

                Output.OutputDebugString("eventIdentity:" + eventIdentity);
               
                Biz.BizBase oper;
                switch (eventIdentity.ToLower())
                {
                    //标准BOM
                    //审核前
                    case "u8api/bom/audit_before": 
                    //审核后
                    case "u8api/bom/audit_after":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(
                            U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." + "Bom_bom", 
                            true, System.Reflection.BindingFlags.CreateInstance, null, 
                            new object[] { conn, bomid, login.UFDataConnstringForNet.ToString() }, null, null);
                        //oper = new U8.Interface.Bus.Event.SyncAdapter.Biz.Factory.HM.Bom_bom(ref conn, bomid, login.UFDataConnstringForNet.ToString());
                        oper.Insert();
                        break;

                    //弃审前
                    case "u8api/bom/cancelaudit_before":
                    case "u8api/bom/unaudit_before":
                    //弃审后
                    case "u8api/bom/cancelaudit_after":
                    case "u8api/bom/unaudit_after": 
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(
                            U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." + "Bom_bom", 
                            true, System.Reflection.BindingFlags.CreateInstance, null, 
                            new object[] { conn, bomid, login.UFDataConnstringForNet.ToString() }, null, null);
                        //oper = new U8.Interface.Bus.Event.SyncAdapter.Biz.Factory.HM.Bom_bom(ref conn, bomid, login.UFDataConnstringForNet.ToString());
                        oper.Delete();
                        break; 

                  //工艺路线
                    //审核前
                    case "u8api/routing/audit_before":
                    //审核后
                    case "u8api/routing/audit_after":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(
                            U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." + "Sfc_prouting",
                            true, System.Reflection.BindingFlags.CreateInstance, null,
                            new object[] { conn, bomid, login.UFDataConnstringForNet.ToString(), "a" }, null, null); 
                        oper.Insert();
                        break;

                    //弃审前
                    case "u8api/routing/cancelaudit_before":
                    case "u8api/routing/unaudit_before":
                    //弃审后
                    case "u8api/routing/cancelaudit_after":
                    case "u8api/routing/unaudit_after":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(
                            U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." + "Sfc_prouting",
                            true, System.Reflection.BindingFlags.CreateInstance, null,
                            new object[] { conn, bomid, login.UFDataConnstringForNet.ToString(), "d" }, null, null);  
                        oper.Delete();
                        break; 
                }

                string msg = "";
                msg = "  BomId ## " + bomid.ToString();

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
