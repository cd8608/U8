using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using U8.Interface.Bus.DBUtility;
using U8.Interface.Bus.ApiService.BLL;

namespace U8.Interface.Bus.ApiService.Voucher
{
    public  static  class Common
    {

        /// <summary>
        /// 获取来源单据表头信息
        /// </summary>
        /// <param name="Vouchertype"></param>
        /// <param name="Voucherno"></param>
        /// <param name="Constring"></param>
        /// <returns></returns>
        public static DataSet GetSourceMainDataset(string Vouchertype,string Voucherno,string Constring)
        {

            DataSet ds = null;
            switch (Vouchertype)
            {

                case "88":
                    ds = GetPO_Pomain(Voucherno, Constring);
                    break;
                case "17":
                    ds = GetSO_SOMain(Voucherno, Constring);
                    break;
                case "27":
                    ds = GetPU_AppVouch(Voucherno, Constring);
                    break;
                case "24":
                    DAL.Rdrecord01 rd01dal = new DAL.Rdrecord01();
                    ds = rd01dal.GetRdrecord01ByCode(Voucherno, Constring);
                    break;
                case "0303":
                    DAL.Rdrecord32 rd32dal = new DAL.Rdrecord32();
                    ds = rd32dal.GetRdrecord32ByCode(Voucherno, Constring);
                    break;
                case "01"://发货单
                    ds = GetDispatchList(Voucherno, Constring);
                    break;
                case "03": //退货单    added by liuxzha  2014.11.27
                    ds = GetDispatchList(Voucherno, Constring);
                    break;
                case "0304"://调拨单
                    ds = GetTransVouch(Voucherno, Constring);
                    break;
                case "0301"://其他入库单
                    ds = GetRdRecord08(Voucherno, Constring);
                    break;
                case "0302"://其他出库单
                    ds = GetRdRecord09(Voucherno, Constring);
                    break;
                case "26"://到货单
                    ds = GetPU_ArrivalVouch(Voucherno, Constring);
                    break;
                case "MO21": //生产订单
                    DAL.CQ.Mom_order modal = new DAL.CQ.Mom_order();
                    ds = modal.GetMom_orderByCode(Voucherno, Constring);
                    break;
                case "0411":  //产成品入库单
                    ds = GetRdRecord10(Voucherno, Constring);
                    break;
            }
            BLL.Common.ErrorMsg(ds, "表头信息获取为空");
            return ds;
        
        }



        /// <summary>
        /// 获取来源单据表体信息
        /// </summary>
        /// <param name="Vouchertype"></param>
        /// <param name="Voucherno"></param>
        /// <param name="Constring"></param>
        /// <returns></returns>
        public static DataSet GetSourceDetailDataset(string Vouchertype, string Voucherno, string Constring)
        {
            DataSet ds = null;

            switch (Vouchertype)
            {

                case "88":
                    ds = GetPO_Podetails(Voucherno, Constring);
                    break;
                case "17":
                    ds = GetSO_SODetails(Voucherno, Constring);
                    break;
                case "27":
                    ds = GetPU_AppVouchs(Voucherno, Constring);
                    break;
                case "24":
                    DAL.Rdrecord01 rd01dal = new DAL.Rdrecord01();
                    ds = rd01dal.GetRdrecord01sByCode(Voucherno, Constring);
                    break;
                case "0303":
                    DAL.Rdrecord32 rd32dal = new DAL.Rdrecord32();
                    ds = rd32dal.GetRdrecords32ByCode(Voucherno, Constring);
                    break;
                case "01":   //发货单
                    ds = GetDispatchLists(Voucherno, Constring);
                    break;
                case "03":  //退货单    added by liuxzha  2014.11.27
                    ds = GetDispatchLists(Voucherno, Constring);
                    break;
                case "0304"://调拨单
                    ds = GetTransVouchs(Voucherno, Constring);
                    break;
                case "0301"://其他入库单
                    ds = GetRdRecords08(Voucherno, Constring);
                    break;
                case "0302"://其他出库单
                    ds = GetRdRecords09(Voucherno, Constring);
                    break;
                case "26"://到货单
                    ds = GetPU_ArrivalVouchs(Voucherno, Constring);
                    break;
                case "MO21": //生产订单
                    DAL.CQ.Mom_order modal = new DAL.CQ.Mom_order();
                    ds = modal.GetMom_orderdetailByCode(Voucherno, Constring);
                    break;  
                case "0411":  //产成品入库单
                    ds = GetRdRecords10(Voucherno, Constring);
                    break;
                     
            }
            BLL.Common.ErrorMsg(ds, "表体信息获取为空");
            return ds;
        
        }



        /// <summary>
        /// 到货单表头
        /// </summary>
        /// <param name="Cvoucherno"></param>
        /// <param name="Constring"></param>
        /// <returns></returns>
        private static DataSet GetPU_ArrivalVouch(string Cvoucherno, string Constring)
        {
            string sql = "select * from pu_ArrHead with(nolock)  where cCode='" + Cvoucherno + "' ";
            DbHelperSQLP help = new DbHelperSQLP(Constring);
            DataSet ds = help.Query(sql);
            BLL.Common.ErrorMsg(ds, "未能获取到货单表头信息");
            return ds;

        }
        /// <summary>
        /// 到货单表体
        /// </summary>
        /// <param name="Cvoucherno"></param>
        /// <param name="Constring"></param>
        /// <returns></returns>
        private static DataSet GetPU_ArrivalVouchs(string Cvoucherno, string Constring)
        {

            string sql = " select * from [pu_ArrBody]  with(nolock) where ID =(select id from [PU_ArrivalVouch] with(nolock)  where ccode='" + Cvoucherno + "')";
            DbHelperSQLP help = new DbHelperSQLP(Constring);
            DataSet ds = help.Query(sql);
            BLL.Common.ErrorMsg(ds, "未能获取到货单表体信息");
            return ds;

        }
        /// <summary>
        /// 其他出库单表头
        /// </summary>
        /// <param name="Cvoucherno"></param>
        /// <param name="Constring"></param>
        /// <returns></returns>
        private static DataSet GetRdRecord09(string Cvoucherno, string Constring)
        {
            string sql = "select * from KCOtherOutH  with(nolock) where ccode='" + Cvoucherno + "' ";
            DbHelperSQLP help = new DbHelperSQLP(Constring);
            DataSet ds = help.Query(sql);
            BLL.Common.ErrorMsg(ds, "未能获取其他出库单表头信息");
            return ds;

        }
        /// <summary>
        /// 其他出库单表体
        /// </summary>
        /// <param name="Cvoucherno"></param>
        /// <param name="Constring"></param>
        /// <returns></returns>
        private static DataSet GetRdRecords09(string Cvoucherno, string Constring)
        {
            string sql = "select * from KCOtherOutB with(nolock) where id=(select id from [RDRecord09] with(nolock) where ccode='" + Cvoucherno + "' )";
            DbHelperSQLP help = new DbHelperSQLP(Constring);
            DataSet ds = help.Query(sql);
            BLL.Common.ErrorMsg(ds, "未能获取其他出库单表体信息");
            return ds;

        }

        /// <summary>
        /// 其他入库单表头
        /// </summary>
        /// <param name="Cvoucherno"></param>
        /// <param name="Constring"></param>
        /// <returns></returns>
        private static DataSet GetRdRecord08(string Cvoucherno, string Constring)
        {
            string sql = "select * from KCOtherInH  with(nolock) where ccode='" + Cvoucherno + "' ";
            DbHelperSQLP help = new DbHelperSQLP(Constring);
            DataSet ds = help.Query(sql);
            BLL.Common.ErrorMsg(ds, "未能获取其他入库单表头信息");
            return ds;
        
        }

        /// <summary>
        /// 其他入库单表体
        /// </summary>
        /// <param name="Cvoucherno"></param>
        /// <param name="Constring"></param>
        /// <returns></returns>
        private static DataSet GetRdRecords08(string Cvoucherno, string Constring)
        {
            string sql = "select * from KCOtherInB  with(nolock) where id=(select id from KCOtherInB  with(nolock) where ccode='" + Cvoucherno + "' )";
            DbHelperSQLP help = new DbHelperSQLP(Constring);
            DataSet ds = help.Query(sql);
            BLL.Common.ErrorMsg(ds, "未能获取其他入库单表体信息");
            return ds;
        }
        /// <summary>
        /// 调拨单表头
        /// </summary>
        /// <param name="Cvoucherno"></param>
        /// <param name="Constring"></param>
        /// <returns></returns>
        private static DataSet GetTransVouch(string Cvoucherno, string Constring)
        {
            string sql = "select * from TransM   with(nolock) where cTVCode='" + Cvoucherno + "' ";
            DbHelperSQLP help = new DbHelperSQLP(Constring);
            DataSet ds = help.Query(sql);
            BLL.Common.ErrorMsg(ds, "未能获取调拨单表头信息");
            return ds;
        }

        /// <summary>
        /// 调拨单表体
        /// </summary>
        /// <param name="Cvoucherno"></param>
        /// <param name="Constring"></param>
        /// <returns></returns>
        private static DataSet GetTransVouchs(string Cvoucherno, string Constring)
        {
            string sql = "select *  from TransD  with (nolock) where id=(select id from [TransVouch] with(nolock)  where cTVCode='" + Cvoucherno + "') ";
            DbHelperSQLP help = new DbHelperSQLP(Constring);
            DataSet ds = help.Query(sql);
            BLL.Common.ErrorMsg(ds, "未能获取调拨单表体信息");
            return ds;
        }

        private  static DataSet GetPO_Pomain(string Cvoucherno, string Constring)
        {
            string sql = "select * from zpurpoheader  with (nolock) where cPOID='" + Cvoucherno + "' ";
            DbHelperSQLP help = new DbHelperSQLP(Constring);
            DataSet ds= help.Query(sql);
            BLL.Common.ErrorMsg(ds, "未能获取采购订单表头信息");
            return ds;
        }

        private static DataSet GetPO_Podetails(string Cvoucherno, string Constring)
        {
            string sql = "select * from zpurpotail with(nolock)  where poid=(select poid from PO_Pomain with(nolock)  where cPOID='" + Cvoucherno + "') ";
            DbHelperSQLP help = new DbHelperSQLP(Constring);
            DataSet ds = help.Query(sql);
            BLL.Common.ErrorMsg(ds, "未能获取采购订单表体信息");
            return ds;
        }

        private static DataSet GetSO_SOMain(string Cvoucherno, string Constring)
        {
            string sql = "select * from SaleOrderQ  with(nolock) where cSOCode='" + Cvoucherno + "' ";
            DbHelperSQLP help = new DbHelperSQLP(Constring);
            DataSet ds = help.Query(sql);
            BLL.Common.ErrorMsg(ds, "未能获取销售订单表头信息");
            return ds;
        }
        private static DataSet GetSO_SODetails(string Cvoucherno, string Constring)
        {
            string sql = "select * from SaleOrderSQ  with(nolock) where id=(select id from SaleOrderQ  with(nolock) where cSOCode='" + Cvoucherno + "') ";
            DbHelperSQLP help = new DbHelperSQLP(Constring);
            DataSet ds = help.Query(sql);
            BLL.Common.ErrorMsg(ds, "未能获取销售订单表体信息");
            return ds;
        }

        private static DataSet GetPU_AppVouchs(string code, string constring)
        {
            string sql = "  select s.*  from pu_AppBody  s with(nolock)  left join PU_AppVouch p with(nolock)  on p.ID=s.ID where p.ccode='" + code + "' ";
            DbHelperSQLP help = new DbHelperSQLP(constring);
            DataSet ds = help.Query(sql);
            BLL.Common.ErrorMsg(ds, "未能获取请购单表体信息");
            return ds;
        }


        private static DataSet GetPU_AppVouch(string code, string constring)
        {
            string sql = "select * from pu_AppHead with(nolock)  where ccode='" + code + "' ";
            DbHelperSQLP help = new DbHelperSQLP(constring);
            DataSet ds = help.Query(sql);
            BLL.Common.ErrorMsg(ds, "未能获取请购订单表头信息");
            return ds;
        }

        private static DataSet GetDispatchList(string code, string constring)
        {
            string sql = "select  *  from Sales_FHD_T with(nolock) where cdlcode='" + code + "' and cvouchtype = '05' ";
            DbHelperSQLP help = new DbHelperSQLP(constring);
            DataSet ds = help.Query(sql);
            if (code.ToLower().Equals("03"))      //added by liuxzha   2014.11.27
            {
                BLL.Common.ErrorMsg(ds, "未能获取退货单表头信息");
            }
            else
            {
                BLL.Common.ErrorMsg(ds, "未能获取发货单表头信息");
            } 
            return ds;
        }
        private static DataSet GetDispatchLists(string code, string constring)
        {
            string sql = "select * from Sales_FHD_W with(nolock)  where DLID=(select DLID from DispatchList with(nolock)   where cdlcode='" + code + "' and cvouchtype = '05' )";
            DbHelperSQLP help = new DbHelperSQLP(constring);
            DataSet ds = help.Query(sql);
            if (code.ToLower().Equals("03"))      //added by liuxzha   2014.11.27
            {
                BLL.Common.ErrorMsg(ds, "未能获取发货单表体信息");
            }
            else
            {
                BLL.Common.ErrorMsg(ds, "未能获取发货单表体信息");
            }
            return ds;
        }


        /// <summary>
        /// 产成品入库单表头
        /// </summary>
        /// <param name="Cvoucherno"></param>
        /// <param name="Constring"></param>
        /// <returns></returns>
        private static DataSet GetRdRecord10(string Cvoucherno, string Constring)
        {
            string sql = "select * from RecordInQ  with(nolock) where ccode='" + Cvoucherno + "' ";
            DbHelperSQLP help = new DbHelperSQLP(Constring);
            DataSet ds = help.Query(sql);
            BLL.Common.ErrorMsg(ds, "未能获取其他入库单表头信息");
            return ds;

        }


        /// <summary>
        /// 产成品入库单表体
        /// </summary>
        /// <param name="Cvoucherno"></param>
        /// <param name="Constring"></param>
        /// <returns></returns>
        private static DataSet GetRdRecords10(string Cvoucherno, string Constring)
        {
            string sql = "select * from RecordInSQ  with(nolock) where id=(select id from KCOtherInB  with(nolock) where ccode='" + Cvoucherno + "' )";
            DbHelperSQLP help = new DbHelperSQLP(Constring);
            DataSet ds = help.Query(sql);
            BLL.Common.ErrorMsg(ds, "未能获取其他入库单表体信息");
            return ds;
        }


    }
}
