using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace U8.Interface.Bus.WebService.Biz.Voucher
{
    public class clsPerson:Biz.Archive.clsArchiveBase
    {

        public clsPerson()
        {
            this.tableName = "MES_Person";
            this.priKeyName = "cPsn_Num";
        }
 
    }
}
