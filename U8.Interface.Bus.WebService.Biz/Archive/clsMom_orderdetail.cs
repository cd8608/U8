using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Interface.Bus.WebService.Biz.Archive
{
    public class clsMom_orderdetail:clsArchiveBase
    {
    //    private long id;
    //    private string depcode;

    //    public string DepCode
    //    {
    //        get { return depcode; }
    //        set { depcode = value; }
    //    }

    //    public long Id
    //    {
    //        get { return id; }
    //        set { id = value; }
    //    }

        public clsMom_orderdetail()
        {
            this.tableName = "MES_mom_orderdetail";
            this.priKeyName = "modid";
        }
 
    }
}
