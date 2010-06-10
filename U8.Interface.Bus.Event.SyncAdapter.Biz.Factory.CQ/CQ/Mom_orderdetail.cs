using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using MSXML2;
 
namespace U8.Interface.Bus.Event.SyncAdapter.Biz.Factory.CQ 
{
    public class Mom_orderdetail : BizBase
    { 
        private int _moid;
        private int _modid;

        public Mom_orderdetail(ref ADODB.Connection conn, int moid, int modid, string ufConnStr, string _opertype)
            : base(conn, ufConnStr)
        {

            oracleTableName = "MES_CQ_mom_order";   //目标表名  //MES_CQ_Mom_orderdetail
            oraclePriKey = "MoCode";      //目标表主键   
            fieldcmpTablename = "MES_CQ_Mom_orderdetail";  
            ufTableName = "v_mom_orderdetail_wf";       //来源表名  mom_orderdetail
            ufPriKey = "MoCode";          //来源表主键
            this.opertype = _opertype;
            this._moid = moid;
            this._modid = modid;
        }
  

        #region 赋值操作

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="doc"></param>
        private void SetData(int moid)
        {
            lst = MakeMultiLineData(null, fieldcmpTablename, ufTableName, ufPriKey, Convert.ToString(moid));
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
            string _tempTable = " ( SELECT d.*,h.MoCode FROM v_mom_orderdetail_wf d with(nolock) inner join v_mom_order_wf h with(nolock) on h.moid = d.moid ) tmp ";
            string sql = "SELECT " + colNames + " FROM " + _tempTable + " WHERE moid =" + _moid + " and modid =" + Convert.ToString(_modid) + " ";
            DataTable dtValue = new DataTable();
            dtValue = UFSelect(sql);
            return dtValue;
        }



        public override StringBuilder CreateDeleteString()
        {
            if (Synch.Equals("UFOper"))
            {
                string sql = "DELETE FROM " + oracleTableName + " WHERE  " + oracleTableName + ".MoCode in( select h.mocode from mom_orderdetail d with(nolock) inner join mom_order h with(nolock) on h.moid = d.moid where  d.moid =" + Convert.ToString(_moid) + " and d.modid =" + Convert.ToString(_modid) + ") ";
                return new StringBuilder(sql);
            }
            else if (Synch.Equals("LinkOper"))
            {
                sqlOper = new LinkOper(oraLinkName, ufConnStr, ufTableName, ufPriKey, oracleTableName, oraclePriKey, l, lst);
                return sqlOper.CreateDeleteString();
            }
            else
            {
                sqlOper = new OracleOper(oraConnStr, oracleTableName, oraclePriKey, l, lst);
                return sqlOper.CreateDeleteString();
            }
        }

        #endregion


    }
}
