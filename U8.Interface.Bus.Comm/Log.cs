using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Net;
using System.Management;


namespace U8.Interface.Bus
{
    public class Log
    { 
         
        /// <summary>
        /// 日志错误
        /// </summary>
        /// <param name="Err"></param>
        public static void WriteWinLog(string Err)
        { 
            EventLog.WriteEntry( SysInfo.productName + "LOG", Err, EventLogEntryType.Error, 88, 88);
        }

        /// <summary>
        /// DeBug 日志
        /// </summary>
        /// <param name="msg"></param>
        public static void WriteWinDebugLog(string msg)
        {
            EventLog.WriteEntry(SysInfo.productName + "DeBug", msg, EventLogEntryType.Information, 88, 88);
        }

        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="Path">文件路径</param>
        /// <param name="Strings">文件内容</param>
        public static void WriteFile(string Path, string Strings)
        {

            string Dir = Path.Remove(Path.LastIndexOf("\\"), Path.Length - Path.LastIndexOf("\\"));
            if (!System.IO.Directory.Exists(Dir))
            {
                System.IO.Directory.CreateDirectory(Dir);
            }

            if (!System.IO.File.Exists(Path))
            {
                System.IO.FileStream f = System.IO.File.Create(Path);
                f.Close();
                f.Dispose();
            }
            System.IO.StreamWriter f2 = new System.IO.StreamWriter(Path, true, System.Text.Encoding.UTF8);
            f2.WriteLine(Strings);
            f2.Close();
            f2.Dispose();

        }


        /// <summary>
        /// 写文件按照文件名
        /// </summary>
        /// <param name="Path">文件路径</param>
        /// <param name="Strings">文件内容</param>
        public static void WriteFileWithName(string sName, string Strings)
        {

            string Dir = AppDomain.CurrentDomain.BaseDirectory;
            if (!System.IO.Directory.Exists(Dir))
            {
                return;
            }
            if (!System.IO.File.Exists(System.IO.Path.Combine(Dir, sName)))
            {
                return;
            }
            System.IO.StreamWriter f2 = new System.IO.StreamWriter(System.IO.Path.Combine(Dir, sName), true, System.Text.Encoding.UTF8);
            f2.WriteLine(Strings);
            f2.Close();
            f2.Dispose();

        }

        /// <summary>
        /// 写文件按照文件名
        /// </summary>
        /// <param name="Path">文件路径</param>
        /// <param name="ds">DataSet</param> 
        public static void WriteFileWithNameFromDs(string sName, DataSet ds)
        {

            string Dir = AppDomain.CurrentDomain.BaseDirectory;
            if (!System.IO.Directory.Exists(Dir))
            {
                return;
            }
            if (!System.IO.File.Exists(System.IO.Path.Combine(Dir, sName)))
            {
                return;
            }
            ds.WriteXml(System.IO.Path.Combine(Dir, sName));  
        }

         

    }
}
