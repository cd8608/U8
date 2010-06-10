using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace U8.Interface.Bus
{
    public class SysInfo
    {
        public static string productName = "MES接口";
        public static string subId = "DP";

        public static string dateFormat = "yyyy-MM-dd";
        public static string datetimeFormat = "yyyy-MM-dd hh:mm:ss";


        /// <summary>
        /// 配置文件路径
        /// </summary>
        public static string xmlFileName = "MesErpBus.config";


        /// <summary>
        /// 注册表路径
        /// </summary>
        public static readonly string u8path = @"Software\U8MesInterface";


        /// <summary>
        /// 是否启用多线程执行任务
        /// </summary>
        public static bool multiThread
        {
            get
            {
                try
                {
                    string _multiThread = Config.ConfigUtility.MultiThread;
                    if (string.IsNullOrEmpty(_multiThread))
                    {
                        return false;
                    }
                    else if (_multiThread.ToLower().Equals("1") || _multiThread.ToLower().Equals("true"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch
                {
                    return false;
                }
            }
        }




    }
}
