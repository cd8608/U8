using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// 退货单(HY_DZ_K7_DLLReflect预置的op类)
    /// </summary>
    public class ReturnOrder : ApiService.BLL.SaleOp  
    {

        /// <summary>
        /// 获取任务队列
        /// </summary>
        /// <returns></returns>
        public override TaskList GetTask()
        {
            return null;
        }


        public override string SetApiAddressAdd()
        {
            return "U8API/ReturnOrder/Save";
        }

        public override string SetApiAddressAudit()
        {
            return "U8API/ReturnOrder/Audit";
        }

        public override string SetApiAddressCancelAudit()
        {
            return "U8API/ReturnOrder/Audit";
        }

        public override string SetApiAddressDelete()
        {
            return "U8API/ReturnOrder/Delete";
        }

        public override string SetApiAddressLoad()
        {
            return "U8API/ReturnOrder/Load";
        }


        public override string SetApiAddressUpdate()
        {
            throw new NotImplementedException();
        }


        public override System.Data.DataSet SetFromTabet(Model.Synergismlogdt dt, Model.Synergismlogdt pdt, Model.APIData apidata)
        {
            ApiService.DAL.SynergismLogDt dtdal = new ApiService.DAL.SynergismLogDt();
            Model.ConnectInfo cimodel = dtdal.GetConnectInfo(pdt);
            return Common.GetSourceMainDataset(pdt.Cvouchertype, pdt.Cvoucherno, cimodel.Constring);
        }


        public override System.Data.DataSet SetFromTabets(Model.Synergismlogdt dt, Model.Synergismlogdt pdt, Model.APIData apidata)
        {
            ApiService.DAL.SynergismLogDt dtdal = new ApiService.DAL.SynergismLogDt();
            Model.ConnectInfo cimodel = dtdal.GetConnectInfo(pdt);
            return Common.GetSourceDetailDataset(pdt.Cvouchertype, pdt.Cvoucherno, cimodel.Constring);

        }


        /// <summary>
        ///  审核单据
        /// </summary>
        /// <param name="bd"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public override Model.DealResult MakeAudit(BaseData bd, Model.Synergismlogdt dt)
        {
            Model.DealResult dr = base.MakeAudit(bd, dt);
            Model.IrownoModel m = new Model.IrownoModel();
            m.Autoidname = "autoid ";
            m.Barcodefomat = "pupo";
            m.Barcodename = "cbsysbarcode";
            m.Code = dt.Cvoucherno;
            m.Id = GetCodeorID(dt.Cvoucherno, bd, "id");
            m.Idname = "DLID";
            m.Tablename = "DispatchLists";
            m.Fliedname = "iorderrowno";
            ApiService.DAL.Common.setirowno(m, bd.ConnectInfo.Constring, false);

            
            return dr;

        }



        /// <summary>
        /// 生单
        /// </summary>
        /// <param name="bd"></param>
        /// <returns></returns>
        public override Model.DealResult MakeVouch(BaseData bd)
        {
            Model.DealResult dr = base.MakeVouch(bd);
            string sql = string.Empty;
            string ccuspersoncode = string.Empty;
            string ccusperson = string.Empty;
            sql = " select cContactCode,cContactName from Crm_Contact   where cCusCode =(select cCusCode  from DispatchList where DLID = '" + dr.VouchIdRet + "')";
            DbHelperSQLP help = new DbHelperSQLP(bd.ConnectInfo.Constring);
            DataSet ds = help.Query(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //设置客户联系人编码，客户联系人
                ccuspersoncode = ds.Tables[0].Rows[0]["cContactCode"].ToString();
                ccusperson = ds.Tables[0].Rows[0]["cContactName"].ToString();
                sql = "update DispatchList set ccuspersoncode='" + ccuspersoncode + "',ccusperson ='" + ccusperson + "' where DLID = '" + dr.VouchIdRet + "'";
                help.ExecuteSql(sql);
            }
            return dr;
        }

         


        public override string SetTableName()
        {
            return "DispatchList";
        }

        public override string SetVouchType()
        {
            return "10";
        }

        public override string GetCodeorID(string strID, BaseData bd, string codeorid)
        {
            string sqlstr = string.Empty;
            if (codeorid == "id")
            {
                sqlstr = "select isnull( dlid,'') from DispatchList  with(nolock)  where cDLCode='" + strID + "' and cvouchtype = '05' ";
            }
            if (codeorid == "code")
            {
                sqlstr = "select  isnull( cDLCode,'') from DispatchList  with(nolock)   where dlid='" + strID + "'";
            }
            Model.APIData apidata = bd as Model.APIData;

            DbHelperSQLP sqlp = new DbHelperSQLP(apidata.ConnectInfo.Constring);
            string ret = sqlp.GetSingle(sqlstr).NullToString();
            //DAL.Common.ErrorMsg(ret, "未能获取发货单ID或单号");
            return ret;
        }

        public override bool CheckAuditStatus(string strVoucherNo, string strConn)
        {
            string sql = string.Empty;
            bool bSucc;

            sql = "select cVerifier  from DispatchList where cDLCode ='" + strVoucherNo + "' and cvouchtype = '05' and breturnflag=1  and isnull(iswfcontrolled,0)=0 ";

            DbHelperSQLP sqlp = new DbHelperSQLP(strConn);
            if (string.IsNullOrEmpty(sqlp.GetSingle(sql).NullToString()))
            {
                bSucc = false;
            }
            else
            {
                bSucc = true;
            }
            return bSucc;
        }


        private string cardNo = "";
        private string headtable = "";
        private string bodytable = "";



        public override Synergismlogdt GetFirst(Synergismlogdt dt)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// 获取下一任务结点
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public override List<Model.Synergismlogdt> GetNext(Model.Synergismlogdt dt)
        {
            throw new NotImplementedException();
        }


        //获取上一结点
        public override Model.Synergismlogdt GetPrevious(Model.Synergismlogdt dt)
        { return null; }
        //获取上一结点
        public override int Update(Model.Synergismlogdt dt)
        {
            return 1;
        }

        //
        public override int Update(Model.Synergismlog dt)
        {
            return 1;
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="autoid">子任务ID</param>
        /// <returns></returns>
        public override Model.Synergismlogdt GetModel(string autoid)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="id">主任务ID</param>
        /// <returns></returns>
        public override Model.Synergismlog GetLogModel(string id)
        {
            throw new NotImplementedException();
        }
    }
}
