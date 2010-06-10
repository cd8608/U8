using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using MSXML2;


namespace U8.Interface.Bus.Event.SyncAdapter.Biz.Factory.CQ 
{
    public class Mom_moallocate : BizBase
    {
        private int _moid;
        private int _modid;

        public Mom_moallocate(ref ADODB.Connection conn, int moid, int modid, string ufConnStr, string _opertype)
            : base(conn, ufConnStr)
        {

            oracleTableName = "MES_mom_moallocate";   //目标表名
            oraclePriKey = "MoId";      //目标表主键 
            fieldcmpTablename = "mom_moallocate";
            ufTableName = "mom_moallocate";       //来源表名
            ufPriKey = "MoId";          //来源表主键
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
            string sql = "SELECT " + colNames + " FROM " + sourceTableName + " with(nolock) WHERE  mom_moallocate.MoDId in( select modid from mom_orderdetail with(nolock) where  mom_orderdetail.moid =" + sourceKeyValue + " and mom_orderdetail.modid =" + Convert.ToString(_modid)  + ") ";
            DataTable dtValue = new DataTable();
            dtValue = UFSelect(sql);
            return dtValue;
        }



        public override StringBuilder CreateDeleteString()
        {
            if (Synch.Equals("UFOper"))
            {
                string sql = "DELETE FROM " + oracleTableName + " WHERE  " + oracleTableName + ".MoDId in( select modid from mom_orderdetail with(nolock) where  mom_orderdetail.moid =" + Convert.ToString(_moid) + " and mom_orderdetail.modid =" + Convert.ToString(_modid) + ") ";
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
