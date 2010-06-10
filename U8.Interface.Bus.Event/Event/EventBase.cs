using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using UFIDA.U8.MomServiceCommon;
using ADODB;
using MSXML2;
using U8Login;

namespace U8.Interface.Bus.Event.SyncAdapter
{
    public class EventBase
    {
          
        /// <summary>
        /// 基础档案事件调插件方法
        /// </summary>
        /// <param name="document" datetype="MSXML2.IXMLDocument2" out="1">基础档案 DOM 对象实例</param>
        /// <param name="message" datatype="string" out="1">错误信息。用于插件方法返回档案的错误信息</param>
        /// <returns datatype="bool" comment="返回值决定原档案业务流程是否会继续">
        ///   <return value="True">操作成功</return>
        ///   <return value="False">操作失败</return>
        /// </returns>
        public bool InvokeArchiveEvent(ref IXMLDOMDocument2 document, ref string message)
        {
            try
            {
                Output.gDebugView("CSharp.SyncAdapter.Archive.Entering...");

                /********** 获取插件上下文信息：登录对象、连接、事件ID ***************/

                //获取插件上下文
                MomCallContext context = MomCallContextCache.Instance.CurrentMomCallContext;

                //从上下文获取U8Login对象
                U8Login.clsLogin login = context.U8Login as U8Login.clsLogin;

                //从上下文获取帐套库连接对象
                ADODB.Connection conn = context.BizDbConnection as ADODB.Connection; 

                //从上下文获取事件ID
                string eventId = context.EventIdentity;

                Biz.BizBase oper;
                switch (eventId.ToLower())
                {
                    //部门
                    case "u8api/department/add_after":
                    case "u8api/department/add_before":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." +
                            "Department", true, System.Reflection.BindingFlags.CreateInstance, null,
                            new object[] {conn, document, login.UFDataConnstringForNet.ToString(), "a"}, null, null);   
                        oper.Insert();
                        break;
                    case "u8api/department/delete_after":
                    case "u8api/department/delete_before": 
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." +
                            "Department", true, System.Reflection.BindingFlags.CreateInstance, null,
                            new object[] { conn, document, login.UFDataConnstringForNet.ToString(), "d" }, null, null);    
                        oper.Delete();
                        break;
                    case "u8api/department/modify_after":
                    case "u8api/department/modify_before":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." +
                            "Department", true, System.Reflection.BindingFlags.CreateInstance, null,
                            new object[] { conn, document, login.UFDataConnstringForNet.ToString(), "m" }, null, null);     
                        oper.Update();
                        break;

                    //人员
                    case "u8api/hr_hi_person/add_after":
                    case "u8api/hr_hi_person/add_before":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." +
                            "Person", true, System.Reflection.BindingFlags.CreateInstance, null,
                            new object[] { conn, document, login.UFDataConnstringForNet.ToString(), "a" }, null, null);  
                        oper.Insert();
                        break;
                    case "u8api/hr_hi_person/delete_after":
                    case "u8api/hr_hi_person/delete_before":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." +
                            "Person", true, System.Reflection.BindingFlags.CreateInstance, null,
                            new object[] { conn, document, login.UFDataConnstringForNet.ToString(), "d" }, null, null);   
                        oper.Delete();
                        break;
                    case "u8api/hr_hi_person/modify_after":
                    case "u8api/hr_hi_person/modify_before":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." +
                            "Person", true, System.Reflection.BindingFlags.CreateInstance, null,
                            new object[] { conn, document, login.UFDataConnstringForNet.ToString(), "m" }, null, null);   
                        oper.Update();
                        break;

                    //主计量单位 
                    case "u8api/computationunit/add_after":
                    case "u8api/computationunit/add_before":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." +
                            "ComputationUnit", true, System.Reflection.BindingFlags.CreateInstance, null,
                            new object[] { conn, document, login.UFDataConnstringForNet.ToString(), "a" }, null, null);    
                        oper.Insert();
                        break;
                    case "u8api/computationunit/delete_after":
                    case "u8api/computationunit/delete_before":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." +
                            "ComputationUnit", true, System.Reflection.BindingFlags.CreateInstance, null,
                            new object[] { conn, document, login.UFDataConnstringForNet.ToString(), "d" }, null, null);  
                        oper.Delete();
                        break;
                    case "u8api/computationunit/modify_after":
                    case "u8api/computationunit/modify_before":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." +
                            "ComputationUnit", true, System.Reflection.BindingFlags.CreateInstance, null,
                            new object[] { conn, document, login.UFDataConnstringForNet.ToString(), "m"}, null, null);   
                        oper.Update();
                        break;

                    //存货
                    case "u8api/inventory/add_after":
                    case "u8api/inventory/add_before":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." +
                            "Inventory", true, System.Reflection.BindingFlags.CreateInstance, null,
                            new object[] { conn, document, login.UFDataConnstringForNet.ToString(), "a" }, null, null);  
                        oper.Insert();
                        break;
                    case "u8api/inventory/delete_after":
                    case "u8api/inventory/delete_before":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." +
                            "Inventory", true, System.Reflection.BindingFlags.CreateInstance, null,
                            new object[] { conn, document, login.UFDataConnstringForNet.ToString(), "d" }, null, null);   
                        oper.Delete();
                        break;
                    case "u8api/inventory/modify_after":
                    case "u8api/inventory/modify_before":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." +
                            "Inventory", true, System.Reflection.BindingFlags.CreateInstance, null,
                            new object[] { conn, document, login.UFDataConnstringForNet.ToString(), "m" }, null, null);    
                        oper.Update();
                        break;

                    //存货分类
                    case "u8api/inventoryclass/add_before":
                    case "u8api/inventoryclass/add_after":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." + "InventoryClass", true, System.Reflection.BindingFlags.CreateInstance, null, 
                            new object[] { conn, document, login.UFDataConnstringForNet.ToString(), "a" }, null, null); 
                        oper.Insert();
                        break;
                    case "u8api/inventoryclass/delete_before":
                    case "u8api/inventoryclass/delete_after":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." + "InventoryClass", true, System.Reflection.BindingFlags.CreateInstance, null,
                            new object[] { conn, document, login.UFDataConnstringForNet.ToString(), "d" }, null, null); 
                        oper.Delete();
                        break;
                    case "u8api/inventoryclass/modify_before":
                    case "u8api/inventoryclass/modify_after":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." + "InventoryClass", true, System.Reflection.BindingFlags.CreateInstance, null,
                            new object[] { conn, document, login.UFDataConnstringForNet.ToString(), "m" }, null, null);  
                        oper.Update();
                        break;

                    //供应商
                    case "u8api/vendor/add_after":
                    case "u8api/vendor/add_before":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." + "Vendor", true, System.Reflection.BindingFlags.CreateInstance, null, new object[] { conn, document, login.UFDataConnstringForNet.ToString() }, null, null);
                        oper.Insert();
                        break;
                    case "u8api/vendor/delete_after":
                    case "u8api/vendor/delete_before": 
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." + "Vendor", true, System.Reflection.BindingFlags.CreateInstance, null, new object[] { conn, document, login.UFDataConnstringForNet.ToString() }, null, null); 
                        oper.Delete();
                        break;
                    case "u8api/vendor/modify_after":
                    case "u8api/vendor/modify_before":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." + "Vendor", true, System.Reflection.BindingFlags.CreateInstance, null, new object[] { conn, document, login.UFDataConnstringForNet.ToString() }, null, null);
                        oper.Update();
                        break;
                    case "u8api/vendor/merge_before":
                    case "u8api/vendor/merge_after":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." + "Vendor", true, System.Reflection.BindingFlags.CreateInstance, null, new object[] { conn, document, login.UFDataConnstringForNet.ToString() }, null, null);
                        oper.LinkMerge(document);
                        break;

                    //客户
                    case "u8api/customer/add_after":
                    case "u8api/customer/add_before":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." + "Customer", true, System.Reflection.BindingFlags.CreateInstance, null, new object[] { conn, document, login.UFDataConnstringForNet.ToString() }, null, null);
                        oper.Insert();
                        break;
                    case "u8api/customer/delete_after":
                    case "u8api/customer/delete_before":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." + "Customer", true, System.Reflection.BindingFlags.CreateInstance, null, new object[] { conn, document, login.UFDataConnstringForNet.ToString() }, null, null);
                        oper.Delete();
                        break;
                    case "u8api/customer/modify_after":
                    case "u8api/customer/modify_before":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." + "Customer", true, System.Reflection.BindingFlags.CreateInstance, null, new object[] { conn, document, login.UFDataConnstringForNet.ToString() }, null, null);
                        oper.Update();
                        break;
                    case "u8api/customer/merge_before":
                    case "u8api/customer/merge_after":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." + "Customer", true, System.Reflection.BindingFlags.CreateInstance, null, new object[] { conn, document, login.UFDataConnstringForNet.ToString() }, null, null);
                        oper.LinkMerge(document);
                        break;

                }


                Output.gDebugView("CSharp.SyncAdapter.Archive." + eventId + ".Writing log..."); 
                Output.mWriteLog(eventId, document, null, conn, login); 
                Output.gDebugView("CSharp.SyncAdapter.Archive." + eventId + ".Creating BO Instance..."); 
                Output.gDebugView("CSharp.SyncAdapter.Archive." + eventId + ".Simulating Business Rule..."); 
                Output.gDebugView("CSharp.SyncAdapter.Archive." + eventId + ".ShowDialog...");

                bool result = true ;

  
                Output.gDebugView("CSharp.SyncAdapter.Archive." + eventId + ".Complete");
                return result;

            }
            catch (Exception ex)
            {
                Output.mWriteLog(ex.Message);
                throw ex;
            }

        }

        /// <summary>
        /// 单据事件调插件方法
        /// </summary>
        /// <param name="domhead" datetype="MSXML2.IXMLDocument2" out="1">单据表头 DOM 对象实例</param>
        /// <param name="dombody" datetype="MSXML2.IXMLDocument2" out="1">单据表体 DOM 对象实例</param>
        /// <param name="message" datatype="string" out="1">错误信息。用于插件方法返回单据的错误信息</param>
        /// <returns datatype="bool" comment="返回值决定原档案业务流程是否会继续">
        ///   <return value="True">操作成功</return>
        ///   <return value="False">操作失败</return>
        /// </returns>
        public bool InvokeVoucherEvent(ref IXMLDOMDocument2 domhead, ref IXMLDOMDocument2 dombody, ref string message)
        {
            try
            {
                /********** 获取插件上下文信息：登录对象、连接、事件ID ***************/

                //获取插件上下文
                MomCallContext context = MomCallContextCache.Instance.CurrentMomCallContext;

                //从上下文获取U8Login对象
                U8Login.clsLogin login = context.U8Login as U8Login.clsLogin;

                //从上下文获取帐套库连接对象
                ADODB.Connection conn = context.BizDbConnection as ADODB.Connection;

                //从上下文获取事件ID
                string eventId = context.EventIdentity;

                Output.mWriteLog(eventId, domhead, dombody, conn, login);


                Biz.BizBase oper;
                switch (eventId.ToLower())
                {

                    //条码管理 
                    case "u8api/genbarcode/delete_before":
                    case "u8api/genbarcode/delete_after":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." + "BarCodeMain", true, System.Reflection.BindingFlags.CreateInstance, null, new object[] {  conn, dombody, login.UFDataConnstringForNet.ToString() }, null, null); 
                        oper.Delete();
                        break; 
                    case "u8api/genbarcode/save_before":
                    case "u8api/genbarcode/save_after":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." + "BarCodeMain", true, System.Reflection.BindingFlags.CreateInstance, null, new object[] { conn, dombody, login.UFDataConnstringForNet.ToString() }, null, null);  
                        oper.Save();
                        break;


                    //销售订单
                    case "u8api/saleorder/audit_after":
                    case "u8api/saleorder/audit_before":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." + "SO_SOMain", true, System.Reflection.BindingFlags.CreateInstance, null, new object[] { conn, domhead,dombody, login.UFDataConnstringForNet.ToString(),"a" }, null, null);
                        oper.Insert();
                        break; 
                    case "u8api/saleorder/cancelaudit_after":
                    case "u8api/saleorder/cancelaudit_before":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." + "SO_SOMain", true, System.Reflection.BindingFlags.CreateInstance, null, new object[] { conn, domhead, dombody, login.UFDataConnstringForNet.ToString(), "d" }, null, null);
                        oper.Delete();
                        break;


                    //采购到货单
                    case "u8api/arrivedgoods/audit_before":
                    case "u8api/arrivedgoods/audit_after":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." + "PU_ArrivalVouch", true, System.Reflection.BindingFlags.CreateInstance, null, new object[] { conn, domhead, dombody, login.UFDataConnstringForNet.ToString(), "d" }, null, null);
                        oper.Insert();
                        break;
                    case "u8api/arrivedgoods/cancelaudit_before":
                    case "u8api/arrivedgoods/cancelaudit_after":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." + "PU_ArrivalVouch", true, System.Reflection.BindingFlags.CreateInstance, null, new object[] { conn, domhead, dombody, login.UFDataConnstringForNet.ToString(), "d" }, null, null);
                        oper.Delete();
                        break;

                        //组装单
                    case "u8api/groupvouch/audit_before":
                    case "u8api/groupvouch/audit_after":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." + "GroupVouch", true, System.Reflection.BindingFlags.CreateInstance, null, new object[] { conn, domhead, dombody, login.UFDataConnstringForNet.ToString(), "a" }, null, null);
                        oper.Insert();
                        break;
                         
                    case "u8api/groupvouch/cancelaudit_before":
                    case "u8api/groupvouch/cancelaudit_after":
                        oper = (Biz.BizBase)System.Reflection.Assembly.Load(U8.Interface.Bus.Config.ConfigUtility.EventBizDllName).CreateInstance(U8.Interface.Bus.Config.ConfigUtility.EventBizNamespace + "." + "GroupVouch", true, System.Reflection.BindingFlags.CreateInstance, null, new object[] { conn, domhead, dombody, login.UFDataConnstringForNet.ToString(), "d" }, null, null);
                        oper.Delete(); 
                        break;
                }



 

                return true;
            }
            catch (Exception ex)
            {
                Output.mWriteLog(ex.Message);
                throw ex;
            }

        }

 

    }
 


} 
