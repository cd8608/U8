using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient; 
using System.Data;
using U8.Interface.Bus.DBUtility;

namespace U8.Interface.Bus.ApiService.DAL
{
    public class DLLReflect
    {
        private string _tablename = "MES_Comm_DLLReflect";  //MES_CQ_DLLReflect
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.DLLReflect GetModel(string where)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select tasktype,id, cvouchertype, Dllpath, Namespace, ClassName, ClassType  ");
            strSql.Append("  from " + _tablename);
            strSql.Append(" where ");
            strSql.Append(where);
            Model.DLLReflect model = new Model.DLLReflect();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.TaskType = int.Parse(ds.Tables[0].Rows[0]["tasktype"].ToString());
                model.Cvouchertype = ds.Tables[0].Rows[0]["cvouchertype"].ToString();
                model.Dllpath = ds.Tables[0].Rows[0]["Dllpath"].ToString();
                model.Npace = ds.Tables[0].Rows[0]["Namespace"].ToString();
                model.ClassName = ds.Tables[0].Rows[0]["ClassName"].ToString();
                model.ClassType = ds.Tables[0].Rows[0]["ClassType"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
