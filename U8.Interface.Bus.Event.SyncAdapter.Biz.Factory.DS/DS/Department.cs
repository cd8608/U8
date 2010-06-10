using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MSXML2;


namespace U8.Interface.Bus.Event.SyncAdapter.Biz.Factory.DS
{
    public class Department : BizBase
    { 

        public Department(ref ADODB.Connection conn, IXMLDOMDocument2 doc, string ufConnStr, string _opertype)
            : base(conn, ufConnStr)
        {

            oracleTableName = "MES_Department";   //目标表名
            oraclePriKey = "cDepCode";      //目标表主键 
            fieldcmpTablename = "Department"; 
            ufTableName = "Department";       //来源表名
            ufPriKey = "cDepCode";          //来源表主键
            this.opertype = _opertype;

            SetData(doc);
        }


        #region 赋值操作

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="doc"></param>
        private void SetData(IXMLDOMDocument2 doc)
        {
            lst = MakeMultiLineData(doc, fieldcmpTablename, ufTableName, ufPriKey, GetNodeValue(doc, "/department/cdepcode"));
        }


        #endregion


    }
}
