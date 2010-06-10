using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using U8.Interface.Bus.ApiService.DAL;
using U8.Interface.Bus.DBUtility;


namespace U8.Interface.Bus.ApiService.Voucher.DAL
{
    public class Rdrecord32
    {
        /// <summary>
        /// 发货单主表
        /// </summary>
        /// <param name="code"></param>
        /// <param name="constring"></param>
        /// <returns></returns>
        public DataSet GetDispatchListByCode(string code, string constring)
        {
            string sql = "select * from DispatchList  with(nolock)  where cDLCode='" + code + "' and cvouchtype = '05' ";
            DbHelperSQLP help = new DbHelperSQLP(constring);
            DataSet ds = help.Query(sql);
            BLL.Common.ErrorMsg(ds, "未能取到发货单主表数据");
            return ds;
        }

        /// <summary>
        /// 发货单子表
        /// </summary>
        /// <param name="code"></param>
        /// <param name="constring"></param>
        /// <returns></returns>
        public DataSet GetDispatchListsByCode(string code, string constring)
        {
            string sql = "select s.* from DispatchLists   with(nolock)  s left join DispatchList  with(nolock)  b on s.dlid=b.dlid where b.cDLCode='" + code + "' and b.cvouchtype = '05'  ";
            DbHelperSQLP help = new DbHelperSQLP(constring);
            DataSet ds = help.Query(sql);
            BLL.Common.ErrorMsg(ds, "未能取到发货单子表数据");
            return ds;
        }

        public string GetCodeByID(string strID, string constring) 
        {
            string sql = "select isnull( ccode,'') from rdrecord32  with(nolock)  where id='" + strID + "' ";
            DbHelperSQLP help = new DbHelperSQLP(constring);
            string ret = help.GetSingle(sql).NullToString();
           // DAL.Common.ErrorMsg(ret, "未能取到发货单号");
            return ret;
        }

        public string GetIDByCode(string strID, string constring)
        {
            string sql = "select isnull( id,'') from rdrecord32  with(nolock)  where ccode='" + strID + "' ";
            DbHelperSQLP help = new DbHelperSQLP(constring);
            string ret = help.GetSingle(sql).NullToString();
           // DAL.Common.ErrorMsg(ret, "未能取到发货ID");
            return ret;
        }


        /// <summary>
        /// 主表
        /// </summary>
        /// <param name="code"></param>
        /// <param name="constring"></param>
        /// <returns></returns>
        public DataSet GetRdrecord32ByCode(string code, string constring)
        {
            string sql = "select * from KCSaleOutH with(nolock) where ccode='" + code + "' ";
            DbHelperSQLP help = new DbHelperSQLP(constring);
            DataSet ds = help.Query(sql);
            BLL.Common.ErrorMsg(ds, "未能获取出库单表头信息");
            return ds;

        }
        /// <summary>
        /// 子表
        /// </summary>
        /// <param name="code"></param>
        /// <param name="constring"></param>
        /// <returns></returns>
        public DataSet GetRdrecords32ByCode(string code, string constring)
        {
            string sql = "select s.* from KCSaleOutB s with(nolock) left join rdrecord32 b with(nolock) on s.ID=b.id where b.ccode='" + code + "' ";
            DbHelperSQLP help = new DbHelperSQLP(constring);
            DataSet ds = help.Query(sql);
            //DAL.Common.ErrorMsg(ds, "未能获取出库单表体信息");
            return ds;

        }

    }
}
