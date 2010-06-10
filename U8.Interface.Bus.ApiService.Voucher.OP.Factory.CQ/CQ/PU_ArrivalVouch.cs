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
    /// 采购退货单 /采购退货单(MES_COMM_DLLReflect预置的op类)   code 不重复
    /// envContext.SetApiContext("sBillType", new string()); //上下文数据类型：string，含义：到货单类型， 到货单 0 退货单 1
    /// </summary>
    public class PU_ArrivalVouch : PurchaseRetOp
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
        private string voucherNoColumnName = "cCode";
        private string headtable = "MES_CQ_rdrecord01Ret";
        private string bodytable = "MES_CQ_rdrecords01Ret"; 
        private string taskStatusflagColName = "operflag"; 
        private string opertype = "opertype";

        /// <summary>
        /// 目标表
        /// </summary> 
        private string cardNo = "26";
        private string voucherTypeName = "采购退货单";
        private string targetVoucherNoColumnName = "cCode";
   

        public override string SetTableName()
        {
            return "PU_ArrivalVouch";
        }


        #region  api  setting

 
        public override string SetVouchType()
        {
            return "2";
        }
 
        public override string SetApiAddressAdd()
        {
            return "U8API/ArrivedGoods/VoucherSave";
        }

        public override string SetApiAddressAudit()
        {
            return "U8API/ArrivedGoods/ConfirmArr";
        }

        public override string SetApiAddressCancelAudit()
        {
            return "U8API/ArrivedGoods/CancelconfirmArr";
        }

        public override string SetApiAddressDelete()
        {
            return "U8API/ArrivedGoods/Delete";
        }

        public override string SetApiAddressLoad()
        {
            return "U8API/ArrivedGoods/GetVoucherData";
        }
        public override string SetApiAddressUpdate()
        {
            throw new NotImplementedException();
        }

        #endregion

   
        public override TaskList GetTask()
        {
            string sql = "SELECT * FROM " + headtable + " WHERE " + taskStatusflagColName + " = 0 ";
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
                t.OperType = (int)dt.Rows[i]["OperType"];
                try
                { 
                    //t.id = int.Parse(dt.Rows[i]["id"].ToString());
                    t.id =  dt.Rows[i]["id"].ToString();
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


        #region 获取结点
        public override Synergismlogdt GetFirst(Synergismlogdt dt)
        {
            throw new NotImplementedException();
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
                //DataSet ds = DbHelperSQL.Query("SELECT MoCode FROM " + bodytable + " with(nolock) WHERE ID = " + U8.Interface.Bus.Comm.Convert.ConvertDbValueFromPro(dt.Id, "string"));
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                pdt.Cvoucherno = "";// ds.Tables[0].Rows[i]["MoCode"].ToString();
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
                tmpd.TaskType = tasktype;
                tmpd.Cstatus = U8.Interface.Bus.ApiService.DAL.Constant.SynerginsLog_Cstatus_NoDeal; 
                tmpd.Isaudit = U8.Interface.Bus.ApiService.DAL.Constant.SynergisnLogDT_Isaudit_True;
                //DataSet ds = DbHelperSQL.Query("SELECT lt." + voucherNoColumnName + " FROM " + bodytable + " lb with(nolock) INNER JOIN " + headtable + " lt WITH(NOLOCK) ON lt.ID = lb.id WHERE lb.ID = '" + dt.Id + "' ");
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                tmpd.Cvoucherno = "";// ds.Tables[0].Rows[i][voucherNoColumnName].ToString();
                //} 

                logdt.Add(tmpd);
                return logdt;
            }
            else
            {
                return logdt;
            }
        }


        #endregion



        #region 组织来源数据

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

            string sql = "select top 1 st.*,"; // t.*,";
            sql += " lt.cRdCode as MES_cRdCode ,lt.ddate as MES_ddate, ";
            sql += " lt.cWhCode as MES_cWhCode ,lt.cRdStyleCode as MES_cRdStyleCode, "; 
            sql += " lt.cDepCode as MES_cDepCode ,lt.cVenCode as MES_cVenCode, "; 
            sql += " lt.cPersonCode as MES_cPersonCode ,lt.cRemark as MES_cRemark, "; 
            sql += " '采购退货单' as cSource ";
            sql += " from  " + headtable + " lt with(nolock) ";
            sql += " INNER JOIN  " + bodytable + " lb with(nolock) on lb.id = lt.id ";
            sql += " INNER JOIN  " + sourceBodyTable + " sb with(nolock) on sb.autoid = lb.dhid ";
            sql += " INNER JOIN  " + sourceHeadTable + " st with(nolock) on sb.id = st.id ";
            sql += " where lt.id ='" + pdt.Id + "' ";
  
            DbHelperSQLP help = new DbHelperSQLP(cimodel.Constring);
            DataSet ds = help.Query(sql);
            BLL.Common.ErrorMsg(ds, "未能获取采购退货单表头信息");
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
            string sql = "select st.cCode as cCode,sb.*,"; 
            sql += " lt.cWhCode as MES_cWhCode,";
            sql += " lb.cInvCode as MES_cInvCode,lb.iquantity as MES_iquantity,   ";
            sql += " CASE lb." + opertype + " WHEN 0 THEN 'A' WHEN 1 THEN 'M' WHEN '2' THEN 'D' ELSE 'A' END as editprop, ";
            //sql += " lb.iquantity * sb.iOriCost as pro_iOriMoney , ";  //原币含税单价
            sql += " lb.iquantity * sb.iOriCost as pro_iOriMoney , ";  //原币金额(不含税) 
            sql += " lb.iquantity * sb.iOriCost * sb.iTaxRate/100 as pro_iOriTaxPrice , ";  //原币税额 
            sql += " (lb.iquantity * sb.iOriCost + lb.iquantity * sb.iOriCost * sb.iTaxRate/100 ) as pro_iOriSum , ";  //原币价税合计
            sql += " lb.iquantity * sb.iCost as pro_iMoney , ";  //本币金额 
            sql += " lb.iquantity * sb.iCost * sb.iTaxRate/100 as pro_iTaxPrice , ";  //本币税额 
            sql += " (lb.iquantity * sb.iCost + lb.iquantity * sb.iCost * sb.iTaxRate/100 ) as pro_iSum   ";  //本币价税合计

            sql += " FROM " + sourceBodyTable + " sb with(nolock) ";
            sql += " INNER JOIN " + sourceHeadTable + " st with(nolock) on sb.id = st.id ";
            sql += " INNER JOIN " + bodytable + " lb with(nolock) on lb.dhid = sb.autoid ";
            sql += " INNER JOIN " + headtable + " lt with(nolock) on lt.id = lb.id where lt.id ='" + pdt.Id + "' ";
            DbHelperSQLP help = new DbHelperSQLP(cimodel.Constring);
            DataSet ds = help.Query(sql);
            BLL.Common.ErrorMsg(ds, "未能获取采购退货单表体信息");
            return ds;
        }

        #endregion


         

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
                sqlstr = "select isnull(id,'') from PU_ArrivalVouch  with(nolock)  where " + targetVoucherNoColumnName + "='" + strID + "'";
            }
            if (codeorid == "code")
            {
                sqlstr = "select isnull(" + targetVoucherNoColumnName + ",'') from PU_ArrivalVouch  with(nolock)  where id ='" + strID + "'";
            }
            Model.APIData apidata = bd as Model.APIData;

            DBUtility.DbHelperSQLP sqlp = new DBUtility.DbHelperSQLP(apidata.ConnectInfo.Constring);
            string ret = sqlp.GetSingle(sqlstr).NullToString();
            BLL.Common.ErrorMsg(ret, "未能获采购退货单ID或单号");
            return ret;
        }

        public override bool CheckAuditStatus(string strVoucherNo, string strConn)
        {
            return false;
        }


        #region update  log
        //修改日志 
        public override int Update(Model.Synergismlog dt)
        {
            return CQ.Utility.UpdateMainLog(dt, headtable, voucherNoColumnName, taskStatusflagColName, "cerrordesc");
        }
        public override int Update(Model.Synergismlogdt dt)
        {
            return CQ.Utility.UpdateDetailLog(dt, headtable, voucherNoColumnName, taskStatusflagColName, "cerrordesc");
        }
 
        #endregion

 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="autoid">子任务ID</param>
        /// <returns></returns>
        public override Model.Synergismlogdt GetModel(string autoid)
        {
            return CQ.Utility.GetModel(tasktype, headtable, cardNo, voucherNoColumnName, opertype, autoid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="id">主任务ID</param>
        /// <returns></returns>
        public override Model.Synergismlog GetLogModel(string id)
        {
            return CQ.Utility.GetLogModel(headtable, cardNo, voucherNoColumnName, opertype, id);
        }



        public override void SetNormalValue(Model.APIData apidata, Model.Synergismlogdt dt)
        {
            base.SetNormalValue(apidata, dt);

            //单据号获取
            string ccode = "ccode";
            Model.U8NameValue nv = ApiService.DAL.Common.U8NameValueFind(apidata.HeadData, ccode);
            if (nv == null) return;
            if (!string.IsNullOrEmpty(nv.U8FieldValue)) return;
            DbHelperSQLP help = new DbHelperSQLP(apidata.ConnectInfo.Constring);
            string sql = "select top 1 ccode from PU_ArrivalVouch  with(nolock) ";
            nv.U8FieldValue = help.GetSingle(sql).NullToString();
            if (string.IsNullOrEmpty(nv.U8FieldValue)) nv.U8FieldValue = "0000000001";


            //envContext.SetApiContext("VoucherType", new int()); //上下文数据类型：int，含义：单据类型， 采购退货单 2 
            //envContext.SetApiContext("bPositive", new bool()); //上下文数据类型：bool，含义：红蓝标识：True,蓝字；False,红字
            //envContext.SetApiContext("sBillType", new string()); //上下文数据类型：string，含义：到货单类型， 到货单 0 退货单 1
            //envContext.SetApiContext("sBusType", new string()); //上下文数据类型：string，含义：业务类型：普通采购,直运采购,受托代销
        }


    }
}
