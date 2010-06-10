using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data; 
using MSXML2;


namespace U8.Interface.Bus.Event.SyncAdapter.Biz.Factory.CQ
{

    public class SO_SODetails : U8.Interface.Bus.Event.SyncAdapter.Biz.BizBase
    {

        private string _csocode; 

        public SO_SODetails(ref ADODB.Connection conn,string csocode, string ufConnStr, string _opertype)
            : base(conn, ufConnStr)
        {

            oracleTableName = "MES_CQ_SO_SODetails";   //目标表名
            oraclePriKey = "cSoCode";      //目标表主键 
            fieldcmpTablename = "MES_CQ_SO_SODetails";
            ufTableName = "SO_SODetails";  // "SaleOrderSQ";      //来源表名
            ufPriKey = "cSoCode";          //来源表主键
            this.opertype = _opertype;
            this._csocode = csocode; 
        }


        #region 赋值操作

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="doc"></param>
        private void SetData(string csocode)
        {
            lst = MakeMultiLineData(null, fieldcmpTablename, ufTableName, ufPriKey, csocode);
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
            string _tempsourcetable = " (select t.cSOCode,t.isosid,t.cinvcode as cinvcode,d.cinvname as cinvname,iquantity ";
            _tempsourcetable += " from so_sodetails t with(nolock) ";
            _tempsourcetable += " inner join inventory  d with(nolock) on t.cinvcode = d.cinvcode ) tmpt   ";

            string sql = "SELECT " + colNames + " FROM " + _tempsourcetable + "  WHERE csocode ='" + _csocode + "' ";
            DataTable dtValue = new DataTable();
            dtValue = UFSelect(sql);
            return dtValue;
        }

  
        public override StringBuilder CreateDeleteString()
        {
            if (Synch.Equals("UFOper"))
            {
                string sql = " DELETE FROM " + oracleTableName + " WHERE  " + oracleTableName + ".isosid in( select isosid from SO_SODetails with(nolock) where  SO_SODetails.cSoCode ='" + _csocode + "') ";
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
