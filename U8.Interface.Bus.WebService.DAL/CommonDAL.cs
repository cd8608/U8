using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;

using MSXML2;
using System.Runtime.InteropServices;
using U8.Interface.Bus.DBUtility;

namespace U8.Interface.Bus.WebService.DAL
{

    #region 帐套及数据库信息
    /// <summary>
    /// 帐套及数据库信息
    /// </summary>
    public struct Info
    {
        public string subID;
        public string BarSubID;
        public string ERPService;
        public string DBService;
    }
    #endregion

    public class CommonDAL
    {

        private static string _productName = "MES接口";
        private static string _subId = "MO";

        #region RF登录
        /// <summary>
        /// 功能：RF登录 
        /// </summary>
        /// <param name="dBString">登入字符串</param>
        /// <returns></returns>
        public static int PrintU8Login(out string dBString)
        {
            int result = 11;
            dBString = "";
            UFSoft.U8.Framework.Login.UI.clsLogin g_NetLogin = new UFSoft.U8.Framework.Login.UI.clsLogin();

            if (g_NetLogin.login("DP"))
            {
                //dBString = g_NetLogin.
                //UFSoft.U8.Framework.Login.UI.

                UFSoft.U8.Framework.LoginContext.UserData userData = g_NetLogin.GetLoginInfo();

                string sqlUser, sqlPassword, dataSource, catalog;

                SplitUserID(userData.ConnString, out sqlUser, out sqlPassword, out dataSource, out catalog);//解析返回数据串



                char[] a = new char[1];
                a[0] = '\"';
                sqlUser = sqlUser.Trim(a);
                sqlPassword = sqlPassword.Trim(a);
                dataSource = dataSource.Trim(a);
                catalog = catalog.Trim(a);


                dBString = "user id=" + sqlUser + ";password=" + sqlPassword + ";data source=" + dataSource
                        + ";persist security info=True;initial catalog=" + catalog;
                return 0;
            }

            return result;
        }

        /// <summary>

        /// 时间：2010-09-01
        /// </summary>
        /// <param name="userCode">用户编码</param>
        /// <param name="password">密码</param>
        /// <param name="accid">帐套号</param>
        /// <param name="year">帐套年度</param>
        /// <param name="msgID"></param>
        /// <param name="loginTime">登入时间</param>
        /// <param name="inf"></param>
        /// <param name="loginString">登入字符串</param>
        /// <param name="dBString">数据库字符串</param>
        /// <param name="taskId">任务ID</param>
        /// <param name="errMsg">错误信息</param>
        /// <param name="loginUser">登入人</param>
        /// <param name="netLogin"></param>
        /// <param name="systemDate">系统时间</param>
        /// <param name="isTaskExc">上下岗时间权限</param>
        /// <param name="isPFReport">工序流转卡权限</param>
        /// <returns></returns>
        public static int RFLogin(string userCode, string password, string accid, string year, string msgID, DateTime loginTime, Info inf,
               out string loginString, out string dBString, out string taskId, out string errMsg,
            out string loginUser, ref UFSoft.U8.Framework.Login.UI.clsLogin netLogin
            , out DateTime systemDate, out bool isTaskExc, out bool isPFReport)
        {
            loginString = "";
            taskId = "";
            loginUser = "";
            dBString = "";
            errMsg = "";
            isTaskExc = false;  //记录当前登录人员是否有修改上下岗时间的权限

            isPFReport = false;  //记录当前登录人员是否有工序流转卡完工单权限

            string ERPService = "";     //ERP服务器地址
            string DBService = "";
            bool result = false;
            string sqlUser = "";
            string sqlPassword = "";
            systemDate = loginTime;

            string serID = msgID + "@0";     //创建加密序列号


            //string serID = "{" + Guid.NewGuid() + "}" + msgID + "@0";  


            string pDate = loginTime.ToString("yyyy-MM-dd");
            try
            {
                ERPService = inf.ERPService;
                DBService = inf.DBService;
            }
            catch (Exception ex)
            {
                errMsg = "配置文件错误" + ex.Message;
                return -1;
            }
            U8Login.clsLoginClass login;    //创建登录对象
            netLogin = new UFSoft.U8.Framework.Login.UI.clsLogin();


            try
            {
                result = netLogin.login("DP", userCode, password, inf.ERPService, pDate, accid, serID, false); //先登录平台
 
                if (result)
                { 
                    netLogin.WorkStationName = userCode + ":" + msgID;//ADD BY HQ 设置工作站名称

                    //netLogin.SubLogin("CJ");                              //加密服务登录用户站点 + 1

                    UFSoft.U8.Framework.LoginContext.ProductContext pcT = new UFSoft.U8.Framework.LoginContext.ProductContext();
                    pcT = netLogin.SubLogin(inf.subID);                        //加密服务登录用户站点 + 1

                    if (pcT == null)
                    {
                        errMsg = "【" +_productName + "】登录错误：" + netLogin.ErrDescript;
                        return 1;
                    }
                    taskId = netLogin.GetTaskID(inf.BarSubID);              //获得任务号          

                }
                else
                {
                    errMsg = "【" + _productName + "】登录错误：" + netLogin.ErrDescript;
                    return 1;
                }

                login = new U8Login.clsLoginClass();                    //生成登录对象   

                result = login.ConstructLogin(netLogin.userToken);
                result = login.Login(ref inf.BarSubID, ref accid, ref  year, ref userCode, ref password, ref pDate, ref inf.ERPService, ref serID);
                if (result)
                {

                    object bDemo = false;

                    //bDemo = true; //正式版
                    //bDemo = False;    演示版


                    login.GetAccInfo(10000, ref bDemo);//判断产品是否演示版


                    isTaskExc = true; //= login.TaskExec("FZ102013", 1, 1);             //获得上下岗时间修改权限 by zhaobo
                    isPFReport = true;// = login.TaskExec("FC06006N", 1, 1);             //获得工序流转卡权限  By zhaobo


                    if (taskId == "")
                    {
                        errMsg = "";
                    }
                    //不是演示版


                    loginUser = login.cUserName.ToString();
                    loginString = netLogin.userToken.ToString();


                    string dataSource, catalog;
                    SplitUserID(login.UfDbName, out sqlUser, out sqlPassword, out dataSource, out catalog);//解析返回数据串


                    char[] a = new char[1];
                    a[0] = '\"';
                    sqlUser = sqlUser.Trim(a);
                    sqlPassword = sqlPassword.Trim(a);
                    dataSource = dataSource.Trim(a);
                    catalog = catalog.Trim(a);


                    dBString = "user id=" + sqlUser + ";password=" + sqlPassword + ";data source=" + dataSource
                            + ";persist security info=True;initial catalog=" + catalog;

                    string tempdBstring = "user id=" + sqlUser + ";password=" + sqlPassword + ";data source=" + dataSource
                            + ";persist security info=True;initial catalog=UFSystem";
                    dBString = dBString + "|" + login.UfDbName;

                    IniU8Message(tempdBstring);

                    if (!Convert.ToBoolean(bDemo))
                    {
                        if (isDemoOver(dBString))
                        {
                            errMsg = "请购买用友U8【" + _productName + "】";
                            return 5;
                        }
                    }


                    return 0;
                }
                else
                {
                    errMsg = "错误:" + login.ShareString;
                    //
                    return 2;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return -2;
            }

            // return 0;
        }



        #region 修改密码
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="NewPwd">新密码</param>
        /// <param name="netLogin">界面登录字符串</param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public static int ChangePassword(string NewPwd, ref UFSoft.U8.Framework.Login.UI.clsLogin netLogin, out string errMsg)
        {
            errMsg = string.Empty;

            try
            {
                if (netLogin == null)
                {
                    errMsg = "登录字符串丢失！";
                    return -1;
                }

                netLogin.ModifyUserPassword(NewPwd);

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return -2;
            }
            return 0;
        }
        #endregion



        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        private static void IniU8Message(string connection)
        {
            string errMsg = "";
            string sSQL = @"if exists(select cSub_Id from ua_subsys_base where cSub_Id='SO')
                              update ua_subsys_base Set cSub_Name ='库存条码' where cSub_Id = 'SO'
                            else
	                            begin
	                              insert into ua_subsys_base(cSub_Id,cSub_Name,iTasks,bInstalled,
	                            iVersion,cObjCreate,dStart,nType,cEntType,localeid,iOrder )
		                            values('SO','库存条码',0,1,'8.0099999999999998','CreatCom',null,0,null,'zh-CN',1)
	                              insert into ua_subsys_base(cSub_Id,cSub_Name,iTasks,bInstalled,
	                            iVersion,cObjCreate,dStart,nType,cEntType,localeid,iOrder )
		                            values('SO','库存条码',0,1,'8.0099999999999998','CreatCom',null,0,null,'zh-TW',1)
	                              insert into ua_subsys_base(cSub_Id,cSub_Name,iTasks,bInstalled,
	                            iVersion,cObjCreate,dStart,nType,cEntType,localeid,iOrder )
		                            values('SO','库存条码',0,1,'8.0099999999999998','CreatCom',null,0,null,'en-US',1)
	                            end";


            SQLHelper.ExecuteSql(sSQL, connection, out errMsg);
        }


        /// <summary>
        /// 功能：判断是否演示版
        /// </summary>
        /// <param name="connString">连接字符串</param>
        /// <returns></returns>
        public static bool isDemoOver(string connString)
        {
            bool result = false;
            DateTime MaxDate;
            DateTime MinDate;
            TimeSpan tsp = new TimeSpan();
            string errMsg = "";

            DataSet ds = new DataSet();
            //sql
            #region 修改SQL错误
            //            string sqlString = @"Select Max(CreateDate) As MaxDate,Min(CreateDate) As MinDate from 
            //                                    HY_barcodeDetail where cBusType is not null";
            string sqlString = @"Select Max(DocDate) As MaxDate,Min(DocDate) As MinDate from   sfc_pfreport ";   // 查询流转卡完工单
            #endregion

            //获取最大日期最小日期


            SQLHelper.GetDataset(sqlString, connString, out ds, out errMsg);

            if (ds.Tables[0].Rows[0]["MaxDate"] != DBNull.Value)
                MaxDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["MaxDate"]);
            else
                return false;

            if (ds.Tables[0].Rows[0]["MinDate"] != DBNull.Value)
                MinDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["MinDate"]);
            else
                return false;

            tsp = MaxDate - MinDate;
            //如果已用超过59天，或者两个月，提示过期

            if (tsp.Days > 59 && Math.Abs((MaxDate.Month - MinDate.Month)) >= 2)
            {
                return true;        //演示期结束

            }
            else
            {
                //查询报工单

                sqlString = @"Select Max(cVouchDate) As MaxDate,Min(cVouchDate) As MinDate  from fc_moroutingbill";  //查工序报工单
                SQLHelper.GetDataset(sqlString, connString, out ds, out errMsg);
                if (ds.Tables[0].Rows[0]["MaxDate"] != DBNull.Value)
                    MaxDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["MaxDate"]);
                else
                    return false;

                if (ds.Tables[0].Rows[0]["MinDate"] != DBNull.Value)
                    MinDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["MinDate"]);
                else
                    return false;

                TimeSpan ts = MaxDate - MinDate;
                if (ts.Days > 59 && Math.Abs((MaxDate.Month - MinDate.Month)) >= 2)
                {
                    return true;        //演示期结束

                }
                else
                {
                    return false;
                }
            }



        }


        /// <summary>
        /// 功能：注销登入
        /// </summary>
        /// <param name="netLogin"></param>
        /// <param name="inf"></param>
        /// <param name="userCode"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static int RFLogout(ref UFSoft.U8.Framework.Login.UI.clsLogin netLogin, object AdodbConn, U8Login.clsLogin login, Info inf, string userCode, string connectionString)
        {
            int result = 0;
            try
            {
                //如果登录对象丢失
                if (netLogin == null)
                    return 0;
                netLogin.SubLogout("CJ");                       //暂时占用CJ
                if (AdodbConn != null)
                {
                    ((ADODB.Connection)AdodbConn).Close();
                }
                if (login != null)
                {
                    login.ShutDown();
                }

                //CancelAllLock(userCode, connectionString);      //接触该用户的所有锁定单据

                //netLogin.SubLogout("SO");
            }
            catch (Exception ex)
            {
                return 1;
            }


            return result;
        }

        #endregion

        #region 解析字符串


        public static void SplitUserID(string connection, out string UserID, out string Pwd)
        {
            UserID = "";
            Pwd = "";
            char[] sp = new char[1];
            sp[0] = ';';
            string[] val = connection.Split(sp);
            int lenIndex = 0;
            foreach (string tval in val)
            {
                lenIndex = 0;
                if (tval.StartsWith("user id"))
                {
                    lenIndex = tval.IndexOf("=") + 1;
                    UserID = tval.Substring(lenIndex, tval.Length - lenIndex);
                }
                else if (tval.StartsWith("password"))
                {
                    lenIndex = tval.IndexOf("=") + 1;
                    Pwd = tval.Substring(lenIndex, tval.Length - lenIndex);
                }
                else
                {
                    continue;
                }
            }
        }
        public static void SplitUserID(string connection, out string UserID, out string Pwd, out string dataSource, out string cataLog)
        {
            UserID = "";
            Pwd = "";
            cataLog = "";
            dataSource = "";
            char[] sp = new char[1];
            sp[0] = ';';
            string[] val = connection.Split(sp);
            int lenIndex = 0;



            foreach (string tval in val)
            {
                lenIndex = 0;
                if (tval.StartsWith("user id"))
                {
                    lenIndex = tval.IndexOf("=") + 1;
                    UserID = tval.Substring(lenIndex, tval.Length - lenIndex);
                }
                else if (tval.StartsWith("password"))
                {
                    lenIndex = tval.IndexOf("=") + 1;
                    Pwd = tval.Substring(lenIndex, tval.Length - lenIndex);
                }
                else if (tval.StartsWith("data source"))
                {
                    lenIndex = tval.IndexOf("=") + 1;
                    dataSource = tval.Substring(lenIndex, tval.Length - lenIndex);
                }
                else if (tval.StartsWith("initial catalog"))
                {
                    lenIndex = tval.IndexOf("=") + 1;
                    cataLog = tval.Substring(lenIndex, tval.Length - lenIndex);
                }
                else
                {
                    continue;
                }
            }
        }
        #endregion

        //public static int LoadAccInformation(string connString, out DataSet ds, out string errMsg)
        //{
        //    ds = new DataSet();
        //    errMsg = "";
        //    string sql = @"select * from accinformation where csysid='KC'";
        //    return SQLHelper.GetDataset(sql, connString, out ds, out errMsg);
        //}

    }
}
