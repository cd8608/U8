using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data; 


namespace U8.Interface.Bus.Event.SyncAdapter.Biz.Factory.HM
{
    public class Bom_bom : BizBase
    {
 
        int bomId;
        System.Data.DataSet ds;

        /// <summary>
        /// 保存前事件使用(保存并自动审核时，BOM单不会自动调用审核事件)
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="ds"></param>
        /// <param name="ufConnStr"></param>
        public Bom_bom(ref ADODB.Connection conn, ref System.Data.DataSet ds, string ufConnStr)
            : base(conn, ufConnStr)
        {

            oracleTableName = "TBLERPSBOM";
            oraclePriKey = "ITEMCODE,SBOMVER";

            ufTableName = "";
            ufPriKey = "InvCode,version";
            this.ds = ds;
         
        }


        public Bom_bom(ref ADODB.Connection conn, int bomId, string ufConnStr)
            : base(conn, ufConnStr)
        {

            oracleTableName = "TBLERPSBOM";
            oraclePriKey = "ITEMCODE,SBOMVER";

            ufTableName = "";
            ufPriKey = "InvCode,version";

            this.bomId = bomId; 
        }


        public override object Insert()
        {
            if (bomId > 0)
            {
                SetAddData(bomId);
            }
            else
            {
                if (CheckAutoAudit(ref ds))
                {
                    SetAddData(ref ds);
                }
            
            }
            if (l.Count == 0 && lst.Count == 0)
            {
                return null;
            }
            else
            {
                return base.BatchInsert();
            }
        }
  
 
        public override object Delete()
        {
            if (bomId >0)
            {
                SetDelData(bomId);
            }
            else
            {
                if (CheckAutoAudit(ref ds))
                {
                    SetDelData(ref ds);
                }

            } 
            return base.Delete();
        }


        /// <summary>
        /// 判断标准BOM是不是保存后默认为审核状态
        /// </summary>
        /// <returns></returns>
        private bool CheckAutoAudit(ref System.Data.DataSet ds)
        {
            string bomId = ds.Tables["StandardBom"].Rows[0]["BomId"].ToString();
            string sql = " select count(1) as  cc from bom_bom with(nolock) where bomid ='" + bomId + "'  ";
            DataTable dt = UFSelect(sql); 
            if (dt.Rows.Count > 0)
            {
                if ((int)dt.Rows[0][0]> 0)
                {
                    return false;
                }
            }

            sql = " select BomDefaultStatus  from mom_parameter  with(nolock)  ";
            dt = UFSelect(sql);
            if (dt.Rows.Count > 0)
            {
                return (bool)(dt.Rows[0][0].ToString().Trim().Equals("3"));
            }
            else
            {
                return false;
            }
        }




        /// <summary>
        /// 保存时,默认为审核状态,需要往MES表中插入数据
        /// ITEMCODE
        /// SBITEMCODE
        /// SBSITEMCODE
        /// SBITEMQTY
        /// SBITEMECN
        /// SBITEMEFFDATE
        /// SBITEMINVDATE
        /// SBITEMUOM
        /// SBOMVER
        /// LOCATION
        /// </summary>
        /// <param name="doc"></param>
        public void SetAddData(ref DataSet ds)
        {
            string InvCode = GetInvCodeByPartid(ds.Tables["BomParent"].Rows[0]["ParentId"].ToString());
            string version = ds.Tables["StandardBom"].Rows[0]["Version"].ToString();
            string VersionEffDate = ds.Tables["StandardBom"].Rows[0]["VersionEffDate"].ToString();
            string VersionEndDate = ds.Tables["StandardBom"].Rows[0]["VersionEndDate"].ToString();

            string DInvCode;
            string DInvUnit;

            //子件表
            for (int i = 0; i < ds.Tables["BomComponents"].Rows.Count; i++)
            {
                if (ds.Tables["BomComponents"].Rows[i].RowState.ToString().ToLower().Equals("deleted"))
                {
                    continue; 
                }
                List<BaseMode> tmpL = new List<BaseMode>();
                tmpL.Add(new BaseMode("InvCode", InvCode, null, "ITEMCODE", InvCode,null,null));
                DInvCode = GetInvCodeByPartid(ds.Tables["BomComponents"].Rows[i]["ComponentId"].ToString());
                tmpL.Add(new BaseMode("DInvCode", DInvCode, null, "SBITEMCODE", DInvCode,null,null));
                tmpL.Add(new BaseMode("subInvCode", DInvCode, null, "SBSITEMCODE", DInvCode,null,null));
                tmpL.Add(new BaseMode("DBaseQtyD", ds.Tables["BomComponents"].Rows[i]["BaseQtyD"].ToString(), null, "SBITEMQTY", ds.Tables["BomComponents"].Rows[i]["BaseQtyD"].ToString(),null,null));

                /// SBITEMECN
                tmpL.Add(new BaseMode("DEffBegDate", VersionEffDate, null, "SBITEMEFFDATE", VersionEffDate,null,null));
                tmpL.Add(new BaseMode("DEffEndDate", VersionEndDate, null, "SBITEMINVDATE", VersionEndDate,null,null));
                DInvUnit = GetUnitCodeByInvCode(DInvCode);
                tmpL.Add(new BaseMode("DInvUnit", DInvUnit, null, "SBITEMUOM", DInvUnit,null,null));
                tmpL.Add(new BaseMode("version", version, null, "SBOMVER", version,null,null));
                tmpL.Add(new BaseMode(null, "", null, "LOCATION", "",null,null));
                tmpL.Add(new BaseMode(null, null, null, "FLAG", "W",null,null));


                tmpL.Add(new BaseMode(null, null, null, "EDITPROP", "A",null,null));
                tmpL.Add(new BaseMode(null, null, null, "FINISHFLAG", "0",null,null));
                tmpL.Add(new BaseMode(null, null, null, "dModifyDate", System.DateTime.Now.ToString(),null,null)); 


                lst.Add(tmpL);
            }

            //替代料
            for (int i = 0; i < ds.Tables["ComponentSubstitutes"].Rows.Count; i++)
            {
                if (ds.Tables["ComponentSubstitutes"].Rows[i].RowState.ToString().ToLower().Equals("deleted"))
                {
                    continue; 
                }
                List<BaseMode> tmpL = new List<BaseMode>();
                tmpL.Add(new BaseMode("InvCode", InvCode, null, "ITEMCODE", InvCode,null,null));
                DInvCode = GetInvCodeByPartid(ds.Tables["BomComponents"].Select("OpComponentId='" + ds.Tables["ComponentSubstitutes"].Rows[i]["OpComponentId"].ToString() + "'")[0]["ComponentId"].ToString());
                DInvUnit = GetUnitCodeByInvCode(DInvCode);
                tmpL.Add(new BaseMode("DInvCode", DInvCode, null, "SBITEMCODE", DInvCode,null,null));
                DInvCode = GetInvCodeByPartid(ds.Tables["ComponentSubstitutes"].Rows[i]["PartId"].ToString());
                tmpL.Add(new BaseMode("subInvCode", DInvCode, null, "SBSITEMCODE", DInvCode,null,null));
                tmpL.Add(new BaseMode("DBaseQtyD", 
                    ds.Tables["BomComponents"].Select("OpComponentId='" + ds.Tables["ComponentSubstitutes"].Rows[i]["OpComponentId"].ToString() + "'")[0]["BaseQtyD"].ToString(),
                    null, "SBITEMQTY", 
                    ds.Tables["BomComponents"].Select("OpComponentId='" + ds.Tables["ComponentSubstitutes"].Rows[i]["OpComponentId"].ToString() + "'")[0]["BaseQtyD"].ToString()
                    ,null,null));

                /// SBITEMECN
                tmpL.Add(new BaseMode("DEffBegDate", VersionEffDate, null, "SBITEMEFFDATE", VersionEffDate,null,null));
                tmpL.Add(new BaseMode("DEffEndDate", VersionEndDate, null, "SBITEMINVDATE", VersionEndDate,null,null)); 
                tmpL.Add(new BaseMode("DInvUnit", DInvUnit, null, "SBITEMUOM", DInvUnit,null,null));
                tmpL.Add(new BaseMode("version", version, null, "SBOMVER", version,null,null));
                tmpL.Add(new BaseMode(null, "", null, "LOCATION", "",null,null));
                tmpL.Add(new BaseMode(null, null, null, "FLAG", "W",null,null)); 

                tmpL.Add(new BaseMode(null, null, null, "EDITPROP", "A",null,null));
                tmpL.Add(new BaseMode(null, null, null, "FINISHFLAG", "0",null,null));
                tmpL.Add(new BaseMode(null, null, null, "dModifyDate", System.DateTime.Now.ToString(),null,null)); 


                lst.Add(tmpL);
            }
        }





        /// <summary>
        /// 保存时,默认为审核状态,需要往MES表中插入数据
        /// ITEMCODE
        /// SBITEMCODE
        /// SBSITEMCODE
        /// SBITEMQTY
        /// SBITEMECN
        /// SBITEMEFFDATE
        /// SBITEMINVDATE
        /// SBITEMUOM
        /// SBOMVER
        /// LOCATION
        /// </summary>
        /// <param name="doc"></param>
        public void SetDelData(ref DataSet ds)
        {
            string InvCode = GetInvCodeByPartid(ds.Tables["BomParent"].Rows[0]["ParentId"].ToString());
            string version = ds.Tables["StandardBom"].Rows[0]["Version"].ToString();
            string VersionEffDate = ds.Tables["StandardBom"].Rows[0]["VersionEffDate"].ToString();
            string VersionEndDate = ds.Tables["StandardBom"].Rows[0]["VersionEndDate"].ToString();

            string DInvCode;
            string DInvUnit;

            //子件表
            for (int i = 0; i < ds.Tables["BomComponents"].Rows.Count; i++)
            {
                if (ds.Tables["BomComponents"].Rows[i].RowState.ToString().ToLower().Equals("deleted"))
                {
                    continue;
                }
                List<BaseMode> tmpL = new List<BaseMode>();
                tmpL.Add(new BaseMode("InvCode", InvCode, null, "ITEMCODE", InvCode,null,null));
                DInvCode = GetInvCodeByPartid(ds.Tables["BomComponents"].Rows[i]["ComponentId"].ToString());
                tmpL.Add(new BaseMode("DInvCode", DInvCode, null, "SBITEMCODE", DInvCode,null,null));
                tmpL.Add(new BaseMode("subInvCode", DInvCode, null, "SBSITEMCODE", DInvCode,null,null));
                tmpL.Add(new BaseMode("DBaseQtyD", ds.Tables["BomComponents"].Rows[i]["BaseQtyD"].ToString(), null, "SBITEMQTY", ds.Tables["BomComponents"].Rows[i]["BaseQtyD"].ToString(),null,null));

                /// SBITEMECN
                tmpL.Add(new BaseMode("DEffBegDate", VersionEffDate, null, "SBITEMEFFDATE", VersionEffDate,null,null));
                tmpL.Add(new BaseMode("DEffEndDate", VersionEndDate, null, "SBITEMINVDATE", VersionEndDate,null,null));
                DInvUnit = GetUnitCodeByInvCode(DInvCode);
                tmpL.Add(new BaseMode("DInvUnit", DInvUnit, null, "SBITEMUOM", DInvUnit,null,null));
                tmpL.Add(new BaseMode("version", version, null, "SBOMVER", version,null,null));
                tmpL.Add(new BaseMode(null, "", null, "LOCATION", "",null,null));


                tmpL.Add(new BaseMode(null, null, null, "EDITPROP", "D",null,null));
                tmpL.Add(new BaseMode(null, null, null, "FINISHFLAG", "0",null,null));
                tmpL.Add(new BaseMode(null, null, null, "dModifyDate", System.DateTime.Now.ToString(),null,null));


                lst.Add(tmpL);
            }

            //替代料
            for (int i = 0; i < ds.Tables["ComponentSubstitutes"].Rows.Count; i++)
            {
                if (ds.Tables["ComponentSubstitutes"].Rows[i].RowState.ToString().ToLower().Equals("deleted"))
                {
                    continue;
                }
                List<BaseMode> tmpL = new List<BaseMode>();
                tmpL.Add(new BaseMode("InvCode", InvCode, null, "ITEMCODE", InvCode,null,null));
                DInvCode = GetInvCodeByPartid(ds.Tables["BomComponents"].Select("OpComponentId='" + ds.Tables["ComponentSubstitutes"].Rows[i]["OpComponentId"].ToString() + "'")[0]["ComponentId"].ToString());
                DInvUnit = GetUnitCodeByInvCode(DInvCode);
                tmpL.Add(new BaseMode("DInvCode", DInvCode, null, "SBITEMCODE", DInvCode,null,null));
                DInvCode = GetInvCodeByPartid(ds.Tables["ComponentSubstitutes"].Rows[i]["PartId"].ToString());
                tmpL.Add(new BaseMode("subInvCode", DInvCode, null, "SBSITEMCODE", DInvCode,null,null));
                tmpL.Add(new BaseMode("DBaseQtyD",
                    ds.Tables["BomComponents"].Select("OpComponentId='" + ds.Tables["ComponentSubstitutes"].Rows[i]["OpComponentId"].ToString() + "'")[0]["BaseQtyD"].ToString(),
                    null, "SBITEMQTY",
                    ds.Tables["BomComponents"].Select("OpComponentId='" + ds.Tables["ComponentSubstitutes"].Rows[i]["OpComponentId"].ToString() + "'")[0]["BaseQtyD"].ToString()
                    ,null,null));

                /// SBITEMECN
                tmpL.Add(new BaseMode("DEffBegDate", VersionEffDate, null, "SBITEMEFFDATE", VersionEffDate,null,null));
                tmpL.Add(new BaseMode("DEffEndDate", VersionEndDate, null, "SBITEMINVDATE", VersionEndDate,null,null));
                tmpL.Add(new BaseMode("DInvUnit", DInvUnit, null, "SBITEMUOM", DInvUnit,null,null));
                tmpL.Add(new BaseMode("version", version, null, "SBOMVER", version,null,null));
                tmpL.Add(new BaseMode(null, "", null, "LOCATION", "",null,null));


                tmpL.Add(new BaseMode(null, null, null, "EDITPROP", "D",null,null));
                tmpL.Add(new BaseMode(null, null, null, "FINISHFLAG", "0",null,null));
                tmpL.Add(new BaseMode(null, null, null, "dModifyDate", System.DateTime.Now.ToString(),null,null));


                lst.Add(tmpL);
            }
        }



        /// <summary>
        /// 根据partid取存货编码
        /// </summary>
        /// <param name="partid"></param>
        /// <returns></returns>
        private string GetInvCodeByPartid(string partid)
        {
            string sql = " select top 1 InvCode from bas_part with(nolock) where PartId = '" +  partid  + "' ";
            DataTable dt = UFSelect(sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            return "";
        }



        /// <summary>
        /// 根据存货编码取计量单位
        /// </summary>
        /// <param name="partid"></param>
        /// <returns></returns>
        private string GetUnitCodeByInvCode(string cinvcode)
        {
            string sql = " select cComUnitCode from inventory with(nolock) where cinvcode = '" + cinvcode + "' ";
            DataTable dt = UFSelect(sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            return "";
        }



        /// <summary>
        /// 根据partid取计量单位
        /// </summary>
        /// <param name="partid"></param>
        /// <returns></returns>
        private string GetUnitCodeByPartid(string partid)
        {
            string sql = " select  i.cComUnitCode from bas_part rm with(nolock) left join inventory i with(nolock) on rm.InvCode = i.cInvCode  where rm.PartId = '" + partid + "' ";
            DataTable dt = UFSelect(sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            return "";
        }


        /// <summary>
        /// 设置数据
        /// </summary>
        /// <param name="bomId"></param>
        public void SetAddData(int bomId)
        {
            DataSet dsBom = new DataSet();
            DataTable dtBom = GetChildByBomId(bomId);
            dsBom.Tables.Add(dtBom.Copy()); 
            //GetAllChildByInvCode(ref dsBom, dtBom);   不需要递归 子件BOM  2015.03.30

            DataTable dtLocation = GetLocation(bomId);

            for (int i = 0; i < dsBom.Tables.Count; i++)
            {
                if (dsBom.Tables[i].Rows.Count > 0)
                { 
                    for (int j = 0; j < dsBom.Tables[i].Rows.Count; j++)
                    {
                        List<BaseMode> tmpL = new List<BaseMode>();
                        tmpL.Add(new BaseMode("InvCode", dsBom.Tables[i].Rows[j]["InvCode"].ToString(), null, "ITEMCODE", dsBom.Tables[i].Rows[j]["InvCode"].ToString(),null,null));
                        tmpL.Add(new BaseMode("DInvCode", dsBom.Tables[i].Rows[j]["DInvCode"].ToString(), null, "SBITEMCODE", dsBom.Tables[i].Rows[j]["DInvCode"].ToString(),null,null));
                        tmpL.Add(new BaseMode("subInvCode", dsBom.Tables[i].Rows[j]["subInvCode"].ToString(), null, "SBSITEMCODE", dsBom.Tables[i].Rows[j]["subInvCode"].ToString(),null,null)); 
                        tmpL.Add(new BaseMode("DBaseQtyD", dsBom.Tables[i].Rows[j]["DBaseQtyD"].ToString(), null, "SBITEMQTY", dsBom.Tables[i].Rows[j]["DBaseQtyD"].ToString(),null,null));
  
                        /// SBITEMECN
                        tmpL.Add(new BaseMode("DEffBegDate", dsBom.Tables[i].Rows[j]["DEffBegDate"].ToString(), null, "SBITEMEFFDATE", dsBom.Tables[i].Rows[j]["DEffBegDate"].ToString(),null,null));
                        tmpL.Add(new BaseMode("DEffEndDate", dsBom.Tables[i].Rows[j]["DEffEndDate"].ToString(), null, "SBITEMINVDATE", dsBom.Tables[i].Rows[j]["DEffEndDate"].ToString(),null,null));
                        tmpL.Add(new BaseMode("DInvUnit", dsBom.Tables[i].Rows[j]["DInvUnit"].ToString(), null, "SBITEMUOM", dsBom.Tables[i].Rows[j]["DInvUnit"].ToString(),null,null));
                        tmpL.Add(new BaseMode("version", dsBom.Tables[i].Rows[j]["version"].ToString(), null, "SBOMVER", dsBom.Tables[i].Rows[j]["version"].ToString(),null,null));
                        tmpL.Add(new BaseMode(null, "", null, "LOCATION", GetLocation(dtLocation,dsBom.Tables[i].Rows[j]["OpComponentId"].ToString()),null,null));   //定位符
                        tmpL.Add(new BaseMode(null, null, null, "FLAG", "W",null,null)); 


                        tmpL.Add(new BaseMode(null, null, null, "EDITPROP", "A",null,null));
                        tmpL.Add(new BaseMode(null, null, null, "FINISHFLAG", "0",null,null));
                        tmpL.Add(new BaseMode(null, null, null, "dModifyDate", System.DateTime.Now.ToString(),null,null));

                        lst.Add(tmpL); 
   
                    }
                    
                }
            }
        }



        /// <summary>
        /// 设置数据
        /// </summary>
        /// <param name="bomId"></param>
        public void SetDelData(int bomId)
        {
            DataSet dsBom = new DataSet();
            DataTable dtBom = GetChildByBomId(bomId);
            dsBom.Tables.Add(dtBom.Copy());
            //GetAllChildByInvCode(ref dsBom, dtBom);     不需要递归 子件BOM  2015.03.30

            for (int i = 0; i < dsBom.Tables.Count; i++)
            {
                if (dsBom.Tables[i].Rows.Count > 0)
                {
                    for (int j = 0; j < dsBom.Tables[i].Rows.Count; j++)
                    {
                        List<BaseMode> tmpL = new List<BaseMode>();
                        tmpL.Add(new BaseMode("InvCode", dsBom.Tables[i].Rows[j]["InvCode"].ToString(), null, "ITEMCODE", dsBom.Tables[i].Rows[j]["InvCode"].ToString(),null,null));
                        tmpL.Add(new BaseMode("DInvCode", dsBom.Tables[i].Rows[j]["DInvCode"].ToString(), null, "SBITEMCODE", dsBom.Tables[i].Rows[j]["DInvCode"].ToString(),null,null));
                        tmpL.Add(new BaseMode("subInvCode", dsBom.Tables[i].Rows[j]["subInvCode"].ToString(), null, "SBSITEMCODE", dsBom.Tables[i].Rows[j]["subInvCode"].ToString(),null,null));
                        tmpL.Add(new BaseMode("DBaseQtyD", dsBom.Tables[i].Rows[j]["DBaseQtyD"].ToString(), null, "SBITEMQTY", dsBom.Tables[i].Rows[j]["DBaseQtyD"].ToString(),null,null));

                        /// SBITEMECN
                        tmpL.Add(new BaseMode("DEffBegDate", dsBom.Tables[i].Rows[j]["DEffBegDate"].ToString(), null, "SBITEMEFFDATE", dsBom.Tables[i].Rows[j]["DEffBegDate"].ToString(),null,null));
                        tmpL.Add(new BaseMode("DEffEndDate", dsBom.Tables[i].Rows[j]["DEffEndDate"].ToString(), null, "SBITEMINVDATE", dsBom.Tables[i].Rows[j]["DEffEndDate"].ToString(),null,null));
                        tmpL.Add(new BaseMode("DInvUnit", dsBom.Tables[i].Rows[j]["DInvUnit"].ToString(), null, "SBITEMUOM", dsBom.Tables[i].Rows[j]["DInvUnit"].ToString(),null,null));
                        tmpL.Add(new BaseMode("version", dsBom.Tables[i].Rows[j]["version"].ToString(), null, "SBOMVER", dsBom.Tables[i].Rows[j]["version"].ToString(),null,null));
                        tmpL.Add(new BaseMode(null, "", null, "LOCATION", "",null,null)); 

                        tmpL.Add(new BaseMode(null, null, null, "EDITPROP", "D",null,null));
                        tmpL.Add(new BaseMode(null, null, null, "FINISHFLAG", "0",null,null));
                        tmpL.Add(new BaseMode(null, null, null, "dModifyDate", System.DateTime.Now.ToString(),null,null));


                        lst.Add(tmpL);

                    }

                }
            }
        }


        private DataTable GetChildByBomId(int bomId)
        {
            DataTable dtBom = new DataTable();
            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT V.* FROM  ");
            sb.Append(" ( ");
            sb.Append("     SELECT  ");
            sb.Append("           h.InvCode,h.InvName,h.version,  ");
            sb.Append("           D.DInvCode,D.DInvCode AS subInvCode,d.DEffBegDate,d.DEffEndDate,d.DInvUnit,d.DBaseQtyD,d.OpComponentId    ");
            sb.Append("     FROM v_bom_head h  with(nolock) ");
            sb.Append("           LEFT JOIN v_bom_detail d  with(nolock) ON h.bomid = d.bomid  ");
            sb.Append("     WHERE  H.bomid ='" + bomId + "' ");
            sb.Append("     UNION ALL ");
            sb.Append("     SELECT ");
            sb.Append("           h.InvCode,h.InvName,h.version, ");
            sb.Append("           D.DInvCode,rm.invcode AS subInvCode,d.DEffBegDate,d.DEffEndDate,i.cComUnitCode as DInvUnit,d.DBaseQtyD,d.OpComponentId   ");
            sb.Append("     FROM v_bom_head h  with(nolock) ");
            sb.Append("           LEFT JOIN v_bom_detail d  with(nolock) ON h.bomid = d.bomid  ");
            sb.Append("           LEFT JOIN bom_opcomponentsub r  with(nolock) ON d.opcomponentid = r.opcomponentid ");
            sb.Append("           LEFT JOIN bas_part rm  with(nolock) ON r.PartId = rm.PartId ");
            sb.Append("           LEFT JOIN inventory i  with(nolock) ON i.cInvCode = rm.InvCode ");
            sb.Append("           WHERE  H.bomid ='" + bomId + "' AND ISNULL(rm.InvCode,'') <> '' ");
            sb.Append(" ) V");
            sb.Append(" ORDER BY  V.DInvCode,V.subInvCode ");

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
                dtChild = GetChildByInvcode(dt.Rows[i]["subInvCode"].ToString());
                if (dtChild.Rows.Count > 0)
                {
                    dtChild.TableName = "Child_" + Guid.NewGuid().ToString();
                    ds.Tables.Add(dtChild.Copy());
                    GetAllChildByInvCode(ref ds, dtChild);
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
            sb.Append("           D.DInvCode,D.DInvCode AS subInvCode,d.DEffBegDate,d.DEffEndDate,d.DInvUnit ,d.DBaseQtyD,d.OpComponentId   ");
            sb.Append("     FROM v_bom_head h  with(nolock) ");
            sb.Append("           LEFT JOIN v_bom_detail d  with(nolock) ON h.bomid = d.bomid  ");
            sb.Append("     WHERE  H.InvCode ='" + cInvcode + "' ");
            sb.Append("     UNION ALL ");
            sb.Append("     SELECT ");
            sb.Append("           h.InvCode,h.InvName,h.version, ");
            sb.Append("           D.DInvCode,rm.invcode AS subInvCode,d.DEffBegDate,d.DEffEndDate,d.DInvUnit ,d.DBaseQtyD,d.OpComponentId  ");
            sb.Append("     FROM v_bom_head h with(nolock) ");
            sb.Append("           LEFT JOIN v_bom_detail d with(nolock) ON h.bomid = d.bomid  ");
            sb.Append("           LEFT JOIN bom_opcomponentsub r with(nolock) ON d.opcomponentid = r.opcomponentid ");
            sb.Append("           LEFT JOIN bas_part rm with(nolock) ON r.PartId = rm.PartId ");
            sb.Append("           WHERE  H.InvCode ='" + cInvcode + "' AND ISNULL(rm.InvCode,'') <> '' ");
            sb.Append(" ) V");
            sb.Append(" ORDER BY  V.DInvCode,V.subInvCode ");

            dt = UFSelect(sb.ToString());

            return dt;
        }


        #region 组织  定位符

        /// <summary>
        /// 组织  定位符原数据
        /// </summary>
        /// <returns></returns>
        private DataTable GetLocation_bak(int bomId)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT  loc,bom_opcomponentloc.OpComponentId FROM bom_opcomponent with(nolock) ");
            sb.Append(" INNER JOIN bom_opcomponentloc  with(nolock) on bom_opcomponentloc.OpComponentId = bom_opcomponent.OpComponentId ");
            sb.Append(" where bom_opcomponent.BomId = " + bomId + "");
            dt = UFSelect(sb.ToString());

            return dt;
        }

        /// <summary>
        /// 组织  定位符原数据
        /// </summary>
        /// <returns></returns>
        private DataTable GetLocation(int bomId)
        {
            DataTable dt = new DataTable();
            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT   a.OpComponentId,     loc=(select ' '+loc from bom_opcomponentloc b where b.OpComponentId=a.OpComponentId for xml path('')) ");
            sb.Append(" FROM bom_opcomponent with(nolock) ");
            sb.Append(" INNER JOIN bom_opcomponentloc a with(nolock) on a.OpComponentId = bom_opcomponent.OpComponentId ");
            sb.Append(" where bom_opcomponent.BomId = " + bomId + "");
            dt = UFSelect(sb.ToString());

            return dt;
        }

        /// <summary>
        /// 格式化定位符
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="OpComponentId"></param>
        /// <returns></returns>
        private string GetLocation(DataTable dt, string OpComponentId)
        {
            string res="";
            DataRow[] drArr = dt.Select("OpComponentId='" + OpComponentId + "'");
            for (int i = 0; i < drArr.Length; i++)
            {
                string tmpRes = drArr[i]["loc"].ToString();
                if (!string.IsNullOrEmpty(tmpRes))
                {
                    res += " " + tmpRes;
                }
            }
            return res;
        }


 
          
        #endregion




    }
}
