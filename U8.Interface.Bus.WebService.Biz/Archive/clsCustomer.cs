using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Interface.Bus.WebService.Biz.Archive
{

    public class clsCustomer:clsArchiveBase
    {

        public clsCustomer()
        {
            this.tableName = "Mes_Customer";
            this.priKeyName = "cInvCode";
        }
         
    }
}
