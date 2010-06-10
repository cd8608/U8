using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MSXML2;


namespace U8.Interface.Bus.Event.SyncAdapter.Biz
{
    class MoBom : BizBase
    {

        int moid, modid;

        public MoBom(ref ADODB.Connection conn, int moid, int modid, string ufConnStr)
            : base(conn, ufConnStr)
        {
            oracleTableName = "TBLERPMOBOM";
            oraclePriKey = "MOCODE";

            ufTableName = "mom_moallocate";
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
                DataRow dr = UFSelect(" SELECT m.MoCode,d.SortSeq from mom_order m left join mom_orderdetail d on m.MoId = d.MoId  WHERE m.MOID = '" + moid + "' AND d.MODID = '" + modid + "'").Rows[0];
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
            DataTable dtBom = GetMoBomInfo(moid,modid);

            dsBom.Tables.Add(dtBom.Copy()); 
            //GetAllChildByInvCode(ref dsBom, dtBom);

            for (int i = 0; i < dsBom.Tables.Count; i++)
            {
                if (dsBom.Tables[i].Rows.Count > 0)
                {

                    for (int j = 0; j < dsBom.Tables[i].Rows.Count; j++)
                    {
                        List<BaseMode> tmpL = new List<BaseMode>();
                        tmpL.Add(new BaseMode("MoCode", dsBom.Tables[i].Rows[j]["MoCode"].ToString(), null, "MOCODE", dsBom.Tables[i].Rows[j]["MoCode"].ToString(), null, null));
                        tmpL.Add(new BaseMode("DSortSeq", dsBom.Tables[i].Rows[j]["DSortSeq"].ToString(), null, "MOLINE", dsBom.Tables[i].Rows[j]["DSortSeq"].ToString(), null, null));   //2015.01.23
                        //MOVER
                        tmpL.Add(new BaseMode("DInvCode", dsBom.Tables[i].Rows[j]["DInvCode"].ToString(), null, "ITEMCODE", dsBom.Tables[i].Rows[j]["DInvCode"].ToString(), null, null));
                        tmpL.Add(new BaseMode("InvCode", dsBom.Tables[i].Rows[j]["InvCode"].ToString(), null, "MOBITEMCODE", dsBom.Tables[i].Rows[j]["InvCode"].ToString(), null, null));
                        tmpL.Add(new BaseMode("BaseQtyN", dsBom.Tables[i].Rows[j]["BaseQtyN"].ToString(), null, "MOBITEMQTY", dsBom.Tables[i].Rows[j]["BaseQtyN"].ToString(), null, null));
  

                        //MOBSITEMCODE
                        tmpL.Add(new BaseMode("cComUnitCode", dsBom.Tables[i].Rows[j]["cComUnitCode"].ToString(), null, "MOBOMITEMUOM", dsBom.Tables[i].Rows[j]["cComUnitCode"].ToString(), null, null));
                        tmpL.Add(new BaseMode("DBomVersion", dsBom.Tables[i].Rows[j]["DBomVersion"].ToString(), null, "MOBOM", dsBom.Tables[i].Rows[j]["DBomVersion"].ToString(), null, null));
                        tmpL.Add(new BaseMode(null, null, null, "Flag", "W", null, null));

                        tmpL.Add(new BaseMode(null, null, null, "EDITPROP", "A", null, null));
                        tmpL.Add(new BaseMode(null, null, null, "FINISHFLAG", "0", null, null));
                        tmpL.Add(new BaseMode(null, null, null, "dModifyDate", System.DateTime.Now.ToString(), null, null)); 

                        lst.Add(tmpL);
                    }
                    
                }
            }
        }



 
        private DataTable GetMoBomInfo(int moid,int modid)
        {
            DataTable dtBom = new DataTable();
            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT  m.MoCode,d.DSortSeq,d.DInvCode,d.DBomVersion,   ");
            sb.Append("    dc.InvCode,dc.BaseQtyN,i.cComUnitCode  ");
            sb.Append("  FROM v_mom_order_wf m ");
            sb.Append("     LEFT JOIN v_mom_orderdetail_wf d ON m.MoId = d.MoId ");
            sb.Append("     LEFT JOIN mom_moallocate dc on d.modid = dc.modid ");
            sb.Append("     LEFT JOIN Inventory I ON I.cInvCode = dc.InvCode  ");
            sb.Append("  WHERE  m.MoId ='" + moid + "' AND d.MoDid ='" + modid + "'  "); 
            

            dtBom = UFSelect(sb.ToString());
            return dtBom;

        }




       
    }
}
