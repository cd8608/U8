using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Interface.Bus.WebService.Biz.Archive
{
    public class clsSfc_operation:clsArchiveBase
    {

        public clsSfc_operation()
        {
            this.tableName = "Mes_Sfc_operation";
            this.priKeyName = "OperationId";
        }
 
    }
}
