using System;
using System.Data;
using System.Data.SqlClient;

namespace U8.Interface.Bus.DBUtility
{
    public class SQLHelper
    {
        #region 执行非查询SQL语句

        /// <summary>
        /// 执行非查询SQL语句
        /// </summary>
        /// <param name="sqlString">sqll语句</param>
        /// <param name="connectionString"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        static public int ExecuteSql(string sqlString, string connectionString, out string errMsg)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            errMsg = "";
            int res;
            conn.ConnectionString = connectionString;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return -1;
            }
            cmd.Connection = conn;
            cmd.CommandText = sqlString;
            try
            {
                res = cmd.ExecuteNonQuery();               //执行非查询SQL语句
            }
            catch (Exception ex)
            {
                errMsg = ex.ToString();
                res = 0;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                    conn = null;
                }
            }
            if (res == 0)
            {
                return -1;
            }
            else
                return 0;
        }
        #endregion

        #region 通过SQL返回DATASET
        /// <summary>
        /// 通过SQL返回DATASET
        /// </summary>
        /// <param name="sqlString">SQL语句</param>
        /// <param name="connectionString">数据库连接语句</param>
        /// <param name="result">返回的DATASET</param>
        /// <param name="errMsg">出错信息</param>
        /// <returns>0：正确 非0：错误</returns>
        static public int GetDataset(string sqlString, string connectionString, out DataSet result, out string errMsg)
        {
            errMsg = "";
            result = new DataSet();
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            conn.ConnectionString = connectionString;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return -1;
            }
            cmd.Connection = conn;
            cmd.CommandText = sqlString;
            adp.SelectCommand = cmd;
            try
            {
                adp.Fill(result);
                return 0;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return -2;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                    conn = null;
                }
            }
        }
        #endregion

        #region 根据sql组更新数据
  
        /// <summary>
        /// 根据sql组更新数据 
        /// </summary>
        /// <param name="SqlArray">sql组</param>
        /// <param name="tabName">表名</param>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="result">返回结果</param>
        /// <param name="errMsg">错误信息</param>
        /// <returns></returns>
        static public int GetDataset(string[] SqlArray, string[] tabName,
 string connectionString, out DataSet result, out string errMsg)
        {
            errMsg = "";
            result = new DataSet();
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter adp = new SqlDataAdapter();
            conn.ConnectionString = connectionString;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return -1;
            }
            cmd.Connection = conn;

            adp.SelectCommand = cmd;
            int itabName = 0;
            try
            {
                foreach (string sql in SqlArray)
                {

                    if (sql == string.Empty)
                    {
                        result.Tables.Add();
                        continue;
                    }
                    cmd.CommandText = sql;
                    adp.Fill(result, tabName[itabName]);
                    itabName++;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return -1;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                    conn = null;
                }
            }
            return 0;
        }
        #endregion

        #region 通通过一个SQL查找一个string数据
        /// <summary>
        /// 通通过一个SQL查找一个string数据
        /// </summary>
        /// <param name="sqlString">sql语句</param>
        /// <param name="connectionString">数据库连接语句</param>
        /// <param name="retString">查找到的string</param>
        /// <param name="errMsg">错误信息</param>
        /// <returns>0正确:非0 错误</returns>
        static public int GetString(string sqlString, string connectionString, out string retString, out string errMsg)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            retString = "";
            errMsg = "";
            conn.ConnectionString = connectionString;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                //errMsg = conn.ConnectionString;
                return -1;
            }
            cmd.Connection = conn;
            cmd.CommandText = sqlString;
            try
            {
                retString = cmd.ExecuteScalar().ToString();
                //执行查询，并返回查询所返回的结果集中第一行的第一列。 忽略其他列或行

            }
            catch (Exception ex)
            {
                errMsg = ex.Message.ToString();
                return -2;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                    conn = null;
                }
            }
            return 0;

        }
        #endregion
    }
}
