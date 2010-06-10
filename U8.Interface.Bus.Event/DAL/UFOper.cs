using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using U8.Interface.Bus.DBUtility;

namespace U8.Interface.Bus.Event.SyncAdapter.Biz
{


    /// <summary>
    /// 操作U8数据库
    /// </summary>
    public class UFOper:ISqlOper
    {

        string oraLinkName;
        string oracleTableName;
        string oraclePriKey;

        string ufTableName;
        string ufPriKey;
        string ufConnStr;
  
        List<BaseMode> l;
        List<List<BaseMode>> lst;

        UfDBUtility uf = new UfDBUtility();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="oraLinkName"></param>
        /// <param name="ufConnStr"></param>
        /// <param name="ufTableName"></param>
        /// <param name="ufPriKey"></param>
        /// <param name="oracleTableName">目标表名</param>
        /// <param name="oraclePriKey"></param>
        /// <param name="l"></param>
        /// <param name="lst"></param>
        public UFOper(string oraLinkName, string ufConnStr, string ufTableName, string ufPriKey, string oracleTableName, string oraclePriKey, List<BaseMode> l, List<List<BaseMode>> lst)
        {
            this.oraLinkName = oraLinkName;
            this.ufConnStr = ufConnStr;
            this.ufTableName = ufTableName;
            this.ufPriKey = ufPriKey;
            this.oracleTableName = oracleTableName;
            this.oraclePriKey = oraclePriKey;
            this.l = l;
            this.lst = lst;
        }


        #region  操作U8数据库


        #region 插入
        /// <summary>
        /// 逐行插入数据
        /// 多行数据,多次执行
        /// </summary>
        /// <returns></returns>
        public virtual object Insert()
        {
            object res;
            string oraCols;
            string oraValues;

            if (lst.Count > 0)
            {
                for (int j = 0; j < lst.Count; j++)
                {
                    l = lst[j];
                    oraCols = "";
                    oraValues = "";

                    if (null == l && l.Count == 0)
                    {
                        throw new Exception("Insert:没有任务字段");
                    } 
                    for (int i = 0; i < l.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(l[i].OrColumnName))
                        {
                            oraCols += l[i].OrColumnName + ",";
                            oraValues += U8.Interface.Bus.Comm.Convert.ConvertDbValueString(l[i].OrColumnValue, l[i].OrFieldType) + ",";
                        }
                    }
                    oraCols = oraCols.Substring(0, oraCols.Length - 1);
                    oraValues = oraValues.Substring(0, oraValues.Length - 1);

                    res = uf.UFInsert(ufConnStr, oraLinkName, oracleTableName, oraCols, oraValues);

                }
                return null;
            }
            else
            {

                oraCols = "";
                oraValues = "";

                for (int i = 0; i < l.Count; i++)
                {
                    if (!string.IsNullOrEmpty(l[i].OrColumnName))
                    {
                        oraCols += l[i].OrColumnName + ",";
                        oraValues += U8.Interface.Bus.Comm.Convert.ConvertDbValueString(l[i].OrColumnValue, l[i].OrFieldType) + ",";   
                    }
                }
                oraCols = oraCols.Substring(0, oraCols.Length - 1);
                oraValues = oraValues.Substring(0, oraValues.Length - 1); 
                
                res = uf.UFInsert(ufConnStr, oraLinkName, oracleTableName, oraCols, oraValues);
                return res;
            }

        }


        /// <summary>
        /// 只组织SQL串,不进行数据库操作
        /// </summary>
        /// <returns></returns>
        public StringBuilder CreateInsertString()
        {
            StringBuilder sb = new StringBuilder();
            string oraCols;
            string oraValues;

            if (lst.Count > 0)
            {
                for (int j = 0; j < lst.Count; j++)
                {
                    l = lst[j];
                    oraCols = "";
                    oraValues = "";

                    if (null == l && l.Count == 0)
                    {
                        throw new Exception("Insert:没有任务字段");
                    }
                    for (int i = 0; i < l.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(l[i].OrColumnName))
                        {
                            oraCols += l[i].OrColumnName + ",";
                            oraValues += U8.Interface.Bus.Comm.Convert.ConvertDbValueString(l[i].OrColumnValue, l[i].OrFieldType) + ",";
                        }
                    }
                    oraCols = oraCols.Substring(0, oraCols.Length - 1);
                    oraValues = oraValues.Substring(0, oraValues.Length - 1);
                    sb.Append(" INSERT INTO " + oracleTableName + " ( " + oraCols + "   ) VALUES( " + oraValues + " )  ");

                }
                return sb;
            }
            else
            {

                oraCols = "";
                oraValues = "";

                for (int i = 0; i < l.Count; i++)
                {
                    if (!string.IsNullOrEmpty(l[i].OrColumnName))
                    {
                        oraCols += l[i].OrColumnName + ",";
                        oraValues += U8.Interface.Bus.Comm.Convert.ConvertDbValueString(l[i].OrColumnValue, l[i].OrFieldType) + ",";
                    }
                }
                oraCols = oraCols.Substring(0, oraCols.Length - 1);
                oraValues = oraValues.Substring(0, oraValues.Length - 1);
                sb.Append(" INSERT INTO " + oracleTableName + " ( " + oraCols + "   ) VALUES( " + oraValues + " )  ");
                return sb;
            }
        }

        /// <summary>
        /// 批量插入数据
        /// 先组织完数据再整体执行
        /// </summary>
        /// <returns></returns>
        public virtual object BatchInsert()
        {   
            string sql = CreateInsertString().ToString(); 
            if (string.IsNullOrEmpty(sql))
            {
                return null;
            }
            else
            {
                return uf.ExecSql(ufConnStr, sql);
            }

        }

        #endregion


        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public virtual object Delete()
        { 
            object res;
            if (lst.Count > 0)
            {
                for (int i = 0; i < lst.Count; i++)
                {
                    l = lst[i];
                    res = uf.UFDelete(ufConnStr, oraLinkName, oracleTableName, oraclePriKey, SetDelWhereString(ufPriKey));
                }
                return null;
            }
            else
            {
                res = uf.UFDelete(ufConnStr, oraLinkName, oracleTableName, oraclePriKey, SetDelWhereString(ufPriKey));
                return res;
            }
        }

        /// <summary>
        /// 只组织SQL串,不进行数据库操作
        /// </summary>
        /// <returns></returns>
        public StringBuilder CreateDeleteString()
        {
            StringBuilder sb = new StringBuilder();
 
            string where = "";

            if (lst.Count > 0)
            {
                for (int i = 0; i < lst.Count; i++)
                {
                    l = lst[i]; 
                    where = Comm.Convert.ConvertDbWhere(oraclePriKey, SetDelWhereString(ufPriKey));
                    sb.Append(" DELETE FROM " + oracleTableName);
                    if (string.IsNullOrEmpty(where))
                    { }
                    else
                    {
                        sb.Append( " WHERE " + Comm.Convert.ConvertDbWhere(oraclePriKey, SetDelWhereString(ufPriKey)));
                    }
                }
            }
            else
            { 
                where = Comm.Convert.ConvertDbWhere(oraclePriKey, SetDelWhereString(ufPriKey));
                sb.Append(" DELETE FROM " + oracleTableName);
                if (string.IsNullOrEmpty(where))
                { }
                else
                {
                    sb.Append(" WHERE " + Comm.Convert.ConvertDbWhere(oraclePriKey, SetDelWhereString(ufPriKey)));
                }

            }

            return sb;
        }


        /// <summary>
        /// 批量删除数据
        /// 先组织完数据再整体执行
        /// </summary>
        /// <returns></returns>
        public virtual object BatchDelete()
        { 
            string sql = CreateDeleteString().ToString(); 
            return uf.ExecSql(ufConnStr, sql);
        }


        #endregion



        #region 修改
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual object Update()
        {
            object res;
            string colNames;
            string oraUpdateCols;

            if (lst.Count > 0)
            {
                for (int j = 0; j < lst.Count; j++)
                {
                    l = lst[j];
                    colNames = "";
                    oraUpdateCols = "";

                    for (int i = 0; i < l.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(l[i].OrColumnName))
                        {
                            colNames += l[i].OrColumnName + ",";
                            oraUpdateCols += l[i].OrColumnName + "= '" + l[i].OrColumnValue + "',";
                        }
                    }
                    colNames = colNames.Substring(0, colNames.Length - 1);
                    oraUpdateCols = oraUpdateCols.Substring(0, oraUpdateCols.Length - 1);

                    res = uf.UFUpdate(ufConnStr, oraLinkName, oracleTableName, colNames, oraclePriKey, l.First(e => e.UfColumnName.Equals(ufPriKey)).UfColumnValue, oraUpdateCols);

                }
                return null;
            }
            else
            {

                colNames = "";
                oraUpdateCols = "";

                for (int i = 0; i < l.Count; i++)
                {
                    if (!string.IsNullOrEmpty(l[i].OrColumnName))
                    {
                        colNames += l[i].OrColumnName + ",";
                        oraUpdateCols += l[i].OrColumnName + "= '" + l[i].OrColumnValue + "',";
                    }
                }
                colNames = colNames.Substring(0, colNames.Length - 1);
                oraUpdateCols = oraUpdateCols.Substring(0, oraUpdateCols.Length - 1);

                res = uf.UFUpdate(ufConnStr, oraLinkName, oracleTableName, colNames, oraclePriKey, l.First(e => e.UfColumnName.Equals(ufPriKey)).UfColumnValue, oraUpdateCols);
                return res;
            }

        }


         /// <summary>
        /// 只组织SQL串,不进行数据库操作
        /// </summary>
        /// <returns></returns> 
        public StringBuilder CreateUpdateSql()
        {
            object res;
            string colNames;
            string oraUpdateCols;


            StringBuilder sb = new StringBuilder();

            if (lst.Count > 0)
            {
                for (int j = 0; j < lst.Count; j++)
                {
                    l = lst[j];
                    colNames = "";
                    oraUpdateCols = "";

                    for (int i = 0; i < l.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(l[i].OrColumnName))
                        {
                            colNames += l[i].OrColumnName + ",";
                            oraUpdateCols += l[i].OrColumnName + "= '" + l[i].OrColumnValue + "',";
                        }
                    }
                    colNames = colNames.Substring(0, colNames.Length - 1);
                    oraUpdateCols = oraUpdateCols.Substring(0, oraUpdateCols.Length - 1); 
                    sb.Append(" UPDATE " + oracleTableName + " SET " + oraUpdateCols + " WHERE " + oraclePriKey + " = '" + l.First(e => e.UfColumnName.Equals(ufPriKey)).UfColumnValue + "'");

                }
                return sb;
            }
            else
            {

                colNames = "";
                oraUpdateCols = "";

                for (int i = 0; i < l.Count; i++)
                {
                    if (!string.IsNullOrEmpty(l[i].OrColumnName))
                    {
                        colNames += l[i].OrColumnName + ",";
                        oraUpdateCols += l[i].OrColumnName + "= '" + l[i].OrColumnValue + "',";
                    }
                }
                colNames = colNames.Substring(0, colNames.Length - 1);
                oraUpdateCols = oraUpdateCols.Substring(0, oraUpdateCols.Length - 1); 
                sb.Append(" UPDATE " + oracleTableName + " SET " + oraUpdateCols + " WHERE " + oraclePriKey + " = '" + l.First(e => e.UfColumnName.Equals(ufPriKey)).UfColumnValue + "'");

                return sb; 
            }
        }

        #endregion



        public virtual object ExecSql(string sql)
        {
            return uf.ExecSql(ufConnStr, sql);
        }



        public virtual object Save()
        {
            return null;
        }


        #endregion

        /// <summary>
        /// 构造where语句,支持多条件,条件间用,号分开
        /// </summary>
        /// <param name="ufPriKey"></param>
        /// <returns></returns>
        private string SetDelWhereString(string ufPriKey)
        {
            string res = "";
            string[] whereColArray = ufPriKey.Split(',');
            for (int i = 0; i < whereColArray.Length; i++)
            {
                res += l.First(e => !string.IsNullOrEmpty(e.UfColumnName) && e.UfColumnName.ToLower().Equals(whereColArray[i].ToLower())).UfColumnValue + ",";
            }
            return res.Substring(0, res.Length - 1);
        }
 

        #region ISqlOper 成员

        public object Select()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
