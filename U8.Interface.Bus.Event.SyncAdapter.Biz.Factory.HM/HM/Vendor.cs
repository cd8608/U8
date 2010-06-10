using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MSXML2;

namespace U8.Interface.Bus.Event.SyncAdapter.Biz.Factory.HM
{
    public class Vendor:BizBase 
    {
 

        public Vendor(ref ADODB.Connection conn, IXMLDOMDocument2 doc, string ufConnStr)
            : base(conn, ufConnStr)
        { 

            oracleTableName = "TBLERPVendor";
            oraclePriKey = "VendorCode";
            ufTableName = "Vendor";
            ufPriKey = "cvencode";

            l.Add(new BaseMode("cvencode", GetNodeValue(doc, "/vendor/cvencode"), "/vendor/cvencode", "VendorCode", GetNodeValue(doc, "/vendor/cvencode"), null, null));
            l.Add(new BaseMode("cinvname", GetNodeValue(doc, "/vendor/cvenname"), "/vendor/cvenname", "VendorName", GetNodeValue(doc, "/vendor/cvenname"), null, null));
            l.Add(new BaseMode(null, null, null, "Flag", "W", null, null));

            l.Add(new BaseMode(null, null, null, "FINISHFLAG", "0", null, null));
            l.Add(new BaseMode(null, null, null, "dModifyDate", System.DateTime.Now.ToString(), null, null));

        }


        public override object Insert()
        {
            l.Add(new BaseMode(null, null, null, "EDITPROP", "A", null, null));
            return base.Insert();
        }

        public override object Delete()
        {
            l.Add(new BaseMode(null, null, null, "EDITPROP", "D", null, null));
            return base.Delete();
        }


        public override object Update()
        {
            l.Add(new BaseMode(null, null, null, "EDITPROP", "M", null, null));
            return base.Update();
        }

        /// <summary>
        /// xml "<vendor><cvencode1>1</cvencode1><cVenCode2>2</cVenCode2></vendor>\r\n"
        /// 1并到2
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public object LinkMerge(IXMLDOMDocument2 doc)
        {
            l.Remove(l.First(e => e.UfColumnName.Equals(ufPriKey)));
            l.Add(new BaseMode(ufPriKey, GetNodeValue(doc, "/vendor/cvencode1"), "/vendor/cvencode1", "VendorCode", GetNodeValue(doc, "/vendor/cvencode1"), null, null)); 
            return base.Delete(); 
        }
    }
}
