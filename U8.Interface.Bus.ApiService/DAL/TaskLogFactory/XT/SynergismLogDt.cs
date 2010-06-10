using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using U8.Interface.Bus.DBUtility;

namespace U8.Interface.Bus.ApiService.DAL
{
    /// <summary>
    /// HY_DZ_K7_SYNERGISMLOGDT
    /// 
    /// </summary>
    public partial class SynergismLogDt : DAL.TaskLogFactory.ITaskLogDetail
    {

        public bool Exists( int autoid,int id, int ilineno, string accid, string cvouchertype, string cvoucherno, string cpk, DateTime dinputtime, DateTime dmaketime, string cerrordesc, string cstatus, int ismanual, int isaudit, int errortimes, int cdealmothed)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from HY_DZ_K7_SYNERGISMLOGDT");
            strSql.Append(" where ");
            strSql.Append(" id = @id and  ");
            strSql.Append(" ilineno = @ilineno and  ");
            strSql.Append(" accid = @accid and  ");
            strSql.Append(" cvouchertype = @cvouchertype and  ");
            strSql.Append(" cvoucherno = @cvoucherno and  ");
            strSql.Append(" cpk = @cpk and  ");
            strSql.Append(" dinputtime = @dinputtime and  ");
            strSql.Append(" dmaketime = @dmaketime and  ");
            strSql.Append(" cerrordesc = @cerrordesc and  ");
            strSql.Append(" cstatus = @cstatus and  ");
            strSql.Append(" ismanual = @ismanual and  ");
            strSql.Append(" isaudit = @isaudit and  ");
            strSql.Append(" errortimes = @errortimes and  ");
            strSql.Append(" cdealmothed = @cdealmothed  ");
            SqlParameter[] parameters = {
					new SqlParameter("@autoid", SqlDbType.Int,4)
			};
            parameters[0].Value = autoid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Synergismlogdt model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into HY_DZ_K7_SYNERGISMLOGDT(");
            strSql.Append("cerrordesc,cstatus,ismanual,isaudit,errortimes,cdealmothed,id,ilineno,accid,cvouchertype,cvoucherno,cpk,dinputtime,dmaketime");
            strSql.Append(") values (");
            strSql.Append("@cerrordesc,@cstatus,@ismanual,@isaudit,@errortimes,@cdealmothed,@id,@ilineno,@accid,@cvouchertype,@cvoucherno,@cpk,@dinputtime,@dmaketime");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@cerrordesc", SqlDbType.NVarChar,1000) ,            
                        new SqlParameter("@cstatus", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@ismanual", SqlDbType.Int,4) ,            
                        new SqlParameter("@isaudit", SqlDbType.Int,4) ,            
                        new SqlParameter("@errortimes", SqlDbType.Int,4) ,            
                        new SqlParameter("@cdealmothed", SqlDbType.Int,4) ,            
                        new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@ilineno", SqlDbType.Int,4) ,            
                        new SqlParameter("@accid", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@cvouchertype", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@cvoucherno", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@cpk", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@dinputtime", SqlDbType.DateTime) ,            
                        new SqlParameter("@dmaketime", SqlDbType.DateTime)             
            };

            parameters[0].Value = model.Cerrordesc;
            parameters[1].Value = model.Cstatus;
            parameters[2].Value = model.Ismanual;
            parameters[3].Value = model.Isaudit;
            parameters[4].Value = model.Errortimes;
            parameters[5].Value = model.Cdealmothed;
            parameters[6].Value = model.Id;
            parameters[7].Value = model.Ilineno;
            parameters[8].Value = model.Accid;
            parameters[9].Value = model.Cvouchertype;
            parameters[10].Value = model.Cvoucherno;
            parameters[11].Value = model.Cpk;
            parameters[12].Value = model.Dinputtime;
            parameters[13].Value = model.Dmaketime;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {

                if (model.Cvoucherno != "")
                {
                    InsSYNERGISMLOGDTID(model);
                }
                return Convert.ToInt32(obj);
            }

        }
        /// <summary>
        /// 写入协同单据的ID值，以便后续单据变号后根据ID更新最新的单据号值
        /// </summary>
        /// <param name="model"></param>
        private void InsSYNERGISMLOGDTID(Model.Synergismlogdt model)
        {
            string ssql = "";
            string ivoucherid = "";
            string sConn = "";
       
            List<Model.Synergismlogdt> ListSyn=new List<Model.Synergismlogdt>() ;
            BLL.SynergisnLogDT LogDTBLL =new BLL.SynergisnLogDT();
            ListSyn = LogDTBLL.GetModelList(" d.id ='" + model.Id + "' and isnull(d.cvoucherno,'')<>'' ");
            for (int i = 0; i < ListSyn.Count; i++)
            {
                StringBuilder strSql = new StringBuilder();
                Model.Synergismlogdt LogDTModel = ListSyn[i];
                sConn = getConnStr(LogDTModel);
                DbHelperSQLP objSql = new DbHelperSQLP(sConn);
                if (sConn == "")
                    continue ;
                switch (LogDTModel.Cvouchertype)
                {
                    case "27":
                        ssql = "select id from PU_AppVouch with(nolock) where cCode='" + LogDTModel.Cvoucherno + "'";
                        break;
                    case "24":
                        ssql = "select id from RdRecord01 with(nolock) where cCode='" + LogDTModel.Cvoucherno + "'";
                        break;
                    case "88":
                        ssql = "select POID from PO_Pomain with(nolock) where cPoID='" + LogDTModel.Cvoucherno + "'";
                        break;
                    case "0301":
                        ssql = "select id from RdRecord08 with(nolock) where cCode='" + LogDTModel.Cvoucherno + "'";
                        break;
                    case "0302":
                        ssql = "select id from RdRecord09 with(nolock) where cCode='" + LogDTModel.Cvoucherno + "'";
                        break;
                    case "01":
                        ssql = "select dlid from DispatchList with(nolock) where cdlcode='" + LogDTModel.Cvoucherno + "' and bReturnFlag=0";
                        break;
                    case "0303":
                        ssql = "select id from RdRecord32 with(nolock) where cCode='" + LogDTModel.Cvoucherno + "'";
                        break;
                    case "17":
                        ssql = "select id from SO_SOMain with(nolock) where cSoCode='" + LogDTModel.Cvoucherno + "'";
                        break;
                    case "26":
                        ssql = "select id from PU_ArrivalVouch with(nolock) where cCode='" + LogDTModel.Cvoucherno + "'";
                        break;
                    case "03":
                        ssql = "select dlid from DispatchList with(nolock) where cdlcode='" + LogDTModel.Cvoucherno + "' and bReturnFlag=1";
                        break;
                    default:
                        ssql = "";
                        break;
                }
                if (ssql != "")
                {
                    DataSet ds = objSql.Query(ssql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ivoucherid = ds.Tables[0].Rows[0][0].ToString();

                        DataSet dsC = DbHelperSQL.Query("select top 1 1 from HY_DZ_K7_SYNERGISMLOGDTID with(nolock) where ivoucherid='" + ivoucherid + "' and cvouchtype='" + LogDTModel.Cvouchertype + "' and accid='" + LogDTModel.Accid + "'");
                        if (dsC.Tables[0].Rows.Count > 0)
                        {
                            continue;
                        }

                        strSql.Append("insert into HY_DZ_K7_SYNERGISMLOGDTID(");
                        strSql.Append("autoid,accid,cvouchtype,cvoucherno,ivoucherid");
                        strSql.Append(") values (");
                        strSql.Append("@autoid,@accid,@cvouchtype,@cvoucherno,@ivoucherid");
                        strSql.Append(") ");
                        strSql.Append(";select @@IDENTITY");
                        SqlParameter[] parameters = {
			            new SqlParameter("@autoid", SqlDbType.Int,4) ,            
                        new SqlParameter("@accid", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@cvouchtype", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@cvoucherno", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@ivoucherid", SqlDbType.Int,4)           
                                                 };

                        parameters[0].Value = LogDTModel.Autoid;
                        parameters[1].Value = LogDTModel.Accid;
                        parameters[2].Value = LogDTModel.Cvouchertype;
                        parameters[3].Value = LogDTModel.Cvoucherno;
                        parameters[4].Value = ivoucherid;
                        DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.Synergismlogdt model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update HY_DZ_K7_SYNERGISMLOGDT set ");

            strSql.Append(" cerrordesc = @cerrordesc , ");
            strSql.Append(" cstatus = @cstatus , ");
            strSql.Append(" ismanual = @ismanual , ");
            strSql.Append(" isaudit = @isaudit , ");
            strSql.Append(" errortimes = @errortimes , ");
            strSql.Append(" cdealmothed = @cdealmothed , ");
            strSql.Append(" id = @id , ");
            strSql.Append(" ilineno = @ilineno , ");
            strSql.Append(" accid = @accid , ");
            strSql.Append(" cvouchertype = @cvouchertype , ");
            strSql.Append(" cvoucherno = @cvoucherno , ");
            strSql.Append(" cpk = @cpk , ");
            strSql.Append(" dinputtime = @dinputtime , ");
            strSql.Append(" dmaketime = @dmaketime  ");
            strSql.Append(" where autoid=@autoid ");

            SqlParameter[] parameters = {
			            new SqlParameter("@autoid", SqlDbType.Int,4) ,            
                        new SqlParameter("@cerrordesc", SqlDbType.NVarChar,1000) ,            
                        new SqlParameter("@cstatus", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@ismanual", SqlDbType.Int,4) ,            
                        new SqlParameter("@isaudit", SqlDbType.Int,4) ,            
                        new SqlParameter("@errortimes", SqlDbType.Int,4) ,            
                        new SqlParameter("@cdealmothed", SqlDbType.Int,4) ,            
                        new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@ilineno", SqlDbType.Int,4) ,            
                        new SqlParameter("@accid", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@cvouchertype", SqlDbType.NVarChar,30) ,            
                        new SqlParameter("@cvoucherno", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@cpk", SqlDbType.NVarChar,200) ,            
                        new SqlParameter("@dinputtime", SqlDbType.DateTime) ,            
                        new SqlParameter("@dmaketime", SqlDbType.DateTime)             
              
            };

            parameters[0].Value = model.Autoid;
            parameters[1].Value = model.Cerrordesc;
            parameters[2].Value = model.Cstatus;
            parameters[3].Value = model.Ismanual;
            parameters[4].Value = model.Isaudit;
            parameters[5].Value = model.Errortimes;
            parameters[6].Value = model.Cdealmothed;
            parameters[7].Value = model.Id;
            parameters[8].Value = model.Ilineno;
            parameters[9].Value = model.Accid;
            parameters[10].Value = model.Cvouchertype;
            parameters[11].Value = model.Cvoucherno;
            parameters[12].Value = model.Cpk;
            parameters[13].Value = model.Dinputtime;
            parameters[14].Value = model.Dmaketime;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

            if (model.Cvoucherno != "")
            {
                InsSYNERGISMLOGDTID(model);
            }
            return rows;
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int autoid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from HY_DZ_K7_SYNERGISMLOGDT ");
            strSql.Append(" where autoid=@autoid");
            SqlParameter[] parameters = {
					new SqlParameter("@autoid", SqlDbType.Int,4)
			};
            parameters[0].Value = autoid;


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
        public bool DeleteList(string autoidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from HY_DZ_K7_SYNERGISMLOGDT ");
            strSql.Append(" where ID in (" + autoidlist + ")  ");
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
        /// 得到一个对象实体
        /// </summary>
        public Model.Synergismlogdt GetModel(string autoid,BLL.BaseOp op)
        {
           return GetModel(autoid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Synergismlogdt GetModel(string autoid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select autoid, cerrordesc, cstatus, ismanual, isaudit, errortimes, cdealmothed, id, ilineno, accid, cvouchertype, cvoucherno, cpk, dinputtime, dmaketime ,fatherid ");
            strSql.Append("  from HY_DZ_K7_SYNERGISMLOGDT ");
            strSql.Append(" where autoid=@autoid");
            SqlParameter[] parameters = {
					new SqlParameter("@autoid", SqlDbType.Int,4)
			};
            parameters[0].Value = autoid;


            Model.Synergismlogdt model = new Model.Synergismlogdt();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["autoid"].ToString() != "")
                {
                    model.Autoid = ds.Tables[0].Rows[0]["autoid"].ToString();  //int.Parse(ds.Tables[0].Rows[0]["autoid"].ToString());
                }
                model.Cerrordesc = ds.Tables[0].Rows[0]["cerrordesc"].ToString();
                model.Cstatus = ds.Tables[0].Rows[0]["cstatus"].ToString();
                if (ds.Tables[0].Rows[0]["ismanual"].ToString() != "")
                {
                    model.Ismanual = int.Parse(ds.Tables[0].Rows[0]["ismanual"].ToString());
                }
                if (ds.Tables[0].Rows[0]["isaudit"].ToString() != "")
                {
                    model.Isaudit = int.Parse(ds.Tables[0].Rows[0]["isaudit"].ToString());
                }
                if (ds.Tables[0].Rows[0]["errortimes"].ToString() != "")
                {
                    model.Errortimes = int.Parse(ds.Tables[0].Rows[0]["errortimes"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cdealmothed"].ToString() != "")
                {
                    model.Cdealmothed = int.Parse(ds.Tables[0].Rows[0]["cdealmothed"].ToString());
                }
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                   // model.Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                    model.Id =  ds.Tables[0].Rows[0]["id"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ilineno"].ToString() != "")
                {
                    model.Ilineno = int.Parse(ds.Tables[0].Rows[0]["ilineno"].ToString());
                }
                model.Accid = ds.Tables[0].Rows[0]["accid"].ToString();
                model.Cvouchertype = ds.Tables[0].Rows[0]["cvouchertype"].ToString();
                model.Cvoucherno = ds.Tables[0].Rows[0]["cvoucherno"].ToString();
                model.Cpk = ds.Tables[0].Rows[0]["cpk"].ToString();
                if (ds.Tables[0].Rows[0]["dinputtime"].ToString() != "")
                {
                    model.Dinputtime = DateTime.Parse(ds.Tables[0].Rows[0]["dinputtime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["dmaketime"].ToString() != "")
                {
                    model.Dmaketime = DateTime.Parse(ds.Tables[0].Rows[0]["dmaketime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["fatherid"].ToString() != "")
                {
                    model.Fatherid = int.Parse(ds.Tables[0].Rows[0]["fatherid"].ToString());
                }

           

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
            strSql.Append("select isnull( b.cbillname,d.cvouchertype)  as cvouchertypename , d.*,r.cacc_id,r.cdatabase AS accname  ");
            strSql.Append("from HY_DZ_K7_SYNERGISMLOGDT d left join HY_DZ_K7_BILLSCOPE b on d.cvouchertype=b.cardnum ");
            strSql.Append(" JOIN HY_DZ_K7_REGIST r ON d.accid=r.acccode ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
                if (strWhere.ToLower().IndexOf(" order") <= 0 && strWhere.ToLower().IndexOf(" by") <= 0)
                    strSql.Append(" order by  ilineno ");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string order, string ascOrDesc)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ISNULL( b.cbillname,d.cvouchertype)  AS cvouchertypename , d.* ,r.cdatabase AS accname ");
            strSql.Append(" FROM HY_DZ_K7_SYNERGISMLOGDT d LEFT JOIN HY_DZ_K7_BILLSCOPE b ON d.cvouchertype=b.cardnum ");
            strSql.Append(" JOIN HY_DZ_K7_REGIST r ON d.accid=r.acccode ");
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

        public string getConnStr(Model.Synergismlogdt dt)
        {
            DAL.Regist rdal = new Regist();
            Model.Regist rmdoel = rdal.GetModel(dt.Accid);
            if (rmdoel != null)
            {
                return string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID=sa;Password={2};Current Language=Simplified Chinese", rmdoel.Caddress, rmdoel.Caccname, rmdoel.Cdbpwd);
            }
            else
            {
                return "";
            }
        }

      
        /// <summary>
        /// 获取当前任务的数据库连接串
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public Model.ConnectInfo GetConnectInfo(Model.Synergismlogdt dt)
        { 
            
            DAL.Regist rdal = new Regist();
            Model.Regist rmdoel = rdal.GetModel(dt.Accid);
            if (rmdoel != null)
            {

                Model.ConnectInfo cimodel = new Model.ConnectInfo();
                cimodel.AccId = rmdoel.Cacc_id;
                cimodel.Source = rmdoel.Datasource;
                cimodel.Password = rmdoel.Cpassword;
                cimodel.Srv = rmdoel.Caddress;
                //应用服务器 add by wangdd
                cimodel.sSrv = rmdoel.Cservername;
                cimodel.SubId = "DP";  //测试
                cimodel.UserId = rmdoel.Cuser_id;
                cimodel.YearId = rmdoel.Ibeginyear.ToString();
                cimodel.Serial = BLL.Common.GetSerial();
                cimodel.BEnable = rmdoel.Benable == "1" || rmdoel.Benable == "是";
                cimodel.Constring = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID=sa;Password={2};Current Language=Simplified Chinese", rmdoel.Caddress, rmdoel.Caccname, rmdoel.Cdbpwd);
                cimodel.Date = BLL.Common.GetVerifyData(dt);
                if (cimodel.Date == DateTime.Now.ToString("yyyy-MM-dd")) cimodel.Date = BLL.Common.GetLoginDate(rmdoel);

                return cimodel;
            
            }
            return null;


        }

        public Model.ConnectInfo getConnectStr(Model.Synergismlogdt dt)
        {

            DAL.Regist rdal = new Regist();
            Model.Regist rmdoel = rdal.GetModel(dt.Accid);
            if (rmdoel != null)
            {

                Model.ConnectInfo cimodel = new Model.ConnectInfo();
                cimodel.AccId = rmdoel.Cacc_id;
                cimodel.Source = rmdoel.Datasource;
                cimodel.Password = rmdoel.Cpassword;
                cimodel.Srv = rmdoel.Caddress;
                //应用服务器 add by wangdd
                cimodel.sSrv = rmdoel.Cservername;
                cimodel.SubId = "DP";  //测试
                cimodel.UserId = rmdoel.Cuser_id;
                cimodel.YearId = rmdoel.Ibeginyear.ToString();
                cimodel.Serial = BLL.Common.GetSerial();
                cimodel.BEnable = rmdoel.Benable == "1" || rmdoel.Benable == "是";
                cimodel.Constring = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID=sa;Password={2};Current Language=Simplified Chinese", rmdoel.Caddress, rmdoel.Caccname, rmdoel.Cdbpwd);

                return cimodel;

            }
            return null;


        }


        /// <summary>
        /// 获取上一条
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public Model.Synergismlogdt GetPrevious(Model.Synergismlogdt dt)
        {
           
            string where = " ilineno=" + (dt.Ilineno - 1).ToString() + " and id=" + dt.Id;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select autoid, cerrordesc, cstatus, ismanual, isaudit, errortimes, cdealmothed, id, ilineno, accid, cvouchertype, cvoucherno, cpk, dinputtime, dmaketime ,fatherid ");
            strSql.Append("  from HY_DZ_K7_SYNERGISMLOGDT ");
            strSql.Append(" where ");
            strSql.Append(where);


            Model.Synergismlogdt model = new Model.Synergismlogdt();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["autoid"].ToString() != "")
                {
                    model.Autoid = ds.Tables[0].Rows[0]["autoid"].ToString(); //int.Parse(ds.Tables[0].Rows[0]["autoid"].ToString());
                }
                model.Cerrordesc = ds.Tables[0].Rows[0]["cerrordesc"].ToString();
                model.Cstatus = ds.Tables[0].Rows[0]["cstatus"].ToString();
                if (ds.Tables[0].Rows[0]["ismanual"].ToString() != "")
                {
                    model.Ismanual = int.Parse(ds.Tables[0].Rows[0]["ismanual"].ToString());
                }
                if (ds.Tables[0].Rows[0]["isaudit"].ToString() != "")
                {
                    model.Isaudit = int.Parse(ds.Tables[0].Rows[0]["isaudit"].ToString());
                }
                if (ds.Tables[0].Rows[0]["errortimes"].ToString() != "")
                {
                    model.Errortimes = int.Parse(ds.Tables[0].Rows[0]["errortimes"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cdealmothed"].ToString() != "")
                {
                    model.Cdealmothed = int.Parse(ds.Tables[0].Rows[0]["cdealmothed"].ToString());
                }
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    //model.Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                    model.Id =  ds.Tables[0].Rows[0]["id"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ilineno"].ToString() != "")
                {
                    model.Ilineno = int.Parse(ds.Tables[0].Rows[0]["ilineno"].ToString());
                }
                model.Accid = ds.Tables[0].Rows[0]["accid"].ToString();
                model.Cvouchertype = ds.Tables[0].Rows[0]["cvouchertype"].ToString();
                model.Cvoucherno = ds.Tables[0].Rows[0]["cvoucherno"].ToString();
                model.Cpk = ds.Tables[0].Rows[0]["cpk"].ToString();
                if (ds.Tables[0].Rows[0]["dinputtime"].ToString() != "")
                {
                    model.Dinputtime = DateTime.Parse(ds.Tables[0].Rows[0]["dinputtime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["dmaketime"].ToString() != "")
                {
                    model.Dmaketime = DateTime.Parse(ds.Tables[0].Rows[0]["dmaketime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["fatherid"].ToString() != "")
                {
                    model.Fatherid = int.Parse(ds.Tables[0].Rows[0]["fatherid"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取第一条数据
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public Model.Synergismlogdt GetFirst(Model.Synergismlogdt dt)
        {

            string where = " fatherid is null and id=" + U8.Interface.Bus.Comm.Convert.ConvertDbValueFromPro(dt.Id,"string");
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select autoid, cerrordesc, cstatus, ismanual, isaudit, errortimes, cdealmothed, id, ilineno, accid, cvouchertype, cvoucherno, cpk, dinputtime, dmaketime ,fatherid ");
            strSql.Append("  from HY_DZ_K7_SYNERGISMLOGDT ");
            strSql.Append(" where ");
            strSql.Append(where);


            Model.Synergismlogdt model = new Model.Synergismlogdt();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["autoid"].ToString() != "")
                {
                    model.Autoid =  ds.Tables[0].Rows[0]["autoid"].ToString();  //int.Parse(ds.Tables[0].Rows[0]["autoid"].ToString());
                }
                model.Cerrordesc = ds.Tables[0].Rows[0]["cerrordesc"].ToString();
                model.Cstatus = ds.Tables[0].Rows[0]["cstatus"].ToString();
                if (ds.Tables[0].Rows[0]["ismanual"].ToString() != "")
                {
                    model.Ismanual = int.Parse(ds.Tables[0].Rows[0]["ismanual"].ToString());
                }
                if (ds.Tables[0].Rows[0]["isaudit"].ToString() != "")
                {
                    model.Isaudit = int.Parse(ds.Tables[0].Rows[0]["isaudit"].ToString());
                }
                if (ds.Tables[0].Rows[0]["errortimes"].ToString() != "")
                {
                    model.Errortimes = int.Parse(ds.Tables[0].Rows[0]["errortimes"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cdealmothed"].ToString() != "")
                {
                    model.Cdealmothed = int.Parse(ds.Tables[0].Rows[0]["cdealmothed"].ToString());
                }
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    //model.Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                    model.Id =  ds.Tables[0].Rows[0]["id"].ToString();
                }
                if (ds.Tables[0].Rows[0]["fatherid"].ToString() != "")
                {
                    model.Fatherid = int.Parse(ds.Tables[0].Rows[0]["fatherid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ilineno"].ToString() != "")
                {
                    model.Ilineno = int.Parse(ds.Tables[0].Rows[0]["ilineno"].ToString());
                }
                model.Accid = ds.Tables[0].Rows[0]["accid"].ToString();
                model.Cvouchertype = ds.Tables[0].Rows[0]["cvouchertype"].ToString();
                model.Cvoucherno = ds.Tables[0].Rows[0]["cvoucherno"].ToString();
                model.Cpk = ds.Tables[0].Rows[0]["cpk"].ToString();
                if (ds.Tables[0].Rows[0]["dinputtime"].ToString() != "")
                {
                    model.Dinputtime = DateTime.Parse(ds.Tables[0].Rows[0]["dinputtime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["dmaketime"].ToString() != "")
                {
                    model.Dmaketime = DateTime.Parse(ds.Tables[0].Rows[0]["dmaketime"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }


    }
}

