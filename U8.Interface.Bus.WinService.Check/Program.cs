using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace U8.Interface.Bus.WinService.Check
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new U8.Interface.Bus.WinService.Check.CheckService() 
			};
            ServiceBase.Run(ServicesToRun);
        }
    }
}
