using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MSXML2;

namespace U8.Interface.Bus.Event.SyncAdapter.Biz.Factory.DS 
{
    /// <summary>
    /// 人员档案
    /// </summary>
    public class Person:BizBase
    {
        public Person(ref ADODB.Connection conn, IXMLDOMDocument2 doc, string ufConnStr, string _opertype)
            : base(conn, ufConnStr)
        {

            oracleTableName = "MES_Person";   //目标表名
            oraclePriKey = "cPsn_Num";      //目标表主键 
            fieldcmpTablename = "hr_hi_person";
            ufTableName = "hr_hi_person";       //来源表名
            ufPriKey = "cPsn_Num";          //来源表主键
            this.opertype = _opertype;      //业务操作类型

            SetData(doc);
        }


        #region 赋值操作

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="doc"></param>
        private void SetData(IXMLDOMDocument2 doc)
        {
            lst = MakeMultiLineData(doc, fieldcmpTablename, ufTableName, ufPriKey, GetNodeValue(doc, "/hr_hi_person/cpsn_num"));
        }


        #endregion
    }
}
