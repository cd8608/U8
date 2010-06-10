using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Interface.Bus.WebService.Biz.Archive
{

    public class clsInventory:clsArchiveBase
    {

        public clsInventory()
        {
            this.tableName = "Mes_Inventory";
            this.priKeyName = "cInvCode";
        }
         
    }
}
