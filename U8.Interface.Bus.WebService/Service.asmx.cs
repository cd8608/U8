using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using U8.Interface.Bus.WebService.DAL;

namespace U8.Interface.Bus.WebService
{
    /// <summary>
    /// Service1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {

        protected U8.Interface.Bus.WebService.Biz.Archive.clsArchiveBase arch;
        protected string subId = U8.Interface.Bus.SysInfo.subId; // "ST"; 

        /// <summary>
        /// 获取档案
        /// </summary>
        /// <param name="connstr">U8数据库连接串</param>
        /// <param name="ArchType">档案类型</param>
        /// <param name="DocList">返回的档案数据</param>
        /// <param name="ErrMsg">返回的错误信息</param>
        [WebMethod]
        public bool GetList(string connstr,string ArchType, out string DocList, out string ErrMsg)
        {
            if (string.IsNullOrEmpty(ArchType))
            {
                DocList = null;
                ErrMsg = "档案类型不能为空!";
                return false;
            }
            try
            {
                switch (ArchType.ToLower())
                {
                    case "department":
                        arch = new U8.Interface.Bus.WebService.Biz.Archive.clsDepartment();
                        arch.connStr = connstr;
                        arch.GetList(out DocList, out ErrMsg);
                        break;
                    case "person":
                        arch = new U8.Interface.Bus.WebService.Biz.Archive.clsPerson();
                        arch.connStr = connstr;
                        arch.GetList(out DocList, out ErrMsg);
                        break;
                    case "inventory":
                        arch = new U8.Interface.Bus.WebService.Biz.Archive.clsInventory();
                        arch.connStr = connstr;
                        arch.GetList(out DocList, out ErrMsg);
                        break;
                    case "inventoryclass":
                        arch = new U8.Interface.Bus.WebService.Biz.Archive.clsInventoryClass();
                        arch.connStr = connstr;
                        arch.GetList(out DocList, out ErrMsg);
                        break;
                    case "computationunit":
                        arch = new U8.Interface.Bus.WebService.Biz.Archive.clsComputationUnit();
                        arch.connStr = connstr;
                        arch.GetList(out DocList, out ErrMsg);
                        break;
                    case "mom_order":
                        arch = new U8.Interface.Bus.WebService.Biz.Archive.clsMom_order();
                        arch.connStr = connstr;
                        arch.GetList(out DocList, out ErrMsg);
                        break;
                    case "mom_orderdetail":
                        arch = new U8.Interface.Bus.WebService.Biz.Archive.clsMom_orderdetail();
                        arch.connStr = connstr;
                        arch.GetList(out DocList, out ErrMsg);
                        break;
                    case "mom_moallocate":
                        arch = new U8.Interface.Bus.WebService.Biz.Archive.clsMom_moallocate();
                        arch.connStr = connstr;
                        arch.GetList(out DocList, out ErrMsg);
                        break;
                    case "sfc_prouting":   //标准工艺主表
                        arch = new U8.Interface.Bus.WebService.Biz.Archive.clsSfc_prouting();
                        arch.connStr = connstr;
                        arch.GetList(out DocList, out ErrMsg);
                        break;
                    case "sfc_proutingdetail": //标准工艺子表
                        arch = new U8.Interface.Bus.WebService.Biz.Archive.clsSfc_proutingdetail();
                        arch.connStr = connstr;
                        arch.GetList(out DocList, out ErrMsg);
                        break; 
                    case "sfc_operation":  //标准工序资料维护  主表
                        arch = new U8.Interface.Bus.WebService.Biz.Archive.clsSfc_operation();
                        arch.connStr = connstr;
                        arch.GetList(out DocList, out ErrMsg);
                        break;
                    case "sfc_moroutingdetail":  //生产订单工序资料子表
                        arch = new U8.Interface.Bus.WebService.Biz.Archive.clsSfc_operation();
                        arch.connStr = connstr;
                        arch.GetList(out DocList, out ErrMsg);
                        break; 

                    default:
                        break;
                }
                if (arch == null)
                {
                    DocList = null;
                    ErrMsg = "没有相应档案的服务!";
                    return false;
                }
                return arch.GetList(out DocList, out ErrMsg);
            }
            catch
            {
                DocList = null;
                ErrMsg = "WebService GetList方法出错";
                return false;
            }
        }

        [WebMethod]
        public string GetListTest(string connstr, string ArchType)
        {
            string DocList = "";
            string ErrMsg = "";
            GetList(connstr, ArchType, out DocList, out ErrMsg);
            return DocList;
        }

        /// <summary>
        /// 返回错误信息
        /// </summary>
        /// <param name="connstr">数据库连接串</param>
        /// <param name="ArchType">档案类型</param>
        /// <param name="KeyValue">档案逻辑主键</param>
        /// <param name="ErrorCode">错误代码</param>
        /// <param name="ErrorMsg">错误信息</param>
        /// <param name="ErrMsg">本接口自身报错信息</param>
        /// <returns></returns>
        [WebMethod]
        public int Update(string connstr, string ArchType,string KeyValue, string ErrorCode,string ErrorMsg, out string ErrMsg)
        {
            if (string.IsNullOrEmpty(ArchType))
            { 
                ErrMsg = "档案类型不能为空!";
                return -1;
            }
            try
            {
                switch (ArchType.ToLower())
                {
                    case "department":
                        arch = new U8.Interface.Bus.WebService.Biz.Archive.clsDepartment(); 
                        break;
                    case "person":
                        arch = new U8.Interface.Bus.WebService.Biz.Archive.clsPerson(); 
                        break;
                    case "inventory":
                        arch = new U8.Interface.Bus.WebService.Biz.Archive.clsInventory(); 
                        break;
                    case "inventoryclass":
                        arch = new U8.Interface.Bus.WebService.Biz.Archive.clsInventoryClass(); 
                        break;
                    case "computationunit":
                        arch = new U8.Interface.Bus.WebService.Biz.Archive.clsComputationUnit(); 
                        break;
                    case "mom_order":
                        arch = new U8.Interface.Bus.WebService.Biz.Archive.clsMom_order(); 
                        break;
                    case "mom_orderdetail":
                        arch = new U8.Interface.Bus.WebService.Biz.Archive.clsMom_orderdetail(); 
                        break;
                    case "mom_moallocate":
                        arch = new U8.Interface.Bus.WebService.Biz.Archive.clsMom_moallocate(); 
                        break;
                    case "sfc_prouting":
                        arch = new U8.Interface.Bus.WebService.Biz.Archive.clsSfc_prouting(); 
                        break;
                    case "sfc_proutingdetail":
                        arch = new U8.Interface.Bus.WebService.Biz.Archive.clsSfc_proutingdetail();  
                        break;
                    default:
                        break;
                }
                if (arch == null)
                { 
                    ErrMsg = "没有相应档案的服务!";
                    return -1;
                }
                arch.connStr = connstr;
                return arch.Update(connstr, KeyValue,ErrorCode, ErrorMsg, out ErrMsg);
            }
            catch
            {
                ErrMsg = "WebService Update方法出错";
                return -1;
            }
        }


        [WebMethod]
        public string UpdateTest(string connstr, string ArchType, string KeyValue, string ErrorCode, string ErrorMsg)
        {
            string tempErr = "";
            Update(connstr, ArchType,KeyValue, ErrorCode, ErrorMsg, out tempErr);
            return tempErr;
        }
 

        /// <summary>
        /// 删除中间表数据
        /// </summary>
        /// <param name="connStr">U8数据库连接串</param>
        /// <param name="ArchType">档案类型</param>
        /// <param name="ID">档案id</param>
        /// <param name="ErrMsg">错误信息</param>
        [WebMethod]
        public bool Delete(string connStr, string ArchType, string ID, out string ErrMsg)
        {

            if (string.IsNullOrEmpty(ArchType))
            {
                ErrMsg = "档案类型不能为空!";
                return false;
            }
            try
            {
                switch (ArchType.ToLower())
                {
                    case "department":
                        arch = new U8.Interface.Bus.WebService.Biz.Archive.clsDepartment();
                        arch.connStr = connStr;
                        break;
                    case "person":
                        arch = new U8.Interface.Bus.WebService.Biz.Archive.clsPerson();
                        arch.connStr = connStr;
                        break;
                    case "inventory":
                        arch = new U8.Interface.Bus.WebService.Biz.Archive.clsInventory();
                        arch.connStr = connStr;
                        break;
                    case "inventoryclass":
                        arch = new U8.Interface.Bus.WebService.Biz.Archive.clsInventoryClass();
                        arch.connStr = connStr;
                        break;
                    case "computationunit":
                        arch = new U8.Interface.Bus.WebService.Biz.Archive.clsComputationUnit();
                        arch.connStr = connStr;
                        break;
                    case "mom_order":
                        arch = new U8.Interface.Bus.WebService.Biz.Archive.clsMom_order();
                        arch.connStr = connStr;
                        break;
                    case "mom_orderdetail":
                        arch = new U8.Interface.Bus.WebService.Biz.Archive.clsMom_orderdetail();
                        arch.connStr = connStr;
                        break;
                    case "mom_moallocate":
                        arch = new U8.Interface.Bus.WebService.Biz.Archive.clsMom_moallocate();
                        arch.connStr = connStr;
                        break;
                    case "sfc_prouting":
                        arch = new U8.Interface.Bus.WebService.Biz.Archive.clsSfc_prouting();
                        arch.connStr = connStr;
                        break;
                    case "sfc_proutingdetail":
                        arch = new U8.Interface.Bus.WebService.Biz.Archive.clsSfc_proutingdetail();
                        arch.connStr = connStr;
                        break;
                    default:
                        break;
                }
                if (arch == null)
                {
                    ErrMsg = "没有相应档案的服务!";
                    return false;
                }
                return arch.Delete(ID, out ErrMsg);
            }
            catch
            {
                ErrMsg = "WebService GetList方法出错";
                return false;
            }
        }

        [WebMethod]
        public string DeleteTest(string connStr, string ArchType, string ID)
        {
            string ErrMsg = "";
            Delete(connStr, ArchType, ID, out ErrMsg);
            return ErrMsg;

        }



        /// <summary>
        /// 上传接口
        /// </summary>
        /// <param name="connstr">U8数据库连接串</param>
        /// <param name="ArchType">档案类型</param>
        /// <param name="DocList">档案数据</param>
        /// <param name="ErrMsg">返回的错误信息</param>
        /// <returns></returns>
        [WebMethod]
        public bool Insert(string connstr, string ArchType, string DocList, out string ErrMsg)
        {
            if (string.IsNullOrEmpty(ArchType))
            {
                ErrMsg = "档案类型不能为空!";
                return false;
            }
            try
            {
                switch (ArchType.ToLower())
                {
                    case "rdrecord10":
                        arch = new U8.Interface.Bus.WebService.Biz.Voucher.clsRdrecord10();
                        break;
                    case "person":
                        arch = new U8.Interface.Bus.WebService.Biz.Voucher.clsPerson();
                        break;
                    case "optransform":
                        arch = new U8.Interface.Bus.WebService.Biz.Voucher.clsOptransform();
                        break;
                    default:
                        break;
                }
                if (arch == null)
                {
                    ErrMsg = "没有相应档案的服务!";
                    return false;
                }

                arch.connStr = connstr;
                return arch.Insert(DocList, out ErrMsg);
            }
            catch
            {
                ErrMsg = "WebService Insert方法出错";
                return false;
            }
        }

        /// <summary>
        /// 上传接口
        /// </summary>
        /// <param name="connstr">U8数据库连接串</param>
        /// <param name="ArchType">档案类型</param>
        /// <param name="DocList">档案数据</param>
        /// <param name="ErrMsg">返回的错误信息</param>
        /// <returns></returns>
        [WebMethod]
        public string InsertTest(string connstr, string ArchType, string DocList)
        {
            string _ErrMsg = "Succeed!";
            Insert(connstr, ArchType, DocList, out _ErrMsg);
            return _ErrMsg;
        }


        #region 用户登录
        /// <summary>
        /// 登录U8
        /// </summary>
        /// <param name="userCode">用户编码</param>
        /// <param name="passWord">用户密码</param>
        /// <param name="accID">U8账套号,例如001</param>
        /// <param name="year">登录年份,例如2016</param>
        /// <param name="loginDateTime">登录时间,例如2016-01-27</param>
        /// <param name="taskID">返回的U8登录taskID,注销时需要用到</param>
        /// <param name="loginString"></param>
        /// <param name="dBstring">返回的U8数据库连接串,方法调用时需要用到</param>
        [WebMethod]
        public int RFLogin(string userCode, string passWord, string accID, string year, DateTime loginDateTime, string msgID, out string taskID,
            out string loginString, out string dBstring, out string errMsg, out string loginUser, out DateTime systemDate, out bool isTaskExc, out bool isPFReport
           )
        {


            Info baseinfo = new Info();
            baseinfo.ERPService = ConfigurationSettings.AppSettings.Get("ERPSERVER");
            baseinfo.subID = subId;
            baseinfo.BarSubID = subId;
            //baseinfo.ERPService = "127.0.0.1";
            //baseinfo.subID = "ST";
            //baseinfo.BarSubID = "ST";

            UFSoft.U8.Framework.Login.UI.clsLogin netLogin = new UFSoft.U8.Framework.Login.UI.clsLogin();


            int val = CommonDAL.RFLogin(userCode, passWord, accID, year, msgID, loginDateTime, baseinfo, out loginString,
                out dBstring, out taskID, out errMsg, out loginUser, ref netLogin, out systemDate, out  isTaskExc, out isPFReport);

            if (val == 0)
            {
                Application[taskID] = netLogin;
            }
            //U8Login.clsLogin u8Login = new U8Login.clsLogin();
            //u8Login.ConstructLogin(netLogin.userToken);
            //U8EnvContext envContext = new U8EnvContext();
            //envContext.U8Login = u8Login;

            #region 判断是否是演示期
            //bool isDemo = true;
            //if ((DateTime.Now - DateTime.Parse("2013-12-31")).Days > 0)
            //{
            //    isDemo = false;
            //}
            //if (isDemo == false)  //不在演示期范围内
            //{
            //    errMsg = "当前系统不在演示期范围内!";
            //    return -1;
            //}
            #endregion
            return val;
        }

        [WebMethod]
        public string LoginTest(string userCode, string passWord, string accID, string year, DateTime loginDateTime, string msgID)
        {

            string res;

            string taskID;
            string loginString;
            string dBstring;
            string errMsg;
            string loginUser;
            DateTime systemDate;
            bool isTaskExc;
            bool isPFReport;


            Info baseinfo = new Info();
            baseinfo.ERPService = ConfigurationSettings.AppSettings.Get("ERPSERVER");
            baseinfo.subID = subId;
            baseinfo.BarSubID = subId;
            //baseinfo.ERPService = "127.0.0.1";
            //baseinfo.subID = "ST";
            //baseinfo.BarSubID = "ST";

            UFSoft.U8.Framework.Login.UI.clsLogin netLogin = new UFSoft.U8.Framework.Login.UI.clsLogin();


            int val = CommonDAL.RFLogin(userCode, passWord, accID, year, msgID, loginDateTime, baseinfo, out loginString,
                out dBstring, out taskID, out errMsg, out loginUser, ref netLogin, out systemDate, out  isTaskExc, out isPFReport);

            if (val == 0)
            {
                Application[taskID] = netLogin;
            }
            //U8Login.clsLogin u8Login = new U8Login.clsLogin();
            //u8Login.ConstructLogin(netLogin.userToken);
            //U8EnvContext envContext = new U8EnvContext();
            //envContext.U8Login = u8Login;

            #region 判断是否是演示期
            //bool isDemo = true;
            //if ((DateTime.Now - DateTime.Parse("2013-12-31")).Days > 0)
            //{
            //    isDemo = false;
            //}
            //if (isDemo == false)  //不在演示期范围内
            //{
            //    errMsg = "当前系统不在演示期范围内!";
            //    return -1;
            //} 

            #endregion

            res = "{\"retcode\":" + val + ",";
            res += "\"taskID\":\"" + taskID + "\",";
            res += "\"loginString\":\"" + loginString + "\",";
            res += "\"dBstring\",\"" + dBstring + "\"";
            res += "\"errMsg\",\"" + errMsg + "\"";
            res += "\"loginUser\",\"" + loginUser + "\"";
            res += "\"systemDate\",\"" + systemDate.ToString("yyyy-MM-dd hh:mm:ss") + "\"";
            res += "\"isTaskExc\",\"" + (isTaskExc ? "1" : "0") + "\"";
            res += "\"isPFReport\",\"" + (isPFReport ? "1" : "0") + "\"";
            res += "}";
            return res;
        }


        [WebMethod]
        public int ChangePwd(string NewPwd, string taskID, out string errMsg)
        {
            UFSoft.U8.Framework.Login.UI.clsLogin netLogin = (UFSoft.U8.Framework.Login.UI.clsLogin)Application[taskID];

            if (CommonDAL.ChangePassword(NewPwd, ref netLogin, out errMsg) != 0)
            {
                return -1;
            }
            Application[taskID] = netLogin;
            return 0;
        }

        /// <summary>
        /// 注销登录
        /// </summary>
        /// <param name="taskID">登录taskID</param>
        /// <param name="userCode">用户编码</param>
        /// <param name="connectionString">U8数据库连接字符串</param>
        [WebMethod]
        public int RFLogout(string taskID,
                                    string userCode, string connectionString)
        {
            Info baseinfo = new Info();
            baseinfo.ERPService = "127.0.0.1";
            baseinfo.subID = "CJ";
            baseinfo.BarSubID = "CJ";
            //baseinfo.ERPService = "127.0.0.1";
            //baseinfo.subID = "ST";
            //baseinfo.BarSubID = "ST";
            UFSoft.U8.Framework.Login.UI.clsLogin netLogin = (UFSoft.U8.Framework.Login.UI.clsLogin)Application[taskID];
            string taskIDBarKey = "Bar" + taskID;
            string taskIDConnKey = "Conn" + taskID;
            string taskIDLoginKey = "Login" + taskID;

            object AdodbConn = Application[taskIDConnKey];

            U8Login.clsLogin login = Application[taskIDLoginKey] != null ? (U8Login.clsLogin)Application[taskIDLoginKey] : null;
            Application.Remove(taskIDBarKey);
            Application.Remove(taskIDConnKey);
            Application.Remove(taskIDLoginKey);
            return CommonDAL.RFLogout(ref netLogin, AdodbConn, login, baseinfo, userCode, connectionString);
        }
            #endregion


    }
}
