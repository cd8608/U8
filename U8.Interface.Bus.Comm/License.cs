using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Interface.Bus
{
    public class License
    {
        public static void Check()
        {
            if (System.DateTime.Now > Convert.ToDateTime("2016-10-20"))
            {
                throw new System.Exception("程序试用结束!请购买正式程序..."); 
            }
        }
    }
}
