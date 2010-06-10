using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using MSXML2;


namespace U8.Interface.Bus.Event.SyncAdapter.Biz.Factory.DS 
{
    public class Sfc_proutingdetail : BizBase
    {

        private int _PRoutingId;

        public Sfc_proutingdetail(ref ADODB.Connection conn, int bomId, string ufConnStr, string _opertype)
            : base(conn, ufConnStr)
        {

            oracleTableName = "MES_Sfc_proutingdetail";   //目标表名
            oraclePriKey = "PRoutingId";      //目标表主键 
            fieldcmpTablename = "Sfc_proutingdetail";
            ufTableName = "Sfc_proutingdetail";       //来源表名
            ufPriKey = "PRoutingId";          //来源表主键
            this.opertype = _opertype;
            this._PRoutingId = bomId;
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
            string sql = "SELECT " + colNames + " FROM " + sourceTableName + " with(nolock) WHERE PRoutingId =" + sourceKeyValue; //+ " and modid =" + Convert.ToString(_PRoutingId) + " ";
            DataTable dtValue = new DataTable();
            dtValue = UFSelect(sql);
            return dtValue;
        }



        public override StringBuilder CreateDeleteString()
        {
            if (Synch.Equals("UFOper"))
            {
                string sql = "DELETE FROM " + oracleTableName + " WHERE  " + oraclePriKey + "=" + Convert.ToString(_PRoutingId) + " ";
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
