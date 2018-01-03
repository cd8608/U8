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
    /// 生产订单(HY_DZ_K7_DLLReflect预置的op类)
    /// </summary>
    public class Mom_order : SfcOp
    { 
        private int tasktype = 0;

 
        /// <summary>
        /// 来源
        /// </summary>
        private string sourceCardNo = "MQ6303";
        string sourceHeadTable = "mps_netdemand";
        string sourceBodyTable = "mps_netdemand";


        /// <summary>
        /// 中间表
        /// </summary>
        private string voucherNoColumnName = "mocode"; 
        private string headtable = "MES_CQ_mom_order";
        private string bodytable = "MES_CQ_mom_orderdetail";
        private string bodysubtable = "MES_CQ_Mom_orderdetailsub";  //api 不支持，需要手工写表
        private string taskStatusflagColName = "operflag"; 
        private string opertype = "opertype";


        /// <summary>
        /// 目标表
        /// </summary> 
        private string cardNo = "MO21";
        private string voucherTypeName = "生产订单";
   



        #region  api 常量 

        /// <summary>
        /// 主表
        /// </summary>
        /// <returns></returns>
        public override string SetTableName()
        {
            return "mom_order";
        }

        /// <summary>
        /// 子表
        /// </summary>
        public override string SubEntityName
        {
            get
            {
                return "Mom_OrderDetail";
            }
            set { }
        }  

        /// <summary>
        /// 子表下的子表
        /// 子件用料表
        /// </summary>
        public override string SubChildEntityName
        {
            get
            {
                return "Mom_MoAllocate";
            }
            set { }
        }

        /// <summary>
        /// 子件替代料表
        /// </summary>
        public string SubChildSubEntityName
        {
            get
            {
                return "Mom_MoAllocatesub";
            }
            set { }
        }  
     


        public override string SetApiAddressAdd()
        {
            return "U8API/MOrder/MOrderAdd";
        } 
        public override string SetApiAddressAudit()
        {
            return "U8API/MOrder/MOrderAuditing";
        } 
        public override string SetApiAddressCancelAudit()
        {
            return "U8API/MOrder/MOrderUnauditing";
        } 
        public override string SetApiAddressDelete()
        {
            return "U8API/MOrder/MOrderDelete";
        } 
        public override string SetApiAddressLoad()
        {
            return "U8API/MOrder/MOrderLoad";
        } 
        public override string SetApiAddressUpdate()
        {
            return "U8API/MOrder/MOrderUpdate";
        }
        #endregion

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
                curid += "'" + t.id + "',";
            }
            if (!string.IsNullOrEmpty(curid))
            {
                string msql = " update " + headtable + " set " + taskStatusflagColName + " = 2 where id in (" + curid.Substring(0,curid.Length-1) + ") ";
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
                DataSet ds = DbHelperSQL.Query("SELECT " + voucherNoColumnName + " FROM " + bodytable + " with(nolock) WHERE ID = " + U8.Interface.Bus.Comm.Convert.ConvertDbValueFromPro(dt.Id, "string"));
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    pdt.Cvoucherno = ds.Tables[0].Rows[i][voucherNoColumnName].ToString();
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
                DataSet ds = DbHelperSQL.Query("SELECT " + voucherNoColumnName + " FROM " + bodytable + " with(nolock) WHERE ID = '" + dt.Id + "' ");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    tmpd.Cvoucherno = ds.Tables[0].Rows[i][voucherNoColumnName].ToString();
                } 

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
  
            string sql = "select st.*,";
            sql += " lt.PlanCode as MES_cWhCode ,lt.MoCode as MES_MoCode,lt.cWcCode as MES_cWcCode,lt.cInvCode as MES_cInvCode, ";
            sql += " lt.cSoCode as MES_cSoCode ,lt.cForCode as MES_cForCode,lt.PStartDate as MES_PStartDate,lt.PDueDate as MES_PDueDate, ";
            sql += " lt.DmandDate as MES_DmandDate ,lt.MoType as MES_MoType,  ";
            sql += " '" + System.DateTime.Now.ToString(SysInfo.dateFormat) + "' as ddate, ";
            sql += " '生产订单' as cSource ";
            sql += " from  " + headtable + " lt with(nolock) ";
            sql += " left join " + sourceHeadTable + " st with(nolock) on  ltrim(rtrim(lt.PlanCode)) = ltrim(rtrim(st.PlanCode))  ";
            sql += " where lt.id ='" + pdt.Id + "' ";
            
            DbHelperSQLP help = new DbHelperSQLP(cimodel.Constring);
            DataSet ds = help.Query(sql);
            BLL.Common.ErrorMsg(ds, "未能获取生产计划表头信息");
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
            ApiService.DAL.TaskLogFactory.ITaskLogDetail dtdal = ClassFactory.GetITaskLogDetailDAL(apidata.TaskType);
            Model.ConnectInfo cimodel = dtdal.GetConnectInfo(pdt);

            string sql = "select st.*,";
            sql += " lt.PlanCode as MES_PlanCode ,lt.MoCode as MES_MoCode,lt.cWcCode as MES_cWcCode,lt.cInvCode as MES_cInvCode, ";
            sql += " lt.cSoCode as MES_cSoCode ,lt.cForCode as MES_cForCode,lt.PStartDate as MES_PStartDate,lt.PDueDate as MES_PDueDate, ";
            sql += " lt.DmandDate as MES_DmandDate ,lt.MoType as MES_MoType,lt.iquantity as MES_iquantity,  ";
            sql += " sob.iRowNo as sob_iRowNo,sob.cSOCode as sob_cSOCode,  ";
            sql += " '" + System.DateTime.Now.ToString(SysInfo.dateFormat) + "' as ddate, ";
            sql += " tt.MoTypeId as PRO_MoTypeId, ";
            sql += " tt.MoTypeCode as PRO_MoType, ";
            sql += " '生产订单' as cSource ";
            sql += " from  " + headtable + " lt with(nolock) ";
            sql += " LEFT JOIN " + sourceHeadTable + " st with(nolock) on  ltrim(rtrim(lt.PlanCode)) = ltrim(rtrim(st.PlanCode))  ";
            sql += " LEFT JOIN mom_motype tt with(nolock) ON lt.MoType  = substring(tt.MotypeCode,LEN(tt.MotypeCode),1)  ";
            sql += " left join SO_SODetails sob with(nolock) on Convert(nvarchar,sob.iSOsID) = st.sodid  ";
            sql += " where lt.id ='" + pdt.Id + "' ";

            DbHelperSQLP help = new DbHelperSQLP(cimodel.Constring);
            DataSet ds = help.Query(sql);
            BLL.Common.ErrorMsg(ds, "未能获取生产计划表体信息");
            return ds;
        }

        public override System.Data.DataSet SetFromTabetsChild(Model.Synergismlogdt dt, Model.Synergismlogdt pdt, Model.APIData apidata)
        {
            ApiService.DAL.TaskLogFactory.ITaskLogDetail dtdal = ClassFactory.GetITaskLogDetailDAL(apidata.TaskType);  //new ApiService.DAL.SynergismLogDt();
            Model.ConnectInfo cimodel = dtdal.GetConnectInfo(pdt);

            string sql = "select st.*,";
            sql += " lt.PlanCode as MES_cWhCode ,lt.MoCode as MES_MoCode,lt.cWcCode as MES_cWcCode, ";
            sql += " lt.cSoCode as MES_cSoCode ,lt.cForCode as MES_cForCode,lt.PStartDate as MES_PStartDate,lt.PDueDate as MES_PDueDate, ";
            sql += " lt.DmandDate as MES_DmandDate ,lt.MoType as MES_MoType,  ";
            sql += " lb.BomID as MES_BomID ,lb.cInvCode as MES_cInvCode,lb.iquantity as MES_iquantity, ";
            sql += " lb.iquantity * lt.iquantity as MES_C_iquantity,  ";
            sql += " '" + System.DateTime.Now.ToString(SysInfo.dateFormat) + "' as ddate , ";
            sql += " '生产订单' as cSource ";
            sql += " from  " + headtable + " lt with(nolock) ";
            sql += " inner join " + bodytable + " lb with(nolock) on lt.id = lb.id ";
            sql += " left join " + sourceHeadTable + " st with(nolock) on  ltrim(rtrim(lt.PlanCode)) = ltrim(rtrim(st.PlanCode))  ";
            sql += " where lt.id ='" + pdt.Id + "' ";

            DbHelperSQLP help = new DbHelperSQLP(cimodel.Constring);
            DataSet ds = help.Query(sql);
            BLL.Common.ErrorMsg(ds, "未能获取生产计划表体子件信息");
            return ds;
        }

  
        #endregion



        #region 为API 赋表头表体数据

         

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
                sqlstr = "select isnull(moid,'') from mom_order  with(nolock)  where mocode='" + strID + "'";
            }
            if (codeorid == "code")
            {
                sqlstr = "select isnull(mocode,'') from mom_order  with(nolock)  where moid ='" + strID + "'";
            }
            Model.APIData apidata = bd as Model.APIData;

            DBUtility.DbHelperSQLP sqlp = new DBUtility.DbHelperSQLP(apidata.ConnectInfo.Constring);
            string ret = sqlp.GetSingle(sqlstr).NullToString();
            BLL.Common.ErrorMsg(ret, "未能获生产订单ID或单号");
            return ret;
        }

        public override bool CheckAuditStatus(string strVoucherNo, string strConn)
        {
            return false;
        }


        public override int Update(Model.Synergismlog dt)
        {
            return CQ.Utility.UpdateMainLog(dt, headtable, voucherNoColumnName, taskStatusflagColName, "cerrordesc");
        }


        //修改日志
        public override int Update(Model.Synergismlogdt dt)
        {
            return CQ.Utility.UpdateDetailLog(dt, headtable, voucherNoColumnName, taskStatusflagColName, "cerrordesc");
        }


          
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="autoid">子任务ID</param>
        /// <returns></returns>
        public override Model.Synergismlogdt GetModel(string autoid)
        {
            return CQ.Utility.GetModel(tasktype, headtable, cardNo, voucherNoColumnName, opertype,autoid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="id">主任务ID</param>
        /// <returns></returns>
        public override Model.Synergismlog GetLogModel(string id)
        {
            return CQ.Utility.GetLogModel(headtable, cardNo,voucherNoColumnName,opertype,id); 
        }



    }
}
