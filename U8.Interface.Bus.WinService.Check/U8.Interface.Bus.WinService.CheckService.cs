using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace U8.Interface.Bus.WinService.Check
{
    public partial class CheckService : ServiceBase
    {
        System.Threading.Thread thread;
        public CheckService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            thread = new System.Threading.Thread(Check);
            thread.Start();

        }

        protected override void OnStop()
        {
            thread.Abort();
        }


        private void Check()
        {
            while (true)
            {

                StartService("U8.Interface.Bus.WinService");
                System.Threading.Thread.Sleep(U8.Interface.Bus.Config.ConfigUtility.CheckTaskSleepTime); 
            }
        
        }


        public void StartService(string sServiceName)
        {
            ServiceController serviceController1 = new ServiceController();
            serviceController1.ServiceName = sServiceName;
            serviceController1.MachineName = "."; 

            if (serviceController1.Status == ServiceControllerStatus.Stopped)
                serviceController1.Start();


        }
    }
}
