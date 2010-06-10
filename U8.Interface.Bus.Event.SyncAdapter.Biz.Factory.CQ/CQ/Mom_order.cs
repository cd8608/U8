using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using MSXML2;



namespace U8.Interface.Bus.Event.SyncAdapter.Biz.Factory.CQ 
{
    public class Mom_order : BizBase
    {
        private int moid, modid; 
        Mom_orderdetail detailBiz;
        Mom_OrderBom detailBomBiz;
        Mom_moallocate locateBiz;

        public Mom_order(ref ADODB.Connection conn, int moid, int modid, string ufConnStr, string _opertype)
            : base(conn, ufConnStr)
        {

            oracleTableName = "MES_CQ_mom_order";   //目标表名
            oraclePriKey = "MoCode";      //目标表主键 
            fieldcmpTablename = "MES_CQ_mom_order";
            ufTableName = "mom_order";       //来源表名
            ufPriKey = "MoId";          //来源表主键
            this.opertype = _opertype;
            this.modid = modid;
            this.moid = moid;
        }
 

        #region 赋值操作

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="doc"></param>
        private void SetData(int moid, int modid)
        {
            //lst = MakeMultiLineData(null, fieldcmpTablename, ufTableName, ufPriKey, Convert.ToString(moid));
            detailBiz = new Mom_orderdetail(ref conn, moid, modid, ufConnStr, opertype);
            detailBiz.lst = detailBiz.MakeMultiLineData(null, detailBiz.fieldcmpTablename, detailBiz.ufTableName, detailBiz.ufPriKey, Convert.ToString(moid));
            detailBomBiz = new Mom_OrderBom(ref conn, moid, modid, ufConnStr, opertype);
            detailBomBiz.lst = detailBomBiz.MakeMultiLineData(null, detailBomBiz.fieldcmpTablename, detailBomBiz.ufTableName, detailBomBiz.ufPriKey, Convert.ToString(moid));
        }
 

        /// <summary>
        /// 获取来源档案数据
        /// </summary>
        /// <param name="sourceTableName"></param>
        /// <param name="sourceKeyName"></param>
        /// <param name="sourceKeyValue"></param>
        /// <param name="colNames"></param>
        /// <returns></returns>
        public override DataTable GetSourceData(string sourceTableName, string sourceKeyName, string sourceKeyValue, string colNames)
        {
            string _tempsourcetable = ufTableName;
            string sql = "SELECT " + colNames + " FROM " + _tempsourcetable + "  WHERE moid ='" + moid + "' ";
            DataTable dtValue = new DataTable();
            dtValue = UFSelect(sql);
            return dtValue;
        }

         /// <summary>
         /// 新增 
         /// </summary>
         /// <returns></returns>
        public override object Insert()
        {
            StringBuilder sb = new StringBuilder();
            SetData(moid, modid);
            //sb.Append(this.CreateInsertString());
            sb.Append(detailBiz.CreateInsertString());
            sb.Append(detailBomBiz.CreateInsertString());

            sb.Replace("main|##newguid", Guid.NewGuid().ToString());

            if (bNoCase)
            {
                DeleteLog();  //清除旧记录
            }
            if (sb.Length > 0)
            {
                return ExecSql(sb.ToString());
            }
            return null;
        }


        /// <summary>
        /// 删除 
        /// </summary>
        /// <returns></returns>
        public override object Delete()
        {
            if (U8.Interface.Bus.Config.ConfigUtility.LogOper)
            {
                return Insert();
            }
            else
            {
                return DeleteLog();
            }
        }



        /// <summary>
        /// 删除中间表数据
        /// </summary>
        /// <returns></returns>
        public object DeleteLog()
        {
            StringBuilder sb = new StringBuilder();
            if (lst.Count == 0)
            {
                SetData(moid, modid);
            }
            //sb.Append(this.CreateDeleteString());
            sb.Append(detailBiz.CreateDeleteString());
            sb.Append(detailBomBiz.CreateDeleteString());

            if (sb.Length > 0)
            {
                return ExecSql(sb.ToString());
            }
            return null;
        }

        #endregion


    }
}
