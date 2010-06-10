using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Interface.Bus.WebService.Biz.Archive
{

    public class clsInventoryClass:clsArchiveBase
    {

        public clsInventoryClass()
        {
            this.tableName = "Mes_InventoryClass";
            this.priKeyName = "cInvCCode";
        }
         
    }
}
