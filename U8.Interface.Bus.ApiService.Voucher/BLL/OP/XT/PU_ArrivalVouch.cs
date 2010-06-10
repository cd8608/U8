using System;
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
    /// 采购到货单(HY_DZ_K7_DLLReflect预置的op类)
    /// </summary>
    public class PU_ArrivalVouch : PurchaseOp
    {
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
        /// <summary>
        /// 获取任务队列
        /// </summary>
        /// <returns></returns>
        public override TaskList GetTask()
        {
            return null;
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

        public override Model.DealResult MakeAudit(BaseData bd, Model.Synergismlogdt dt)
        {
            Model.DealResult dr = base.MakeAudit(bd, dt);

            ////设置审核日期
            //Model.APIData apidata = bd as Model.APIData;
            //Model.OrderModel o = new Model.OrderModel();
            //o.MainTable = SetTableName();
            //o.HeadPKFld = "cCode";
            //o.HeadPKVal = dt.Cvoucherno;

            //Model.U8NameValue nv;
            //nv = DAL.Common.GetApiDataValue(apidata, "T", 0, "ddate");
            //DateTime date = DateTime.Parse(nv.U8FieldValue);

            //nv = DAL.Common.GetApiDataValue(apidata, "T", 0, "cAuditDate");
            //if (nv.U8FieldValue == "") nv.U8FieldValue = DateTime.Now.ToString("yyyy-MM-dd");
            //if (DateTime.Parse(nv.U8FieldValue) < date) nv.U8FieldValue = date.ToString("yyyy-MM-dd");
            //o.FieldList.Add(nv);
            //nv = DAL.Common.GetApiDataValue(apidata, "T", 0, "cAuditTime");
            //if (nv.U8FieldValue == "") nv.U8FieldValue = o.FieldList[0].U8FieldValue + " " + DateTime.Now.ToShortTimeString();
            //o.FieldList.Add(nv);
            //DAL.Common.SetHeadInfo(o, bd.ConnectInfo.Constring);

            return dr;

        }

        public override string SetTableName()
        {
            return "PU_ArrivalVouch";
        }

        public override string SetVouchType()
        {
            return "2";
        }


        /// <summary>
        /// 重写删除
        /// </summary>
        /// <param name="bd"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public override Model.DealResult UndoMake(BaseData bd, Model.Synergismlogdt dt)
        {
            Model.DealResult dr = new Model.DealResult();
            dr = base.UndoMake(bd, dt);
            string vouchid = this.GetCodeorID(dt.Cvoucherno, bd, "id");
            string sql1 = string.Format("delete PU_ArrivalVouch_ExtraDefine where id='{0}'", vouchid);
            string sql2 = string.Format("delete PU_ArrivalVouchs where id='{0}'", vouchid);
            string sql3 = string.Format("delete PU_ArrivalVouch where id='{0}'", vouchid);

            try
            {
                DbHelperSQLP help = new DbHelperSQLP(bd.ConnectInfo.Constring);
                help.ExecuteSql(sql1);
                help.ExecuteSql(sql2);
                help.ExecuteSql(sql3);

            }
            catch
            { }
            return dr;

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
        }

        public override string GetCodeorID(string strID, BaseData bd, string codeorid)
        {
            string sqlstr = string.Empty;
            if (codeorid == "id")
            {
                sqlstr = "select isnull(id,'') from PU_ArrivalVouch  with(nolock)  where ccode='" + strID + "'";
            }
            if (codeorid == "code")
            {
                sqlstr = "select isnull(ccode,'') from PU_ArrivalVouch  with(nolock)  where id='" + strID + "'";
            }
            Model.APIData apidata = bd as Model.APIData;

            DbHelperSQLP sqlp = new DbHelperSQLP(apidata.ConnectInfo.Constring);
            string ret = sqlp.GetSingle(sqlstr).NullToString();
            //DAL.Common.ErrorMsg(ret, "未能获采购到货单ID或单号");
            return ret;
        }

        public override bool CheckAuditStatus(string strVoucherNo, string strConn)
        {
            string sql = string.Empty;
            bool bSucc;
            //edit by wangdd
            //添加审批流判断条件，有只有非审批流才能直接在日志内删除，审批流必须进入单据
            sql = "select cverifier  from PU_ArrivalVouch where cCode = '" + strVoucherNo + "'  and isnull(iswfcontrolled,0)=0";

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

        public override Model.Synergismlogdt GetFirst(Model.Synergismlogdt dt)
        {
            return null;
        }
        //获取上一结点
        public override Model.Synergismlogdt GetPrevious(Model.Synergismlogdt dt)
        { return null; }
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
        public override int Update(Model.Synergismlogdt dt)
        {
            return 1;
        }

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
