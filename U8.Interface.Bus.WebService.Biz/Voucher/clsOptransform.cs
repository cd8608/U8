using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace U8.Interface.Bus.WebService.Biz.Voucher
{
    public class clsOptransform:Biz.Archive.clsArchiveBase
    {

        public clsOptransform()
        {
            this.tableName = "MES_Int_Optransform";
            this.priKeyName = "MoCode";
        }
 
    }
}
