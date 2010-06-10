using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Interface.Bus.WebService.Biz.Archive
{
    public class clsMom_order:clsArchiveBase
    {

        public clsMom_order()
        {
            this.tableName = "Mes_Mom_order";
            this.priKeyName = "MoId";
        }
 
    }
}
