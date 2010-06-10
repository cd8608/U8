using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data; 
using MSXML2;


namespace U8.Interface.Bus.Event.SyncAdapter.Biz.Factory.CQ
{

    public class PU_ArrivalVouchs : U8.Interface.Bus.Event.SyncAdapter.Biz.BizBase
    {

        private string _ccode; 

        public PU_ArrivalVouchs(ref ADODB.Connection conn,string ccode, string ufConnStr, string _opertype)
            : base(conn, ufConnStr)
        {

            oracleTableName = "MES_CQ_PU_ArrivalVouchs";   //目标表名
            oraclePriKey = "dhcode";      //目标表主键 
            fieldcmpTablename = "MES_CQ_PU_ArrivalVouchs";
            ufTableName = "PU_ArrivalVouchs";  // "SaleOrderSQ";      //来源表名
            ufPriKey = "ccode";          //来源表主键
            this.opertype = _opertype;
            this._ccode = ccode; 
        }


        #region 赋值操作

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="doc"></param>
        private void SetData(string ccode)
        {
            lst = MakeMultiLineData(null, fieldcmpTablename, ufTableName, ufPriKey, ccode);
        }



        /// <summary>
        /// 获取来源档案数据
        /// </summary>
        /// <param name="sourceTableName"></param>
        /// <param name="sourceKeyName"></param>
        /// <param name="sourceKeyValue"></param>
        /// <param name="colNames"></param>
        /// <returns></returns>
        public override DataTable GetSourceData(string sourceTableName, string sourceKeyName, string sourceKeyValue, string colNames)
        {
            string _tempsourcetable = " (select t.ccode as dhCode,b.Autoid as dhid,cPoCode,ddate,";
            _tempsourcetable += "cVenCode,cDepCode,cPersonCode,t.cPTCode,cPTName,cInvCode,iquantity ";
            _tempsourcetable += " from PU_ArrivalVouchs b with(nolock) inner join PU_ArrivalVouch t on t.id = b.id ";
            _tempsourcetable += " left join PurchaseType ty with(nolock) on t.cPTCode = ty.cPTCode ) tmpt   ";

            string sql = "SELECT " + colNames + " FROM " + _tempsourcetable + "  WHERE dhcode ='" + _ccode + "' ";
            DataTable dtValue = new DataTable();
            dtValue = UFSelect(sql);
            return dtValue;
        }

  
        public override StringBuilder CreateDeleteString()
        {
            if (Synch.Equals("UFOper"))
            {
                string sql = " DELETE FROM " + oracleTableName + " WHERE  " + oracleTableName + ".dhcode ='" + _ccode + "'  ";
                return new StringBuilder(sql);
            }
            else if (Synch.Equals("LinkOper"))
            {
                sqlOper = new U8.Interface.Bus.Event.SyncAdapter.Biz.LinkOper(oraLinkName, ufConnStr, ufTableName, ufPriKey, oracleTableName, oraclePriKey, l, lst);
                return sqlOper.CreateDeleteString();
            }
            else
            {
                sqlOper = new U8.Interface.Bus.Event.SyncAdapter.Biz.OracleOper(oraConnStr, oracleTableName, oraclePriKey, l, lst);
                return sqlOper.CreateDeleteString();
            }
        }

        #endregion


    }
}
