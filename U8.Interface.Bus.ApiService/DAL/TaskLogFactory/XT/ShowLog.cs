using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using U8.Interface.Bus.DBUtility;

namespace U8.Interface.Bus.ApiService.DAL
{
    public class ShowLog
    {

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="strWhere"></param>
        /// <param name="order"></param>
        /// <param name="ascOrDesc"></param>
        /// <returns></returns>
        public DataSet GetList(string Top, string strWhere, string order, string ascOrDesc)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ");
            if (!string.IsNullOrEmpty(Top) && int.Parse(Top) > 0)
            {
                strSql.Append(" TOP " + Top);
            }
            strSql.Append(" * FROM (");
            strSql.Append(" SELECT DISTINCT ");
            strSql.Append(" SY.*,ISNULL(RE.caddress,'') AS Caddress,ISNULL(RE.cacc_id,'') AS Cacc_Id,ISNULL(RE.cdatabase,'') AS Cacc_Name ");
            strSql.Append(" FROM HY_DZ_K7_SYNERGISMLOG SY ");
            strSql.Append(" JOIN HY_DZ_K7_SYNERGISMLOGDT DT ");
            strSql.Append(" ON SY.id=DT.id ");
            strSql.Append(" LEFT JOIN HY_DZ_K7_REGIST RE ");
            strSql.Append(" ON SY.caccid=RE.acccode ");
            strSql.Append(" LEFT JOIN HY_DZ_K7_REGIST RT ");
            strSql.Append(" ON DT.accid=RT.acccode ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                if (strWhere.Trim() != "1=1")
                    strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) AS T ");
            if (!string.IsNullOrEmpty(order))
            {
                if (order.ToLower() == "cstatus")
                    strSql.Append(string.Format(" ORDER BY CHARINDEX(cstatus, '处理中,未处理,等待中,错误,完成,已作废') {0} ", ascOrDesc));
                else
                {
                    strSql.Append(" ORDER BY CHARINDEX(cstatus, '处理中,未处理,等待中,错误,完成,已作废') ");
                    strSql.Append(string.Format(" ,{0} {1} ", order, ascOrDesc));
                }
            }
            else
            {
                strSql.Append(" ORDER BY CHARINDEX(cstatus, '处理中,未处理,等待中,错误,完成,已作废') ");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取导出数据
        /// </summary>
        /// <param name="isList"></param>
        /// <param name="Top"></param>
        /// <param name="strWhere"></param>
        /// <param name="order"></param>
        /// <param name="ascOrDesc"></param>
        /// <returns></returns>
        public DataSet GetOutputInfo(bool isList, string Top, string strWhere, string order, string ascOrDesc)
        {
            StringBuilder strSql = new StringBuilder();
            string[] arrOrder = order.Split(',');
            string[] arrDesc = ascOrDesc.Split(',');

            strSql.Append("SELECT ");
            if (!string.IsNullOrEmpty(Top) && int.Parse(Top) > 0)
            {
                strSql.Append(" TOP " + Top);
            }
            strSql.Append(" * FROM (");
            strSql.Append(" SELECT DISTINCT ");
            if (isList)
                strSql.Append(" SY.id,SY.cserialno,SY.croutetype,SY.caccid,SY.cvouchertype,SY.cvoucherno,SY.starttime,SY.endtime,SY.cstatus, ");
            else
                strSql.Append(" DT.autoid,DT.id,DT.ilineno,DT.accid,ISNULL(BI.cbillname,DT.cvouchertype) AS cvouchertype,DT.cvoucherno,DT.cpk,UD.cname AS CpkName,DT.dinputtime,DT.dmaketime,DT.cerrordesc,DT.cstatus,CASE DT.ismanual WHEN '1' THEN '是' ELSE '否' END AS ismanualc,CASE DT.isaudit WHEN '1' THEN '是' ELSE '否' END AS isauditc,DT.errortimes,CASE DT.cdealmothed WHEN '1' THEN '新增' WHEN '2' THEN '修改' WHEN '3' THEN '删除' ELSE '生单' END AS cdealmothedc,DT.fatherid, ");
            strSql.Append(" ISNULL(RE.caddress,'') AS Caddress,ISNULL(RE.cacc_id,'') AS Cacc_Id,ISNULL(RE.cdatabase,'') AS Cacc_Name ");
            strSql.Append(" FROM HY_DZ_K7_SYNERGISMLOG SY ");
            strSql.Append(" JOIN HY_DZ_K7_SYNERGISMLOGDT DT ");
            strSql.Append(" ON SY.id=DT.id ");
            strSql.Append(" LEFT JOIN HY_DZ_K7_REGIST RE ");
            strSql.Append(" ON SY.caccid=RE.acccode ");
            strSql.Append(" LEFT JOIN HY_DZ_K7_REGIST RT ");
            strSql.Append(" ON DT.accid=RT.acccode ");
            if (!isList)
            {
                strSql.Append(" LEFT JOIN HY_DZ_K7_BILLSCOPE BI ");
                strSql.Append(" ON DT.cvouchertype=BI.cardnum ");
                strSql.Append(" LEFT JOIN HY_DZ_K7_MASTERUPD UD ");
                strSql.Append(" ON DT.cpk=UD.ccode ");
            }
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                if (strWhere.Trim() != "1=1")
                    strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) AS T ORDER BY ");
            if (!string.IsNullOrEmpty(order))
            {
                if (isList)
                {
                    for (int i = 0; i < arrOrder.Length; i++)
                    {
                        if (string.IsNullOrEmpty(arrDesc[i])) arrDesc[i] = "asc";
                        if (arrOrder[i].ToLower() == "cstatus")
                        {
                            strSql.Append(string.Format(" CHARINDEX(cstatus, '处理中,未处理,等待中,错误,完成,已作废') {0},", arrDesc[i]));
                        }
                        else
                        {
                            strSql.Append(string.Format(" {0} {1},", arrOrder[i], arrDesc[i]));
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < arrOrder.Length; i++)
                    {
                        if (string.IsNullOrEmpty(arrDesc[i])) arrDesc[i] = "asc";
                        strSql.Append(string.Format(" {0} {1},", arrOrder[i], arrDesc[i]));
                    }
                }
            }
            else
            {
                if (isList)
                {
                    strSql.Append(" id desc");
                }
                else
                {
                    strSql.Append(" id desc,ilineno");
                }
            }
            if (strSql[strSql.Length - 1] == ',') strSql.Remove(strSql.Length - 1, 1);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取档案名称
        /// </summary>
        /// <param name="cVoucerType"></param>
        /// <param name="cVoucherNo"></param>
        /// <returns></returns>
        public string GetDataName(string cVoucerType, string cVoucherNo)
        {
            if (string.IsNullOrEmpty(cVoucerType)) return cVoucherNo;

            string strName;
            string strSql;
            object oName;
            switch (cVoucerType)
            {
                //case "发货单":
                //case "销售出库单":
                //case "调拨单":
                //case "其他入库单":
                //case "销售订单":
                //case "采购订单":
                //case "采购入库单":
                //case "其他出库单":
                //case "采购请购单":
                //case "采购到货单":
                //    strName = cVoucherNo;
                //    break;
                case "存货价格列表":
                    //strSql = "SELECT TOP 1 ISNULL(B.ccode,'') AS DataName FROM SA_InvPriceJustDetail A LEFT JOIN SA_InvPriceJustMain B ON A.id=B.id WHERE A.autoid='" + cVoucherNo + "' ";
                    strSql = "SELECT TOP 1 ISNULL(B.cInvName,'') AS DataName FROM SA_InvPriceJustDetail A JOIN Inventory B ON A.cinvcode=B.cInvCode WHERE A.autoid='" + cVoucherNo + "' ";
                    oName = DbHelperSQL.GetSingle(strSql);
                    if (oName == null || oName == DBNull.Value) strName = cVoucherNo;
                    else strName = oName.ToString();
                    break;
                case "客户价格列表":
                    //strSql = "SELECT TOP 1 ISNULL(B.ccode,'') AS DataName FROM SA_CusPriceJustDetail A LEFT JOIN SA_CusPriceJustMain B ON A.id=B.id WHERE A.autoid='" + cVoucherNo + "' ";
                    strSql = "SELECT TOP 1 ISNULL(B.cCusName,'')+' | '+ISNULL(C.cInvName,'') AS DataName FROM SA_CusPriceJustDetail A JOIN Customer B ON A.ccuscode=B.cCusCode JOIN Inventory C ON A.cinvcode=C.cInvCode WHERE A.autoid='" + cVoucherNo + "' ";
                    oName = DbHelperSQL.GetSingle(strSql);
                    if (oName == null || oName == DBNull.Value) strName = cVoucherNo;
                    else strName = oName.ToString();
                    break;
                case "供应商存货价格表":
                    //strSql = "SELECT TOP 1 ISNULL(B.ccode,'') AS DataName FROM PU_PriceJustDetail A LEFT JOIN PU_PriceJustMain B ON A.id=B.id WHERE A.autoid='" + cVoucherNo + "' ";
                    strSql = "SELECT TOP 1 ISNULL(B.cVenName,'')+' | '+ISNULL(C.cInvName,'') AS DataName FROM PU_PriceJustDetail A JOIN Vendor B ON A.cvencode=B.cVenCode JOIN Inventory C ON A.cinvcode=C.cInvCode WHERE A.autoid='" + cVoucherNo + "' ";
                    oName = DbHelperSQL.GetSingle(strSql);
                    if (oName == null || oName == DBNull.Value) strName = cVoucherNo;
                    else strName = oName.ToString();
                    break;
                case "部门档案":
                    strSql = "SELECT TOP 1 ISNULL(cDepName,'') AS DataName FROM Department WHERE cDepCode='" + cVoucherNo + "' ";
                    oName = DbHelperSQL.GetSingle(strSql);
                    if (oName == null || oName == DBNull.Value) strName = cVoucherNo;
                    else strName = oName.ToString();
                    break;
                //固定资产部门档案
                //add by wangdd 
                case "固定资产部门档案":
                    strSql = "SELECT TOP 1 ISNULL(sName,'') AS DataName FROM fa_Departments WHERE sNum='" + cVoucherNo + "' ";
                    oName = DbHelperSQL.GetSingle(strSql);
                    if (oName == null || oName == DBNull.Value) strName = cVoucherNo;
                    else strName = oName.ToString();
                    break;
                case "人员档案":
                    strSql = "SELECT TOP 1 ISNULL(cPsn_Name,'') AS DataName FROM hr_hi_person WHERE cPsn_Num='" + cVoucherNo + "' ";
                    oName = DbHelperSQL.GetSingle(strSql);
                    if (oName == null || oName == DBNull.Value) strName = cVoucherNo;
                    else strName = oName.ToString();
                    break;
                case "供应商档案":
                    strSql = "SELECT TOP 1 ISNULL(cVenName,'') AS DataName FROM Vendor WHERE cVenCode='" + cVoucherNo + "' ";
                    oName = DbHelperSQL.GetSingle(strSql);
                    if (oName == null || oName == DBNull.Value) strName = cVoucherNo;
                    else strName = oName.ToString();
                    break;
                case "客户档案":
                    strSql = "SELECT TOP 1 ISNULL(cCusName,'') AS DataName FROM Customer WHERE cCusCode='" + cVoucherNo + "' ";
                    oName = DbHelperSQL.GetSingle(strSql);
                    if (oName == null || oName == DBNull.Value) strName = cVoucherNo;
                    else strName = oName.ToString();
                    break;
                case "存货档案":
                    strSql = "SELECT TOP 1 ISNULL(cInvName,'') AS DataName FROM Inventory WHERE cInvCode='" + cVoucherNo + "' ";
                    oName = DbHelperSQL.GetSingle(strSql);
                    if (oName == null || oName == DBNull.Value) strName = cVoucherNo;
                    else strName = oName.ToString();
                    break;
                case "采购类型":
                    strSql = "SELECT TOP 1 ISNULL(cPTName,'') AS DataName FROM PurchaseType WHERE cPTCode='" + cVoucherNo + "' ";
                    oName = DbHelperSQL.GetSingle(strSql);
                    if (oName == null || oName == DBNull.Value) strName = cVoucherNo;
                    else strName = oName.ToString();
                    break;
                case "销售类型":
                    strSql = "SELECT TOP 1 ISNULL(cSTName,'') AS DataName FROM SaleType WHERE cSTCode='" + cVoucherNo + "' ";
                    oName = DbHelperSQL.GetSingle(strSql);
                    if (oName == null || oName == DBNull.Value) strName = cVoucherNo;
                    else strName = oName.ToString();
                    break;
                case "供应商存货对照表":
                    if (cVoucherNo.Split('|').Length <= 2) return cVoucherNo;
                    strSql = "SELECT TOP 1 ISNULL(B.cVenName,'')+' | '+ISNULL(C.cInvName,'') AS DataName,* FROM VenAndInv A LEFT JOIN Vendor B ON A.CVenCode=B.cVenCode LEFT JOIN Inventory C ON A.cInvCode=C.cInvCode WHERE A.CVenCode='" + cVoucherNo.Split('|')[0] + "' AND A.cInvCode='" + cVoucherNo.Split('|')[1] + "' AND A.iSuppProperty='" + cVoucherNo.Split('|')[2] + "' ";
                    oName = DbHelperSQL.GetSingle(strSql);
                    if (oName == null || oName == DBNull.Value) strName = cVoucherNo;
                    else strName = oName.ToString();
                    break;
                case "项目档案":
                    DataSet dsItem;
                    if (cVoucherNo.Split('|').Length <= 1) return cVoucherNo;
                    strSql = "SELECT TOP 1 ISNULL(ctable,'') AS TableName,ISNULL(citem_name,'') AS ItemName FROM FITEM WHERE citem_class='" + cVoucherNo.Split('|')[0] + "' ";
                    dsItem = DbHelperSQL.Query(strSql);
                    if (dsItem == null || dsItem.Tables[0].Rows.Count <= 0) return cVoucherNo;
                    if (string.IsNullOrEmpty(dsItem.Tables[0].Rows[0]["TableName"].ToString())) return cVoucherNo;
                    if (dsItem.Tables[0].Rows[0]["TableName"].ToString().ToLower() == "inventory")
                        strSql = "SELECT TOP 1 '" + dsItem.Tables[0].Rows[0]["ItemName"] + " | '+ISNULL(cInvName,'') AS DataName FROM Inventory WHERE cInvCode='" + cVoucherNo.Split('|')[1] + "' ";
                    else
                        strSql = "SELECT TOP 1 '" + dsItem.Tables[0].Rows[0]["ItemName"] + " | '+ISNULL(citemname,'') AS DataName FROM " + dsItem.Tables[0].Rows[0]["TableName"] + " WHERE citemcode='" + cVoucherNo.Split('|')[1] + "' ";
                    oName = DbHelperSQL.GetSingle(strSql);
                    if (oName == null || oName == DBNull.Value) strName = cVoucherNo;
                    else strName = oName.ToString();
                    break;
                default:
                    strName = cVoucherNo;
                    break;
            }
            return strName;
        }
    }
}
