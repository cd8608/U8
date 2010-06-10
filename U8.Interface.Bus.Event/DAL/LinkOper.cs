using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using U8.Interface.Bus.DBUtility;

namespace U8.Interface.Bus.Event.SyncAdapter.Biz
{


    /// <summary>
    /// 通过数据链接操作oracle
    /// </summary>
    public class LinkOper:ISqlOper
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

        public LinkOper(string oraLinkName,string ufConnStr, string ufTableName, string ufPriKey,string oracleTableName,string oraclePriKey, List<BaseMode> l, List<List<BaseMode>> lst)
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
 

        #region 通过DBLink操作oracle

        /// <summary>
        /// 
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

                    for (int i = 0; i < l.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(l[i].OrColumnName))
                        {
                            oraCols += l[i].OrColumnName + ",";
                            oraValues += "'" + l[i].OrColumnValue + "',";
                        }
                    }
                    oraCols = oraCols.Substring(0, oraCols.Length - 1);
                    oraValues = oraValues.Substring(0, oraValues.Length - 1);

                    res = uf.LinkInsert(ufConnStr, oraLinkName, oracleTableName, oraCols, oraValues);

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
                        oraValues += "'" + l[i].OrColumnValue + "',";
                    }
                }
                oraCols = oraCols.Substring(0, oraCols.Length - 1);
                oraValues = oraValues.Substring(0, oraValues.Length - 1);

                res = uf.LinkInsert(ufConnStr, oraLinkName, oracleTableName, oraCols, oraValues);
                return res;
            }

        }


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

                    for (int i = 0; i < l.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(l[i].OrColumnName))
                        {
                            oraCols += l[i].OrColumnName + ",";
                            oraValues += "'" + l[i].OrColumnValue + "',";
                        }
                    }
                    oraCols = oraCols.Substring(0, oraCols.Length - 1);
                    oraValues = oraValues.Substring(0, oraValues.Length - 1);
                    sb.Append(" INSERT OPENQUERY (" + oraLinkName + ", 'SELECT  " + oraCols + " FROM " + oracleTableName + "  ') VALUES( " + oraValues + ")  ;");

                }

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
                        oraValues += "'" + l[i].OrColumnValue + "',";
                    }
                }
                oraCols = oraCols.Substring(0, oraCols.Length - 1);
                oraValues = oraValues.Substring(0, oraValues.Length - 1);

                sb.Append(" INSERT OPENQUERY (" + oraLinkName + ", 'SELECT  " + oraCols + " FROM " + oracleTableName + "  ') VALUES( " + oraValues + ")  ;");

            }

            return sb;
        }

        /// <summary>
        /// 批量增加
        /// </summary>
        /// <returns></returns>
        public virtual object BatchInsert()
        {
            object res; 
            string sql = CreateInsertString().ToString(); 

            if (string.IsNullOrEmpty(sql))
            {
                return null;
            }
            else
            {
                res = uf.ExecSql(ufConnStr, sql);
            }

            return res;

        }
  
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
                    res = uf.LinkDelete(ufConnStr, oraLinkName, oracleTableName, oraclePriKey, SetDelWhereString(ufPriKey));
                }
                return null;
            }
            else
            {
                res = uf.LinkDelete(ufConnStr, oraLinkName, oracleTableName, oraclePriKey, SetDelWhereString(ufPriKey));
                return res;
            }
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


        public virtual object ExecSql(string sql)
        {
            return uf.ExecSql(ufConnStr, sql);
        }


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

                    res = uf.LinkUpdate(ufConnStr, oraLinkName, oracleTableName, colNames, oraclePriKey, l.First(e => e.UfColumnName.Equals(ufPriKey)).UfColumnValue, oraUpdateCols);

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

                res = uf.LinkUpdate(ufConnStr, oraLinkName, oracleTableName, colNames, oraclePriKey, l.First(e => e.UfColumnName.Equals(ufPriKey)).UfColumnValue, oraUpdateCols);
                return res;
            }

        }



        public virtual StringBuilder CreateUpdateSql()
        {
            throw new NotImplementedException("开支持此功能!");
        }

        public virtual object Save()
        {
            return null;
        }


        #endregion


        private string SetDelWhereString(string ufPriKey)
        {
            string res = "";
            string[] whereColArray = ufPriKey.Split(',');
            for (int i = 0; i < whereColArray.Length; i++)
            {
                res += l.First(e => e.UfColumnName.ToLower().Equals(whereColArray[i].ToLower())).UfColumnValue + ",";
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
