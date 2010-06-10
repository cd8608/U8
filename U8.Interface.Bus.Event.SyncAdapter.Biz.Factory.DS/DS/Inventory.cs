using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MSXML2;


namespace U8.Interface.Bus.Event.SyncAdapter.Biz.Factory.DS 
{
    public class Inventory : BizBase
    {
         
        public Inventory(ref ADODB.Connection conn, IXMLDOMDocument2 doc, string ufConnStr, string _opertype)
            : base(conn, ufConnStr)
        {

            oracleTableName = "MES_Inventory";   //目标表名
            oraclePriKey = "cInvCode";      //目标表主键 
            fieldcmpTablename = "Inventory";
            ufTableName = "Inventory";       //来源表名
            ufPriKey = "cInvCode";          //来源表主键
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
            lst = MakeMultiLineData(doc, fieldcmpTablename, ufTableName, ufPriKey, GetNodeValue(doc, "/inventory/cinvcode"));
        }


        #endregion


    }
}
