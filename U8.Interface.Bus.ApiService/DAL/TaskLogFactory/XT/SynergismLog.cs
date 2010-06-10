using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

using U8.Interface.Bus.DBUtility;

namespace U8.Interface.Bus.ApiService.DAL
{
    //HY_DZ_K7_SYNERGISMLOG
    public partial class SynergismLog : DAL.TaskLogFactory.ITaskLogMain
    {


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Synergismlog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into HY_DZ_K7_SYNERGISMLOG(");
            strSql.Append("cserialno,croutetype,caccid,cvouchertype,cvoucherno,starttime,endtime,cstatus");
            strSql.Append(") values (");
            strSql.Append("@cserialno,@croutetype,@caccid,@cvouchertype,@cvoucherno,@starttime,@endtime,@cstatus");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@cserialno", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@croutetype", SqlDbType.NVarChar,60) ,            
                        new SqlParameter("@caccid", SqlDbType.NVarChar,60) ,            
                        new SqlParameter("@cvouchertype", SqlDbType.NVarChar,60) ,            
                        new SqlParameter("@cvoucherno", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@starttime", SqlDbType.DateTime) ,            
                        new SqlParameter("@endtime", SqlDbType.DateTime) ,            
                        new SqlParameter("@cstatus", SqlDbType.NVarChar,30)             
              
            };

            parameters[0].Value = model.Cserialno;
            parameters[1].Value = model.Croutetype;
            parameters[2].Value = model.Caccid;
            parameters[3].Value = model.Cvouchertype;
            parameters[4].Value = model.Cvoucherno;
            parameters[5].Value = model.Starttime;
            parameters[6].Value = model.Endtime;
            parameters[7].Value = model.Cstatus;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {

                return Convert.ToInt32(obj);

            }

        }



        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.Synergismlog model, BLL.BaseOp op)
        {
            return Update(model);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.Synergismlog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update HY_DZ_K7_SYNERGISMLOG set ");

            strSql.Append(" cserialno = @cserialno , ");
            strSql.Append(" croutetype = @croutetype , ");
            strSql.Append(" caccid = @caccid , ");
            strSql.Append(" cvouchertype = @cvouchertype , ");
            strSql.Append(" cvoucherno = @cvoucherno , ");
            strSql.Append(" starttime = @starttime , ");
            strSql.Append(" endtime = @endtime , ");
            strSql.Append(" cstatus = @cstatus  ");
            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@cserialno", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@croutetype", SqlDbType.NVarChar,60) ,            
                        new SqlParameter("@caccid", SqlDbType.NVarChar,60) ,            
                        new SqlParameter("@cvouchertype", SqlDbType.NVarChar,60) ,            
                        new SqlParameter("@cvoucherno", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@starttime", SqlDbType.DateTime) ,            
                        new SqlParameter("@endtime", SqlDbType.DateTime) ,            
                        new SqlParameter("@cstatus", SqlDbType.NVarChar,30)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.Cserialno;
            parameters[2].Value = model.Croutetype;
            parameters[3].Value = model.Caccid;
            parameters[4].Value = model.Cvouchertype;
            parameters[5].Value = model.Cvoucherno;
            parameters[6].Value = model.Starttime;
            parameters[7].Value = model.Endtime;
            parameters[8].Value = model.Cstatus;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            return rows;
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from HY_DZ_K7_SYNERGISMLOG ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;


            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from HY_DZ_K7_SYNERGISMLOG ");
            strSql.Append(" where ID in (" + idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        /// <summary>
        ///  
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public Model.Synergismlog GetModel(string autoid, BLL.BaseOp op)
        {
            return GetModel(autoid.ToString());
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Synergismlog GetModel(string id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, cserialno, croutetype, caccid, cvouchertype, cvoucherno, starttime, endtime, cstatus  ");
            strSql.Append("  from HY_DZ_K7_SYNERGISMLOG ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;


            Model.Synergismlog model = new Model.Synergismlog();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.Id = ds.Tables[0].Rows[0]["id"].ToString(); // int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.Cserialno = ds.Tables[0].Rows[0]["cserialno"].ToString();
                model.Croutetype = ds.Tables[0].Rows[0]["croutetype"].ToString();
                model.Caccid = ds.Tables[0].Rows[0]["caccid"].ToString();
                model.Cvouchertype = ds.Tables[0].Rows[0]["cvouchertype"].ToString();
                model.Cvoucherno = ds.Tables[0].Rows[0]["cvoucherno"].ToString();
                if (ds.Tables[0].Rows[0]["starttime"].ToString() != "")
                {
                    model.Starttime = DateTime.Parse(ds.Tables[0].Rows[0]["starttime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["endtime"].ToString() != "")
                {
                    model.Endtime = DateTime.Parse(ds.Tables[0].Rows[0]["endtime"].ToString());
                }
                model.Cstatus = ds.Tables[0].Rows[0]["cstatus"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 200 HY_DZ_K7_SYNERGISMLOG.*,r.cacc_id,r.cdatabase AS accname  ");
            strSql.Append(" FROM HY_DZ_K7_SYNERGISMLOG ");
            strSql.Append(" JOIN HY_DZ_K7_REGIST r ON HY_DZ_K7_SYNERGISMLOG.caccid=r.acccode ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
                strSql.Append(" order by  id asc");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetList(int Top, string strWhere, string order, string ascOrDesc)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM HY_DZ_K7_SYNERGISMLOG ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (!string.IsNullOrEmpty(order))
            {
                strSql.Append(string.Format(" order by  {0} {1}", order, ascOrDesc));
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM HY_DZ_K7_SYNERGISMLOG ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 获得服务数据列表
        /// </summary>
        public DataSet GetServiceList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP 200 s.*,r.cacc_id,r.cdatabase AS accname ");
            strSql.Append(" FROM HY_DZ_K7_SYNERGISMLOG s ");
            strSql.Append(" JOIN HY_DZ_K7_SYNERGISMLOGDT d ON s.id=d.id ");
            strSql.Append(" JOIN HY_DZ_K7_REGIST r ON s.caccid=r.acccode ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
                strSql.Append(" order by  s.id asc");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }



    }
}
