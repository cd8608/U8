using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MSXML2;


namespace U8.Interface.Bus.Event.SyncAdapter.Biz.Factory.HM
{
    class Customer : BizBase
    {

        public Customer(ref ADODB.Connection conn, IXMLDOMDocument2 doc, string ufConnStr)
            : base(conn, ufConnStr)
        {

            oracleTableName = "TBLERPCustomer";
            oraclePriKey = "CustomerCode";
            ufTableName = "Customer";
            ufPriKey = "ccuscode";

            l.Add(new BaseMode("ccuscode", GetNodeValue(doc, "/customer/ccuscode"), "/customer/ccuscode", "CustomerCode", GetNodeValue(doc, "/customer/ccuscode"), null, null));
            l.Add(new BaseMode("ccusname", GetNodeValue(doc, "/customer/ccusname"), "/customer/ccusname", "CustomerName", GetNodeValue(doc, "/customer/ccusname"), null, null));
            l.Add(new BaseMode(null, null, null, "Flag", "W", null, null));

            l.Add(new BaseMode(null, null, null, "FINISHFLAG", "0", null, null));
            l.Add(new BaseMode(null, null, null, "dModifyDate", System.DateTime.Now.ToString(), null, null));

        }


        public override object Insert()   //virtual  父类实例(用父类声明，用子类创建) 仍调用父类方法，override 父类实例 将调用子类方法
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
        /// xml "<vendor><ccuscode1>1</ccuscode1><cVenCode2>2</cVenCode2></vendor>\r\n"
        /// 1并到2
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public object LinkMerge(IXMLDOMDocument2 doc)
        {
            l.Remove(l.First(e => e.UfColumnName.Equals(ufPriKey)));
            l.Add(new BaseMode(ufPriKey, GetNodeValue(doc, "/customer/ccuscode1"), "/customer/ccuscode1", "CustomerCode", GetNodeValue(doc, "/customer/ccuscode1"), null, null));

            l.Add(new BaseMode(null, null, null, "EDITPROP", "D", null, null));
            l.Add(new BaseMode(null, null, null, "FINISHFLAG", "0", null, null));
            l.Add(new BaseMode(null, null, null, "dModifyDate", System.DateTime.Now.ToString(), null, null));

            return base.Delete();
        }
 
        
    }
}
