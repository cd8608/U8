using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Interface.Bus.WebService.Biz.Archive
{

    public class clsComputationUnit:clsArchiveBase
    {

        public clsComputationUnit()
        {
            this.tableName = "Mes_ComputationUnit";
            this.priKeyName = "cComunitCode";
        }
         
    }
}
