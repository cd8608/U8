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
    /// 其他入库单(HY_DZ_K7_DLLReflect预置的op类)
    /// </summary>
   public class RdRecord08:StockOP
    {
        public override string SetApiAddressAdd()
        {
            return "U8API/otherin/Add";
        }

        public override string SetApiAddressAudit()
        {
            return "U8API/otherin/Audit";
        }

        public override string SetApiAddressCancelAudit()
        {
            return "U8API/otherin/CancelAudit";
        }

        public override string SetApiAddressDelete()
        {
            return "U8API/otherin/Delete";
        }

        public override string SetApiAddressLoad()
        {
            return "U8API/otherin/Load";
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
            //nv = DAL.Common.GetApiDataValue(apidata, "T", 0, "dVeriDate");
            //if (nv.U8FieldValue == "") nv.U8FieldValue = DateTime.Now.ToString("yyyy-MM-dd");
            //o.FieldList.Add(nv);
            //nv = DAL.Common.GetApiDataValue(apidata, "T", 0, "dnverifytime");
            //if (nv.U8FieldValue == "") nv.U8FieldValue = o.FieldList[0].U8FieldValue + " " + DateTime.Now.ToShortTimeString();
            //o.FieldList.Add(nv);
            //DAL.Common.SetHeadInfo(o, bd.ConnectInfo.Constring);

            return dr;

        }

        public override string SetTableName()
        {
            return "RdRecord08";
        }

        public override string SetVouchType()
        {
            return "08";
        }

        public override string GetCodeorID(string strID, BaseData bd, string codeorid)
        {
            string sqlstr = string.Empty;
            if (codeorid == "id")
            {
                sqlstr = "select isnull(id,'') from RdRecord08   with(nolock) where ccode='" + strID + "'";
            }
            if (codeorid == "code")
            {
                sqlstr = "select isnull(ccode,'') from RdRecord08   with(nolock) where id='" + strID + "'";
            }
            Model.APIData apidata = bd as Model.APIData;

            DbHelperSQLP sqlp = new DbHelperSQLP(apidata.ConnectInfo.Constring);
            string ret = sqlp.GetSingle(sqlstr).NullToString();
           //DAL.Common.ErrorMsg(ret, "未能获其他入库单ID或单号");
            return ret;
        } 

        public override bool CheckAuditStatus(string strVoucherNo, string strConn)
        {
            return false;
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
        
        // 
        public override int Update(Model.Synergismlog dt)
        {
            return 1;
        }

        public override int Update(Model.Synergismlogdt dt)
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
