using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MSXML2;


namespace U8.Interface.Bus.Event.SyncAdapter.Biz.Factory.CQ
{
    public class Inventory : BizBase
    {
         
        public Inventory(ref ADODB.Connection conn, IXMLDOMDocument2 doc, string ufConnStr, string _opertype)
            : base(conn, ufConnStr)
        {

            oracleTableName = "MES_CQ_Inventory";   //目标表名
            oraclePriKey = "cInvCode";      //目标表主键 
            fieldcmpTablename = "MES_CQ_Inventory";
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


        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        public override object Insert()
        { 

            StringBuilder sb = new StringBuilder();
            StringBuilder sbm = new StringBuilder();
            sbm = this.CreateInsertString();
            if (sbm.Length > 0)
            {
                sb.Append(" DECLARE @mainid AS INT ");
                sb.Append(sbm);
                sb.Append(" SELECT @mainid = @@IDENTITY "); 
                sb.Replace("main|##newguid", Guid.NewGuid().ToString());

            }

            if (bNoCase)
            {
                base.Delete();  //清除旧记录
            }
            if (sb.Length > 0)
            {
                return ExecSql(sb.ToString());
            }
            return null;
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public override object Update()
        {
            if (Synch.Equals("UFOper"))
            {
                sqlOper = new UFOper(oraLinkName, ufConnStr, ufTableName, ufPriKey, oracleTableName, oraclePriKey, l, lst);
                if (bNoCase)
                {
                    sqlOper.Delete();  //清除旧记录
                }
                return this.Insert();
            }
            else if (Synch.Equals("LinkOper"))
            {
                sqlOper = new LinkOper(oraLinkName, ufConnStr, ufTableName, ufPriKey, oracleTableName, oraclePriKey, l, lst);
                return sqlOper.Update();
            }
            else
            {
                sqlOper = new OracleOper(oraConnStr, oracleTableName, oraclePriKey, l, lst);
                return sqlOper.Update();
            }
        }


        #endregion


    }
}
