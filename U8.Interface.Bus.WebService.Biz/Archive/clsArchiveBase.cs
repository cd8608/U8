using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

using System.IO;
using System.Xml;

using U8.Interface.Bus.DBUtility;

namespace U8.Interface.Bus.WebService.Biz.Archive
{
    public class clsArchiveBase
    { 
        protected string tableName;
        protected string priKeyName;
        protected string priKeyValue;
        public string connStr;
        public System.Text.Encoding textEncode = Encoding.UTF8;

        protected UfDBUtility uf = new UfDBUtility();

        #region 接口方法
        public virtual bool GetList(out string DocList, out string ErrMsg)
        {
            if (string.IsNullOrEmpty(connStr))
            {
                ErrMsg = "数据库连接串为空!";
                DocList = null;
                return false; 
            }
            try
            {
                string sqlWhere;
                if (string.IsNullOrEmpty(priKeyValue))
                {
                    //sqlWhere = "";
                    sqlWhere = " WHERE ISNULL(cMesRecErrCode,'') = ''  "; 
                }
                else
                {
                    sqlWhere = " WHERE " + priKeyName + " ='" + priKeyValue + "' AND ISNULL(cMesRecErrCode,'') = '' ";
                }
                string sql = " SELECT * FROM " + tableName + " WITH(NOLOCK) " + sqlWhere;
                DataTable dt = new DataTable();
                dt = uf.UFSelect(connStr, sql);
                DocList = ConvertDataTableToXML(dt);
                ErrMsg = null;
                return true;
            }
            catch
            {
                ErrMsg = "数据库执行出错!";
                DocList = null;
                return false;
            }
           
        }

        /// <param name="ID">XML串，返回部门处理信息列表</param>
        /// <param name="ErrMsg">返回的错误码，当函数返回类型为FALSE有值</param>
        public virtual bool Delete(string ID, out string ErrMsg)
        {
            if (string.IsNullOrEmpty(connStr))
            {
                ErrMsg = "数据库连接串为空!"; 
                return false;
            }
            try
            {
                System.IO.MemoryStream sr = new System.IO.MemoryStream();
                string sqlWhere;
                if (string.IsNullOrEmpty(priKeyValue))
                {
                    sqlWhere = "";
                }
                else
                {
                    //sqlWhere = " WHERE " + priKeyName + " ='" + priKeyValue + "'";
                    sqlWhere = " WHERE ID =" + ID ;
                }
                string sql = " DELETE FROM " + tableName + " " + sqlWhere;
                DataTable dt = new DataTable();
                object res = uf.ExecSql(connStr, sql);
                ErrMsg = null;
                return true;
            }
            catch
            {
                ErrMsg = "数据库执行出错!";
                return false;
            }
        }
  
        /// <summary>
        /// 状态修改
        /// </summary>
        /// <param name="connstr"></param>
        /// <param name="ErrorCode"></param>
        /// <param name="ErrorMsg"></param>
        /// <param name="ErrMsg"></param>
        /// <returns></returns>
        public virtual int Update(string connstr,string keyValue,string ErrorCode, string ErrorMsg, out string ErrMsg)
        {

            if (string.IsNullOrEmpty(connStr))
            {
                ErrMsg = "数据库连接串为空!";
                return -1;
            }
            try
            {
                ErrMsg = null;
                string sql = " UPDATE " + tableName + " SET cMesRecErrCode = '" + ErrorCode + "' , cMesRecErrDesc = '" + ErrorMsg + "'";
                if (string.IsNullOrEmpty(keyValue))
                {
                }
                else
                {
                    sql += " WHERE " + priKeyName + " ='" + keyValue + "' ";
                }
                object records = uf.ExecSql(connStr, sql);
                return 1;
            }
            catch(Exception ee) {

                ErrMsg = "Update操作,数据库执行出错!" + ee.ToString();
                return -1;
            }
        }


        /// <summary>
        /// 插入中间表
        /// </summary>
        /// <param name="DocList">XML格式数据</param>
        /// <param name="ErrMsg">返回的错误信息</param>
        /// <returns></returns>
        public virtual bool Insert(string DocList,out string ErrMsg)
        {

            if (string.IsNullOrEmpty(connStr))
            {
                ErrMsg = "数据库连接串为空!";
                return false;
            }
            if (string.IsNullOrEmpty(DocList))
            {
                ErrMsg = "参数DocList为空!";
                return false;
            }

            DataSet ds = new DataSet();
            ds = ConvertXMLToDataSet(DocList);
            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                ErrMsg = "DocList格式不合法!";
                return false;
            }

            StringBuilder sbName = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();

            StringBuilder sql = new StringBuilder();
            
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                {
                    sbName.Append(ds.Tables[0].Columns[j].ColumnName.ToString() + ",");
                    string tempValue = U8.Interface.Bus.Comm.Convert.ConvertDbValueFromPro(ds.Tables[0].Rows[i][j].ToString(), ds.Tables[0].Columns[j].DataType.Name.ToLower());
                    sbValue.Append(tempValue + ",");
                }
                sql.Append(" INSERT INTO " + tableName + " ( " + sbName.ToString().Substring(0, sbName.Length - 1) + " ) ");
                sql.Append(" VALUES ");
                sql.Append(" ( " + sbValue.ToString().Substring(0, sbValue.Length - 1) + ")");

                sbName.Remove(0, sbName.Length);
                sbValue.Remove(0, sbValue.Length);

            }

            if (sql.Length > 0)
            {
                try
                {
                    object res = uf.ExecSql(connStr, sql.ToString());
                    if ((bool)res)
                    {
                        ErrMsg = null;
                        return true;
                    }
                    else
                    {
                        ErrMsg = "没有插入任何数据";
                        return false;
                    }
                }
                catch (Exception ee)
                {
                    ErrMsg = "Insert 插入错误!" + ee.ToString();
                    return false;
                }
            }
            else
            {
                ErrMsg = "没有插入任何数据";
                return false;
            }
        }

        #endregion


        #region 常用方法
        private string ConvertDataTableToXML(DataTable xmlDS)
        {

            MemoryStream stream = null;
            XmlTextWriter writer = null;

            try
            {

                stream = new MemoryStream(); 
                //writer = new XmlTextWriter(stream, Encoding.Default);
                writer = new XmlTextWriter(stream, textEncode);
                xmlDS.WriteXml(writer);
                int count = (int)stream.Length;
                byte[] arr = new byte[count];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(arr, 0, count);
                UTF8Encoding utf = new UTF8Encoding();
                return utf.GetString(arr).Trim();

            }

            catch
            {
                return String.Empty; 
            }

            finally
            { 
                if (writer != null) writer.Close(); 
            }

        }
        protected DataSet ConvertXMLToDataSet(string xmlData)
        {
            StringReader stream = null;
            XmlTextReader reader = null; 
            try
            { 
                DataSet xmlDS = new DataSet(); 
                stream = new StringReader(xmlData); 
                reader = new XmlTextReader(stream); 
                xmlDS.ReadXml(reader); 
                return xmlDS; 
            } 
            catch (Exception ex)
            { 
                string strTest = ex.Message; 
                return null; 
            } 
            finally
            { 
                if (reader != null) 
                    reader.Close(); 
            }

        }
        #endregion

    }
}
