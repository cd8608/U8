using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MSXML2;


namespace U8.Interface.Bus.Event.SyncAdapter.Biz.Factory.HM
{
    class MoMain : BizBase
    {

        int moid, modid;

        public MoMain(ref ADODB.Connection conn, int moid, int modid, string ufConnStr)
            : base(conn, ufConnStr)
        {
            oracleTableName = "TBLERPMO";
            oraclePriKey = "MOCODE";

            ufTableName = "";
            ufPriKey = "MoCode";

            this.moid = moid;
            this.modid = modid;
        }

        public override object Insert()
        {
            SetAddData(moid, modid);
            return base.Insert();
        }

        public override object Delete()
        {
            SetDeleteData(moid, modid);
            return base.Delete();
        }



        /// <summary>
        /// 设置数据
        /// </summary>
        /// <param name="bomId"></param>
        public void SetDeleteData(int moid, int modid)
        {

            DataRow dr = UFSelect(" SELECT MoCode,SortSeq  from mom_order m  with(nolock) left join mom_orderdetail d with(nolock) on m.MoId = d.MoId  WHERE m.MOID = '" + moid + "' AND d.MODID = '" + modid + "'").Rows[0];
            string mocode = dr[0].ToString();
            string SortSeq = dr[1].ToString();
            l.Add(new BaseMode("MoCode", mocode, null, "MOCODE", mocode, null, null));
            l.Add(new BaseMode("DSortSeq", SortSeq, null, "MOLINE", SortSeq, null, null));   //2015.01.23 

            l.Add(new BaseMode(null, null, null, "EDITPROP", "D", null, null));
            l.Add(new BaseMode(null, null, null, "FINISHFLAG", "0", null, null));
            l.Add(new BaseMode(null, null, null, "dModifyDate", System.DateTime.Now.ToString(), null, null));
        }

        /// <summary>
        /// 设置数据
        /// </summary>
        /// <param name="bomId"></param>
        public void SetAddData( int moid, int modid)
        {
            DataSet dsBom = new DataSet();
            DataTable dtBom = GetOrderInfo(moid,modid);

            dsBom.Tables.Add(dtBom.Copy()); 
            //GetAllChildByInvCode(ref dsBom, dtBom);

            for (int i = 0; i < dsBom.Tables.Count; i++)
            {
                if (dsBom.Tables[i].Rows.Count > 0)
                { 
                    for (int j = 0; j < dsBom.Tables[i].Rows.Count; j++)
                    {
                        List<BaseMode> tmpL = new List<BaseMode>();
                        tmpL.Add(new BaseMode("MoCode", dsBom.Tables[i].Rows[j]["MoCode"].ToString(), null, "MOCODE", dsBom.Tables[i].Rows[j]["MoCode"].ToString(),null,null));
                        tmpL.Add(new BaseMode("DSortSeq ", dsBom.Tables[i].Rows[j]["DSortSeq"].ToString(), null, "MOLINE", dsBom.Tables[i].Rows[j]["DSortSeq"].ToString(),null,null));  //2015.01.23
                        //tmpL.Add(new BaseMode("DMoTypeCode", dsBom.Tables[i].Rows[j]["DMoTypeCode"].ToString(), null, "MOTYPE", dsBom.Tables[i].Rows[j]["DMoTypeCode"].ToString(),null,null));
                        tmpL.Add(new BaseMode("DMoTypeCode", dsBom.Tables[i].Rows[j]["DMoTypeCode"].ToString(), null, "MOTYPE", "NORMAL",null,null));
                        
                        tmpL.Add(new BaseMode("DQty", dsBom.Tables[i].Rows[j]["DQty"].ToString(), null, "MOPLANQTY", dsBom.Tables[i].Rows[j]["DQty"].ToString(),null,null));
                        tmpL.Add(new BaseMode("DStartDate", dsBom.Tables[i].Rows[j]["DStartDate"].ToString(), null, "MOPLANSTARTDATE", dsBom.Tables[i].Rows[j]["DStartDate"].ToString(),null,null));
                        tmpL.Add(new BaseMode("DDueDate", dsBom.Tables[i].Rows[j]["DDueDate"].ToString(), null, "MOPLANENDDATE", dsBom.Tables[i].Rows[j]["DDueDate"].ToString(),null,null));
                        tmpL.Add(new BaseMode("DOrderCode", dsBom.Tables[i].Rows[j]["DOrderCode"].ToString(), null, "ORDERNO", dsBom.Tables[i].Rows[j]["DOrderCode"].ToString(),null,null));
                        string ORDERSEQ = dsBom.Tables[i].Rows[j]["DOrderSeq"].ToString();
                        if (!string.IsNullOrEmpty(ORDERSEQ))
                        {
                            tmpL.Add(new BaseMode("DOrderSeq", dsBom.Tables[i].Rows[j]["DOrderSeq"].ToString(), null, "ORDERSEQ", dsBom.Tables[i].Rows[j]["DOrderSeq"].ToString(),null,null));
                        }
                        tmpL.Add(new BaseMode("CreateDate", dsBom.Tables[i].Rows[j]["CreateDate"].ToString(), null, "MODOWNDATE", dsBom.Tables[i].Rows[j]["CreateDate"].ToString(),null,null));
                        tmpL.Add(new BaseMode("DInvCode", dsBom.Tables[i].Rows[j]["DInvCode"].ToString(), null, "ITEMCODE", dsBom.Tables[i].Rows[j]["DInvCode"].ToString(),null,null));
                        tmpL.Add(new BaseMode("DCustInvCode", dsBom.Tables[i].Rows[j]["DCustInvCode"].ToString(), null, "CUSITEMCODE", dsBom.Tables[i].Rows[j]["DCustInvCode"].ToString(),null,null));
                        tmpL.Add(new BaseMode("DBomVersion", dsBom.Tables[i].Rows[j]["DBomVersion"].ToString(), null, "MOBOM", dsBom.Tables[i].Rows[j]["DBomVersion"].ToString(),null,null));
                        tmpL.Add(new BaseMode("DRemark", dsBom.Tables[i].Rows[j]["DRemark"].ToString(), null, "MORemark", dsBom.Tables[i].Rows[j]["DRemark"].ToString(),null,null));
                        tmpL.Add(new BaseMode(null, null, null, "FLAG", "W",null,null)); 

                        tmpL.Add(new BaseMode(null, null, null, "EDITPROP", "A",null,null));
                        tmpL.Add(new BaseMode(null, null, null, "FINISHFLAG", "0",null,null));
                        tmpL.Add(new BaseMode(null, null, null, "dModifyDate", System.DateTime.Now.ToString(),null,null)); 

                        lst.Add(tmpL); 
                    }
                    
                }
            }
        }




        private DataTable GetOrderInfo(int moid, int modid)
        {
            DataTable dtBom = new DataTable();
            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT m.MoCode,d.DSortSeq,d.DMoTypeCode,d.DQty,d.DStartDate,d.DDueDate,  ");
            sb.Append("     case when d.DOrderType = '1' then d.DOrderCode else null end as DOrderCode,");
            sb.Append("     case when d.DOrderType ='1' then d.DOrderSeq else null end as DOrderSeq,  ");
            sb.Append("     m.CreateDate, ");
            sb.Append("     d.DInvCode,d.DCustInvCode,d.DBomVersion, ");
            sb.Append("     d.DRemark    ");
            sb.Append("  FROM v_mom_order_wf m with(nolock) ");
            sb.Append("     LEFT JOIN v_mom_orderdetail_wf d with(nolock) ON m.MoId = d.MoId ");
            sb.Append("  WHERE  m.MoId ='" + moid + "'  AND d.MoDid = '" + modid + "' "); 

            dtBom = UFSelect(sb.ToString());
            return dtBom;

        }


        /// <summary>
        /// 递归BOM
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="dt"></param>
        private void GetAllChildByInvCode(ref DataSet ds, DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataTable dtChild = new DataTable();
                dtChild = GetChildByInvcode(dt.Rows[i]["InvCode"].ToString());
                if (dtChild.Rows.Count > 0)
                {
                    ds.Tables.Add(dtChild.Copy());
                    GetAllChildByInvCode(ref ds, dt);
                }
            }
        }

        private DataTable GetChildByInvcode(string cInvcode)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT V.* FROM  ");
            sb.Append(" ( ");
            sb.Append("     SELECT  ");
            sb.Append("           h.InvCode,h.InvName,h.version,  ");
            sb.Append("           D.DInvCode,D.DInvCode AS subInvCode,d.DEffBegDate,d.DEffEndDate,d.DInvUnit ,d.DBaseQtyD   ");
            sb.Append("     FROM v_bom_head h with(nolock)  ");
            sb.Append("           LEFT JOIN v_bom_detail d with(nolock) ON h.bomid = d.bomid  ");
            sb.Append("     WHERE  H.InvCode ='" + cInvcode + "' ");
            sb.Append("     UNION ALL ");
            sb.Append("     SELECT ");
            sb.Append("           h.InvCode,h.InvName,h.version, ");
            sb.Append("           D.DInvCode,rm.invcode AS subInvCode,d.DEffBegDate,d.DEffEndDate,d.DInvUnit ,d.DBaseQtyD  ");
            sb.Append("     FROM v_bom_head h ");
            sb.Append("           LEFT JOIN v_bom_detail d with(nolock) ON h.bomid = d.bomid  ");
            sb.Append("           LEFT JOIN bom_opcomponentsub r with(nolock) ON d.opcomponentid = r.opcomponentid ");
            sb.Append("           LEFT JOIN bas_part rm with(nolock) ON r.PartId = rm.PartId ");
            sb.Append("           WHERE  H.InvCode ='" + cInvcode + "' AND ISNULL(rm.InvCode,'') <> '' ");
            sb.Append(" ) V");
            sb.Append(" ORDER BY  V.DInvCode,V.subInvCode ");

            dt = UFSelect(sb.ToString());

            return dt;
        }




       
    }
}
