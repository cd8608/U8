using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MSXML2;



namespace U8.Interface.Bus.Event.SyncAdapter.Biz.Factory.CQ 
{
    class Customer : BizBase
    {

        public Customer(ref ADODB.Connection conn, IXMLDOMDocument2 doc, string ufConnStr)
            : base(conn, ufConnStr)
        {

            oracleTableName = "MES_CQ_Customer";
            oraclePriKey = "ccuscode";
            ufTableName = "Customer";
            ufPriKey = "ccuscode";


            l.Add(new BaseMode("id",null,null,"id",Guid.NewGuid().ToString(), null, null));

            l.Add(new BaseMode("ccuscode", GetNodeValue(doc, "/customer/ccuscode"), "/customer/ccuscode", "ccuscode", GetNodeValue(doc, "/customer/ccuscode"), null, null));
            l.Add(new BaseMode("ccusname", GetNodeValue(doc, "/customer/ccusname"), "/customer/ccusname", "ccusname", GetNodeValue(doc, "/customer/ccusname"), null, null));
            l.Add(new BaseMode("ccccode", GetNodeValue(doc, "/customer/ccccode"), "/customer/ccccode", "ccccode", GetNodeValue(doc, "/customer/ccccode"), null, null));
            l.Add(new BaseMode("ccusname", GetNodeValue(doc, "/customer/ccusaddress"), "/customer/ccusaddress", "ccusaddress", GetNodeValue(doc, "/customer/ccusaddress"), null, null));
            l.Add(new BaseMode("ccusotype", GetNodeValue(doc, "/customer/ccusotype"), "/customer/ccusotype", "ccusotype", GetNodeValue(doc, "/customer/ccusotype"), null, null));
            l.Add(new BaseMode("ccusdefine1", GetNodeValue(doc, "/customer/ccusdefine1"), "/customer/ccusdefine1", "ccusdefine1", GetNodeValue(doc, "/customer/ccusdefine1"), null, null));

        }


        public override object Insert()   //virtual  父类实例(用父类声明，用子类创建) 仍调用父类方法，override 父类实例 将调用子类方法
        { 
            l.Add(new BaseMode("opertype",null,null,"opertype","0","string","string"));
            return base.Insert();
        }

        public override object Delete()
        {
            if (bSaveOper)
            {
                l.Add(new BaseMode("opertype", null, null, "opertype", "2", "string", "string"));
                return base.Insert();
            }
            else
            {
                return base.Delete();
            }
            
        }

        public override object Update()
        {

            l.Add(new BaseMode("opertype", null, null, "opertype", "1", "string", "string"));
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

            return base.Delete();
        }
 
        
    }
}
