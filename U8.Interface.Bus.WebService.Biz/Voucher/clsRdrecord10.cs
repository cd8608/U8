using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace U8.Interface.Bus.WebService.Biz.Voucher
{
    public class clsRdrecord10:Biz.Archive.clsArchiveBase
    {

        public clsRdrecord10()
        { 
            this.tableName = "MES_Int_rdrecord10";
            this.priKeyName = "MoCode";

        }
 
    }
}
