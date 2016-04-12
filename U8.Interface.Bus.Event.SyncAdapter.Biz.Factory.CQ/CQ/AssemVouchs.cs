using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data; 
using MSXML2;


namespace U8.Interface.Bus.Event.SyncAdapter.Biz.Factory.CQ
{

    public class AssemVouchs : U8.Interface.Bus.Event.SyncAdapter.Biz.BizBase
    {

        private string _cAVCode;

        public AssemVouchs(ref ADODB.Connection conn, string cAVCode, string ufConnStr, string _opertype)
            : base(conn, ufConnStr)
        {

            oracleTableName = "MES_CQ_AssemVouchs";   //目标表名
            oraclePriKey = "cAVCode";      //目标表主键 
            fieldcmpTablename = "MES_CQ_AssemVouchs";
            ufTableName = "AssemVouchs";  // "SaleOrderSQ";      //来源表名
            ufPriKey = "cAVCode";          //来源表主键
            this.opertype = _opertype;
            this._cAVCode = cAVCode; 
        }


        #region 赋值操作

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="doc"></param>
        private void SetData(string cAVCode)
        {
            lst = MakeMultiLineData(null, fieldcmpTablename, ufTableName, ufPriKey, cAVCode);
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
            string _tempsourcetable = " ( select sb.*,h.cAVCode from " + ufTableName + " sb WITH(NOLOCK)  INNER JOIN AssemVouch sh WITH(NOLOCK) sb.id = sh.id  ) tmpt   ";

            string sql = "SELECT " + colNames + " FROM " + ufTableName + " WHERE ID IN ( SELECT ID FROM AssemVouch WITH(NOLOCK) WHERE cVouchType = '13'  AND cAVCode ='" + _cAVCode + "'  ) ";
             
            DataTable dtValue = new DataTable();
            dtValue = UFSelect(sql);
            return dtValue;
        }

  
        public override StringBuilder CreateDeleteString()
        {
            if (Synch.Equals("UFOper"))
            {
                string sql = " DELETE FROM " + oracleTableName + " WHERE  " + oracleTableName + ".cAVDID in( select  autoid from " + ufTableName + " sb with(nolock) INNER JOIN AssemVouch sh WITH(NOLOCK) ON sh.id = sb.id where sh.cVouchType = '13' AND sh.cAVCode ='" + _cAVCode + "') ";
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
