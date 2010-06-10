using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace U8.Interface.Bus.WinService
{
    public partial class MainService : ServiceBase
    { 

        System.Threading.Thread thread;

        System.Threading.Thread threadTask;
        U8.Interface.Bus.ApiService.BLL.TaskOperator oper;

        public MainService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            thread = new System.Threading.Thread(Run);
            thread.Start();
        }

        protected override void OnStop()
        { 
            thread.Abort();
        }

        
        /// <summary>
        /// 
        /// </summary>
        private void Run()
        {
            oper = new U8.Interface.Bus.ApiService.BLL.TaskOperator(); 
            while (true)
            { 
                try
                { 
                    U8.Interface.Bus.ApiService.Model.TaskList tasklist = oper.GetTask();
                    if (tasklist.Count > 0)
                    {
                        foreach (U8.Interface.Bus.ApiService.Model.Task task in tasklist)
                        {
                            U8.Interface.Bus.ApiService.Model.Synergismlog log = new U8.Interface.Bus.ApiService.Model.Synergismlog();

                            log.Cvouchertype = task.VouchType.CardNo;
                            log.Id = task.id;
                            log.TaskType = task.taskType;
                            log.OPClass = task.VouchType.VoucherClass;

                            if (SysInfo.multiThread)
                            {
                                threadTask = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(oper.Run)); 
                                threadTask.Start(log);  
                            }
                            else
                            {
                                oper.Run(log);
                            }
                        }
                    }
                    else
                    { 
                        System.Threading.Thread.Sleep(U8.Interface.Bus.Config.ConfigUtility.TaskSleepTime);
                    }

                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry(U8.Interface.Bus.SysInfo.productName, ex.ToString(), EventLogEntryType.Error, 0, 0);
                } 
            }

        }


         
    }
}
