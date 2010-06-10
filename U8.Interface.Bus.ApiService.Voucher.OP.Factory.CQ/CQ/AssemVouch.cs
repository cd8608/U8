using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using U8.Interface.Bus;
using U8.Interface.Bus.Comm;
using U8.Interface.Bus.ApiService;

using U8.Interface.Bus.ApiService.Model;
using U8.Interface.Bus.ApiService.BLL;
using U8.Interface.Bus.ApiService.DAL;
using U8.Interface.Bus.DBUtility;


namespace U8.Interface.Bus.ApiService.Voucher.OP.Factory.CQ
{
    /// <summary>
    /// 组装单(HY_DZ_K7_DLLReflect预置的op类)
    /// </summary>
    public class AssemVouch : StockOP
    {


        private int tasktype = 0;

        /// <summary>
        /// 来源
        /// </summary>
        private string sourceCardNo = "";
        private string sourceHeadTable = "";
        private string sourceBodyTable = "";
        private string sourceVoucherNoColumnName = "cAVCode";

        /// <summary>
        /// 目标
        /// </summary>
        private string voucherNoColumnName = "cAVCode";
        private string cardNo = "0308";
        private string headtable = "MES_CQ_AssemVouch";
        private string bodytable = "MES_CQ_AssemVouchs";
        private string voucherTypeName = "组装单";


        private string taskStatusflagColName = "operflag";

        public override string SetTableName()
        {
            return "AssemVouch";
        }

        public override string SetVouchType()
        {
            return "13";
        }


        public override string SetApiAddressAdd()
        {
            return "U8API/GroupVouch/Add";
        }

        public override string SetApiAddressAudit()
        {
            return "U8API/GroupVouch/Audit";
        }

        public override string SetApiAddressCancelAudit()
        {
            return "U8API/GroupVouch/CancelAudit";
        }

        public override string SetApiAddressDelete()
        {
            return "U8API/GroupVouch/Delete";
        }

        public override string SetApiAddressLoad()
        {
            return "U8API/GroupVouch/Load";
        }

        public override string SetApiAddressUpdate()
        {
            throw new NotImplementedException();
        }

        #region 普通操作

        public override TaskList GetTask()
        {
            string sql = "SELECT * FROM " + headtable + " WHERE operflag = 0 "; 
            string curid = "";  
            DataTable dt = new DataTable();
            dt = DbHelperSQL.Query(sql).Tables[0];
            if (null == dt || dt.Rows.Count == 0)
            {
                return null;
            }
            TaskList tl = new TaskList();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Task t = new Task();
                VoucherType v = new VoucherType();
                v.SourceCardNo = sourceCardNo;
                v.SourceVoucherNo = dt.Rows[i][sourceVoucherNoColumnName].ToString();
                v.CardNo = cardNo;
                v.VoucherName = "组装单"; 
                t.VouchType = v;
                t.taskType = 0;   //MES接口任务  
                t.OperType = (int)dt.Rows[i]["OperType"];
                try
                {
                    t.id = dt.Rows[i]["id"].ToString(); // int.Parse(dt.Rows[i]["id"].ToString());
                }
                catch (Exception ee)
                {
                    BLL.Common.ErrorMsg(SysInfo.productName, "id 值出错！");
                }
                try
                {
                    t.OperType = int.Parse(dt.Rows[i]["opertype"].ToString());
                }
                catch (Exception ee)
                {
                    BLL.Common.ErrorMsg(SysInfo.productName, "opertype 值出错！");
                }
                tl.Add(t);
                curid += "'" + t.id + "'";
            }
            if (!string.IsNullOrEmpty(curid))
            {
                string msql = " update " + headtable + " set " + taskStatusflagColName + " = 2 where id in (" + curid + ") ";
                DbHelperSQL.ExecuteSql(msql);
            }
            return tl;
        }


        /// <summary>
        /// ID CODE 互查
        /// </summary>
        /// <param name="strID"></param>
        /// <param name="bd"></param>
        /// <param name="codeorid"></param>
        /// <returns></returns>
        public override string GetCodeorID(string strID, BaseData bd, string codeorid)
        {
            string sqlstr = string.Empty;
            if (codeorid == "id")
            {
                sqlstr = "select isnull(id,'') from AssemVouch  with(nolock)  where cAVCode ='" + strID + "'";
            }
            if (codeorid == "code")
            {
                sqlstr = "select isnull(cAVCode,'') from AssemVouch  with(nolock)  where id ='" + strID + "'";
            }
            Model.APIData apidata = bd as Model.APIData;

            DBUtility.DbHelperSQLP sqlp = new DBUtility.DbHelperSQLP(apidata.ConnectInfo.Constring);
            string ret = sqlp.GetSingle(sqlstr).NullToString();
            BLL.Common.ErrorMsg(ret, "未能获取" + voucherTypeName + "ID或单号");
            return ret;
        }

        public override bool CheckAuditStatus(string strVoucherNo, string strConn)
        {
            return false;
        }

        #endregion


        #region 获取任务实体

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="autoid"> ID</param>
        /// <returns></returns>
        public override Model.Synergismlog GetLogModel(string autoid)
        {
            Model.Synergismlog tmpd = new Synergismlog(); 
            tmpd.Id = autoid;
            tmpd.Cvouchertype = cardNo; 
            tmpd.Cstatus = U8.Interface.Bus.ApiService.DAL.Constant.SynerginsLog_Cstatus_NoDeal;
            DataSet ds = DbHelperSQL.Query("SELECT t." + voucherNoColumnName + ",t.id,t.opertype FROM " + headtable + " t with(nolock)  WHERE t.id = " + autoid);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                tmpd.Cvoucherno = ds.Tables[0].Rows[i][voucherNoColumnName].ToString();
                tmpd.Id = ds.Tables[0].Rows[i]["id"].ToString(); // int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                //tmpd.Cdealmothed = int.Parse(ds.Tables[0].Rows[i]["opertype"].ToString()) + 1; // 0(自动生单/自动审核) 1增 2修改 3删
            }
            return tmpd;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="autoid">子任务ID</param>
        /// <returns></returns>
        public override Model.Synergismlogdt GetModel(string autoid)
        {
            Model.Synergismlogdt tmpd = new Synergismlogdt();
            tmpd.Autoid = autoid;
            tmpd.Id = autoid;
            tmpd.Cvouchertype = cardNo;
            tmpd.Ilineno = 2;
            tmpd.Cstatus = U8.Interface.Bus.ApiService.DAL.Constant.SynerginsLog_Cstatus_NoDeal; 
            DataSet ds = DbHelperSQL.Query("SELECT t." + voucherNoColumnName + ",t.id,t.opertype FROM " + headtable + " t with(nolock)  WHERE t.id = " + U8.Interface.Bus.Comm.Convert.ConvertDbValueFromPro(autoid,"string"));
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                tmpd.Cvoucherno = ds.Tables[0].Rows[i][voucherNoColumnName].ToString();
                tmpd.Autoid = ds.Tables[0].Rows[i]["id"].ToString(); // int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                tmpd.Id = ds.Tables[0].Rows[i]["id"].ToString(); // int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                tmpd.Cdealmothed = int.Parse(ds.Tables[0].Rows[i]["opertype"].ToString()) + 1; // 0(自动生单/自动审核) 1增 2修改 3删
            }
            return tmpd;
        }



        public override Synergismlogdt GetFirst(Synergismlogdt dt)
        {
            Model.Synergismlogdt fdt = new Model.Synergismlogdt();
            fdt.Cvouchertype = sourceCardNo;
            fdt.Id = dt.Id;
            fdt.Ilineno = 1;
            //DataSet ds = DbHelperSQL.Query("SELECT cSoCode FROM " + headtable + " with(nolock) WHERE ID = " + dt.Id);
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    fdt.Cvoucherno = ds.Tables[0].Rows[i]["cSoCode"].ToString();
                fdt.Autoid = dt.Id;
            //}
            return fdt;

        }



        /// <summary>
        /// 获取上一结点
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public override Model.Synergismlogdt GetPrevious(Model.Synergismlogdt dt)
        {
            if (dt.Cvouchertype == cardNo)
            {
                Model.Synergismlogdt pdt = new Model.Synergismlogdt();
                pdt.Cvouchertype = sourceCardNo;
                pdt.Id = dt.Id;
                //DataSet ds = DbHelperSQL.Query("SELECT cSoCode FROM " + headtable + " with(nolock) WHERE ID = " + dt.Id);
                //for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
                //{
                    //pdt.Cvoucherno = ds.Tables[0].Rows[i]["cSoCode"].ToString();
                    pdt.Autoid = dt.Id;
                //} 
                return pdt;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获取下一任务结点
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public override List<Model.Synergismlogdt> GetNext(Model.Synergismlogdt dt)
        { 
            List<Model.Synergismlogdt> logdt = new List<U8.Interface.Bus.ApiService.Model.Synergismlogdt>();
            if (dt.Ilineno == 1)
            {
                Model.Synergismlogdt tmpd = new Synergismlogdt();
                tmpd.Id = dt.Id;
                tmpd.Cvouchertype = cardNo; 
                tmpd.Ilineno = 2;
                tmpd.Cstatus = U8.Interface.Bus.ApiService.DAL.Constant.SynerginsLog_Cstatus_NoDeal;
                tmpd.TaskType = tasktype;

                DataSet ds = DbHelperSQL.Query("SELECT t." + voucherNoColumnName + ",t.id,t.opertype FROM " + headtable + " t with(nolock)  WHERE t.id = " + U8.Interface.Bus.Comm.Convert.ConvertDbValueFromPro(dt.Id,"string"));
           
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    tmpd.Cvoucherno = ds.Tables[0].Rows[i][voucherNoColumnName].ToString();
                    tmpd.Autoid = ds.Tables[0].Rows[i]["id"].ToString(); // int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                    tmpd.Cdealmothed = int.Parse(ds.Tables[0].Rows[i]["opertype"].ToString()) + 1; // 0(自动生单/自动审核) 1增 2修改 3删
                } 
                
                logdt.Add(tmpd);
                return logdt;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region 获取来源数据

        /// <summary>
        /// 获取来源表头数据
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="pdt"></param>
        /// <param name="apidata"></param>
        /// <returns></returns>
        public override System.Data.DataSet SetFromTabet(Model.Synergismlogdt dt, Model.Synergismlogdt pdt, Model.APIData apidata)
        {  

            ApiService.DAL.TaskLogFactory.ITaskLogDetail dtdal = ClassFactory.GetITaskLogDetailDAL(apidata.TaskType);
            Model.ConnectInfo cimodel = dtdal.GetConnectInfo(pdt);
             
            string sql = "select ";
            sql += " '" + cimodel.UserId  + "' as cMaker,";
            sql += " '" + System.DateTime.Now.ToString(SysInfo.dateFormat) + "' as dTVDate ";   //移库日期
            sql += ",'" + System.DateTime.Now.ToString(SysInfo.datetimeFormat) + "' as dnmaketime, ";   //制单时间
            sql += " lt.cAVCode as mes_cAVCode ,";
            sql += " lt.cIWhCode as mes_cIWhCode ,";
            sql += " lt.cOWhCode as mes_cOWhCode ,";
            sql += " lt.cIRdCode as mes_cIRdCode ,";
            sql += " lt.cORdCode as mes_cORdCode, ";
            sql += " lt.cremark as mes_cTVMemo  "; 
            sql += " from   " + bodytable + " lb with(nolock) INNER JOIN " + headtable + " lt with(nolock) on lt.id = lb.id where lt.id ='" + pdt.Id + "' ";
            

            DbHelperSQLP help = new DbHelperSQLP(cimodel.Constring);
            DataSet ds = help.Query(sql);
            BLL.Common.ErrorMsg(ds, "未能获取 表头信息");
            return ds;
 
        }

  
        /// <summary>
        /// 获取来源表体数据
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="pdt"></param>
        /// <param name="apidata"></param>
        /// <returns></returns>
        public override System.Data.DataSet SetFromTabets(Model.Synergismlogdt dt, Model.Synergismlogdt pdt, Model.APIData apidata)
        {

            ApiService.DAL.TaskLogFactory.ITaskLogDetail dtdal = ClassFactory.GetITaskLogDetailDAL(apidata.TaskType);  //new ApiService.DAL.SynergismLogDt();
            Model.ConnectInfo cimodel = dtdal.GetConnectInfo(pdt);

            string sql = "select  ";
            sql += " lt.cAVCode as mes_cAVCode ,";
            sql += " lt.cIWhCode as mes_cIWhCode ,";
            sql += " lt.cOWhCode as mes_cOWhCode ,";
            sql += " lt.cIRdCode as mes_cIRdCode ,";
            sql += " lt.cORdCode as mes_cORdCode, ";
            sql += " lt.cremark as mes_cTVMemo , "; 
            sql += " CASE lb.opertype WHEN 0 THEN 'A' WHEN 1 THEN 'M' WHEN '2' THEN 'D' ELSE 'A' END as editprop, ";
            sql += " lb.cinvcode as mes_cinvcode   ";
            sql += " ,lb.iquantity as MES_iquantity   "; 
            sql += " from   " + bodytable + " lb with(nolock) INNER JOIN " + headtable + " lt with(nolock) on lt.id = lb.id where lt.id ='" + pdt.Id + "' ";
            
            DbHelperSQLP help = new DbHelperSQLP(cimodel.Constring);
            DataSet ds = help.Query(sql);
            BLL.Common.ErrorMsg(ds, "未能获取 表体信息");
            return ds;
        }

        #endregion


        #region update  log


        public override int Update(Model.Synergismlog dt)
        { 
            DateTime? finishTime = new DateTime?(); 
            string operflag = dt.Cstatus;
            
            if (operflag == Constant.SynerginsLog_Cstatus_Complete || operflag == Constant.SynerginsLog_Cstatus_Wait)
            {
                operflag = "1";
                finishTime = DateTime.Now;
            }
            else if (operflag == Constant.SynerginsLog_Cstatus_Error)
            {
                operflag = "3";
            }
            else if (operflag == Constant.SynerginsLog_Cstatus_NoDeal)
            {
                operflag = "0";
            }
            else
            {
                operflag = "2";
            }
             
 
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + headtable + " set ");
            if (!string.IsNullOrEmpty(dt.Cvoucherno))
            {
                strSql.Append(" cAVCode = '" + dt.Cvoucherno + "',  ");

            } 
            if (finishTime == null)
            {
                strSql.Append(" finishTime = null,  ");
            }
            else
            {
                strSql.Append(" finishTime = '" + finishTime + "',  ");
            }
            strSql.Append(" operflag = " + operflag + "  ");
            strSql.Append(" where id= " + U8.Interface.Bus.Comm.Convert.ConvertDbValueFromPro(dt.Id,"string")  + " ");

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());

            return rows;


        }


        //修改日志
        public override int Update(Model.Synergismlogdt dt)
        {

            string operflag = dt.Cstatus;
            if (operflag == Constant.SynergisnLogDT_Cstatus_Complete)
            {
                operflag = "1";
            }
            else if (operflag == Constant.SynergisnLogDT_Cstatus_Error)
            {
                operflag = "3";
            }
            else if (operflag == Constant.SynergisnLogDT_Cstatus_NoDeal)
            {
                operflag = "0";
            }
            else if (operflag == Constant.SynergisnLogDT_Cstatus_Delete)
            {
                operflag = "1";
            }
            else
            {
                operflag = "2";
            }
 
            StringBuilder strSql = new StringBuilder(); 

            strSql.Append("update " + headtable + " set ");
            if (!string.IsNullOrEmpty(dt.Cvoucherno))
            {
                strSql.Append(" cAVCode = '" + dt.Cvoucherno + "',  "); 
            }  
            strSql.Append(" operflag = " + operflag + ",  ");
            strSql.Append(" cerrordesc = '" + dt.Cerrordesc + "'  ");
            strSql.Append(" where id=" + U8.Interface.Bus.Comm.Convert.ConvertDbValueFromPro(dt.Id,"string") + " ");

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());

            return rows;
        }


        #endregion

         



    }
}
