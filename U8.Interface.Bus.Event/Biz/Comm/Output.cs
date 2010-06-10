using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace U8.Interface.Bus.Event.SyncAdapter
{
    static class Output
    {

        #region 输出调试信息
        [DllImport("kernel32.dll")]
        public static extern void OutputDebugString(string lpOutputString);

        /// <summary>
        /// 将调试信息输出至调试器 
        /// </summary>
        /// <param name="message"></param>
        public static void gDebugView(string message)
        {
            OutputDebugString(message);
        }

        #endregion


        #region 写日志

        public static void mWriteLog(
            string eventId,
            MSXML2.IXMLDOMDocument2 document1,
            MSXML2.IXMLDOMDocument2 document2,
            ADODB.Connection connection,
            U8Login.clsLogin login)
        {
            string logText = "";

            logText = "  EventId##" + eventId + "\r\n";

            if (login != null)
            {

                logText = logText
                    + "  AccId|AccName##" + login.get_cAcc_Id() + "|" + login.cAccName + "\r\n"
                    + "  SubId##" + login.cSub_Id + "\r\n"
                    + "  UserId##" + login.cUserId + "\r\n"
                    + "  LanguageRegion##" + login.LanguageRegion + "\r\n"
                    + "  UfDbName##" + login.UfDbName + "\r\n";
            }

            if (connection != null)
            {
                logText = logText
                    + "  ConnectionState##" + connection.State + "\r\n"
                    + "  ConnectionString##" + connection.ConnectionString + "\r\n";
            }

            if (document1 != null)
            {
                logText = logText
                    + "  Document1##" + document1.xml + "\r\n";
            }

            if (document2 != null)
            {
                logText = logText
                    + "  Document2##" + document2.xml + "\r\n";
            }

            //Log.WriteLog("C:\\DotNetUAPEventSyncAdapterLog.txt", logText);
        }


        public static void mWriteLog(string message)
        {
            string logText;

            logText = " Message##" + message;

            //Log.WriteLog("C:\\DotNetUAPEventSyncAdapterErrorLog.txt", logText);
        }


        private static void mWriteLog(string eventId, string message)
        {
            string logText;

            logText = "  EventId##" + eventId + "\r\n";
            logText = logText + " Message##" + message + "\r\n";

            //Log.WriteLog("C:\\DotNetUAPEventSyncAdapterDataLog.txt", logText);
        }
 

        #endregion

    }

}