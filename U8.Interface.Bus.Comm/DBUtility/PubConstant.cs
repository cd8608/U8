using System;
using System.Configuration;


namespace U8.Interface.Bus.DBUtility
{
    public class PubConstant
    {        
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    //string servname = Comm.RegistryKeyHelp.getValueRegEdit(SysInfo.u8path, "servername");
                    string servname = U8.Interface.Bus.Config.ConfigUtility.DataBaseSrv;

                    if (string.IsNullOrEmpty(servname))
                    {
                        throw new Exception("未设置主服务器信息,请在同步服务,服务器设置中设置!");

                    }
                    //string username = Comm.RegistryKeyHelp.getValueRegEdit(SysInfo.u8path, "username");
                    //string pwd = Comm.RegistryKeyHelp.getValueRegEdit(SysInfo.u8path, "pwd");
                    //string dbname = Comm.RegistryKeyHelp.getValueRegEdit(SysInfo.u8path, "dbname");
                    string username = U8.Interface.Bus.Config.ConfigUtility.DataBaseUser;
                    string pwd = U8.Interface.Bus.Config.ConfigUtility.DataBasePwd;
                    string dbname = U8.Interface.Bus.Config.ConfigUtility.DataBaseCatalog;

                    pwd = Comm.DESEncrypt.Decrypt(pwd);
                    _connectionString = string.Format("Data Source={0};Initial Catalog={3};Persist Security Info=True;User ID={1};Password={2};Current Language=Simplified Chinese", servname, username, pwd, dbname);

                }
                return _connectionString;
            }

           
        }

        private static string _connectionString;

        /// <summary>
        /// 得到web.config里配置项的数据库连接字符串。
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string configName)
        {
            string connectionString = ConfigurationManager.AppSettings[configName];
            string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
            if (ConStringEncrypt == "true")
            {
                connectionString = Comm.DESEncrypt.Decrypt(connectionString);
            }
            return connectionString;
        }


    }
}
