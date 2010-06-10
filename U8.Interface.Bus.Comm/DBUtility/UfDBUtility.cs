using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace U8.Interface.Bus.DBUtility
{
    public class UfDBUtility
    {
        //ADODB.Connection conn; 

        public void SimulatePluginBusiness(ref ADODB.Connection conn)
        {
            try
            {
                string sql;

                sql = "DELETE FROM AA_Enum_UAPEventTest WHERE cProjectNO = 'CSharpSync'; \r\n"
                    + "INSERT INTO AA_Enum_UAPEventTest(\r\n"
                    + "    EnumType, EnumCode, LocaleId, EnumName, EnumIndex, cProjectNO, cTimeStamp)\r\n"
                    + "SELECT TOP 5 \r\n"
                    + "    NEWID() AS EnumType, EnumCode, LocaleId, EnumName, EnumIndex, 'CSharpSync' AS cProjectNO, GETDATE() AS cTimeStamp\r\n"
                    + "FROM AA_Enum ";

                object recordsAffected; 
                conn.Execute(sql, out recordsAffected, -1);

            }
            catch (Exception ex)
            {
                //Output.mWriteLog(ex.Message);
                throw ex;
            }
        }


        #region SQLServer 基本操作
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object ExecSql(ref ADODB.Connection conn, string sql)
        {
            object recordsAffected;
            conn.Execute(sql, out recordsAffected, -1);
            return recordsAffected;
        }


        public object ExecSql(string connStr, string mSql)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            object recordsAffected;
            try
            {
                conn.ConnectionString = connStr;
                conn.Open();
                cmd.CommandTimeout = 600;
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = mSql;
                int iRetCount;
                iRetCount = cmd.ExecuteNonQuery();
                cmd.Dispose();
                recordsAffected = true;
                return recordsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();

                }

            }
        }

        #endregion


        #region 操作UF



        public DataTable UFSelect(string connStr, string mSql)
        {
            SqlConnection conn = new SqlConnection();
            DataSet ds = new DataSet();

            try
            {
                conn.ConnectionString = connStr;
                conn.Open();

                SqlDataAdapter sqlAdapter = new SqlDataAdapter(mSql, conn);
                sqlAdapter.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();

                }

            }
        } 

        /// <summary>
        ///  Link查询
        ///  select * from openquery(ORASVR,'select * from t_vbtest')
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object UFSelect(ref ADODB.Connection conn, string oraLinkName, string sql)
        {
            string mSql = sql;
            object recordsAffected;
            conn.Execute(sql, out recordsAffected, -1);
            return recordsAffected;

        }

        /// <summary>
        ///  Link查询
        ///  select * from openquery(ORASVR,'select * from t_vbtest'
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object UFSelect(ref ADODB.Connection conn, string oraLinkName, string tableName, string colNames)
        {
            string mSql = "   SELECT " + colNames + " FROM " + tableName + " ";
            object recordsAffected;
            conn.Execute(mSql, out recordsAffected, -1);
            return recordsAffected;

        }

        /// <summary>
        /// 插入语句
        /// INSERT OPENQUERY (ORASVR, 'SELECT ID,TEXT FROM t_vbtest') VALUES ('3','测试数据Insert');
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="oraLinkName"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object UFInsert(ref ADODB.Connection conn, string oraLinkName, string tableName, string colNames, string colValues)
        {
            string mSql = " INSERT INTO "  + tableName + " ( " + colNames  + "   ) VALUES( " + colValues + ")  ";
            object recordsAffected;
            conn.Execute(mSql, out recordsAffected, -1);
            return recordsAffected;
        }


        /// <summary>
        /// 插入语句
        /// INSERT OPENQUERY (ORASVR, 'SELECT ID,TEXT FROM t_vbtest') VALUES ('3','测试数据Insert');
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="oraLinkName"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object UFInsert(string connStr, string oraLinkName, string tableName, string colNames, string colValues)
        {

            string mSql = " INSERT INTO " + tableName + " ( " + colNames + "   ) VALUES( " + colValues + " )  ";
            object recordsAffected;

            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                conn.ConnectionString = connStr;
                conn.Open();
                cmd.CommandTimeout = 600;
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = mSql;
                int iRetCount;

                iRetCount = cmd.ExecuteNonQuery();
                cmd.Dispose();
                recordsAffected = true;
                return recordsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();

                }

            }

        }



        /// <summary>
        /// LINK 更新语句
        /// UPDATE OPENQUERY (ORASVR, 'SELECT TEXT FROM t_vbtest WHERE id = 1')  SET TEXT = '测试数据Update';
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="oraLinkName"></param>
        /// <param name="sql"></param>
        /// <returns></returns> 
        public object UFUpdate(ref ADODB.Connection conn, string oraLinkName, string tableName, string colNames, string keyName, string keyValue, string setCols)
        {
            string mSql = " UPDATE " + tableName + " SET " + setCols  + " WHERE " + keyName + " = '" + keyValue + "'";
            
            object recordsAffected;
            conn.Execute(mSql, out recordsAffected, -1);
            return recordsAffected;

        }


        /// <summary>
        /// LINK 更新语句
        /// UPDATE OPENQUERY (ORASVR, 'SELECT TEXT FROM t_vbtest WHERE id = 1')  SET TEXT = '测试数据Update';
        /// UPDATE OPENQUERY (ORASVR, 'SELECT ITEMNAME FROM TBLERPITEM WHERE ITEMCODE = ''fff''')  SET ITEMNAME = '测试数据Update';
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="oraLinkName"></param>
        /// <param name="sql"></param>
        /// <returns></returns> 
        public object UFUpdate(string connStr, string oraLinkName, string tableName, string colNames, string keyName, string keyValue, string setCols)
        {
            string mSql = " UPDATE " + tableName + " SET " + setCols + " WHERE " + keyName + " = '" + keyValue + "'";
            object recordsAffected; 
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                conn.ConnectionString = connStr;
                conn.Open();
                cmd.CommandTimeout = 600;
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = mSql;
                int iRetCount;
                iRetCount = cmd.ExecuteNonQuery();
                cmd.Dispose();
                recordsAffected = true;
                return recordsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();

                }

            }


        }



        /// <summary>
        /// 删除语句
        /// DELETE OPENQUERY (ORASVR, 'SELECT ID,TEXT FROM t_vbtest WHERE ID = ''3''');
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="oraLinkName"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object UFDelete(ref ADODB.Connection conn, string oraLinkName, string tableName, string colName, string colValue)
        {
            string mSql = " DELETE FROM "   + tableName  + "  WHERE " + colName + " = '" + colValue + "'";
            object recordsAffected;
            conn.Execute(mSql, out recordsAffected, -1);
            return recordsAffected;

        }
 

        /// <summary>
        /// 删除语句
        /// DELETE OPENQUERY (ORASVR, 'SELECT ID,TEXT FROM t_vbtest WHERE ID = ''3''');
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="oraLinkName"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object UFDelete(string connStr, string oraLinkName, string tableName, string colNames, string colValues)
        {
            string where;
            string[] colNameArray = colNames.Split(',');

            if (colNameArray.Length > 1)
            {
                string[] colValueArray = colValues.Split(',');
                if (colNameArray.Length != colValueArray.Length)
                    throw new System.Exception("删除列与传入值个数不匹配");
                where = "";
                for (int i = 0; i < colNameArray.Length; i++)
                {
                    where += (where.Equals("") ? "" : " AND ") + " " + colNameArray[i] + "= '" + colValueArray[i] + "'";
                }
            }
            else
            {
                where = colNames + " = '" + colValues + "' ";
            }
            
            string mSql = " DELETE FROM " + tableName  + " WHERE " + where + " ";
            object recordsAffected;
            recordsAffected = ExecSql(connStr, mSql);
            return recordsAffected;

        }
         
          
        #endregion


        #region Link操作数据库


        /// <summary>
        ///  Link查询
        ///  select * from openquery(ORASVR,'select * from t_vbtest')
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object LinkSelect(ref ADODB.Connection conn, string oraLinkName, string sql)
        {
            string mSql = " SELECT * FROM OPENQUERY (" + oraLinkName + ",'" + sql + "')";
            object recordsAffected;
            conn.Execute(sql, out recordsAffected, -1);
            return recordsAffected;

        }

        /// <summary>
        ///  Link查询
        ///  select * from openquery(ORASVR,'select * from t_vbtest'
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object LinkSelect(ref ADODB.Connection conn, string oraLinkName, string tableName, string colNames)
        {
            string mSql = " SELECT * FROM OPENQUERY (" + oraLinkName + ",' SELECT " + colNames + " FROM " + tableName + "')";
            object recordsAffected;
            conn.Execute(mSql, out recordsAffected, -1);
            return recordsAffected;

        }

        /// <summary>
        /// 插入语句
        /// INSERT OPENQUERY (ORASVR, 'SELECT ID,TEXT FROM t_vbtest') VALUES ('3','测试数据Insert');
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="oraLinkName"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object LinkInsert(ref ADODB.Connection conn, string oraLinkName, string tableName, string colNames, string colValues)
        {
            string mSql = " INSERT OPENQUERY (" + oraLinkName + ", 'SELECT  " + colNames + " FROM " + tableName + "  ') VALUES( " + colValues + ")  ;";
            object recordsAffected;
            conn.Execute(mSql, out recordsAffected, -1);
            return recordsAffected;
        }


        /// <summary>
        /// 插入语句
        /// INSERT OPENQUERY (ORASVR, 'SELECT ID,TEXT FROM t_vbtest') VALUES ('3','测试数据Insert');
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="oraLinkName"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object LinkInsert(string connStr, string oraLinkName, string tableName, string colNames, string colValues)
        {

            string mSql = " INSERT OPENQUERY (" + oraLinkName + ", 'SELECT  " + colNames + " FROM " + tableName + "  ') VALUES( " + colValues + ")  ;";
            object recordsAffected;

            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                conn.ConnectionString = connStr;
                conn.Open();
                cmd.CommandTimeout = 600;
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = mSql;
                int iRetCount;

                iRetCount = cmd.ExecuteNonQuery();
                cmd.Dispose();
                recordsAffected = true;
                return recordsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();

                }

            }

        }



        /// <summary>
        /// LINK 更新语句
        /// UPDATE OPENQUERY (ORASVR, 'SELECT TEXT FROM t_vbtest WHERE id = 1')  SET TEXT = '测试数据Update';
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="oraLinkName"></param>
        /// <param name="sql"></param>
        /// <returns></returns> 
        public object LinkUpdate(ref ADODB.Connection conn, string oraLinkName, string colNames, string sql)
        {
            string mSql = " UPDATE OPENQUERY (" + oraLinkName + ", 'SELECT colNames FROM t_vbtest WHERE id = 1')  SET " + sql + ";";
            object recordsAffected;
            conn.Execute(sql, out recordsAffected, -1);
            return recordsAffected;

        }


        /// <summary>
        /// LINK 更新语句
        /// UPDATE OPENQUERY (ORASVR, 'SELECT TEXT FROM t_vbtest WHERE id = 1')  SET TEXT = '测试数据Update';
        /// UPDATE OPENQUERY (ORASVR, 'SELECT ITEMNAME FROM TBLERPITEM WHERE ITEMCODE = ''fff''')  SET ITEMNAME = '测试数据Update';
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="oraLinkName"></param>
        /// <param name="sql"></param>
        /// <returns></returns> 
        public object LinkUpdate(string connStr, string oraLinkName, string tableName, string colNames, string keyName, string keyValue, string setCols)
        {
            string mSql = " UPDATE OPENQUERY (" + oraLinkName + ", 'SELECT " + colNames + " FROM " + tableName + " WHERE " + keyName + " = ''" + keyValue + "''')  SET " + setCols + ";";
            object recordsAffected;

            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                conn.ConnectionString = connStr;
                conn.Open();
                cmd.CommandTimeout = 600;
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = mSql;
                int iRetCount;
                iRetCount = cmd.ExecuteNonQuery();
                cmd.Dispose();
                recordsAffected = true;
                return recordsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();

                }

            }


        }



        /// <summary>
        /// 删除语句
        /// DELETE OPENQUERY (ORASVR, 'SELECT ID,TEXT FROM t_vbtest WHERE ID = ''3''');
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="oraLinkName"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object LinkDelete(ref ADODB.Connection conn, string oraLinkName, string tableName, string colName, string colValue)
        {
            string mSql = " DELETE OPENQUERY (" + oraLinkName + ", 'SELECT " + colName + " FROM " + tableName + " WHERE id = '' " + colValue + "''')  ;";
            object recordsAffected;
            conn.Execute(mSql, out recordsAffected, -1);
            return recordsAffected;

        }

 
        /// <summary>
        /// 删除语句
        /// DELETE OPENQUERY (ORASVR, 'SELECT ID,TEXT FROM t_vbtest WHERE ID = ''3''');
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="oraLinkName"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object LinkDelete(string connStr, string oraLinkName, string tableName, string colNames, string colValues)
        {
            string where;
            string[] colNameArray = colNames.Split(',');

            if (colNameArray.Length > 1)
            {
                string[] colValueArray = colValues.Split(',');
                if (colNameArray.Length != colValueArray.Length)
                    throw new System.Exception("删除列与传入值个数不匹配");
                where = "";
                for (int i = 0; i < colNameArray.Length; i++)
                {
                    where += (where.Equals("") ? "" : " AND ") + " " + colNameArray[i] + "= ''" + colValueArray[i] + "''";
                }
            }
            else
            {
                where = colNames + " = ''" + colValues + "''";
            }
            string mSql = " DELETE OPENQUERY (" + oraLinkName + ", 'SELECT " + colNames + " FROM " + tableName + " WHERE " + where + "')  ;";
            object recordsAffected;
            recordsAffected = ExecSql(connStr, mSql);
            return recordsAffected;

        }

 
        #endregion




    }
}
