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
    /// 销售出库单 (HY_DZ_K7_DLLReflect预置的op类)
    /// </summary>
    public class SalesOutStockOrder : SaleOp
    {

        /// <summary>
        /// 获取任务队列
        /// </summary>
        /// <returns></returns>
        public override TaskList GetTask()
        {
            return null;
        }



        public override string GetCodeorID(string strID, BaseData bd, string codeorid)
        {
            string strCode = string.Empty;
            try
            {
                Model.APIData apidta = bd as Model.APIData;
                DAL.Rdrecord32 rd32dal = new DAL.Rdrecord32();

                if (codeorid == "code")
                {
                    strCode = rd32dal.GetCodeByID(strID, apidta.ConnectInfo.Constring);
                }
                if (codeorid == "id")
                {
                    strCode = rd32dal.GetIDByCode(strID, apidta.ConnectInfo.Constring);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return strCode;
        }

        public override Model.DealResult MakeVouch(BaseData bd)
        {


            Model.DealResult dr = new Model.DealResult();
            DbHelperSQLP help = new DbHelperSQLP(bd.ConnectInfo.Constring);
            string sql = "select cvalue from accinformation  with(nolock)  where  cname = 'bSAcreat' and ISNULL(cValue,'')<>''";
            string flag = help.GetSingle(sql).NullToString();
            if (flag.ToLower() != "true") return base.MakeVouch(bd);

            Model.Synergismlogdt dt = bd.Synergismlogdt;
            BLL.SynergisnLogDT bll = new BLL.SynergisnLogDT();
            Model.Synergismlogdt prnext = bll.GetPrevious(dt,null);
            if (prnext.Cvouchertype != "01" && prnext.Cvouchertype != "03") return base.MakeVouch(bd);   //modified by liuxzha 支持退货单

            string id = string.Empty;
            int time = 1;
            while (string.IsNullOrEmpty(id) && time < 5)
            {
                sql = "select id from rdrecord32   with(nolock) where cbuscode='" + prnext.Cvoucherno + "'";
                id = help.GetSingle(sql).NullToString();
                System.Threading.Thread.Sleep(1000 * time);
                time++;
            }
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("未能取到U8系统自动生成的出库单!");

            }
            // DAL.Common.WriteWinLog(id);
            dr.VouchIdRet = id;
            return dr;

        }
         

        public override Model.DealResult MakeAudit(BaseData bd, Model.Synergismlogdt dt)
        {
            Model.DealResult dr = base.MakeAudit(bd, dt);

            Model.IrownoModel m = new Model.IrownoModel();
            m.Autoidname = "autoid";
            m.Barcodefomat = "st32";
            m.Barcodename = "cbsysbarcode";
            m.Code = dt.Cvoucherno;
            m.Id = GetCodeorID(dt.Cvoucherno, bd, "id");
            m.Idname = "id";
            m.Tablename = "rdrecords32";
            m.Fliedname = "irowno";
            ApiService.DAL.Common.setirowno(m, bd.ConnectInfo.Constring, true); 

            return dr;

        }


        public override string SetVouchType()
        {
            return "32";
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

        public override string SetTableName()
        {
            return "rdrecord32";
        }

        public override string SetApiAddressAdd()
        {
            return "U8API/saleout/Add";
        }

        public override string SetApiAddressAudit()
        {
            return "U8API/saleout/Audit";
        }

        public override string SetApiAddressDelete()
        {
            return "U8API/saleout/Delete";
        }
        public override string SetApiAddressCancelAudit()
        {
            return "U8API/saleout/CancelAudit";
        }
        public override string SetApiAddressLoad()
        {
            return "U8API/saleout/Load";
        }

        public override string SetApiAddressUpdate()
        {
            throw new NotImplementedException();
        }


        public override bool CheckAuditStatus(string strVoucherNo, string strConn)
        {
            string sql = string.Empty;
            bool bSucc;
            //edit by wangdd
            //添加审批流判断条件，有只有非审批流才能直接在日志内删除，审批流必须进入单据
            sql = "select cHandler  from rdrecord32 where cCode = '" + strVoucherNo + "' and isnull(iswfcontrolled,0)=0 ";

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
        {
            return null;
        }

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
