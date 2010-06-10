using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MSXML2;


namespace U8.Interface.Bus.Event.SyncAdapter.Biz.Factory.CQ 
{
    public class Sfc_workcenter : BizBase
    {
                          
        //protected string oracleTableName = "MES_Department";   //目标表名
        //protected string oraclePriKey = "cDepCode";      //目标表主键

        //protected string fieldcmpTablename = "Department";

        //protected string ufTableName = "Department";       //来源表名
        //protected string ufPriKey = "cDepCode";          //来源表主键

        public Sfc_workcenter(ref ADODB.Connection conn, IXMLDOMDocument2 doc, string ufConnStr, string _opertype)
            : base(conn, ufConnStr)
        {

            oracleTableName = "MES_CQ_Workcenter";   //目标表名
            oraclePriKey = "WcCode";      //目标表主键 
            fieldcmpTablename = "MES_CQ_Workcenter";
            ufTableName = "Sfc_workcenter";       //来源表名
            ufPriKey = "WcCode";          //来源表主键
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
            lst = MakeMultiLineData(doc, fieldcmpTablename, ufTableName, ufPriKey, GetNodeValue(doc, "/sfc_workcenter/wccode"));
        }


        #endregion


    }
}
