using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace U8.Interface.Bus.Config
{
    public class ConfigUtility
    { 
        /// <summary>
        /// 配置文件
        /// </summary>
        private static System.Xml.XmlDocument xml;
        public static System.Xml.XmlDocument ConfigXml
        {
            get
            {
                if (null == xml)
                {
                    string dllDir = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    dllDir = dllDir.Substring(0, dllDir.LastIndexOf('\\'));//删除文件名 
                    xml = new System.Xml.XmlDocument();
                    xml.Load(dllDir + @"\..\" + U8.Interface.Bus.SysInfo.xmlFileName);
                }
                return xml;
            }

        }

        public static bool SaveXml()
        {
            try
            {
                string dllDir = System.Reflection.Assembly.GetExecutingAssembly().Location;
                dllDir = dllDir.Substring(0, dllDir.LastIndexOf('\\'));//删除文件名 
                XmlTextWriter writer = new XmlTextWriter(dllDir + @"\..\" + U8.Interface.Bus.SysInfo.xmlFileName, Encoding.Default);
                writer.Formatting = Formatting.Indented;
                ConfigXml.Save(writer);
                writer.Close();
                return true;
            }
            catch(Exception ee)
            {
                return false;
            }
        }

        #region U8登录配置
        private static string u8appsrv;
        public static string U8AppSrv
        {
            get
            {
                if (string.IsNullOrEmpty(u8appsrv))
                {
                    u8appsrv = GetU8AppSrv();
                }
                return u8appsrv;
            }
            set
            {
                SetU8AppSrv(value);
            }
        } 
        private static string GetU8AppSrv()
        {
            string res = GetAttrib("/configuration/ApiService", "u8server");
            return res;
        }
        private static void SetU8AppSrv(string value)
        {
            string res = SetAttrib("/configuration/ApiService", "u8server", value);
            SaveXml();
        }

 
        private static string u8appuser;
        public static string U8AppUser
        {
            get
            {
                if (string.IsNullOrEmpty(u8appuser))
                {
                    u8appuser = GetU8AppUser();
                }
                return u8appuser;
            }
            set
            {
                SetU8AppUser(value);
            }
        }
        private static string GetU8AppUser()
        {
            string res = GetAttrib("/configuration/ApiService", "u8user");
            return res;
        }
        private static void SetU8AppUser(string value)
        {
            string res = SetAttrib("/configuration/ApiService", "u8user", value);
            SaveXml();
        }

        private static string u8apppwd;
        public static string U8AppPwd
        {
            get
            {
                if (string.IsNullOrEmpty(u8apppwd))
                {
                    u8apppwd = GetU8AppPwd();
                }
                return u8apppwd;
            }
            set
            {
                SetU8AppPwd(value);
            }
        }
        private static string GetU8AppPwd()
        {
            string res = GetAttrib("/configuration/ApiService", "u8pwd");
            return res;
        }
        private static void SetU8AppPwd(string value)
        {
            string res = SetAttrib("/configuration/ApiService", "u8pwd", value);
            SaveXml();
        }

        private static string u8appacc;
        public static string U8AppAcc
        {
            get
            {
                if (string.IsNullOrEmpty(u8appacc))
                {
                    u8appacc = GetU8AppAcc();
                }
                return u8appacc;
            }
            set
            {
                SetU8AppAcc(value);
            }
        }
        private static string GetU8AppAcc()
        {
            string res = GetAttrib("/configuration/ApiService", "u8acc");
            return res;
        }
        private static void SetU8AppAcc(string value)
        {
            string res = SetAttrib("/configuration/ApiService", "u8acc", value);
            SaveXml();
        }
         

         

        #endregion

        #region 数据库登录配置
        private static string databasesrv;
        public static string DataBaseSrv
        {
            get
            {
                if (string.IsNullOrEmpty(databasesrv))
                {
                    databasesrv = GetDataBaseSrv();
                }
                return databasesrv; 
            }
            set
            {
                SetDataBaseSrv(value);
            }
        }

        private static string databasecatalog;
        public static string DataBaseCatalog
        {
            get
            {
                if (string.IsNullOrEmpty(databasecatalog))
                {
                    databasecatalog = GetDataBaseCatalog();
                }
                return databasecatalog;
            }
            set
            {
                SetDataBaseCatalog(value);
            }
        }


        private static string databaseuser = "sa";
        public static string DataBaseUser
        {
            get
            {
                if (string.IsNullOrEmpty(databaseuser))
                {
                    databaseuser = GetDataBaseUser();
                }
                return databaseuser;
            }
            set
            {
                SetDataBaseUser(value);
            }
        }
        private static string databasepwd;
        public static string DataBasePwd
        {
            get
            {
                if (string.IsNullOrEmpty(databasepwd))
                {
                    databasepwd = GetDataBasePwd();
                }
                return databasepwd;
            }
            set
            {
                SetDataBasePwd(value);
            }

        }

 
        private static string GetDataBaseSrv()
        {
            string res = GetAttrib("/configuration/DataService", "databasesrv"); 
            return res;
        }
        private static string GetDataBaseCatalog()
        {
            string res = GetAttrib("/configuration/DataService", "dbname");
            return res;
        }
        private static string GetDataBaseUser()
        {
            string res = GetAttrib("/configuration/DataService", "user");
            return res;
        }
        private static string GetDataBasePwd()
        {
            string res = GetAttrib("/configuration/DataService", "pwd");
            return res;
        }
        private static void SetDataBaseSrv(string value)
        {
            string res = SetAttrib("/configuration/DataService", "databasesrv",value);
            SaveXml(); 
        }
        private static void SetDataBaseCatalog(string value)
        {
            string res = SetAttrib("/configuration/DataService", "dbname", value);
            SaveXml();
        }
        private static void SetDataBaseUser(string value)
        {
            string res = SetAttrib("/configuration/DataService", "user",value);
            SaveXml(); 
        }
        private static void SetDataBasePwd(string pwd)
        {
            SetAttrib("/configuration/DataService", "pwd",pwd);
            SaveXml(); 
        }

        #endregion


        #region 事件配置

        #region 属性
        /// <summary>
        /// 事件工厂BIZ DLL名称
        /// </summary>
        private static string eventbizdllname;
        public static string EventBizDllName
        {
            get
            {
                if (string.IsNullOrEmpty(eventbizdllname))
                {
                    eventbizdllname = GetEventBiz()[0];
                }
                return eventbizdllname;
            }
        }

        /// <summary>
        /// 事件工厂BIZ 命名空间
        /// </summary>
        private static string eventbiznamespace;
        public static string EventBizNamespace
        {
            get
            {
                if (string.IsNullOrEmpty(eventbiznamespace))
                {
                    eventbiznamespace = GetEventBiz()[1];
                }
                return eventbizdllname;
            }
        }


        /// <summary>
        /// 只保留最后一次操作
        /// </summary>
        private static string lognocase;
        public static bool LogNoCase
        {
            get
            {
                if (string.IsNullOrEmpty(lognocase))
                {
                    lognocase = GetLognocase();
                }
                if (lognocase.ToLower().Equals("1") || lognocase.ToLower().Equals("true"))
                {
                    return true;
                }
                return false; 
            }
        }

        /// <summary>
        /// 保留操作
        /// 1保留操作
        /// 0保留数据
        /// </summary>
        private static string logoper;
        public static bool LogOper
        {
            get
            {
                if (string.IsNullOrEmpty(logoper))
                {
                    logoper = GetLogType();
                }
                if (logoper.ToLower().Equals("1") || logoper.ToLower().Equals("true"))
                {
                    return true;
                }
                return false;
            }
        }



        /// <summary>
        /// OP工厂BIZ DLL名称
        /// </summary>
        private static string servopdllname;
        public static string ServOpDllname
        {
            get
            {
                if (string.IsNullOrEmpty(servopdllname))
                {
                    servopdllname = GetApiOpBiz()[0];
                }
                return servopdllname;
            }
        }

        /// <summary>
        /// OP工厂BIZ 命名空间
        /// </summary>
        private static string servopnamespace;
        public static string ServOpNamespace
        {
            get
            {
                if (string.IsNullOrEmpty(servopnamespace))
                {
                    servopnamespace = GetApiOpBiz()[1];
                }
                return servopnamespace;
            }
        }

        #endregion 属性


        #region 方法
        /// <summary>
        /// 获取事件dll及命名空间
        /// </summary>
        /// <returns></returns>
        private static string[] GetEventBiz()
        {
            string[] res = new string[2];
            res[0] = GetAttrib("/configuration/Event/Biz", "dllname");
            res[1] = GetAttrib("/configuration/Event/Biz", "namespace");
            return res;
        }

        /// <summary>
        /// 只保留最终结果
        /// </summary>
        /// <returns></returns>
        private static string GetLognocase()
        {
            string res = GetAttrib("/configuration/Event", "lognocase");
            return res;
        }


        /// <summary>
        /// 中间表记录类型
        /// 记录操作  1
        /// 记录档案  0
        /// </summary>
        /// <returns></returns>
        private static string GetLogType()
        {
            string res = GetAttrib("/configuration/Event", "logtype");
            return res;
        }



        /// <summary>
        /// 获取生单op dll及命名空间
        /// </summary>
        /// <returns></returns>
        private static string[] GetApiOpBiz()
        {
            string[] res = new string[2];
            res[0] = GetAttrib("/configuration/ApiService/Op", "dllname");
            res[1] = GetAttrib("/configuration/ApiService/Op", "namespace");
            return res;
        } 
        #endregion 方法
 
        #endregion

        #region 服务设置


        /// <summary>
        /// 是否用多线程执行任务
        /// </summary>
        private static string multiThread;
        public static string MultiThread
        {
            get
            {
                if (string.IsNullOrEmpty(multiThread))
                {
                    multiThread = GetMultiThread();
                }
                return multiThread;
            } 
        }
        


        /// <summary>
        /// 任务轮循间隔时间
        /// </summary>
        private static int tasksleeptime=-1;
        public static int TaskSleepTime
        {
            get
            {
                if (tasksleeptime ==-1)
                {
                    tasksleeptime = GetTaskSleepTime();
                }
                return tasksleeptime;
            }
        }


        /// <summary>
        /// 任务轮循间隔时间
        /// </summary>
        private static int checktasksleeptime;
        public static int CheckTaskSleepTime
        {
            get
            {
                if (checktasksleeptime == -1)
                {
                    checktasksleeptime = GetCheckTaskSleepTime();
                }
                return checktasksleeptime;
            }
        }


        private static string GetMultiThread()
        {
            string res = GetAttrib("/configuration/ApiService/Task", "multithread");
            return res;
        }


        /// <summary>
        /// 任务轮循间隔时间
        /// </summary>
        /// <returns></returns>
        private static int GetTaskSleepTime()
        {
            return Convert.ToInt16(GetAttrib("/configuration/ApiService/Task", "sleeptime"));
        }


        /// <summary>
        /// 任务轮循间隔时间
        /// </summary>
        /// <returns></returns>
        private static int GetCheckTaskSleepTime()
        {
            return Convert.ToInt16(GetAttrib("/configuration/ApiService/CheckTask", "sleeptime"));
        }

#endregion

        #region XML操作
        /// <summary>
        /// 获取结点值
        /// </summary>
        /// <returns></returns>
        public static string  GetNodeValue(string node)
        {
            System.Xml.XmlNode _node = ConfigXml.SelectSingleNode(node);
           
            string res = "";
            if (_node == null)
            { 
            
            }
            else
            {
                res = _node.InnerText.ToString();
            }
            return res;
        }

        /// <summary>
        /// 获取结点值
        /// </summary>
        /// <returns></returns>
        public static string SetNodeValue(string node,string value)
        {
            System.Xml.XmlNode _node = ConfigXml.SelectSingleNode(node);

            string res = "";
            if (_node == null)
            {

            }
            else
            {
                _node.InnerText = value;
            }
            return res;
        }


        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <returns></returns>
        public static string GetAttrib(string node,string attribname)
        { 
            string res = "";
            try
            {
                System.Xml.XmlNode _node = ConfigXml.SelectSingleNode(node);
                res = _node.Attributes[attribname].InnerText;
            }
            catch { 
            }
            return res;
        }

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <returns></returns>
        public static string SetAttrib(string node, string attribname,string value)
        {
            string res = "";
            try
            {
                System.Xml.XmlNode _node = ConfigXml.SelectSingleNode(node);
                _node.Attributes[attribname].InnerText = value;
            }
            catch
            {
            }
            return res;
        }

       

        #endregion

    }
}
