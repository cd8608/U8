using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MSXML2;


namespace U8.Interface.Bus.Event.SyncAdapter.Biz.Factory.DS 
{
    public class Sfc_prouting : BizBase
    {
        private int _PRoutingId;
        Sfc_proutingdetail detailBiz; 

        public Sfc_prouting(ref ADODB.Connection conn, int bomId, string ufConnStr, string _opertype)
            : base(conn, ufConnStr)
        {

            oracleTableName = "MES_Sfc_prouting";   //目标表名
            oraclePriKey = "PRoutingId";      //目标表主键 
            fieldcmpTablename = "Sfc_prouting";
            ufTableName = "Sfc_prouting";       //来源表名
            ufPriKey = "PRoutingId";          //来源表主键
            this.opertype = _opertype;
            this._PRoutingId = bomId; 
        }



        #region 赋值操作

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="doc"></param>
        private void SetData(int PRoutingId)
        {
            lst = MakeMultiLineData(null, fieldcmpTablename, ufTableName, ufPriKey, Convert.ToString(PRoutingId));
            detailBiz = new Sfc_proutingdetail(ref conn, PRoutingId, ufConnStr, opertype);
            detailBiz.lst = detailBiz.MakeMultiLineData(null, detailBiz.fieldcmpTablename, detailBiz.ufTableName, detailBiz.ufPriKey, Convert.ToString(PRoutingId)); 
        }

        public override object Insert()
        {
            StringBuilder sb = new StringBuilder();
            SetData(_PRoutingId);
            sb.Append(this.CreateInsertString());
            sb.Append(detailBiz.CreateInsertString());

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

        public object Delete2()
        {
            StringBuilder sb = new StringBuilder();
            if (lst.Count == 0)
            {
                SetData(_PRoutingId);
            }
            sb.Append(this.CreateDeleteString());
            sb.Append(detailBiz.CreateDeleteString());
            if (sb.Length > 0)
            {
                return ExecSql(sb.ToString());
            }
            return null;
        }

        #endregion


    }
}
