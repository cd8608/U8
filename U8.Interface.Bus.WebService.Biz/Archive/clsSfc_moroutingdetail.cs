using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Interface.Bus.WebService.Biz.Archive
{
    public class clsSfc_moroutingdetail:clsArchiveBase
    { 
        public clsSfc_moroutingdetail()
        {
            this.tableName = "Mes_Sfc_moroutingdetail";
            this.priKeyName = "MoRoutingId";
        }
 
    }
}
