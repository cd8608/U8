using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using U8.Interface.Bus.DBUtility;
using System.Data;

namespace U8.Interface.Bus.ApiService.Voucher.DAL.CQ
{
    public class Mom_order
    {
        string vouchername = "生产订单";
        string headtable = "v_mom_order_wf";
        string bodytable = "v_mom_orderdetail_wf";
        string codename = "MoCode";
        string keyname = "moid";

        /// <summary>
        /// 主表
        /// </summary>
        /// <param name="code"></param>
        /// <param name="constring"></param>
        /// <returns></returns>
        public DataSet GetMom_orderByCode(string code, string constring)
        {
            string sql = "select * from " + headtable + " with (nolock) where MoCode='" + code + "' ";
            DbHelperSQLP help = new DbHelperSQLP(constring);
            DataSet ds = help.Query(sql);
            BLL.Common.ErrorMsg(ds, "未能取到" + vouchername + "主表数据");
            return ds;

        }


        /// <summary>
        /// 子表
        /// </summary>
        /// <param name="code"></param>
        /// <param name="constring"></param>
        /// <returns></returns>
        public DataSet GetMom_orderdetailByCode(string code, string constring)
        {
            string sql = "select b.* from " + bodytable + " b with (nolock) left join v_mom_order_wf t with (nolock)  on b." + keyname + "=t." + keyname + " where t." + codename + "='" + code + "' ";
            DbHelperSQLP help = new DbHelperSQLP(constring);
            DataSet ds = help.Query(sql);
            BLL.Common.ErrorMsg(ds, "未能取到" + vouchername + "子表数据");
            return ds;
        }

    }
}
