using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace U8.Interface.Bus.ApiService.Setting
{
    static class Program
    {
        //private static System.Threading.Mutex mutex;
        public static System.Threading.Mutex Run;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] arr)
        {
            try
            {
                U8.Interface.Bus.License.Check();
            }
            catch (Exception ee)
            {
                Common.MessageShow(ee.ToString());
                return;
            }

            bool noRun = false;
            Run = new System.Threading.Mutex(true, System.Diagnostics.Process.GetCurrentProcess().ProcessName, out noRun);
            //检测是否已经运行
            if (!noRun)
            {
                Common.MessageShow("本程序已经在运行了，请不要重复运行!");
                Application.Exit();
            }
            else
            {
                Run.ReleaseMutex();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                if (Common.Verification_lxz())
                {
                    Form frm;
                    switch (U8.Interface.Bus.Config.ConfigUtility.TaskType.ToLower())
                    {
                        case "cq":
                            if (arr.Length > 0)
                            {
                                frm = new FrmMainwork(arr[0].Split(';')[0], arr[0].Split(';')[1], arr[0].Split(';')[2], arr[0].Split(';')[3]);
                            }
                            else
                            {
                                frm = new FrmMainwork("", "", "", "");
                            }
                            break;
                        case "ds":
                            if (arr.Length > 0)
                            {
                                frm = new FrmMainwork(arr[0].Split(';')[0], arr[0].Split(';')[1], arr[0].Split(';')[2], arr[0].Split(';')[3]);
                            }
                            else
                            {
                                frm = new FrmMainwork("", "", "", "");
                            }
                            break;
                        default:
                            if (arr.Length > 0)
                            {
                                frm = new FrmTeamwork(arr[0].Split(';')[0], arr[0].Split(';')[1], arr[0].Split(';')[2], arr[0].Split(';')[3]);
                            }
                            else
                            {
                                frm = new FrmTeamwork("", "", "", "");
                            }
                            break;

                    }
                    if (arr.Length > 0)
                    {
                        Application.Run(frm);
                        Common.SetConfig();
                    }
                    else
                    {
                        Application.Run(frm);
                        Common.SetConfig();
                    }

                }
                Application.Exit();
            }
        }
    }
}