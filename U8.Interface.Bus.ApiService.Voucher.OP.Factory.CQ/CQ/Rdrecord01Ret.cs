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
    /// 采购入库单(红字) (HY_DZ_K7_DLLReflect预置的op类)
    /// </summary>
    public class Rdrecord01Ret : StockOP
    {
        private int tasktype = 0;
   

        /// <summary>
        /// 来源
        /// </summary>
        private string sourceCardNo = "26";
        string sourceHeadTable = "PU_ArrivalVouch";
        string sourceBodyTable = "PU_ArrivalVouchs";


        /// <summary>
        /// 中间表
        /// </summary>
        private string voucherNoColumnName = "cPuRdCode";
        private string headtable = "MES_CQ_rdrecord01Ret";
        private string bodytable = "mes_cq_rdrecords01Ret";
        private string taskStatusflagColName = "operflag_rd";
        private string opertype = "opertype_rd";

        /// <summary>
        /// 目标表
        /// </summary> 
        private string cardNo = "24_Ret";  //"24";
        private string voucherTypeName = "采购入库单(红字)";

 

        public override string SetTableName()
        {
            return "rdrecord01";
        }
        #region API 常量
        //public override string SetVouchType()
        //{
        //    return "01";
        //}
        //public override string SetApiAddressAdd()
        //{
        //    return "U8API/RdRecord01/Add";
        //} 
        //public override string SetApiAddressAudit()
        //{
        //    return "U8API/RdRecord01/Audit";
        //}
        //public override string SetApiAddressCancelAudit()
        //{
        //    return "U8API/RdRecord01/CancelAudit";
        //}
        //public override string SetApiAddressDelete()
        //{
        //    return "U8API/RdRecord01/Delete";
        //}
        //public override string SetApiAddressLoad()
        //{
        //    return "U8API/RdRecord01/Load";
        //}
        //public override string SetApiAddressUpdate()
        //{
        //    return "U8API/RdRecord01/Update";
        //}

        public override string SetVouchType()
        {
            return "01";
        }

        public override string SetApiAddressAdd()
        {
            return "U8API/PuStoreIn/Add";
        }

        public override string SetApiAddressAudit()
        {
            return "U8API/PuStoreIn/Audit";
        }

        public override string SetApiAddressCancelAudit()
        {
            return "U8API/PuStoreIn/CancelAudit";
        }

        public override string SetApiAddressDelete()
        {
            return "U8API/PuStoreIn/Delete";
        }

        public override string SetApiAddressLoad()
        {
            return "U8API/PuStoreIn/Load";
        }

        public override string SetApiAddressUpdate()
        {
            return "U8API/PuStoreIn/Update";
        }


        #endregion

        public override TaskList GetTask()
        {
            string sql = "SELECT * FROM " + headtable + " WHERE " + taskStatusflagColName + " =0 and operflag = 1 ";
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
                //v.SourceVoucherNo = dt.Rows[i][""].ToString();
                v.CardNo = cardNo;
                v.VoucherName = voucherTypeName;
                t.VouchType = v;
                t.taskType = tasktype;   //MES接口任务  
                t.OperType = (int)dt.Rows[i][opertype];
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
                    t.OperType = int.Parse(dt.Rows[i][opertype].ToString());
                }
                catch (Exception ee)
                {
                    BLL.Common.ErrorMsg(SysInfo.productName, "opertype 值出错！");
                }
                tl.Add(t);
                curid += "'" + t.id + "',";
            }
            if (!string.IsNullOrEmpty(curid))
            {
                string msql = " update " + headtable + " set " + taskStatusflagColName + " = 2 where id in (" + curid.Substring(0,curid.Length-1) + ") ";
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
            DataSet ds = DbHelperSQL.Query("SELECT t." + voucherNoColumnName + ",t.id,t." + opertype + " FROM " + headtable + " t with(nolock)  WHERE t.id = '" + autoid + "' ");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                tmpd.Cvoucherno = ds.Tables[0].Rows[i][voucherNoColumnName].ToString();
                tmpd.Id = ds.Tables[0].Rows[i]["id"].ToString();  
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
            DataSet ds = DbHelperSQL.Query("SELECT t." + voucherNoColumnName + ",t.id,t." + opertype + " FROM " + headtable + " t with(nolock)  WHERE t.id = " + 
                U8.Interface.Bus.Comm.Convert.ConvertDbValueFromPro(autoid,"string"));
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                tmpd.Cvoucherno = ds.Tables[0].Rows[i][voucherNoColumnName].ToString();
                tmpd.Autoid = ds.Tables[0].Rows[i]["id"].ToString(); // int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                tmpd.Id = ds.Tables[0].Rows[i]["id"].ToString();  // int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                tmpd.Cdealmothed = int.Parse(ds.Tables[0].Rows[i][opertype].ToString()) + 1; // 0(自动生单/自动审核) 1增 2修改 3删
            }
            return tmpd;
        }



        public override Synergismlogdt GetFirst(Synergismlogdt dt)
        {
            string sourceCodeColName = "dhCode";

            Model.Synergismlogdt fdt = new Model.Synergismlogdt();
            fdt.Cvouchertype = sourceCardNo;
            fdt.Id = dt.Id;
            fdt.Ilineno = 1;
            DataSet ds = DbHelperSQL.Query("SELECT " + sourceCodeColName + " FROM " + bodytable + " with(nolock) WHERE ID = " + U8.Interface.Bus.Comm.Convert.ConvertDbValueFromPro(dt.Id,"string"));
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                fdt.Cvoucherno = ds.Tables[0].Rows[i][sourceCodeColName].ToString();
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

            string sourceCodeColName = "dhCode";

            if (dt.Cvouchertype == cardNo)
            {
                Model.Synergismlogdt pdt = new Model.Synergismlogdt();
                pdt.Cvouchertype = sourceCardNo;
                pdt.Id = dt.Id;
                DataSet ds = DbHelperSQL.Query("SELECT " + sourceCodeColName + " FROM " + bodytable + " with(nolock) WHERE ID = " + U8.Interface.Bus.Comm.Convert.ConvertDbValueFromPro(dt.Id,"string") );
                for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
                {
                    pdt.Cvoucherno = ds.Tables[0].Rows[i][sourceCodeColName].ToString();
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
                tmpd.Isaudit = U8.Interface.Bus.ApiService.DAL.Constant.SynergisnLogDT_Isaudit_True;

                DataSet ds = DbHelperSQL.Query("SELECT t." + voucherNoColumnName + ",t.id,t." + opertype + " FROM " + headtable + " t with(nolock)  WHERE t.id = " + U8.Interface.Bus.Comm.Convert.ConvertDbValueFromPro(dt.Id, "string"));
           
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    tmpd.Cvoucherno = ds.Tables[0].Rows[i][voucherNoColumnName].ToString();
                    tmpd.Autoid = ds.Tables[0].Rows[i]["id"].ToString(); // int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                    tmpd.Cdealmothed = int.Parse(ds.Tables[0].Rows[i][opertype].ToString()) + 1; // 0(自动生单/自动审核) 1增 2修改 3删
                } 
                
                logdt.Add(tmpd);
                return logdt;
            }
            else
            {
                return logdt;
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

            string sourceHeadTable = "pu_ArrHead";
            string sourceBodyTable = "pu_ArrBody";

            ApiService.DAL.TaskLogFactory.ITaskLogDetail dtdal = ClassFactory.GetITaskLogDetailDAL(apidata.TaskType);
            Model.ConnectInfo cimodel = dtdal.GetConnectInfo(pdt);

            string sql = "select distinct st.*,";
            sql += " st.ccode as MES_cARVCode, "; //到货单号
            sql += " st.id as iarriveid ,"; //到货单id
            sql += " st.id as ipurarriveid ,"; //采购到货单id
            sql += " '' as ipurorderid ,";  //采购订单ID
            sql += " lt.cvencode as MES_cvencode,"; 
            sql += " '" + System.DateTime.Now.ToString(SysInfo.dateFormat) + "' as ddate ";   //入库日期
            sql += ",'" + System.DateTime.Now.ToString(SysInfo.datetimeFormat) + "' as dnmaketime, ";   //制单时间
            sql += " lt." + voucherNoColumnName + " as cCode ,";
            sql += " lt.cWhCode as MES_cWhCode,lt.cRdStyleCode as MES_cRdCode,lt.cDepCode as MES_cDepCode,lt.cPersonCode as MES_cPersonCode ";
            sql += " FROM " + sourceBodyTable + " sb with(nolock) ";
            sql += " INNER JOIN " + sourceHeadTable + " st with(nolock) on sb.id = st.id ";
            sql += " INNER JOIN " + bodytable + " lb with(nolock) on lb.dhid = sb.autoid ";
            sql += " INNER JOIN " + headtable + " lt with(nolock) on lt.id = lb.id where lt.id ='" + dt.Id + "' ";


            DbHelperSQLP help = new DbHelperSQLP(cimodel.Constring);
            DataSet ds = help.Query(sql);
            BLL.Common.ErrorMsg(ds, "未能获取采购到货单表头信息");
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

            string sourceHeadTable = "pu_ArrHead";
            string sourceBodyTable = "pu_ArrBody";

            ApiService.DAL.TaskLogFactory.ITaskLogDetail dtdal = ClassFactory.GetITaskLogDetailDAL(apidata.TaskType);  //new ApiService.DAL.SynergismLogDt();
            Model.ConnectInfo cimodel = dtdal.GetConnectInfo(pdt); 

            string sql = "select sb.*,";
            sql += " lt.cWhCode as MES_cWhCode,lt.cRdStyleCode as MES_cRdCode,lt.cDepCode as MES_cDepCode,lt.cPersonCode as MES_cPersonCode, ";
            sql += " lt.cvencode as MES_cvencode,";
            sql += " CASE lb." + opertype + " WHEN 0 THEN 'A' WHEN 1 THEN 'M' WHEN '2' THEN 'D' ELSE 'A' END as editprop, ";
            sql += " lb.iquantity as MES_iquantity,   ";
            sql += " inv.cComUnitCode as inv_cComUnitCode,inv.cAssComUnitCode as inv_cAssComUnitCode,inv.cSTComUnitCode as inv_cSTComUnitCode ";
            sql += " FROM " + sourceBodyTable + " sb with(nolock) ";
            sql += " INNER JOIN " + sourceHeadTable + " st with(nolock) on sb.id = st.id ";
            sql += " INNER JOIN " + bodytable + " lb with(nolock) on lb.dhid = sb.autoid ";
            sql += " INNER JOIN " + headtable + " lt with(nolock) on lt.id = lb.id ";
            sql += " INNER JOIN inventory inv with(nolock) on inv.cinvcode = lb.cinvcode  ";
            sql += " where lt.id ='" + dt.Id + "' ";
            
            DbHelperSQLP help = new DbHelperSQLP(cimodel.Constring);
            DataSet ds = help.Query(sql);
            BLL.Common.ErrorMsg(ds, "未能获取采购到货单表体信息");
            return ds;
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
                sqlstr = "select isnull(id,'') from rdrecord01  with(nolock)  where ccode='" + strID + "'";
            }
            if (codeorid == "code")
            {
                sqlstr = "select isnull(ccode,'') from rdrecord01  with(nolock)  where id='" + strID + "'";
            }
            Model.APIData apidata = bd as Model.APIData;

            DBUtility.DbHelperSQLP sqlp = new DBUtility.DbHelperSQLP(apidata.ConnectInfo.Constring);
            string ret = sqlp.GetSingle(sqlstr).NullToString();
            BLL.Common.ErrorMsg(ret, "未能获采购入库单ID或单号");
            return ret;
        }

        public override bool CheckAuditStatus(string strVoucherNo, string strConn)
        {
            return false;
        }

        #region update  log


        public override int Update(Model.Synergismlog dt)
        {
            return CQ.Utility.UpdateMainLog(dt, headtable, voucherNoColumnName, taskStatusflagColName, "cerrordesc_rd");
        }

        //修改日志
        public override int Update(Model.Synergismlogdt dt)
        {
            return CQ.Utility.UpdateDetailLog(dt, headtable, voucherNoColumnName, taskStatusflagColName, "cerrordesc_rd");
        }
 
        #endregion 

    }
}
