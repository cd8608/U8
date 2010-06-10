using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace U8.Interface.Bus.Event.SyncAdapter.Biz.Factory.DS 
{
    public class Mom_order : BizBase
    {
        private int moid, modid; 
        Mom_orderdetail detailBiz;
        Mom_moallocate locateBiz;

        public Mom_order(ref ADODB.Connection conn, int moid, int modid, string ufConnStr, string _opertype)
            : base(conn, ufConnStr)
        {

            oracleTableName = "MES_Mom_order";   //目标表名
            oraclePriKey = "MoId";      //目标表主键 
            fieldcmpTablename = "mom_order";
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
            lst = MakeMultiLineData(null, fieldcmpTablename, ufTableName, ufPriKey, Convert.ToString(moid));
            detailBiz = new Mom_orderdetail(ref conn, moid, modid, ufConnStr, opertype);
            detailBiz.lst = detailBiz.MakeMultiLineData(null, detailBiz.fieldcmpTablename, detailBiz.ufTableName, detailBiz.ufPriKey, Convert.ToString(moid));
            locateBiz = new Mom_moallocate(ref conn, moid, modid, ufConnStr,opertype);
            locateBiz.lst = locateBiz.MakeMultiLineData(null, locateBiz.fieldcmpTablename, locateBiz.ufTableName, locateBiz.ufPriKey, Convert.ToString(moid));
             
        }

        public override object Insert()
        {
            StringBuilder sb = new StringBuilder();
            SetData(moid, modid);
            sb.Append(this.CreateInsertString());
            sb.Append(detailBiz.CreateInsertString());
            sb.Append(locateBiz.CreateInsertString());

            if (bNoCase)
            {
                Delete2();  //清除旧记录
            }
            if (sb.Length > 0)
            {
                return ExecSql(sb.ToString());
            }
            return null;
        }

        public override object Delete()
        {
            return Insert();
        }

        /// <summary>
        /// 删除中间表数据
        /// </summary>
        /// <returns></returns>
        public object Delete2()
        {
            StringBuilder sb = new StringBuilder();
            if (lst.Count == 0)
            {
                SetData(moid, modid);
            }
            sb.Append(this.CreateDeleteString());
            sb.Append(detailBiz.CreateDeleteString());
            sb.Append(locateBiz.CreateDeleteString());

            if (sb.Length > 0)
            {
                return ExecSql(sb.ToString());
            }
            return null;
        }

        #endregion


    }
}
