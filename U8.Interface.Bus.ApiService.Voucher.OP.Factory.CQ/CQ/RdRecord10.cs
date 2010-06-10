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


namespace U8.Interface.Bus.ApiService.Voucher
{
    /// <summary>
    /// 产成品入库单(HY_DZ_K7_DLLReflect预置的op类)
    /// </summary>
    public class RdRecord10 : StockOP
    {
        private int tasktype = 0;

        private string cardNo = "0411";
        private string headtable = "MES_CQ_rdrecord10";
        private string bodytable = "mes_cq_rdrecords10";


        private string taskStatusflagColName = "operflag";


        public override string SetTableName()
        {
            return "RdRecord10";
        }

        public override string SetVouchType()
        {
            return "10";
        }

        public override string SetApiAddressAdd()
        {
            return "U8API/ProductIn/Add";
        }

        public override string SetApiAddressAudit()
        {
            return "U8API/ProductIn/Audit";
        }

        public override string SetApiAddressCancelAudit()
        {
            return "U8API/ProductIn/CancelAudit";
        }

        public override string SetApiAddressDelete()
        {
            return "U8API/ProductIn/Delete";
        }

        public override string SetApiAddressLoad()
        {
            return "U8API/ProductIn/Load";
        }

        public override string SetApiAddressUpdate()
        {
            return "U8API/ProductIn/Update";
        }

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
                v.SourceCardNo = "MO21";
                //v.SourceVoucherNo = dt.Rows[i][""].ToString();
                v.CardNo = cardNo;
                v.VoucherName = "产成品入库单";
                t.VouchType = v;
                t.taskType = 0;   //MES接口任务  
                t.OperType = (int)dt.Rows[i]["OperType"];
                try
                {
                    t.id = dt.Rows[i]["id"].ToString();  //int.Parse(dt.Rows[i]["id"].ToString());
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
            DataSet ds = DbHelperSQL.Query("SELECT t.cRdCode,t.id,t.opertype FROM " + headtable + " t with(nolock)  WHERE t.id = " + U8.Interface.Bus.Comm.Convert.ConvertDbValueFromPro(autoid,"string"));
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                tmpd.Cvoucherno = ds.Tables[0].Rows[i]["cRdCode"].ToString();
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
            //DataSet ds = DbHelperSQL.Query("SELECT b.cRdCode,b.id,b.did,t.opertype FROM " + bodytable + " b with(nolock) left join " + headtable + " t with(nolock) on b.id = t.id WHERE b.DID = " + autoid);
            DataSet ds = DbHelperSQL.Query("SELECT t.cRdCode,t.id,t.opertype FROM " + headtable + " t with(nolock)  WHERE t.id = " + autoid);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                tmpd.Cvoucherno = ds.Tables[0].Rows[i]["cRdCode"].ToString();
                tmpd.Autoid = ds.Tables[0].Rows[i]["id"].ToString(); // int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                tmpd.Id = ds.Tables[0].Rows[i]["id"].ToString(); // int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                tmpd.Cdealmothed = int.Parse(ds.Tables[0].Rows[i]["opertype"].ToString()) + 1; // 0(自动生单/自动审核) 1增 2修改 3删
            }
            return tmpd;
        }



        public override Synergismlogdt GetFirst(Synergismlogdt dt)
        {
            Model.Synergismlogdt fdt = new Model.Synergismlogdt();
            fdt.Cvouchertype = "MO21";
            fdt.Id = dt.Id;
            fdt.Ilineno = 1;
            DataSet ds = DbHelperSQL.Query("SELECT MoCode FROM " + bodytable + " with(nolock) WHERE ID = " + dt.Id);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                fdt.Cvoucherno = ds.Tables[0].Rows[i]["MoCode"].ToString();
                fdt.Autoid = dt.Id;
            }
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
                pdt.Cvouchertype = "MO21";
                pdt.Id = dt.Id;
                DataSet ds = DbHelperSQL.Query("SELECT MoCode FROM " + bodytable + " with(nolock) WHERE ID = " + U8.Interface.Bus.Comm.Convert.ConvertDbValueFromPro(dt.Id,"string"));
                for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
                {
                    pdt.Cvoucherno = ds.Tables[0].Rows[i]["MoCode"].ToString();
                    //pdt.Autoid = null;
                } 
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
                tmpd.TaskType = tasktype;
                tmpd.Cstatus = U8.Interface.Bus.ApiService.DAL.Constant.SynerginsLog_Cstatus_NoDeal;
                //DataSet ds = DbHelperSQL.Query("SELECT b.cRdCode,b.id,b.did,t.opertype FROM " + bodytable + " b with(nolock) left join " + headtable + " t with(nolock) on b.id = t.id WHERE b.ID = " + dt.Id);
                DataSet ds = DbHelperSQL.Query("SELECT t.cRdCode,t.id,t.opertype FROM " + headtable + " t with(nolock)  WHERE t.id = " + U8.Interface.Bus.Comm.Convert.ConvertDbValueFromPro(dt.Id,"string"));
           
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    tmpd.Cvoucherno = ds.Tables[0].Rows[i]["cRdCode"].ToString();
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

            string sql = "select t.*,lt.cWhCode as cWhCode ,lt.cRdCode as cCode ";
            sql += ",'" + System.DateTime.Now.ToString(SysInfo.dateFormat) + "' as ddate ";
            sql += ",'生产订单' as cSource ";
            sql += " from  v_mom_order_wf t with(nolock) left join " + bodytable + " lb with(nolock) on lb.mocode = t.mocode left join " + headtable + " lt with(nolock) on lt.id = lb.id where lt.id ='" + pdt.Id + "' ";
            DbHelperSQLP help = new DbHelperSQLP(cimodel.Constring);
            DataSet ds = help.Query(sql);
            BLL.Common.ErrorMsg(ds, "未能获取生产订单表头信息");
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
            string sql = "select b.*,lt.cWhCode as cWhCode,lb.iquantity as iquantity,lt.cRdCode as cCode   ";
            
            sql += " from v_mom_orderdetail_wf b with(nolock) left join  v_mom_order_wf t with(nolock) on b.moid = t.moid left join " + bodytable + " lb with(nolock) on lb.mocode = t.mocode left join " + headtable + " lt with(nolock) on lt.id = lb.id where lt.id ='" + pdt.Id + "' ";
            
            DbHelperSQLP help = new DbHelperSQLP(cimodel.Constring);
            DataSet ds = help.Query(sql);
            BLL.Common.ErrorMsg(ds, "未能获取其他入库单表体信息");
            return ds;
        }



        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="bd"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public override Model.DealResult MakeAudit(BaseData bd, Model.Synergismlogdt dt)
        {
            Model.DealResult dr = base.MakeAudit(bd, dt);  
            return dr;

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
                sqlstr = "select isnull(id,'') from RdRecord10  with(nolock)  where ccode='" + strID + "'";
            }
            if (codeorid == "code")
            {
                sqlstr = "select isnull(ccode,'') from RdRecord10  with(nolock)  where id='" + strID + "'";
            }
            Model.APIData apidata = bd as Model.APIData;

            DBUtility.DbHelperSQLP sqlp = new DBUtility.DbHelperSQLP(apidata.ConnectInfo.Constring);
            string ret = sqlp.GetSingle(sqlstr).NullToString();
            BLL.Common.ErrorMsg(ret, "未能获产成品入库单ID或单号");
            return ret;
        }

        public override bool CheckAuditStatus(string strVoucherNo, string strConn)
        {
            return false;
        }

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
                strSql.Append(" cRdCode = '" + dt.Cvoucherno + "',  ");

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
            strSql.Append(" where id= " + U8.Interface.Bus.Comm.Convert.ConvertDbValueFromPro(dt.Id,"string") + " ");

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
                strSql.Append(" cRdCode = '" + dt.Cvoucherno + "',  ");

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
