using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using U8.Interface.Bus.DBUtility;

namespace U8.Interface.Bus.Event.SyncAdapter.Biz
{


    /// <summary>
    /// Oracle数据操作类
    /// </summary>
    public class OracleOper :ISqlOper
    {
        string oraConnStr;
        string oracleTableName;
        string oraclePriKey;
        List<BaseMode> l;
        List<List<BaseMode>> lst;

        public OracleOper(string oraConnStr,string oracleTableName, string oraclePriKey, List<BaseMode> l, List<List<BaseMode>> lst)
        {
            this.oraConnStr = oraConnStr;
            this.oracleTableName = oracleTableName;
            this.oraclePriKey = oraclePriKey;
            this.l = l;
            this.lst = lst;
        }

        #region 直联ORACLE不走DBLink (暂时不用)



        public object Select()
        {
            object res;
            return null;
        }



        public object Insert()
        {
            object res;
            string oraCols = "";
            string oraValues = "";
            for (int i = 0; i < l.Count; i++)
            {
                if (!string.IsNullOrEmpty(l[i].OrColumnName))
                {
                    oraCols += l[i].OrColumnName + ",";
                    oraValues += "'" + l[i].OrColumnValue + "',";
                }
            }
            oraCols = "(" + oraCols.Substring(0, oraCols.Length - 1) + ")";
            oraValues = "(" + oraCols.Substring(0, oraCols.Length - 1) + ")";

            string sql = " INSERT FROM " + oracleTableName + " WHERE " + oraclePriKey + "'" + l.First<BaseMode>(e => e.UfColumnName.Equals("cinvcode")).UfColumnValue + "'";
            res = OracleDBUtility.ExecuteNonQuery(oraConnStr, System.Data.CommandType.Text, sql, null);
            return res;

        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public virtual StringBuilder CreateInsertString()
        {
            throw new NotImplementedException("开支持此功能!");
        }

        public object BatchInsert()
        {
            object res;
            string oraCols = "";
            string oraValues = "";
            for (int i = 0; i < l.Count; i++)
            {
                if (!string.IsNullOrEmpty(l[i].OrColumnName))
                {
                    oraCols += l[i].OrColumnName + ",";
                    oraValues += "'" + l[i].OrColumnValue + "',";
                }
            }
            oraCols = "(" + oraCols.Substring(0, oraCols.Length - 1) + ")";
            oraValues = "(" + oraCols.Substring(0, oraCols.Length - 1) + ")";

            string sql = " INSERT FROM " + oracleTableName + " WHERE " + oraclePriKey + "'" + l.First<BaseMode>(e => e.UfColumnName.Equals("cinvcode")).UfColumnValue + "'";
            res = OracleDBUtility.ExecuteNonQuery(oraConnStr, System.Data.CommandType.Text, sql, null);
            return res;

        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object Delete()
        {
            object res;
            string sql = " DELETE FROM " + oracleTableName + " WHERE " + oraclePriKey + "'" + l.First<BaseMode>(e => e.UfColumnName.Equals("cinvcode")).UfColumnValue + "'";
            res = OracleDBUtility.ExecuteNonQuery(oraConnStr, System.Data.CommandType.Text, sql, null);
            return res;

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public virtual StringBuilder CreateDeleteString()
        {
            throw new NotImplementedException("开支持此功能!");
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public virtual object BatchDelete()
        {
            throw new NotImplementedException("开支持此功能!");
        }

        public object Update()
        {
            object res;
            string oraUpdateCols = "";
            for (int i = 0; i < l.Count; i++)
            {
                if (!string.IsNullOrEmpty(l[i].OrColumnName))
                {
                    oraUpdateCols += l[i].OrColumnName + "= '" + l[i].OrColumnValue + "',";
                }
            }
            oraUpdateCols = oraUpdateCols.Substring(0, oraUpdateCols.Length - 1);

            string sql = " UPDATE " + oracleTableName + " SET " + oraUpdateCols + " WHERE " + oraclePriKey + "'" + l.First<BaseMode>(e => e.UfColumnName.Equals("cinvcode")).UfColumnValue + "'";
            res = OracleDBUtility.ExecuteNonQuery(oraConnStr, System.Data.CommandType.Text, sql, null);
            return res;

        }


        public virtual StringBuilder CreateUpdateSql()
        {
            throw new NotImplementedException("开支持此功能!");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual object ExecSql(string sql)
        {

            object res;
            res = OracleDBUtility.ExecuteNonQuery(oraConnStr, System.Data.CommandType.Text, sql, null);
            return res;
        }


        #endregion  
    }
}
