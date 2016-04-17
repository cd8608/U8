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
    public static class Utility
    {

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="autoid">子任务ID</param>
        /// <returns></returns>
        public static Model.Synergismlogdt GetModel(int tasktype,string headtable,string cvouchertype,string vouchernocolname,string opertypecolname,string autoid)
        {
            Model.Synergismlogdt tmpd = new Synergismlogdt();
            tmpd.Autoid = autoid;
            tmpd.Id = autoid;
            tmpd.Cvouchertype = cvouchertype;
            tmpd.Ilineno = 2;
            tmpd.TaskType = tasktype;
            tmpd.Cstatus = U8.Interface.Bus.ApiService.DAL.Constant.SynerginsLog_Cstatus_NoDeal;
            DataSet ds = DbHelperSQL.Query("SELECT t." + vouchernocolname + ",t.id,t." + opertypecolname + " FROM " + headtable 
                + " t with(nolock)  WHERE t.id = " + U8.Interface.Bus.Comm.Convert.ConvertDbValueFromPro(autoid, "string"));
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                tmpd.Cvoucherno = ds.Tables[0].Rows[i][vouchernocolname].ToString();
                tmpd.Autoid = ds.Tables[0].Rows[i]["id"].ToString(); // int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                tmpd.Id = ds.Tables[0].Rows[i]["id"].ToString(); // int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                tmpd.Cdealmothed = int.Parse(ds.Tables[0].Rows[i][opertypecolname].ToString()) + 1; // 0(自动生单/自动审核) 1增 2修改 3删
            }
            return tmpd;
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="headtable"></param>
        /// <param name="cvouchertype"></param>
        /// <param name="voucherNoColumnName"></param>
        /// <param name="opertypecolname"></param>
        /// <param name="autoid"></param>
        /// <returns></returns>
        public static Model.Synergismlog GetLogModel(string headtable,string cvouchertype, string voucherNoColumnName,string opertypecolname,string autoid)
        { 
            Model.Synergismlog tmpd = new Synergismlog(); 
            tmpd.Id = autoid;
            tmpd.Cvouchertype = cvouchertype; 
            tmpd.Cstatus = U8.Interface.Bus.ApiService.DAL.Constant.SynerginsLog_Cstatus_NoDeal;
            DataSet ds = DbHelperSQL.Query("SELECT t." + voucherNoColumnName + ",t.id,t." + opertypecolname + " FROM " + headtable + " t with(nolock)  WHERE t.id = '" + autoid + "' ");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                tmpd.Cvoucherno = ds.Tables[0].Rows[i][voucherNoColumnName].ToString();
                tmpd.Id = ds.Tables[0].Rows[i]["id"].ToString(); // int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                //tmpd.Cdealmothed = int.Parse(ds.Tables[0].Rows[i]["opertype"].ToString()) + 1; // 0(自动生单/自动审核) 1增 2修改 3删
            }
            return tmpd; 
        }


        public static int UpdateMainLog(Model.Synergismlog dt, string headtable, string voucherNoColumnName, string flagColname, string errordesccolname)
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
            else if (operflag == Constant.SynerginsLog_Cstatus_Scrap)
            {
                operflag = "4";
            }
            else
            {
                operflag = "2";
            }


            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + headtable + " set ");
            if (!string.IsNullOrEmpty(dt.Cvoucherno))
            {
                strSql.Append(" " + voucherNoColumnName + " = '" + dt.Cvoucherno + "',  ");
            }
            if (finishTime == null)
            {
                strSql.Append(" finishTime = null,  ");
            }
            else
            {
                strSql.Append(" finishTime = '" + finishTime + "',  ");
            }
            if (operflag == "0")
            {
                strSql.Append(" " + errordesccolname + " = null ,  ");
            }
            strSql.Append(" " + flagColname + " = " + operflag + "  ");
            strSql.Append(" where id= " + U8.Interface.Bus.Comm.Convert.ConvertDbValueFromPro(dt.Id, "string") + " ");

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());

            return rows;

        }

        public static int UpdateDetailLog(Model.Synergismlogdt dt, string headtable, string voucherNoColumnName, string flagColname, string errordesccolname)
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
                strSql.Append(" " + voucherNoColumnName + " = '" + dt.Cvoucherno + "',  ");
            }
            strSql.Append(" " + flagColname + " = " + operflag + ",  ");
            strSql.Append(" " + errordesccolname + " = '" + U8.Interface.Bus.Comm.Convert.EncodeDbValue(dt.Cerrordesc) + "'  ");
            strSql.Append(" where id=" + U8.Interface.Bus.Comm.Convert.ConvertDbValueFromPro(dt.Id, "string") + " ");

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());

            return rows;

        }
    }
}