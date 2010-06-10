using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Interface.Bus.WebService.Biz.Archive
{

    public class clsPerson:clsArchiveBase
    {

        public clsPerson()
        {
            this.tableName = "Mes_Person";
            this.priKeyName = "cPsn_Num";
        }
         
    }
}
