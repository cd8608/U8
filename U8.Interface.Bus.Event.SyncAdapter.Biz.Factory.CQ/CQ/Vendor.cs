using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MSXML2;


namespace U8.Interface.Bus.Event.SyncAdapter.Biz.Factory.CQ 
{
    class Vendor:BizBase 
    {
 

        public Vendor(ref ADODB.Connection conn, IXMLDOMDocument2 doc, string ufConnStr)
            : base(conn, ufConnStr)
        {

            oracleTableName = "MES_CQ_Vendor";
            oraclePriKey = "cvencode";
            ufTableName = "Vendor";
            ufPriKey = "cvencode"; 

            l.Add(new BaseMode("id", null, null, "id", Guid.NewGuid().ToString(), null, null)); 
            l.Add(new BaseMode("cvencode", GetNodeValue(doc, "/vendor/cvencode"), "/vendor/cvencode", "cvencode", GetNodeValue(doc, "/vendor/cvencode"), null, null));
            l.Add(new BaseMode("cVenName", GetNodeValue(doc, "/vendor/cvenname"), "/vendor/cvenname", "cvenname", GetNodeValue(doc, "/vendor/cvenname"), null, null));
            l.Add(new BaseMode("cvccode", GetNodeValue(doc, "/vendor/cvccode"), "/vendor/cvccode", "cvccode", GetNodeValue(doc, "/vendor/cvccode"), null, null));
            l.Add(new BaseMode("cvenperson", GetNodeValue(doc, "/vendor/cvenperson"), "/vendor/cvenperson","cVenContact", GetNodeValue(doc, "/vendor/cvenperson"), null, null));
            l.Add(new BaseMode("cvenhand", GetNodeValue(doc, "/vendor/cvenhand"), "/vendor/cvenhand", "cVenContactPhone", GetNodeValue(doc, "/vendor/cvenhand"), null, null)); 
 

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
            l.Add(new BaseMode(ufPriKey, GetNodeValue(doc, "/vendor/cvencode1"), "/vendor/cvencode1", "cvencode", GetNodeValue(doc, "/vendor/cvencode1"), null, null)); 
            return base.Delete(); 
        }
    }
}
