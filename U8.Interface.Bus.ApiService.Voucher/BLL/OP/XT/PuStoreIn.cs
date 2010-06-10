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
    /// 采购入库单(HY_DZ_K7_DLLReflect预置的op类)
    /// </summary>
    public class PuStoreIn : StockOP
    {
        public override string SetApiAddressAdd()
        {
            return "U8API/PuStoreIn/Add";
        }

        public override string SetApiAddressAudit()
        {
            return "U8API/PuStoreIn/Audit";
        }

        public override string SetApiAddressDelete()
        {
            return "U8API/PuStoreIn/Delete";
        }


        public override string SetApiAddressCancelAudit()
        {
            return "U8API/PuStoreIn/CancelAudit";
        }

        public override string SetApiAddressLoad()
        {
            return "U8API/PuStoreIn/Load";
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



        /// <summary>
        /// 获取表头数据
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="pdt"></param>
        /// <param name="apidata"></param>
        /// <returns></returns>
        public override System.Data.DataSet SetFromTabet(Model.Synergismlogdt dt, Model.Synergismlogdt pdt, Model.APIData apidata)
        {
            ApiService.DAL.SynergismLogDt dtdal = new ApiService.DAL.SynergismLogDt();
            Model.ConnectInfo cimodel = dtdal.GetConnectInfo(pdt);
            return Common.GetSourceMainDataset(pdt.Cvouchertype, pdt.Cvoucherno, cimodel.Constring);
        }



        /// <summary>
        /// 获取表体数据
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="pdt"></param>
        /// <param name="apidata"></param>
        /// <returns></returns>
        public override System.Data.DataSet SetFromTabets(Model.Synergismlogdt dt, Model.Synergismlogdt pdt, Model.APIData apidata)
        {
            ApiService.DAL.SynergismLogDt dtdal = new ApiService.DAL.SynergismLogDt();
            Model.ConnectInfo cimodel = dtdal.GetConnectInfo(pdt);
            return Common.GetSourceDetailDataset(pdt.Cvouchertype, pdt.Cvoucherno, cimodel.Constring);
        }


        public override string SetTableName()
        {
            return "Rdrecord01";
        }

        public override string SetVouchType()
        {
            return "01";
        }

        public override string GetCodeorID(string strID, BaseData bd,string codeorid)
        {
            string sqlstr = string.Empty;
            if (codeorid == "id")
            {
                sqlstr = "select isnull(id,'') from Rdrecord01  with(nolock)  where ccode='" + strID + "'";
            }
            if (codeorid == "code")
            {
                sqlstr = "select isnull(ccode,'') from Rdrecord01  with(nolock)  where id='" + strID + "'";
            }
            Model.APIData apidata = bd as Model.APIData;
          
            DbHelperSQLP sqlp = new DbHelperSQLP(apidata.ConnectInfo.Constring);
            return sqlp.GetSingle(sqlstr).NullToString();
        }
 

        public override Model.DealResult MakeAudit(BaseData bd, Model.Synergismlogdt dt)
        {
            Model.DealResult dr = base.MakeAudit(bd, dt);

            Model.IrownoModel m = new Model.IrownoModel();
            m.Autoidname = "autoid";
            m.Barcodefomat = "st01";
            m.Barcodename = "cbsysbarcode";
            m.Code=dt.Cvoucherno;
            m.Id = GetCodeorID(dt.Cvoucherno,bd,"id");
            m.Idname="id";
            m.Tablename="rdrecords01";
            m.Fliedname = "irowno";
            ApiService.DAL.Common.setirowno(m, bd.ConnectInfo.Constring, true);
             
            return dr;

        }

        public override void SetNormalValue(Model.APIData apidata, Model.Synergismlogdt dt)
        {
            base.SetNormalValue(apidata, dt); 
          
        }

        public override bool CheckAuditStatus(string strVoucherNo, string strConn)
        {
            string sql = string.Empty;
            bool bSucc;
            //edit by wangdd
            //添加审批流判断条件，有只有非审批流才能直接在日志内删除，审批流必须进入单据
            sql = "select cHandler  from RdRecord01 where ccode = '" + strVoucherNo + "'  and isnull(iswfcontrolled,0)=0";

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
