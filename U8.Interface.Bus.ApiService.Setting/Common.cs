using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.ServiceProcess;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;
using System.Data;
using System.IO;
using U8.Interface.Bus.Comm;

using U8.Interface.Bus.DBUtility;
using U8.Interface.Bus.ApiService.Model;

namespace U8.Interface.Bus.ApiService.Setting
{

    #region 自定义枚举类型
    /// <summary>
    /// 服务操作
    /// </summary>
    public enum ServiceOpear
    {
        /// <summary>
        /// 停止服务
        /// </summary>
        Stop = 0,
        /// <summary>
        /// 启动服务
        /// </summary>
        Run = 1,
        /// <summary>
        /// 暂停服务
        /// </summary>
        Pause = 2,
        /// <summary>
        /// 恢复服务
        /// </summary>
        Continue = 3
    }

    /// <summary>
    /// 服务启动模式
    /// </summary>
    public enum ServiceMode
    {
        /// <summary>
        /// 禁用
        /// </summary>
        Disabled = 0,
        /// <summary>
        /// 手动
        /// </summary>
        Demand = 1,
        /// <summary>
        /// 自动
        /// </summary>
        Auto = 2
    }

    #endregion

    /// <summary>
    /// 公共类
    /// </summary>
    public static class Common
    {
        #region 公共变量
        /// <summary>
        /// 默认界面排版
        /// </summary>
        public const string UIStyle = "1";
        /// <summary>
        /// 默认任务显示方式
        /// </summary>
        public const string Display = "14";
        /// <summary>
        /// 默认任务列表宽度
        /// </summary>
        public const string ListSize = "490";
        /// <summary>
        /// 默认任务结构宽度
        /// </summary>
        public const string TaskSize = "220";
        /// <summary>
        /// 默认任务列表显示列
        /// </summary>
        public const string HColumn = "9482";
        /// <summary>
        /// 默认详细信息显示列
        /// </summary>
        public const string BColumn = "49862";

        /// <summary>
        /// 是否失效
        /// </summary>
        public static bool bIsValid;
        /// <summary>
        /// 是否连接
        /// </summary>
        public static bool bIsLinked;
        /// <summary>
        /// 本地机器名
        /// </summary>
        public static string sHostName;
        /// <summary>
        /// 注册表信息
        /// </summary>
        public static Dictionary<string, string> dicRegist;
        /// <summary>
        /// 服务显示信息
        /// </summary>
        public static List<ServiceModel> lstService;


        public static string mainServiceName = "U8.Interface.Bus.WinService"; 
        public static string checkServiceName = "U8.Interface.Bus.WinService.Check";

        #endregion

        #region 注册表方法

        /// <summary>
        /// 获取注册表信息
        /// </summary>
        /// <returns></returns>
        public static bool GetRegist()
        {
            try
            {

                dicRegist = new Dictionary<string, string>();
                dicRegist.Add("servername", RegistryKeyHelp.getValueRegEdit(RegistryKeyHelp.u8path, "servername"));
                dicRegist.Add("dbname", RegistryKeyHelp.getValueRegEdit(RegistryKeyHelp.u8path, "dbname"));
                dicRegist.Add("username", RegistryKeyHelp.getValueRegEdit(RegistryKeyHelp.u8path, "username"));
                dicRegist.Add("pwd", DESEncrypt.Decrypt(RegistryKeyHelp.getValueRegEdit(RegistryKeyHelp.u8path, "pwd")));

                dicRegist.Add("uistyle", RegistryKeyHelp.getValueRegEdit(RegistryKeyHelp.u8path, "uistyle"));
                dicRegist.Add("display", RegistryKeyHelp.getValueRegEdit(RegistryKeyHelp.u8path, "display"));
                dicRegist.Add("hcolumn", RegistryKeyHelp.getValueRegEdit(RegistryKeyHelp.u8path, "hcolumn"));
                dicRegist.Add("bcolumn", RegistryKeyHelp.getValueRegEdit(RegistryKeyHelp.u8path, "bcolumn"));

                dicRegist.Add("listsize", RegistryKeyHelp.getValueRegEdit(RegistryKeyHelp.u8path, "listsize"));
                dicRegist.Add("tasksize", RegistryKeyHelp.getValueRegEdit(RegistryKeyHelp.u8path, "tasksize"));

                if (string.IsNullOrEmpty(dicRegist["servername"])) bIsLinked = false;
                else if (string.IsNullOrEmpty(dicRegist["dbname"])) bIsLinked = false;
                else if (string.IsNullOrEmpty(dicRegist["username"])) bIsLinked = false;
                else bIsLinked = TestLink(dicRegist["servername"], dicRegist["dbname"], dicRegist["username"], dicRegist["pwd"]) == 1;

                if (string.IsNullOrEmpty(dicRegist["uistyle"])) dicRegist["uistyle"] = UIStyle;
                if (string.IsNullOrEmpty(dicRegist["display"])) dicRegist["display"] = Display;
                if (string.IsNullOrEmpty(dicRegist["listsize"])) dicRegist["listsize"] = ListSize;
                if (string.IsNullOrEmpty(dicRegist["tasksize"])) dicRegist["tasksize"] = TaskSize;
                if (string.IsNullOrEmpty(dicRegist["hcolumn"])) dicRegist["hcolumn"] = HColumn;
                if (string.IsNullOrEmpty(dicRegist["bcolumn"])) dicRegist["bcolumn"] = BColumn;

                sHostName = System.Net.Dns.GetHostName().ToUpper();

                return true;
            }
            catch (Exception ex)
            {
                MessageShow(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 保存注册表信息
        /// </summary>
        /// <returns></returns>
        public static bool SetRegist()
        {
            try
            {
                if (dicRegist == null || dicRegist.Count == 0) return false;

                if (!RegistryKeyHelp.CreateItemRegEdit(RegistryKeyHelp.u8path)) return false;
                RegistryKeyHelp.SetValueRegEdit(RegistryKeyHelp.u8path, "servername", dicRegist["servername"]);
                RegistryKeyHelp.SetValueRegEdit(RegistryKeyHelp.u8path, "dbname", dicRegist["dbname"]);
                RegistryKeyHelp.SetValueRegEdit(RegistryKeyHelp.u8path, "username", dicRegist["username"]);
                RegistryKeyHelp.SetValueRegEdit(RegistryKeyHelp.u8path, "pwd", DESEncrypt.Encrypt(dicRegist["pwd"]));
                RegistryKeyHelp.SetValueRegEdit(RegistryKeyHelp.u8path, "uistyle", dicRegist["uistyle"]);
                RegistryKeyHelp.SetValueRegEdit(RegistryKeyHelp.u8path, "display", dicRegist["display"]);
                RegistryKeyHelp.SetValueRegEdit(RegistryKeyHelp.u8path, "hcolumn", dicRegist["hcolumn"]);
                RegistryKeyHelp.SetValueRegEdit(RegistryKeyHelp.u8path, "bcolumn", dicRegist["bcolumn"]);
                RegistryKeyHelp.SetValueRegEdit(RegistryKeyHelp.u8path, "listsize", dicRegist["listsize"]);
                RegistryKeyHelp.SetValueRegEdit(RegistryKeyHelp.u8path, "tasksize", dicRegist["tasksize"]);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 保存注册表信息
        /// </summary>
        /// <returns></returns>
        public static bool SetRegist(out string strErr)
        {
            try
            {
                if (dicRegist == null || dicRegist.Count == 0)
                {
                    strErr = "没有需要保存的信息";
                    return false;
                }

                if (!RegistryKeyHelp.CreateItemRegEdit(RegistryKeyHelp.u8path))
                {
                    strErr = "当前用户没有对注册表的写入权限";
                    return false;
                }

                RegistryKeyHelp.SetValueRegEdit(RegistryKeyHelp.u8path, "servername", dicRegist["servername"]);
                RegistryKeyHelp.SetValueRegEdit(RegistryKeyHelp.u8path, "dbname", dicRegist["dbname"]);
                RegistryKeyHelp.SetValueRegEdit(RegistryKeyHelp.u8path, "username", dicRegist["username"]);
                RegistryKeyHelp.SetValueRegEdit(RegistryKeyHelp.u8path, "pwd", DESEncrypt.Encrypt(dicRegist["pwd"]));
                RegistryKeyHelp.SetValueRegEdit(RegistryKeyHelp.u8path, "uistyle", dicRegist["uistyle"]);
                RegistryKeyHelp.SetValueRegEdit(RegistryKeyHelp.u8path, "display", dicRegist["display"]);
                RegistryKeyHelp.SetValueRegEdit(RegistryKeyHelp.u8path, "hcolumn", dicRegist["hcolumn"]);
                RegistryKeyHelp.SetValueRegEdit(RegistryKeyHelp.u8path, "bcolumn", dicRegist["bcolumn"]);
                RegistryKeyHelp.SetValueRegEdit(RegistryKeyHelp.u8path, "listsize", dicRegist["listsize"]);
                RegistryKeyHelp.SetValueRegEdit(RegistryKeyHelp.u8path, "tasksize", dicRegist["tasksize"]);

                strErr = "";
                return true;
            }
            catch (Exception ex)
            {
                strErr = ex.Message;
                return false;
            }
        }




        /// <summary>
        /// 获取注册表信息
        /// </summary>
        /// <returns></returns>
        public static bool GetConfig()
        {
            try
            {

                dicRegist = new Dictionary<string, string>(); 

                dicRegist.Add("servername", U8.Interface.Bus.Config.ConfigUtility.DataBaseSrv);
                dicRegist.Add("dbname", U8.Interface.Bus.Config.ConfigUtility.DataBaseCatalog);
                dicRegist.Add("username", U8.Interface.Bus.Config.ConfigUtility.DataBaseUser);
                dicRegist.Add("pwd", DESEncrypt.Decrypt(U8.Interface.Bus.Config.ConfigUtility.DataBasePwd));

                dicRegist.Add("uistyle", RegistryKeyHelp.getValueRegEdit(RegistryKeyHelp.u8path, "uistyle"));
                dicRegist.Add("display", RegistryKeyHelp.getValueRegEdit(RegistryKeyHelp.u8path, "display"));
                dicRegist.Add("hcolumn", RegistryKeyHelp.getValueRegEdit(RegistryKeyHelp.u8path, "hcolumn"));
                dicRegist.Add("bcolumn", RegistryKeyHelp.getValueRegEdit(RegistryKeyHelp.u8path, "bcolumn"));

                dicRegist.Add("listsize", RegistryKeyHelp.getValueRegEdit(RegistryKeyHelp.u8path, "listsize"));
                dicRegist.Add("tasksize", RegistryKeyHelp.getValueRegEdit(RegistryKeyHelp.u8path, "tasksize"));

                if (string.IsNullOrEmpty(dicRegist["servername"])) bIsLinked = false;
                else if (string.IsNullOrEmpty(dicRegist["dbname"])) bIsLinked = false;
                else if (string.IsNullOrEmpty(dicRegist["username"])) bIsLinked = false;
                else bIsLinked = TestLink(dicRegist["servername"], dicRegist["dbname"], dicRegist["username"], dicRegist["pwd"]) == 1;

                if (string.IsNullOrEmpty(dicRegist["uistyle"])) dicRegist["uistyle"] = UIStyle;
                if (string.IsNullOrEmpty(dicRegist["display"])) dicRegist["display"] = Display;
                if (string.IsNullOrEmpty(dicRegist["listsize"])) dicRegist["listsize"] = ListSize;
                if (string.IsNullOrEmpty(dicRegist["tasksize"])) dicRegist["tasksize"] = TaskSize;
                if (string.IsNullOrEmpty(dicRegist["hcolumn"])) dicRegist["hcolumn"] = HColumn;
                if (string.IsNullOrEmpty(dicRegist["bcolumn"])) dicRegist["bcolumn"] = BColumn;

                sHostName = System.Net.Dns.GetHostName().ToUpper();

                return true;
            }
            catch (Exception ex)
            {
                MessageShow(ex.Message);
                return false;
            }
        }



        /// <summary>
        /// 保存注册表信息
        /// </summary>
        /// <returns></returns>
        public static bool SetConfig(out string strErr)
        {
            try
            {
                if (dicRegist == null || dicRegist.Count == 0)
                {
                    strErr = "没有需要保存的信息";
                    return false;
                }

                if (!RegistryKeyHelp.CreateItemRegEdit(RegistryKeyHelp.u8path))
                {
                    strErr = "当前用户没有对注册表的写入权限";
                    return false;
                }

                U8.Interface.Bus.Config.ConfigUtility.DataBaseSrv = dicRegist["servername"];
                U8.Interface.Bus.Config.ConfigUtility.DataBaseCatalog = dicRegist["dbname"];
                U8.Interface.Bus.Config.ConfigUtility.DataBaseUser = dicRegist["username"];
                U8.Interface.Bus.Config.ConfigUtility.DataBasePwd = DESEncrypt.Encrypt(dicRegist["pwd"]);


                RegistryKeyHelp.SetValueRegEdit(RegistryKeyHelp.u8path, "uistyle", dicRegist["uistyle"]);
                RegistryKeyHelp.SetValueRegEdit(RegistryKeyHelp.u8path, "display", dicRegist["display"]);
                RegistryKeyHelp.SetValueRegEdit(RegistryKeyHelp.u8path, "hcolumn", dicRegist["hcolumn"]);
                RegistryKeyHelp.SetValueRegEdit(RegistryKeyHelp.u8path, "bcolumn", dicRegist["bcolumn"]);
                RegistryKeyHelp.SetValueRegEdit(RegistryKeyHelp.u8path, "listsize", dicRegist["listsize"]);
                RegistryKeyHelp.SetValueRegEdit(RegistryKeyHelp.u8path, "tasksize", dicRegist["tasksize"]);

                strErr = "";
                return true;
            }
            catch (Exception ex)
            {
                strErr = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 保存注册表信息
        /// </summary>
        /// <returns></returns>
        public static bool SetConfig()
        {
            try
            {
                if (dicRegist == null || dicRegist.Count == 0) return false;


                U8.Interface.Bus.Config.ConfigUtility.DataBaseSrv = dicRegist["servername"];
                U8.Interface.Bus.Config.ConfigUtility.DataBaseCatalog = dicRegist["dbname"];
                U8.Interface.Bus.Config.ConfigUtility.DataBaseUser = dicRegist["username"];
                U8.Interface.Bus.Config.ConfigUtility.DataBasePwd = DESEncrypt.Encrypt(dicRegist["pwd"]);


                if (!RegistryKeyHelp.CreateItemRegEdit(RegistryKeyHelp.u8path)) return false;
                RegistryKeyHelp.SetValueRegEdit(RegistryKeyHelp.u8path, "uistyle", dicRegist["uistyle"]);
                RegistryKeyHelp.SetValueRegEdit(RegistryKeyHelp.u8path, "display", dicRegist["display"]);
                RegistryKeyHelp.SetValueRegEdit(RegistryKeyHelp.u8path, "hcolumn", dicRegist["hcolumn"]);
                RegistryKeyHelp.SetValueRegEdit(RegistryKeyHelp.u8path, "bcolumn", dicRegist["bcolumn"]);
                RegistryKeyHelp.SetValueRegEdit(RegistryKeyHelp.u8path, "listsize", dicRegist["listsize"]);
                RegistryKeyHelp.SetValueRegEdit(RegistryKeyHelp.u8path, "tasksize", dicRegist["tasksize"]);

                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region 链接方法
        /// <summary>
        /// 设置链接
        /// </summary>
        /// <param name="ServerName"></param>
        /// <param name="DBName"></param>
        /// <param name="UserName"></param>
        /// <param name="DBPwd"></param>
        /// <returns></returns>
        public static bool SetLink(string ServerName, string DBName, string UserName, string DBPwd)
        {
            try
            {
                //SetRegist();
                //DbHelperSQL.connectionString = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};Current Language=Simplified Chinese", ServerName, DBName, UserName, DBPwd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 测试链接
        /// </summary>
        /// <returns></returns>
        public static int TestLink(string ServerName, string DBName, string UserName, string DBPwd)
        {
            string consting = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};Current Language=Simplified Chinese", ServerName, DBName, UserName, DBPwd);
            SqlConnection sqlcon = new SqlConnection(consting);
            SqlCommand sqlcmd = new SqlCommand("SELECT COUNT(1) FROM sysobjects WHERE type='U' AND name IN ('HY_DZ_K7_SYNERGISMLOGDT','HY_DZ_K7_SYNERGISMLOG','HY_DZ_K7_RELATIONS','HY_DZ_K7_RELATION','HY_DZ_K7_REGIST') ", sqlcon);
            try
            {
                sqlcon.Open();
                object obj = sqlcmd.ExecuteScalar();
                if (obj == null || obj == DBNull.Value) return -1;
                if (System.Convert.ToInt32(obj) != 5) return 0;
                return 1;
            }
            catch
            {
                return -1;
            }
            finally
            {
                sqlcon.Close();
            }
        }
        #endregion

        #region 服务方法

        /// <summary>
        /// 获取服务列表
        /// </summary>
        /// <returns></returns>
        public static bool GetServices()
        {
            try
            {
                lstService = new List<ServiceModel>();
                ServiceController sc;

                ServiceModel sm;

                sc = GetServiceInfo(mainServiceName);  //U8TeamworkService
                if (sc == null) return false;

                sm = TransService(sc);
                sm.SerNo = "1";
                sm.ID = "001";
                lstService.Add(sm);


                sc = GetServiceInfo(checkServiceName);  //U8TeamworkCheck
                if (sc == null) return false;

                sm = TransService(sc);
                sm.SerNo = "2";
                sm.ID = "002";
                lstService.Add(sm);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 获取服务列表
        /// </summary>
        public static List<Model.ServiceModel> GetServices(string sMachineName)
        {
            List<ServiceModel> Services = new List<Model.ServiceModel>();
            ServiceController sc;
            ServiceModel sm;

            try
            {
                sc = GetServiceInfo(sMachineName, mainServiceName);
                if (sc == null) return Services;

                sm = TransService(sc);
                sm.SerNo = "1";
                sm.ID = "001";
                Services.Add(sm);


                sc = GetServiceInfo(sMachineName, checkServiceName);
                if (sc == null) return Services;

                sm = TransService(sc);
                sm.SerNo = "2";
                sm.ID = "002";
                Services.Add(sm);

                return Services;
            }
            catch
            {
                return Services;
            }
        }

        /// <summary>
        /// 转化服务显示
        /// </summary>
        /// <param name="sc"></param>
        /// <returns></returns>
        public static ServiceModel TransService(ServiceController sc)
        {
            ServiceModel sm = new ServiceModel();
            try
            {
                sm.Machine = sc.MachineName == "." ? sHostName : sc.MachineName;
                sm.Name = sc.ServiceName;
                sm.Desc = sc.DisplayName;
                sm.Status = GetServiceStatus(sc);
                sm.StartMod = GetServiceStartType(sc.ServiceName);
                return sm;
            }
            catch
            {
                return sm;
            }
        }

        /// <summary>
        /// 获取服务信息
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public static ServiceController GetServiceInfo(string sServiceName)
        {
            try
            {
                ServiceController[] Services;
                ServiceController sc;

                if (!bIsLinked)
                {
                    Services = ServiceController.GetServices();
                }
                else
                {
                    if (!string.IsNullOrEmpty(dicRegist["servername"]) && dicRegist["servername"].ToUpper() != sHostName)
                    {
                        Services = ServiceController.GetServices(dicRegist["servername"]);
                    }
                    else
                    {
                        Services = ServiceController.GetServices();
                    }
                }

                if (Services == null || Services.Length <= 0) return null;
                sc = Services.First(delegate(ServiceController temp) { return temp.ServiceName.ToLower() == sServiceName.ToLower(); });
                return sc;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取服务信息
        /// </summary>
        public static ServiceController GetServiceInfo(string sMachineName, string sServiceName)
        {
            try
            {
                ServiceController[] Services;
                ServiceController sc;

                Services = ServiceController.GetServices(sMachineName);
                if (Services == null || Services.Length <= 0) return null;
                sc = Services.First(delegate(ServiceController temp) { return temp.ServiceName.ToLower() == sServiceName.ToLower(); });
                return sc;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取服务状态
        /// </summary>
        /// <param name="sServiceName"></param>
        /// <returns></returns>
        public static string GetServiceStatus(ServiceController sc)
        {
            try
            {
                switch (sc.Status)
                {
                    case ServiceControllerStatus.Running:
                        return "运行中";

                    case ServiceControllerStatus.Paused:
                        return "已暂停";

                    case ServiceControllerStatus.Stopped:
                        return "已停止";

                    case ServiceControllerStatus.ContinuePending:
                        return "继续中";

                    case ServiceControllerStatus.PausePending:
                        return "暂停中";

                    case ServiceControllerStatus.StartPending:
                        return "启动中";

                    case ServiceControllerStatus.StopPending:
                        return "停止中";

                    default:
                        return "未知";
                }
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 获取服务状态
        /// </summary>
        /// <param name="sServiceName"></param>
        /// <returns></returns>
        public static string GetServiceStatus(string sServiceName)
        {
            try
            {
                ServiceController sc = new ServiceController();
                sc.ServiceName = sServiceName;
                sc.MachineName = dicRegist["servername"];   // ".";

                switch (sc.Status)
                {
                    case ServiceControllerStatus.Running:
                        return "运行中";

                    case ServiceControllerStatus.Paused:
                        return "已暂停";

                    case ServiceControllerStatus.Stopped:
                        return "已停止";

                    case ServiceControllerStatus.ContinuePending:
                        return "恢复中";

                    case ServiceControllerStatus.PausePending:
                        return "暂停中";

                    case ServiceControllerStatus.StartPending:
                        return "启动中";

                    case ServiceControllerStatus.StopPending:
                        return "停止中";

                    default:
                        return "未知";
                }
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 获取服务类型
        /// </summary>
        /// <param name="sServiceName"></param>
        /// <returns></returns>
        public static string GetServiceStartType(String sServiceName)
        {
            string sState = "";

            try
            {
                System.Diagnostics.ProcessStartInfo objProcessInf = new System.Diagnostics.ProcessStartInfo();

                objProcessInf.FileName = "cmd.exe";

                objProcessInf.UseShellExecute = false;

                objProcessInf.RedirectStandardError = true;
                objProcessInf.RedirectStandardInput = true;
                objProcessInf.RedirectStandardOutput = true;

                objProcessInf.CreateNoWindow = true;

                objProcessInf.Arguments = "/c sc qc " + sServiceName;

                System.Diagnostics.Process objProcess = System.Diagnostics.Process.Start(objProcessInf);

                String sStateValue = objProcess.StandardOutput.ReadToEnd();

                if (sStateValue.IndexOf("AUTO_START") > 0)
                {
                    return sState = "自动";

                }

                if (sStateValue.IndexOf("DEMAND_START") > 0)
                {
                    return sState = "手动";

                }

                if (sStateValue.IndexOf("DISABLED") > 0)
                {
                    return sState = "禁用";

                }

                return "";

            }
            catch (Exception e)
            {
                sState = e.Message;
                return "";
            }
        }

        /// <summary>
        /// 设置服务状态
        /// </summary>
        /// <param name="opear"></param>
        /// <param name="sServiceName"></param>
        /// <returns></returns>
        public static bool SetService(ServiceOpear opear, string sServiceName)
        {
            try
            {
                ServiceController sc = new ServiceController();
                sc.ServiceName = sServiceName;
                sc.MachineName = dicRegist["servername"];   // ".";

                switch (opear)
                {
                    case ServiceOpear.Run:
                        if (sc.Status == ServiceControllerStatus.Stopped)
                            sc.Start();
                        break;
                    case ServiceOpear.Pause:
                        if (sc.Status != ServiceControllerStatus.Paused)
                            sc.Pause();
                        break;
                    case ServiceOpear.Continue:
                        if (sc.Status == ServiceControllerStatus.Paused)
                            sc.Continue();
                        break;
                    default:
                        if (sc.Status == ServiceControllerStatus.Running)
                        {
                            sc.Stop();
                            KillProcess(sServiceName);
                        }
                        break;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 设置服务启动模式
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="sServiceName"></param>
        /// <returns></returns>
        public static bool SetServiceMode(ServiceMode mode, string sServiceName)
        {
            try
            {
                switch (mode)
                {
                    case ServiceMode.Auto:
                        if (Execute("sc config " + sServiceName + " start= auto", 1000).IndexOf("成功") > 0)
                            SetService(ServiceOpear.Run, sServiceName);
                        else
                            return false;
                        break;
                    case ServiceMode.Disabled:
                        if (Execute("sc config " + sServiceName + " start= disabled", 1000).IndexOf("成功") > 0)
                            SetService(ServiceOpear.Stop, sServiceName);
                        else
                            return false;
                        break;
                    default:
                        if (Execute("sc config " + sServiceName + " start= demand", 1000).IndexOf("成功") <= 0) return false;
                        break;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion


        #region 检查方法

        /// <summary>
        /// 检查主账套设置
        /// </summary>
        /// <returns></returns>
        public static bool CheckMain()
        {
            if (!bIsLinked) return true;

            try
            {
                if (!DbHelperSQL.Exists("SELECT 1 FROM UFSystem..sysobjects WHERE name = 'HY_DZ_K7_MAINACC' AND type='U'")) return true;
            }
            catch
            { return true; }

            try
            {
                return DbHelperSQL.Exists("SELECT 1 FROM UFSystem..HY_DZ_K7_MAINACC WHERE (caddress='" + Common.dicRegist["servername"] + "' OR caddress LIKE '" + Common.dicRegist["servername"] + "/%') AND cdatabase='" + Common.dicRegist["dbname"] + "' ");
            }
            catch
            { return false; }
        }

        /// <summary>
        /// 检查插件安装
        /// </summary>
        /// <returns></returns>
        public static bool CheckInstall()
        {
            if (!bIsLinked) return true; 
            try
            {
                object obj;
                if (!DbHelperSQL.Exists("SELECT 1 FROM UFSystem..sysobjects  WHERE  name = 'HY_DZ_K7_MAINACC' AND type = 'U' ")) return false;
                obj = DbHelperSQL.GetSingle("SELECT COUNT(1) FROM UFSystem..HY_DZ_K7_MAINACC ");
                if (obj == null || obj == DBNull.Value) return false;
                if (System.Convert.ToInt32(obj) <= 0) return false; 
                return true;
            }
            catch { return true; }
        }

        /// <summary>
        /// 验证U8加密
        /// </summary>
        /// <returns></returns>
        public static bool CheckU8Encrypt()
        {
            if (!bIsLinked) return true;

            try
            {
                //DataSet dsAcc;
                //dsAcc = DbHelperSQL.Query("SELECT * FROM HY_DZ_K7_REGIST WHERE caddress='" + dicRegist["servername"] + "' AND caccname='" + dicRegist["dbname"] + "' ");
                //if (dsAcc == null || dsAcc.Tables[0].Rows.Count <= 0) return true;
                //DataRow drAcc = dsAcc.Tables[0].Rows[0];

                //string Caddress = drAcc["Caddress"].ToString();
                //string Cdatabase = drAcc["Cdatabase"].ToString();
                //string Cdbpwd = drAcc["Cdbpwd"].ToString();
                //string Cacc_id = drAcc["Cacc_id"].ToString();
                //string Caccname = drAcc["Caccname"].ToString();
                //string Datasource = drAcc["Datasource"].ToString();
                //string Ibeginyear = drAcc["Ibeginyear"].ToString();
                //string Cuser_id = drAcc["Cuser_id"].ToString();
                //string Cpassword = drAcc["Cpassword"].ToString();
                //string Csub_id = "DP";
                //string Cserial = "";

                //string Cyear;
                //string Cdate;
                //object oYear = DbHelperSQL.GetSingle("SELECT iYear FROM UFSystem..UA_Account WHERE iYear<=YEAR(GETDATE()) AND iMonth<=MONTH(GETDATE()) AND cAcc_Id='" + AccInfo.Cacc_id + "' ");
                //if (oYear == null || oYear == DBNull.Value) return true;
                //int iStartYear = int.Parse(oYear.ToString());
                //int iYear = int.Parse(DbHelperSQL.GetSingle("SELECT YEAR(GETDATE()) ").ToString());
                //int iMonth = int.Parse(DbHelperSQL.GetSingle("SELECT MONTH(GETDATE()) ").ToString());
                //Cyear = iYear.ToString();
                //Cdate = iYear.ToString() + "-" + iMonth.ToString("00") + "-01";
                //U8Login.clsLogin Login = new U8Login.clsLogin();
                //while (iYear >= iStartYear && !Login.Login(ref Csub_id, ref Cacc_id, ref Cyear, ref Cuser_id, ref Cpassword, ref Cdate, ref Caddress, ref Cserial))
                //{
                //    if (iMonth >= 2)
                //    { iMonth--; }
                //    else
                //    {
                //        iMonth = 12;
                //        iYear--;
                //    }
                //    Cyear = iYear.ToString();
                //    Cdate = iYear.ToString() + "-" + iMonth.ToString("00") + "-01";
                //}
                //if (iYear < iStartYear) return true;

                //return Login.TaskExec("K7", 10, 0);

                return true;
            }
            catch { return true; }
        }

        /// <summary>
        /// 验证本地是否服务器
        /// </summary>
        /// <returns></returns>
        public static bool CheckLocalMain()
        {
            if (!ExistSqlServerService()) return false;

            //SqlConnection sqlCon = new SqlConnection("Data Source=.;Initial Catalog=Master;Integrated Security=SSPI;");
            //using (sqlCon)
            //{
            //    if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
            //    object oScalar = null;
            //    SqlCommand sqlCmd = sqlCon.CreateCommand();
            //    sqlCmd.CommandType = CommandType.Text;
            //    sqlCmd.CommandText = "SELECT name FROM master..SYSDATABASES WHERE name='UFSYSTEM' ";
            //    oScalar = sqlCmd.ExecuteScalar();
            //    if (oScalar == null || oScalar == DBNull.Value) return false;
            //    sqlCmd.CommandText = "SELECT connstr FROM UFSystem..HY_DZ_K7_MAINACC WHERE caddress=CONVERT(NVARCHAR(200),SERVERPROPERTY('ServerName')) ";
            //    oScalar = sqlCmd.ExecuteScalar();
            //    if (oScalar == null || oScalar == DBNull.Value) return false;
            //}

            if (!DbHelperSQL.Exists("SELECT 1 FROM UFSystem..sysobjects WHERE name = 'HY_DZ_K7_MAINACC' AND type='U'")) return true;

            if (DbHelperSQL.Exists("SELECT 1 FROM UFSystem..HY_DZ_K7_MAINACC WHERE (caddress='" + sHostName + "' OR caddress LIKE '" + sHostName + "/%') ")) return true;

            return false;
        }

        /// <summary>
        /// 验证有效性
        /// </summary>
        public static bool Verification()
        {
            bIsValid = true;

            if (!GetRegist())
            {
                MessageShow("获取界面初始化数据失败");
                return false;
            }

            if (dicRegist == null || !bIsLinked) return true;

            if (CheckU8Encrypt()) return true;

            if (!CheckDate())
            {
                SetServiceMode(ServiceMode.Disabled, mainServiceName);
                SetServiceMode(ServiceMode.Disabled, checkServiceName);
                MessageShow("请购买用友U8 " + Common.GetU8Version() +  U8.Interface.Bus.SysInfo.productName + "模块");
                bIsValid = false;
                return false;
            }

            return true;
        }

        /// <summary>
        /// 验证有效性
        /// </summary>
        public static bool Verification_lxz()
        {
            bIsValid = true;

            if (!GetConfig())
            {
                MessageShow("获取界面初始化数据失败");
                return false;
            }

            if (dicRegist == null || !bIsLinked) return true;

            if (CheckU8Encrypt()) return true;

            if (!CheckDate())
            {
                SetServiceMode(ServiceMode.Disabled, mainServiceName);
                SetServiceMode(ServiceMode.Disabled, checkServiceName);
                MessageShow("请购买用友U8 " + Common.GetU8Version() + U8.Interface.Bus.SysInfo.productName + "模块");
                bIsValid = false;
                return false;
            }

            return true;
        }



        /// <summary>
        /// 验证时间有效性
        /// </summary>
        /// <returns></returns>
        public static bool CheckDate()
        {
            if (!bIsLinked) return true;

            try
            {
                //object obj = DbHelperSQL.GetSingle("SELECT DATEDIFF(M,MIN(starttime),MAX(starttime)) FROM HY_DZ_K7_SYNERGISMLOG ");
                //if (obj == null || obj == DBNull.Value) return true;
                //if (string.IsNullOrEmpty(obj.ToString().Trim())) return true;

                //if (int.Parse(obj.ToString()) >= 2)
                //    return false;

                return true;
            }
            catch { return true; }
        }

        /// <summary>
        /// 是否是IP地址
        /// </summary>
        /// <param name="strAddress"></param>
        /// <returns></returns>
        public static bool IsIPAddress(string strAddress)
        {
            int len; int index1; int index2; int index3;
            string strip1; string strip2; string strip3; string strip4;

            len = strAddress.Length;
            if (string.IsNullOrEmpty(strAddress)) return false;
            else if (len <= 6) return false;
            else if (len >= 16) return false;
            else if (strAddress.Split('.').Length != 4) return false;
            else
            {
                index1 = strAddress.IndexOf('.');
                if (index1 - 0 <= 1 || index1 == len) return false;

                index2 = strAddress.IndexOf('.', index1 + 1);
                if (index2 - index1 <= 1 || index2 == len) return false;

                index3 = strAddress.LastIndexOf('.');
                if (index3 - index2 <= 1 || index3 == len) return false;

                strip1 = strAddress.Substring(0, index1);
                if (string.IsNullOrEmpty(strip1.Trim()) || !isNumberic(strip1)) return false;

                strip2 = strAddress.Substring(index1 + 1, index2 - index1 - 1);
                if (string.IsNullOrEmpty(strip2.Trim()) || !isNumberic(strip2)) return false;

                strip3 = strAddress.Substring(index2 + 1, index3 - index2 - 1);
                if (string.IsNullOrEmpty(strip3.Trim()) || !isNumberic(strip3)) return false;

                strip4 = strAddress.Substring(index3 + 1, len - index3 - 1);
                if (string.IsNullOrEmpty(strip4.Trim()) || !isNumberic(strip4)) return false;

            }
            return true;
        }

        /// <summary>
        /// 是否是数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool isNumberic(string str)
        {
            System.Text.RegularExpressions.Regex rex =
            new System.Text.RegularExpressions.Regex(@"^\d+$");

            if (rex.IsMatch(str)) return true;

            return false;
        }

        /// <summary>
        /// 检查是否安装SQL
        /// </summary>
        /// <returns></returns>
        public static bool ExistSqlServerService()
        {
            try
            {
                ServiceController[] Services = ServiceController.GetServices();
                foreach (ServiceController sc in Services)
                {
                    if (sc.ServiceName.ToUpper() == "MSSQLSERVER") return true;
                }
                return false;
            }
            catch { return false; }
        }

        /// <summary>
        /// 判断是否安装Excel
        /// </summary>
        public static bool isExcelInstalled()
        {
            Type type = Type.GetTypeFromProgID("Excel.Application");
            return type != null;
        }
        #endregion

        #region 其他方法

        /// <summary>
        /// 弹出指定文本的消息框
        /// </summary>
        /// <param name="str">弹出文本</param>
        public static void MessageShow(string str)
        {
            MessageBox.Show("             " + str + "             ");
        }

        /// <summary>
        /// 弹出指定文本的选择框
        /// </summary>
        /// <param name="str">弹出文本</param>
        /// <param name="caption">消息框标题</param>
        public static DialogResult MessageShow(string str, string caption)
        {
            return MessageBox.Show("   " + str + "                  ", caption, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
        }

        /// <summary>  
        /// 执行DOS命令，返回DOS命令的输出  
        /// </summary>  
        /// <param name="dosCommand">dos命令</param>  
        /// <param name="milliseconds">等待命令执行的时间（单位：毫秒），  
        /// 如果设定为0，则无限等待</param>  
        /// <returns>返回DOS命令的输出</returns>  
        public static string Execute(string dosCommand, int milliseconds)
        {
            string output = ""; //输出字符串  
            if (dosCommand != null && !dosCommand.Equals(""))
            {
                Process process = new Process();//创建进程对象  
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "cmd.exe";//设定需要执行的命令  
                startInfo.Arguments = "/C " + dosCommand;//“/C”表示执行完命令后马上退出  
                startInfo.UseShellExecute = false;//不使用系统外壳程序启动  
                startInfo.RedirectStandardInput = false;//不重定向输入  
                startInfo.RedirectStandardOutput = true; //重定向输出  
                startInfo.CreateNoWindow = true;//不创建窗口  
                process.StartInfo = startInfo;
                try
                {
                    if (process.Start())//开始进程  
                    {
                        if (milliseconds == 0)
                        {
                            process.WaitForExit();//这里无限等待进程结束  
                        }
                        else
                        {
                            process.WaitForExit(milliseconds); //等待进程结束，等待时间为指定的毫秒  
                        }
                        output = process.StandardOutput.ReadToEnd();//读取进程的输出  
                    }
                }
                catch
                {
                }
                finally
                {
                    if (process != null)
                        process.Close();
                }
            }
            return output;
        }

        /// <summary>
        /// 结束进程
        /// </summary>
        /// <param name="ProName">进程名</param>
        /// <returns></returns>
        public static bool KillProcess(string ProName)
        {
            Process[] arrPros;
            try
            {
                arrPros = Process.GetProcessesByName(ProName);
                foreach (Process p in arrPros)
                {
                    if (p != null && p.Modules != null && p.Modules.Count > 0)
                    {
                        try { p.Kill(); }
                        catch { }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            { }
        }

        /// <summary>
        /// 获取U8版本
        /// </summary>
        /// <returns></returns>
        public static string GetU8Version()
        {
            if (!bIsLinked) return string.Empty;

            string str = "SELECT ISNULL(iVer,'') FROM UFSystem..UA_Version ";
            object oVersion = DbHelperSQL.GetSingle(str);
            if (oVersion == null || oVersion == DBNull.Value) return string.Empty;
            if (oVersion.ToString().IndexOf("111") >= 0) return "V11.1";
            else return "V11.0";
        }

        /// <summary>
        /// 保存DataGridView到Excel
        /// (数据流写入方式)
        /// </summary>
        public static bool SaveToExcel(SaveFileDialog saveFileDialog, DataGridView dgvData)
        {
            #region 数据参数
            Stream myStream;
            StreamWriter sw;
            string columnTitle = "";
            myStream = saveFileDialog.OpenFile();
            sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
            #endregion

            try
            {
                #region 写入数据
                #region 写入标题
                foreach (DataGridViewColumn col in dgvData.Columns)
                {
                    if (col.Visible)
                    {
                        columnTitle += "\t";
                        columnTitle += col.HeaderText;
                    }
                }
                sw.WriteLine(columnTitle);
                #endregion

                #region 写入内容
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    string columnValue = "";
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Visible)
                        {
                            columnValue += "\t";
                            if (cell.Value == null || string.IsNullOrEmpty(cell.Value.ToString()))
                            {
                                columnValue += "";
                            }
                            else
                            {
                                columnValue += "'" + cell.Value.ToString().Trim().Replace("\r", " ");
                            }
                        }
                    }
                    sw.WriteLine(columnValue);
                }
                #endregion
                #endregion

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                sw.Close();
                myStream.Close();
            }
        }
        /// <summary>
        /// 保存DataGridView到Excel
        /// (调用Microsoft.Office.Interop.Excel方式)
        /// </summary>
        public static bool SaveToExcel(string strFileName, DataGridView dgvData, string strTitle)
        {
            try
            {

                #region Excel参数
                strTitle = string.IsNullOrEmpty(strTitle) ? "协同日志记录" : strTitle;
                System.Reflection.Missing miss = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.ApplicationClass();
                Microsoft.Office.Interop.Excel.Workbooks books = (Microsoft.Office.Interop.Excel.Workbooks)excel.Workbooks;
                Microsoft.Office.Interop.Excel.Workbook book = (Microsoft.Office.Interop.Excel.Workbook)(books.Add(miss));
                Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)book.ActiveSheet;
                Microsoft.Office.Interop.Excel.Range range;     // 选择单元格区域
                sheet.Name = strTitle;
                #endregion

                #region 写入数据
                #region 写入标题
                int colIndex = 0;
                foreach (DataGridViewColumn col in dgvData.Columns)
                {
                    if (col.Visible)
                    {
                        colIndex++;
                        excel.Cells[2, colIndex] = col.HeaderText;
                    }
                }
                #endregion

                #region 写入内容
                int celIndex;
                for (int i = 0; i < dgvData.Rows.Count; i++)
                {
                    celIndex = 0;
                    foreach (DataGridViewCell cell in dgvData.Rows[i].Cells)
                    {
                        if (cell.Visible)
                        {
                            celIndex++;
                            if (cell.Value == null || string.IsNullOrEmpty(cell.Value.ToString()))
                            {
                                excel.Cells[i + 3, celIndex] = "";
                            }
                            else
                            {
                                excel.Cells[i + 3, celIndex] = cell.ValueType.Name == "String" ? "'" + cell.Value.ToString().Trim().Replace("\r", " ") : cell.Value.ToString().Trim().Replace("\r", " ");   // 文本类型前缀"'"
                            }
                        }
                    }
                }
                #endregion
                #endregion

                #region 设置格式

                #region 表头格式
                char cSite;
                cSite = (colIndex < 25) ? (char)(64 + colIndex) : 'Z';
                range = sheet.get_Range("A1", cSite + "1");                  // 获取多个单元格  
                range.Merge(System.Reflection.Missing.Value);               // 合并单元格  
                range.Columns.AutoFit();        // 设置列宽为自动适应  
                range.RowHeight = 30;           // 设置行高
                range.Font.Bold = true;         // 加粗字体  
                range.Font.Size = 20;           // 设置字体大小   
                range.Value2 = strTitle;  // 设置表头
                range = sheet.get_Range("A1", cSite + "2");
                range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;  // 设置单元格水平居中
                #endregion

                #region 表体格式
                int iSite = dgvData.Rows.Count + 3;
                celIndex = 0;
                foreach (DataGridViewCell cell in dgvData.Rows[0].Cells)
                {
                    if (cell.Visible)
                    {
                        celIndex++;
                        cSite = (char)(64 + celIndex);
                        range = sheet.get_Range(cSite + "3", cSite + iSite.ToString());
                        range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft;    // 设置单元格左对齐
                        range.ColumnWidth = cell.Size.Width * 0.15; // 设置列宽
                        switch (cell.ValueType.Name)    // 设置单元格数据格式
                        {
                            case "String":
                                range.NumberFormat = "@";
                                break;
                            case "DateTime":
                                range.NumberFormat = "yyyy-mm-dd";
                                break;
                            case "Nullable`1":
                                range.NumberFormat = "yyyy-mm-dd";
                                break;
                            case "Decimal":
                                range.NumberFormat = "#,##0.00";
                                break;
                            case "Double":
                                range.NumberFormat = "#,##0.00";
                                break;
                            default:
                                range.NumberFormat = "@";
                                break;
                        }
                    }
                }
                #endregion
                #endregion

                #region 保存文件
                sheet.SaveAs(strFileName, miss, miss, miss, miss, miss, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, miss, miss, miss);
                book.Close(false, miss, miss);
                books.Close();
                excel.Quit();
                //System.Runtime.InteropServices.Marshal.ReleaseComObject();   
                System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(book);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(books);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                #endregion

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                GC.Collect();
            }
        }

        #endregion

    }
}
