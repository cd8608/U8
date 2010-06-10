using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Interface.Bus.WebService.Biz.Archive
{
    public class clsMom_moallocate:clsArchiveBase
    { 
        public clsMom_moallocate()
        {
            this.tableName = "MES_mom_moallocate";
            this.priKeyName = "AllocateId";
        }
 
    }
}
