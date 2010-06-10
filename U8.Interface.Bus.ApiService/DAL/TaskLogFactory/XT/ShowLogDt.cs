using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using U8.Interface.Bus.DBUtility;

namespace U8.Interface.Bus.ApiService.DAL
{
    public class ShowLogDt
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
            strSql.Append(" SY.*,ISNULL(BI.cbillname,SY.cvouchertype) AS Cvouchertypename,ISNULL(RE.caddress,'') AS Caddress,ISNULL(RE.cacc_id,'') AS Acc_id,ISNULL(RE.cdatabase,'') AS Accname,ISNULL(MA.cname,'') AS CpkName ");
            strSql.Append(" FROM HY_DZ_K7_SYNERGISMLOGDT SY ");
            strSql.Append(" LEFT JOIN HY_DZ_K7_REGIST RE ON SY.accid=RE.acccode ");
            strSql.Append(" LEFT JOIN HY_DZ_K7_MASTERUPD MA ON SY.cpk=MA.ccode ");
            strSql.Append(" LEFT JOIN HY_DZ_K7_BILLSCOPE BI ON SY.cvouchertype=BI.cardnum ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            if (!string.IsNullOrEmpty(order))
            {
                if (order.ToLower() == "accid")
                    order = "SY." + order;
                strSql.Append(string.Format(" ORDER BY {0} {1}", order, ascOrDesc));
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取档案名称
        /// </summary>
        /// <param name="cVoucerType"></param>
        /// <param name="cVoucherNo"></param>
        /// <returns></returns>
        public string GetDataName(string cVoucerName, string cVoucherNo)
        {
            if (string.IsNullOrEmpty(cVoucerName)) return cVoucherNo;

            string strName;
            string strSql;
            object oName;
            switch (cVoucerName)
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
