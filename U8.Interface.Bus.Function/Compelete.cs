using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Data;

using U8.Interface.Bus.ApiService;
using U8.Interface.Bus.ApiService.BLL;
using U8.Interface.Bus.ApiService.DAL;
using U8.Interface.Bus.ApiService.Model; 
using U8.Interface.Bus.Comm;
using U8.Interface.Bus.DBUtility;

namespace U8.Interface.Bus.Function
{
    public static class Compelete
    { 
        /// <summary>
        /// 获取上游单据信息
        /// </summary>
        /// <param name="routeid"></param>
        /// <param name="accid"></param>
        /// <param name="vouchertype"></param>
        /// <param name="invcode">存货编码+10个自由项+自定义项</param>
        /// <returns></returns>
        public static string GetReturnValueByinvCode(string routeid, string accid, string vouchertype, string invcode)
        {
            if (string.IsNullOrEmpty(routeid)) return "error:" + "路线id不能为空";
            if (string.IsNullOrEmpty(accid)) return "error:" + "账套号不能为空";
            if (string.IsNullOrEmpty(vouchertype)) return "error:" + "单据类型不能为空";
            if (string.IsNullOrEmpty(invcode)) return "error:" + "存货不能为空";

            //Common.WriteWinDebugLog(routeid + "|" + accid + "|" + vouchertype + "|" + invcode);

            string sql = string.Empty;
            string cfreeWhere = string.Empty;    //获取参数invcode中 自由项值
            string cdefineWhere = string.Empty;    //获取参数invcode中 自定义项值
            string cbatchWhere = string.Empty;    //获取参数invcode中 批次值
            //int i =0;
            //int iTempID=0;
            object objLine = null;
            bool haveMult = false;
            string[] arr = invcode.Split(';');
            if (arr.Length >= 4)
            {
                cbatchWhere = arr[3];
                cdefineWhere = arr[2];
                cfreeWhere = arr[1];
            }
            invcode = arr[0];

            sql = string.Format("select acccode from HY_dz_k7_regist where accid='{0}'", accid);
            accid = DbHelperSQL.GetSingle(sql).NullToString();
            if (string.IsNullOrEmpty(accid)) return "error:" + "未能取到账套ID";
            string voucherno = string.Empty;
 
            
            U8.Interface.Bus.ApiService.BLL.SynergisnLogDT dtbll = new U8.Interface.Bus.ApiService.BLL.SynergisnLogDT();
            U8.Interface.Bus.ApiService.DAL.SynergismLogDt dtdal = new U8.Interface.Bus.ApiService.DAL.SynergismLogDt();
            sql = string.Format("  d.id={0} and d.accid='{1}' and cvouchertype='{2}'  and d.cstatus='完成' and cvoucherno<>'' order by  ilineno desc", routeid, accid, vouchertype);
            List<U8.Interface.Bus.ApiService.Model.Synergismlogdt> list = dtbll.GetModelList(sql);
            if (list.Count == 0) return "error:" + "未能取到该路线单号";
            U8.Interface.Bus.ApiService.Model.ConnectInfo connectinfo = dtdal.GetConnectInfo(list[0]);
            voucherno = list[0].Cvoucherno;

            DbHelperSQLP dbhelper = new DbHelperSQLP(connectinfo.Constring);
            switch (vouchertype)
            {
                case "27"://请购单
                    cbatchWhere = string.Empty;
                    sql = string.Format(" select count(1) from PU_AppVouch a left join PU_AppVouchs b on a.id=b.id where a.ccode='{0}' and b.cinvcode='{1}'", voucherno, invcode);
                    objLine = dbhelper.GetSingle(sql);
                    sql = " select  b.irowno, a.ccode,a.id,b.autoid,b.ioritaxcost as itaxprice  from PU_AppVouch a left join PU_AppVouchs b on a.id=b.id   where a.ccode='{0}' and b.cinvcode='{1}'";
                    break;
                case "88"://采购订单
                    cbatchWhere = string.Empty;
                    sql = string.Format(" select count(1) from po_pomain a left join PO_Podetails b on a.poid=b.poid left join SO_SODetails c on b.iSOsID=c.iSOsID left join SO_SOMain d on d.ID=c.id left outer join Customer e on d.cCusCode = e.cCusCode where a.cpoid='{0}' and b.cinvcode='{1}'", voucherno, invcode);
                    objLine = dbhelper.GetSingle(sql);
                    sql = "select c.iquotedprice,a.nflat, a.cexch_name, a.cdepcode as cdepcodepo ,d.cdepcode as cdepcodeso,a.cpersoncode as cpersoncodepo,d.cpersoncode as cpersoncodeso,d.ccusoaddress,d.csccode,d.cdefine3,e.ccusdefine5,d.caddcode," +
                          "d.iExchRate as sonflat,d.cexch_name as socexch_name, b.irowno,c.iRowNo as soirowno,  c.cSOCode, c.iTaxUnitPrice as soiTaxUnitPrice,b.iTaxPrice,c.iUnitPrice as soiUnitPrice, b.iUnitPrice,a.cpoid as ccode,a.poid as id," +
                          "b.id as autoid ,b.isosid,cVenPUOMProtocol,a.cMemo,b.cbMemo,d.cSTCode,st.cRdCode,a.cPTCode,pt.cRdCode as cPuRdCode  from po_pomain a with(nolock) left join PO_Podetails b with(nolock) on a.poid=b.poid left join SO_SODetails c with(nolock) on b.iSOsID=c.iSOsID left join " +
                          "SO_SOMain d with(nolock) on d.ID=c.id left outer join Customer e with(nolock) on d.cCusCode = e.cCusCode left join SaleType st with(nolock) on st.cSTCode=d.cSTCode left join PurchaseType pt with(nolock) on pt.cPTCode=a.cPTCode " +
                          "where a.cpoid='{0}' and b.cinvcode='{1}'";
                    break;
                case "17"://销售订单
                    cbatchWhere = string.Empty;
                    sql = string.Format(" select count(1) from SO_SOmain a left join so_sodetails b on a.id=b.id where a.csocode='{0}' and b.cinvcode='{1}'", voucherno, invcode);
                    objLine = dbhelper.GetSingle(sql);
                    sql = "select b.iRowNo,b.iUnitPrice,b.iTaxUnitPrice as iTaxPrice, a.csocode as ccode,a.id,b.autoid,a.cgatheringplan,st.cRdCode from SO_SOmain a with(nolock) left join so_sodetails b with(nolock) on a.id=b.id left join SaleType st with(nolock) on st.cSTCode=a.cSTCode where a.csocode='{0}' and b.cinvcode='{1}'";
                    break;
                case "01"://销售发货单 
                    sql = string.Format("select count(1) from DispatchList a left join DispatchLists b  on a.dlid=b.dlid where a.cvouchtype = '05' and a.bReturnFlag = 0 and a.cdlcode='{0}' and b.cinvcode='{1}'", voucherno, invcode);
                    objLine = dbhelper.GetSingle(sql);
                    sql = "select  b.irowno, a.cdlcode as ccode , a.dlid as id, b.autoid,b.iTaxUnitPrice as itaxprice,a.cSTCode,st.cRdCode from DispatchList a with(nolock) left join DispatchLists b with(nolock)  on a.dlid=b.dlid left join SaleType st with(nolock) on st.cSTCode=a.cSTCode where a.cvouchtype = '05' and a.bReturnFlag = 0 and a.cdlcode='{0}' and b.cinvcode='{1}'";
                     
                    break;
                case "03"://销售退货单
                     
                    sql = string.Format(" select count(1) from DispatchList a left join DispatchLists b  on a.dlid=b.dlid where a.bReturnFlag = 1 and b.iDLsID='{1}'  and a.cvouchtype = '05' ", voucherno, invcode);
                    objLine = dbhelper.GetSingle(sql);
                    sql = "select  b.irowno, a.cdlcode as ccode , a.dlid as id, b.autoid,b.iTaxUnitPrice as itaxprice,a.cSTCode,st.cRdCode from DispatchList a with(nolock) left join DispatchLists b with(nolock)  on a.dlid=b.dlid left join SaleType st with(nolock) on st.cSTCode=a.cSTCode where a.cvouchtype = '05' and a.bReturnFlag = 1 and a.cdlcode='{0}' and b.cinvcode='{1}'";
                     
                    break;
                case "24"://采购入库单
                    sql = string.Format(" select count(1) from rdrecords01 b where ID =(select ID from rdrecord01 where cCode='{0}' ) and b.cinvcode='{1}'", voucherno, invcode);
                    objLine = dbhelper.GetSingle(sql);
                    sql = "select cbatch  from rdrecords01 b where ID =(select ID from rdrecord01 where cCode='{0}' ) and b.cinvcode='{1}'";
                    break;
                case "26"://采购到货单
                    sql = string.Format(" select count(1) from PU_ArrivalVouch a  left join PU_ArrivalVouchs b on a.id=b.id where a.cCode='{0}' and b.cinvcode='{1}'", voucherno, invcode);
                    objLine = dbhelper.GetSingle(sql);
                    sql = "select  b.irowno, a.id,a.cCode,b.autoid,b.ioritaxcost as itaxprice  from PU_ArrivalVouch a  left join PU_ArrivalVouchs b on a.id=b.id where a.cCode='{0}' and b.cinvcode='{1}'";
                    break;
                default:
                    return "error:" + "未能取到单据类型";
                //  break;
            }
            if (objLine == null || objLine == DBNull.Value) return "error:" + "未能取到对应行数据";
            if (System.Convert.ToInt32(objLine) <= 0) return "error:" + "未能取到对应行数据";
            haveMult = System.Convert.ToInt32(objLine) >= 2;
            sql = string.Format(sql, voucherno, invcode);
            DataSet ds = null;

            if (!haveMult)
            {
                ds = dbhelper.Query(sql);
                if (ds == null || ds.Tables[0].Rows.Count == 0) return "error:" + "未能取到对应行数据";
            }
            else
            {
                ds = GetMultLineQuery(dbhelper, sql, cfreeWhere, cdefineWhere, cbatchWhere);
                //DAL.Common.WriteWinLog(string.Format("多行相同存货自定义项对应错误。（routeid：{0}, accid：{1}, vouchertype：{2}, voucherno：{3}, invcode：{4}, sql：{5}。）", routeid, accid, vouchertype, voucherno, invcode, sql + cfreeWhere + cdefineWhere + cbatchWhere));
                if (ds == null || ds.Tables[0].Rows.Count == 0) return "error:" + "未能取到对应行数据";
            }

            if (vouchertype == "24")
            {
                string cbatch = ds.Tables[0].Rows[0]["cbatch"].ToString();

                return string.Format("ccode,{0};id,{1};autoid,{2};cbatch,{3};isosid,{4}", "", "", "", cbatch, "");

            }

            else if (vouchertype == "88")
            {
                string ccode = ds.Tables[0].Rows[0]["ccode"].ToString();
                string id = ds.Tables[0].Rows[0]["id"].ToString();
                string autoid = ds.Tables[0].Rows[0]["autoid"].ToString();
                string isosid = ds.Tables[0].Rows[0]["isosid"].ToString();
                string iUnitPrice = ds.Tables[0].Rows[0]["iunitprice"].ToString();
                string soiUnitPrice = ds.Tables[0].Rows[0]["soiunitprice"].ToString();
                string soiTaxUnitPrice = ds.Tables[0].Rows[0]["soiTaxUnitPrice"].ToString();
                string iTaxPrice = ds.Tables[0].Rows[0]["iTaxPrice"].ToString();
                string cSOCode = ds.Tables[0].Rows[0]["cSOCode"].ToString();
                string irowno = ds.Tables[0].Rows[0]["irowno"].ToString();
                string soirowno = ds.Tables[0].Rows[0]["soirowno"].ToString();
                string nflat = ds.Tables[0].Rows[0]["nflat"].ToString();
                string cexch_name = ds.Tables[0].Rows[0]["cexch_name"].ToString();
                string sonflat = ds.Tables[0].Rows[0]["sonflat"].ToString();
                string socexch_name = ds.Tables[0].Rows[0]["socexch_name"].ToString();
                if (string.IsNullOrEmpty(sonflat)) sonflat = "1";
                if (string.IsNullOrEmpty(socexch_name)) socexch_name = "人民币";
                string cdepcodepo = ds.Tables[0].Rows[0]["cdepcodepo"].ToString();
                string cdepcodeso = ds.Tables[0].Rows[0]["cdepcodeso"].ToString();
                string cpersoncodepo = ds.Tables[0].Rows[0]["cpersoncodepo"].ToString();//采购订单业务员编码
                string cpersoncodeso = ds.Tables[0].Rows[0]["cpersoncodeso"].ToString();//销售订单业务员编码
                string ccusoaddress = ds.Tables[0].Rows[0]["ccusoaddress"].ToString();//发货地址
                string csccode = ds.Tables[0].Rows[0]["csccode"].ToString();//发运方式编码
                string cdefine3 = ds.Tables[0].Rows[0]["cdefine3"].ToString();//运费承担
                string ccusdefine5 = ds.Tables[0].Rows[0]["ccusdefine5"].ToString();//运费承担
                string caddcode = ds.Tables[0].Rows[0]["caddcode"].ToString();//收货地址编码
                string iquotedprice = ds.Tables[0].Rows[0]["iquotedprice"].ToString();//销售订单报价
                string ccuscode = "";
                string cMemo = ds.Tables[0].Rows[0]["cMemo"].ToString();//表头备注
                string cbMemo = ds.Tables[0].Rows[0]["cbMemo"].ToString();//表体备注
                if (!string.IsNullOrEmpty(cSOCode))
                {
                    string sqlstr = " select cCusCode from SO_SOMain where cSOCode='" + cSOCode + "'";
                    ccuscode = dbhelper.GetSingle(sqlstr).NullToString();
                 
                }
                string cVenPUOMProtocol = ds.Tables[0].Rows[0]["cVenPUOMProtocol"].ToString();//收付款协议
                string cSTCode = ds.Tables[0].Rows[0]["cSTCode"].ToString();//销售类型
                string cRdCode = ds.Tables[0].Rows[0]["cRdCode"].ToString();//销售类型对应入库类别
                string cPTCode = ds.Tables[0].Rows[0]["cPTCode"].ToString();//采购类型
                string cPuRdCode = ds.Tables[0].Rows[0]["cPuRdCode"].ToString();//采购类型对应入库类别
                return string.Format("ccode,{0};id,{1};autoid,{2};cbatch,{3};isosid,{4};iunitprice,{5};soiunitprice,{6};" +
                    "soitaxunitprice,{7};itaxprice,{8};csocode,{9};irowno,{10};soirowno,{11}" +
                    ";nflat,{12};cexch_name,{13};sonflat,{14};socexch_name,{15};ccuscode,{16};cdepcodepo,{17};cdepcodeso,{18};" +
                    "cpersoncodepo,{19};ccusoaddress,{20};csccode,{21};ccusdefine5,{22};caddcode,{23};cpersoncodeso,{24};iquotedprice,{25};" +
                    "cVenPUOMProtocol,{26};cMemo,{27};cbMemo,{28};cSTCode,{29};cRdCode,{30};cPTCode,{31};cPuRdCode,{32}"
                    , ccode
                    , id
                    , autoid
                    , ""
                    , isosid
                    , iUnitPrice
                    , soiUnitPrice
                    , soiTaxUnitPrice
                    , iTaxPrice
                    , cSOCode
                    , irowno
                    , soirowno
                    , nflat
                    , cexch_name
                    , sonflat
                    , socexch_name
                    , ccuscode
                    , cdepcodepo
                    , cdepcodeso
                    , cpersoncodepo
                    , ccusoaddress
                    , csccode
                    , ccusdefine5
                    , caddcode
                    , cpersoncodeso
                    , iquotedprice
                    , cVenPUOMProtocol
                    , cMemo
                    , cbMemo
                    , cSTCode
                    , cRdCode
                    , cPTCode
                    , cPuRdCode);

            }

            else if (vouchertype == "17")
            {
                string ccode = ds.Tables[0].Rows[0]["ccode"].ToString();
                string id = ds.Tables[0].Rows[0]["id"].ToString();
                string autoid = ds.Tables[0].Rows[0]["autoid"].ToString();
                string iUnitPrice = ds.Tables[0].Rows[0]["iunitprice"].ToString();
                string iTaxPrice = ds.Tables[0].Rows[0]["iTaxPrice"].ToString();
                string irowno = ds.Tables[0].Rows[0]["irowno"].ToString();
                string cgatheringplan = ds.Tables[0].Rows[0]["cgatheringplan"].ToString();
                string cRdCode = ds.Tables[0].Rows[0]["cRdCode"].ToString();//销售类型对应入库类别
                return string.Format("ccode,{0};id,{1};autoid,{2};cbatch,{3};iunitprice,{4};itaxprice,{5};irowno,{6};cgatheringplan,{7};cRdCode,{8}"
                    , ccode
                    , id
                    , autoid
                    , ""
                    , iUnitPrice
                    , iTaxPrice
                    , irowno
                    , cgatheringplan
                    , cRdCode);


            }
            else if (vouchertype == "01" || vouchertype == "03")
            {

                string ccode = ds.Tables[0].Rows[0]["ccode"].ToString();
                string id = ds.Tables[0].Rows[0]["id"].ToString();
                string autoid = ds.Tables[0].Rows[0]["autoid"].ToString();
                string irowno = ds.Tables[0].Rows[0]["irowno"].ToString();
                string itaxprice = ds.Tables[0].Rows[0]["itaxprice"].ToString();
                string cSTCode = ds.Tables[0].Rows[0]["cSTCode"].ToString();//销售类型
                string cRdCode = ds.Tables[0].Rows[0]["cRdCode"].ToString();//销售类型对应入库类别
                return string.Format("ccode,{0};id,{1};autoid,{2};cbatch,{3};isosid,{4};irowno,{5};itaxprice,{6};cSTCode,{7};cRdCode,{8}"
                    , ccode
                    , id
                    , autoid
                    , ""
                    , ""
                    , irowno
                    , itaxprice
                    , cSTCode
                    , cRdCode);
            }
            else
            {

                string ccode = ds.Tables[0].Rows[0]["ccode"].ToString();
                string id = ds.Tables[0].Rows[0]["id"].ToString();
                string autoid = ds.Tables[0].Rows[0]["autoid"].ToString();
                string irowno = ds.Tables[0].Rows[0]["irowno"].ToString();
                string itaxprice = ds.Tables[0].Rows[0]["itaxprice"].ToString();
                return string.Format("ccode,{0};id,{1};autoid,{2};cbatch,{3};isosid,{4};irowno,{5};itaxprice,{6}"
                    , ccode
                    , id
                    , autoid
                    , ""
                    , ""
                    , irowno
                    , itaxprice);
            }
        }

        private static DataSet GetMultLineQuery(DbHelperSQLP dbhelper, string sql, string cfreeWhere, string cdefineWhere, string cbatchWhere)
        {
            DataSet ds = null;
            string sqlMult = sql;
            if (!string.IsNullOrEmpty(cfreeWhere)) sqlMult = sqlMult + " " + cfreeWhere;   //添加 where 自由项过滤 条件
            if (!string.IsNullOrEmpty(cdefineWhere)) sqlMult = sqlMult + " " + cdefineWhere;   //添加 where 自定义项过滤 条件
            if (!string.IsNullOrEmpty(cbatchWhere)) sqlMult = sqlMult + " " + cbatchWhere;   //添加 where 批次过滤 条件

            ds = dbhelper.Query(sqlMult);

            if (ds.Tables[0].Rows.Count == 0)
            {
                if (sqlMult == sql) return null;

                if (!string.IsNullOrEmpty(cbatchWhere))
                {
                    sqlMult = sql + " " + cbatchWhere;   //添加 where 批次过滤 条件
                    ds = dbhelper.Query(sqlMult);
                    if (ds.Tables[0].Rows.Count >= 1) return ds;
                }

                if (!string.IsNullOrEmpty(cfreeWhere))
                {
                    sqlMult = sql + " " + cfreeWhere;   //添加 where 自由项过滤 条件
                    ds = dbhelper.Query(sqlMult);
                    if (ds.Tables[0].Rows.Count >= 1) return ds;
                }

                if (!string.IsNullOrEmpty(cdefineWhere))
                {
                    sqlMult = sql + " " + cdefineWhere;   //添加 where 自定义项过滤 条件
                    ds = dbhelper.Query(sqlMult);
                    if (ds.Tables[0].Rows.Count >= 1) return ds;
                }

                ds = dbhelper.Query(sql);
                if (ds.Tables[0].Rows.Count == 0) return null;
                return ds;
            }
            else
            {
                return ds;
            }
        }

        /// <summary>
        /// 根据客户存货对照表获取客户存货编码和客户存货名称
        /// </summary>
        /// <param name="strCusCode">客户编码</param>
        /// <param name="strInvCode">存货编码</param>
        /// <param name ="strAccid">账套号</param>
        /// <returns></returns>
        public static string GetCusInvInfo(string strCusCode, string strInvCode, string strAccid)
        {
            try
            {
                if (string.IsNullOrEmpty(strCusCode)) return "error:函数GetCusInvInfo参数错误:" + "客户编码不能为空";
                if (string.IsNullOrEmpty(strInvCode)) return "error:函数GetCusInvInfo参数错误:" + "存货编码不能为空";
                if (string.IsNullOrEmpty(strAccid)) return "error:函数GetCusInvInfo参数错误:" + "账套号不能为空";

                string sql = string.Empty;

                sql = string.Format("select acccode from HY_dz_k7_regist where accid='{0}'", strAccid);
                strAccid = DbHelperSQL.GetSingle(sql).NullToString();
                if (string.IsNullOrEmpty(strAccid)) return "error:函数GetCusInvInfo取值错误:" + "未能取到账套ID";

                U8.Interface.Bus.ApiService.DAL.SynergismLogDt dtdal = new U8.Interface.Bus.ApiService.DAL.SynergismLogDt();
                U8.Interface.Bus.ApiService.Model.Synergismlogdt dt = new U8.Interface.Bus.ApiService.Model.Synergismlogdt();
                dt.Accid = strAccid;
                U8.Interface.Bus.ApiService.Model.ConnectInfo connectinfo = dtdal.GetConnectInfo(dt);

                DbHelperSQLP dbhelper = new DbHelperSQLP(connectinfo.Constring);
                sql = string.Format("select cCusInvCode,cCusInvName  from CusInvContrapose where cCusCode = '{0}' and cInvCode = '{1}'", strCusCode, strInvCode);
                DataSet ds = dbhelper.Query(sql);
                if (ds.Tables[0].Rows.Count == 0) return "error:函数GetCusInvInfo取值错误:" + "未能取到客户存货信息，请查看是否设置了对照关系";

                string cCusInvCode = ds.Tables[0].Rows[0]["cCusInvCode"] == System.DBNull.Value ? "" : ds.Tables[0].Rows[0]["cCusInvCode"].ToString();
                string cCusInvName = ds.Tables[0].Rows[0]["cCusInvName"] == System.DBNull.Value ? "" : ds.Tables[0].Rows[0]["cCusInvName"].ToString();

                return string.Format("ccusinvcode,{0};ccusinvname,{1}"
                    , cCusInvCode
                    , cCusInvName);

            }
            catch (Exception ex)
            {
                return "error:函数GetCusInvInfo发生异常:" + ex.Message;
            }
        }

        public static string GetDepCode(string routeid) //, string accid, string vouchertype
        {
            try
            {
                if (string.IsNullOrEmpty(routeid)) return "error:函数GetDepCode参数错误:" + "路线ID不能为空";


                string sql = string.Empty;
                string strRouteName = string.Empty;
                string strDepCode = string.Empty;

                sql = string.Format("select croutetype  from HY_DZ_K7_SYNERGISMLOG where id = '{0}'", routeid);
                strRouteName = DbHelperSQL.GetSingle(sql).NullToString();
                if (string.IsNullOrEmpty(strRouteName)) return "error:函数GetCusInvInfo取值错误:" + "未能取到路线名称";


                if (strRouteName.Contains("集售分产"))
                {
                    return string.Format("cdepcode,{0}"
                    , "C10206");
                }

                if (strRouteName.Contains("内部购销"))
                {
                    return string.Format("cdepcode,{0}"
                    , "C106");
                }

                return string.Format("cdepcode,{0}"
                    , "");
            }
            catch (System.Exception ex)
            {
                return "error:函数GetDepCode发生异常:" + ex.Message;
            }
        }


        /// <summary>
        /// 根据客户编码和地址编码获取收货地址，联系人，
        /// </summary>
        /// <param name="strCusCode"></param>
        /// <param name="strAddCode"></param>
        /// <returns></returns>
        public static string GetAddressByCus(string strCusCode, string strAddCode, string strAccid)
        {
            try
            {
                if (string.IsNullOrEmpty(strCusCode)) return "error:函数GetAddressByCus参数错误:" + "客户编码不能为空";//return "ccontactname,"+""+";cmobilephone,"+""+";cofficephone,"+""+"";
                if (string.IsNullOrEmpty(strAddCode)) return "error:函数GetAddressByCus参数错误:" + "客户地址编码不能为空";


                string sql = string.Empty;

                sql = string.Format("select acccode from HY_dz_k7_regist where accid='{0}'", strAccid);
                strAccid = DbHelperSQL.GetSingle(sql).NullToString();
                if (string.IsNullOrEmpty(strAccid)) return "error:函数GetAddressByCus取值错误:" + "未能取到账套ID";

                U8.Interface.Bus.ApiService.DAL.SynergismLogDt dtdal = new U8.Interface.Bus.ApiService.DAL.SynergismLogDt();
                U8.Interface.Bus.ApiService.Model.Synergismlogdt dt = new U8.Interface.Bus.ApiService.Model.Synergismlogdt();
                dt.Accid = strAccid;
                U8.Interface.Bus.ApiService.Model.ConnectInfo connectinfo = dtdal.GetConnectInfo(dt);

                DbHelperSQLP dbhelper = new DbHelperSQLP(connectinfo.Constring);
                sql = string.Format("select cusadd.cdeliveradd as cshipaddress,cusadd.cdeliveradd as ccusoaddress,cusadd.caddcode,cusadd.cdeliverunit," +
                                     "crm.ccontactname as ccontactname , crm.cmobilephone, crm.cofficephone,crm.cContactCode  from cusdeliveradd cusadd " +
                                      "left join crm_contact crm on (crm.ccontactcode=cusadd.clinkperson)  where cusadd.ccuscode = '{0}' and (cusadd.cdeliveradd='{1}' or caddcode='{2}')", strCusCode, strAddCode, strAddCode);
                DataSet ds = dbhelper.Query(sql);
                if (ds.Tables[0].Rows.Count == 0) return "error:函数GetAddressByCus取值错误:" + "未能取到客户对应的地址信息";

                string ccontactname = ds.Tables[0].Rows[0]["ccontactname"].ToString();//收货联系人              
                string cmobilephone = ds.Tables[0].Rows[0]["cmobilephone"].ToString();//收货联系人手机
                string cofficephone = ds.Tables[0].Rows[0]["cofficephone"].ToString();//收货联系电话
                string ccontactcode = ds.Tables[0].Rows[0]["ccontactcode"].ToString();//联系人编码
                return string.Format("ccontactname,{0};cmobilephone,{1};cofficephone,{2};ccontactcode,{3}"
                    , ccontactname
                    , cmobilephone
                    , cofficephone
                    , ccontactcode);

            }
            catch (Exception ex)
            {
                return "error:函数GetAddressByCus发生异常:" + ex.Message;
            }


        }


        /// <summary>
        /// 根据客户编码获取付款条件和业务员
        /// </summary>
        /// <param name="strCusCode"></param>
        /// <param name="strAccid"></param>
        /// <returns></returns>
        public static string GetPayPerson(string strCusCode, string strAccid)
        {
            try
            {
                if (string.IsNullOrEmpty(strCusCode)) return "error:函数GetPayPerson参数错误:" + "客户编码不能为空";//return "ccontactname,"+""+";cmobilephone,"+""+";cofficephone,"+""+"";



                string sql = string.Empty;

                sql = string.Format("select acccode from HY_dz_k7_regist where accid='{0}'", strAccid);
                strAccid = DbHelperSQL.GetSingle(sql).NullToString();
                if (string.IsNullOrEmpty(strAccid)) return "error:函数GetPayPerson取值错误:" + "未能取到账套ID";

                U8.Interface.Bus.ApiService.DAL.SynergismLogDt dtdal = new SynergismLogDt();
                U8.Interface.Bus.ApiService.Model.Synergismlogdt dt = new U8.Interface.Bus.ApiService.Model.Synergismlogdt();
                dt.Accid = strAccid;
                U8.Interface.Bus.ApiService.Model.ConnectInfo connectinfo = dtdal.GetConnectInfo(dt);

                DbHelperSQLP dbhelper = new DbHelperSQLP(connectinfo.Constring);
                sql = string.Format("select a.cCusPayCond,a.cCusPPerson,a.cCusContactCode  from customer a left join Person b on a.cCusPPerson=b.cPersonCode left join  PayCondition c on a.cCusPayCond = c.cPayCode where a.cCusCode ='{0}'", strCusCode);
                DataSet ds = dbhelper.Query(sql);
                if (ds.Tables[0].Rows.Count == 0) return "error:函数GetPayPerson取值错误:" + "未能取到客户对应的付款条件或业务员";

                string ccuspaycond = ds.Tables[0].Rows[0]["ccuspaycond"].ToString();//付款条件              
                string ccuspperson = ds.Tables[0].Rows[0]["ccuspperson"].ToString();//业务员编码
                string ccuscontactcode = ds.Tables[0].Rows[0]["ccuscontactcode"].ToString();//联系人编码

                return string.Format("ccuspaycond,{0};ccuspperson,{1};ccuscontactcode,{2}"
                    , ccuspaycond
                    , ccuspperson
                    , ccuscontactcode
                    );

            }
            catch (Exception ex)
            {
                return "error:函数GetPayPerson发生异常:" + ex.Message;
            }


        }


        public static string GetSOValueByinvCode(string routeid, string invcode)
        {
            if (string.IsNullOrEmpty(routeid)) return "error:" + "路线id不能为空";
            if (string.IsNullOrEmpty(invcode)) return "error:" + "存货不能为空";

            //Common.WriteWinDebugLog(routeid + "|" + accid + "|" + vouchertype + "|" + invcode);

            string sql = string.Empty;
            string cPOID = string.Empty;

            U8.Interface.Bus.ApiService.BLL.SynergisnLogDT dtbll = new U8.Interface.Bus.ApiService.BLL.SynergisnLogDT();
            U8.Interface.Bus.ApiService.DAL.SynergismLogDt dtdal = new SynergismLogDt();
            sql = string.Format("  d.id={0} AND d.fatherid IS NULL and d.cstatus='完成' and cvoucherno<>'' order by  ilineno ", routeid);
            List<U8.Interface.Bus.ApiService.Model.Synergismlogdt> list = dtbll.GetModelList(sql);
            if (list.Count == 0) return "error:" + "未能取到该路线单号";
            if (list[0].Cvouchertype != "88") return "error:" + "该函数不适用于当前路线";
            U8.Interface.Bus.ApiService.Model.ConnectInfo connectinfo = dtdal.GetConnectInfo(list[0]);
            cPOID = list[0].Cvoucherno;

            DbHelperSQLP dbhelper = new DbHelperSQLP(connectinfo.Constring);

            string cSOCode = string.Empty;
            sql = string.Format("SELECT B.cupsocode FROM PO_Pomain A JOIN PO_Podetails B ON A.POID=B.POID WHERE A.cPOID='{0}' AND B.cInvCode='{1}' ", cPOID, invcode);
            object obj = dbhelper.GetSingle(sql);
            if (obj == null || obj == DBNull.Value) return "error:" + "未能取到采购订单上游单据数据";
            cSOCode = obj.ToString();

            sql = string.Format("SELECT cgatheringplan,cpaycode,ccusoaddress,csccode,caddcode,ccuscode,ccusname,ccuspersoncode,ccusperson,ccrmpersoncode,ccrmpersonname,cdepcode,cstcode,cpersoncode FROM SO_SOMain WHERE cSOCode='{0}' ", cSOCode);
            DataSet ds = dbhelper.Query(sql);

            if (ds.Tables[0].Rows.Count == 0) return "error:" + "未能取到对应行数据";

            string cgatheringplan = ds.Tables[0].Rows[0]["cgatheringplan"].ToString();
            string cpaycode = ds.Tables[0].Rows[0]["cpaycode"].ToString();
            string ccusoaddress = ds.Tables[0].Rows[0]["ccusoaddress"].ToString();
            string csccode = ds.Tables[0].Rows[0]["csccode"].ToString();
            string caddcode = ds.Tables[0].Rows[0]["caddcode"].ToString();
            string ccuscode = ds.Tables[0].Rows[0]["ccuscode"].ToString();
            string ccusname = ds.Tables[0].Rows[0]["ccusname"].ToString();
            string ccuspersoncode = ds.Tables[0].Rows[0]["ccuspersoncode"].ToString();
            string ccusperson = ds.Tables[0].Rows[0]["ccusperson"].ToString();
            string ccrmpersoncode = ds.Tables[0].Rows[0]["ccrmpersoncode"].ToString();
            string ccrmpersonname = ds.Tables[0].Rows[0]["ccrmpersonname"].ToString();
            string cdepcode = ds.Tables[0].Rows[0]["cdepcode"].ToString();
            string cstcode = ds.Tables[0].Rows[0]["cstcode"].ToString();
            string cpersoncode = ds.Tables[0].Rows[0]["cpersoncode"].ToString();

            return string.Format("cgatheringplan,{0};cpaycode,{1};ccusoaddress,{2};csccode,{3};caddcode,{4};ccuscode,{5};" +
                "ccusname,{6};ccuspersoncode,{7};ccusperson,{8};ccrmpersoncode,{9};ccrmpersonname,{10};cdepcode,{11};cstcode,{12};cpersoncode,{13}"
              , cgatheringplan
              , cpaycode
              , ccusoaddress
              , csccode
              , caddcode
              , ccuscode
              , ccusname
              , ccuspersoncode
              , ccusperson
              , ccrmpersoncode
              , ccrmpersonname
              , cdepcode
              , cstcode
              , cpersoncode);
        }



        /// <summary>
        /// 获取订单跟踪信息   added by liuxzha 2015.03.12
        /// 
        /// </summary>
        /// <param name="routeid"></param>
        /// <param name="invcode"></param>
        /// <returns></returns>
        public static string GetDidTraceInfo(string s_accid, string d_accid, string s_vouchertype, string d_vouchertype, string s_did)
        {
            try
            {
                return string.Format("s_accid,{0};d_accid,{1};s_vouchertype,{2};d_vouchertype,{3};s_did,{4}"
                  , s_accid
                  , d_accid
                  , s_vouchertype
                  , d_vouchertype
                  , s_did);
            }
            catch (Exception ex)
            {
                return "error:函数GetDidTraceInfo发生异常:" + ex.Message;
            }

        }
        /// <summary>
        /// 根据来源账套采购订单子表ID获取目标账套销售订单信息 added by wangdd 
        /// </summary>
        /// <param name="s_accid"></param>
        /// <param name="d_accid"></param>
        /// <param name="iposid">po</param>
        /// <param name="cardsection">title or body</param>
        /// <param name="sfieldname">fieldname</param>
        /// <returns>field value</returns>
        public static string GetSoInfoForReturnOrder(string s_accid, string d_accid, string iposid, string cardsection, string sfieldname)
        {
            string ssql = "";
            string s_acccode = "";
            string d_acccode = "";
            try
            {
                ssql = "select did from HY_DZ_K7_SYNERGISMLOGDID with (nolock) where cvouchertype='17' and precvouchertype='88' and accid='" + d_accid + "' and preaccid='" + s_accid + "' and predid='" + iposid + "'";
                DataSet dsSo = DbHelperSQL.Query(ssql);
                if (dsSo.Tables[0].Rows.Count == 0) return "error:函数GetSoInfoForReturnOrder取值错误:" + "无法找到采购入库单上游采购订单所生成销售订单信息!";
                string isosid = dsSo.Tables[0].Rows[0]["did"].ToString();

                ssql = string.Format("select acccode from HY_dz_k7_regist  with (nolock) where accid='{0}'", s_accid);
                s_acccode = DbHelperSQL.GetSingle(ssql).NullToString();
                if (string.IsNullOrEmpty(s_acccode)) return "error:" + "未能取到来源账套";


                ssql = string.Format("select acccode from HY_dz_k7_regist  with (nolock) where accid='{0}'", d_accid);
                d_acccode = DbHelperSQL.GetSingle(ssql).NullToString();
                if (string.IsNullOrEmpty(d_acccode)) return "error:" + "未能取到目标账套";

                #region 获取数据库连接
                U8.Interface.Bus.ApiService.DAL.SynergismLogDt dtdal = new SynergismLogDt();
                U8.Interface.Bus.ApiService.Model.Synergismlogdt dt = new U8.Interface.Bus.ApiService.Model.Synergismlogdt();

                dt.Accid = d_acccode;
                U8.Interface.Bus.ApiService.Model.ConnectInfo connectinfo = dtdal.GetConnectInfo(dt);

                DbHelperSQLP dbhelper = new DbHelperSQLP(connectinfo.Constring);
                #endregion

                if (cardsection.ToLower().Equals("t"))  //表头
                {
                    ssql = " SELECT top 1 t.csocode as vouchno,t." + sfieldname + " as rowName FROM SaleOrderQ t with(nolock) inner join SO_SODetails b  with(nolock) on t.id=b.id where b.isosid='" + isosid + "' ";
                }
                else                                   //表体
                {
                    ssql = " SELECT t.csocode as vouchno,b." + sfieldname + " as rowName, b.isosid as did FROM SaleOrderSQ b with(nolock) left join SaleOrderQ t with(nolock) on t.id = b.id where  b.isosid ='" + isosid + "' ";
                }

                DataSet ds = dbhelper.Query(ssql);
                if (ds.Tables[0].Rows.Count == 0) return "error:函数GetValueByAccVouchnoItemname取值错误:" + "未能取到对应单据";

                return string.Format("b_res,{0}", ds.Tables[0].Rows[0]["rowName"].ToString());
            }
            catch (Exception ex)
            {
                return "error:函数GetSoInfoForReturnOrder发生异常:" + ex.Message;
            }

        }


        /// <summary>
        /// 获取指定帐套单据的字段值   added by liuxzha  2015.03.17
        /// 参数赋值方式:
        ///     保留字.公共变量.当前路线号
        ///     保留字.固定值.来源单据acccode
        ///     保留字.单据类型.相应单据类型名
        ///     上游单据.表头/表体.字段名称
        /// </summary>
        /// <param name="routeId">路线号   
        /// 取值 保留字.公共变量.当前路线号
        /// </param>
        /// <param name="strAccid">协同平台中注册的账套ID
        /// 取值  保留字.公共变量.目标单据帐套ID
        /// </param>
        /// <param name="cardNo">参数取值方式:保留字.单据类型.单据名称</param>
        /// <param name="cardSection">后台直接赋值</param>
        /// <param name="strFieldName">后台直接赋值</param>
        /// <param name="iRowNo">后台直接赋值</param>
        /// <returns></returns>
        public static string GetValueByAccVouchnoItemname(string routeId, string strAccid, string cardNo, string cardSection, string strFieldName, string iRowNo, string logDid)
        {

            string sql;
            string acccode = "";

            try
            {

                #region 验证来源数据库连接
                //sql = string.Format("select acccode from HY_dz_k7_regist with(nolock) where accid='{0}'", strAccid);   //accid 转 acccode
                if (!string.IsNullOrEmpty(strAccid))
                {
                    sql = string.Format("select acccode from HY_dz_k7_regist with(nolock) where acccode='{0}'", strAccid);  //验证acccode
                    acccode = DbHelperSQL.GetSingle(sql).NullToString();
                    if (string.IsNullOrEmpty(acccode)) return "error:函数GetValueByAccVouchnoItemname取值错误:" + "未能取到上游单据账套ID" + strAccid;
                }
                #endregion

                #region  获取voucherNo   这个不准:1.取不到LOGDT外的单;2分单情况不准.
                //if (string.IsNullOrEmpty(acccode))
                //{
                //    sql = string.Format("SELECT d.cvoucherno FROM HY_DZ_K7_SYNERGISMLOGDT d with(nolock)  LEFT JOIN  HY_DZ_K7_SYNERGISMLOG a  with(nolock) ON A.ID = D.id WHERE b.cvouchertype ='{0}' and a.croutetype ='{1}' ",cardNo,routeId);
                //}
                //else 
                //{
                //    sql = string.Format("SELECT d.cvoucherno FROM HY_DZ_K7_SYNERGISMLOGDT d with(nolock)  LEFT JOIN  HY_DZ_K7_SYNERGISMLOG a  with(nolock) ON A.ID = D.id WHERE d.cvouchertype ='{0}' AND d.accid = '{1}' and d.id ='{2}' ",cardNo,acccode,routeId);
                //}
                //string vouchNo = DbHelperSQL.GetSingle(sql).NullToString();
                //if (string.IsNullOrEmpty(vouchNo)) return "error:函数GetValueByAccVouchnoItemname取值错误:" + "未能取到账套号:" + acccode + " ,CardNum:" + cardNo + "对应的单据号!";
                string vouchNo = "";
                #endregion

                #region  获取bodydid
                //获取上一任务节点   
                sql = string.Format(" SELECT id,autoid,accid,cvouchertype,cvoucherno FROM HY_DZ_K7_SYNERGISMLOGDT WITH(NOLOCK) WHERE autoid = ( SELECT fatherid FROM HY_DZ_K7_SYNERGISMLOGDT with(nolock) WHERE autoid ='{0}' ) ", logDid);
                DataSet dsPre = DbHelperSQL.Query(sql);
                if (dsPre.Tables[0].Rows.Count == 0) return "error:函数GetValueByAccVouchnoItemname取值错误:" + "不存在上游单据!";
                string preAcccode = dsPre.Tables[0].Rows[0]["accid"].ToString();
                string preCardNo = dsPre.Tables[0].Rows[0]["cvouchertype"].ToString();
                string preVoucherNo = dsPre.Tables[0].Rows[0]["cvoucherno"].ToString();

                //根据上一任务节点以及行号信息计算出上一任务节点的bodydid
                sql = "select max(id) from HY_DZ_K7_SYNERGISMLOGDID ddd with(nolock) where ddd.id in (  ";
                sql += " SELECT top " + (System.Convert.ToInt32(iRowNo) + 1) + " dd.id FROM HY_DZ_K7_SYNERGISMLOGDID dd with(nolock) LEFT JOIN  HY_dz_k7_regist r with(nolock) on dd.accid = r.accid  ";
                sql += " where r.acccode = '" + preAcccode + "' and dd.cvouchertype = '" + preCardNo + "' and voucherNo = '" + preVoucherNo + "' ";
                sql += " order by id asc) ";
                string bodyid = DbHelperSQL.GetSingle(sql).NullToString();
                sql = "SELECT did FROM HY_DZ_K7_SYNERGISMLOGDID dd with(nolock) ";
                sql += " where dd.id = '" + bodyid + "'";
                string bodyDid = DbHelperSQL.GetSingle(sql).NullToString();
                if (string.IsNullOrEmpty(bodyDid)) return "error:函数GetValueByAccVouchnoItemname取值错误:" + "未能取到上游单据表体ID,如果上游单据是来源单据,请使用完全参照!";

                //递归计算bodydid
                DataSet dsBefore = GetBodyDid(acccode, cardNo, vouchNo, preAcccode, preCardNo, bodyDid);
                if (dsBefore.Tables[0].Rows.Count == 0)
                {
                    return "error:函数GetValueByAccVouchnoItemname取值错误:" + "未能取到上游单据表体ID!";
                }
                string bodydid = dsBefore.Tables[0].Rows[0]["PreDid"].ToString();
                #endregion


                #region 获取数据库连接
                U8.Interface.Bus.ApiService.DAL.SynergismLogDt dtdal = new SynergismLogDt();
                U8.Interface.Bus.ApiService.Model.Synergismlogdt dt = new U8.Interface.Bus.ApiService.Model.Synergismlogdt();
                string beforeAcccode = dsBefore.Tables[0].Rows[0]["preAcccode"].ToString();
                string beforeVoucherType = dsBefore.Tables[0].Rows[0]["preAcccode"].ToString();
                dt.Accid = beforeAcccode;
                U8.Interface.Bus.ApiService.Model.ConnectInfo connectinfo = dtdal.GetConnectInfo(dt);

                DbHelperSQLP dbhelper = new DbHelperSQLP(connectinfo.Constring);
                #endregion



                #region  获取voucherNo (从对应账套去取)
                if (string.IsNullOrEmpty(vouchNo))
                {
                    switch (cardNo.ToLower())
                    {

                        case "01":  //销售发货单
                            sql = " SELECT t.cdlcode as vouchno, b.idlsid as did FROM Sales_FHD_W b with(nolock) left join Sales_FHD_T t with(nolock) on t.dlid = b.dlid where t.cvouchtype = '05' and t.breturnflag=0  and b.idlsid ='" + bodydid + "'"; //DispatchList DispatchLists order by b." + rowName + " ";
                            break;
                        case "03":  //退货单
                            sql = " SELECT t.cdlcode as vouchno, b.idlsid as did FROM Sales_FHD_W b with(nolock) left join Sales_FHD_T t with(nolock) on t.dlid = b.dlid where t.cvouchtype = '05'  and t.breturnflag=1  and b.idlsid = '" + bodydid + "' "; //order by b." + rowName + " ";
                            break;
                        case "0303":    //销售出库单
                            sql = " SELECT t.ccode as vouchno, b.AutoID as did FROM KCSaleOutB b with(nolock) left join KCSaleOutH t with(nolock) on t.id = b.id where b.AutoID='" + bodydid + "'"; //rdrecord32 rdrecords32 order by b." + rowName + " ";
                            break;
                        case "17":  //销售订单
                            sql = " SELECT t.csocode as vouchno, b.isosid as did FROM SaleOrderSQ b with(nolock) left join SaleOrderQ t with(nolock) on t.id = b.id where b.isosid ='" + bodydid + "' "; // so_sodetails order by b." + rowName + " ";
                            break;
                        case "24":      //采购入库单
                            sql = " SELECT t.ccode as vouchno,b.AutoID as did FROM zpurRkdTail b with(nolock) left join zpurRkdHead t with(nolock) on t.id = b.id where b.autoid ='" + bodydid + "'"; //RdRecords01 RdRecord01 order by b." + rowName + " ";
                            break;
                        case "26":      //采购到货单
                            sql = " SELECT t.cCode as vouchno, b.Autoid as did FROM pu_ArrBody b with(nolock) left join pu_ArrHead t with(nolock) on t.id = b.id where b.icorid ='" + bodydid + "'"; //PU_ArrivalVouch PU_ArrivalVouchs order by b." + rowName + " ";
                            break;
                        case "27":  //采购请购单
                            sql = " SELECT t.ccode as vouchno,b.autoid as did FROM pu_AppBody b with(nolock) left join pu_AppHead t with(nolock) on t.id = b.id where b.autoid = '" + bodydid + "'"; //PU_AppVouch PU_AppVouchs order by b." + rowName + " ";
                            break;
                        case "88":  //采购订单
                            sql = " SELECT t.cpoid as vouchno,b.id as did FROM zpurpotail b with(nolock) left join zpurpoheader t with(nolock) on t.poid = b.poid where b.id = '" + bodydid + "'"; //PO_Pomain PO_Podetails  order by b." + rowName + " ";
                            break;
                        default:
                            return "error:函数GetValueByAccVouchnoItemname取值错误:" + "未能取到账套号:" + acccode + " ,CardNum:" + cardNo + "对应的单据号!";

                    }
                    DataSet dsVoucher = dbhelper.Query(sql);
                    if (dsVoucher.Tables[0].Rows.Count == 0) return "error:函数GetValueByAccVouchnoItemname取值错误:" + "未能取到账套号:" + acccode + " ,CardNum:" + cardNo + "对应的单据号!";

                    vouchNo = dsVoucher.Tables[0].Rows[0]["vouchno"].ToString();
                    if (string.IsNullOrEmpty(vouchNo)) return "error:函数GetValueByAccVouchnoItemname取值错误:" + "未能取到账套号:" + acccode + " ,CardNum:" + cardNo + "对应的单据号!";
                }
                #endregion


                #region 字段校验
                //sql = "select FieldName from voucheritems where carditemname  = '" + strFieldName + "' and CardNum = '" + cardNo + "' and CardSection = '" + cardSection + "'  and ISNULL(carditemname,'')<>''";
                sql = "select FieldName from voucheritems where FieldName  = '" + strFieldName + "' and CardNum = '" + cardNo + "' and CardSection = '" + cardSection + "'  and ISNULL(carditemname,'')<>''";
                DataSet ds = dbhelper.Query(sql);
                if (ds.Tables[0].Rows.Count == 0) return "error:函数GetValueByAccVouchnoItemname取值错误:" + "参数【" + strFieldName + "】没有对应的数据库字段!";
                #endregion

                if (cardSection.ToLower().Equals("t"))  //表头
                {
                    switch (cardNo.ToLower())
                    {
                        case "01":  //销售发货单
                            sql = " SELECT t.cdlcode as vouchno,t." + strFieldName + " as rowName FROM  Sales_FHD_T t with(nolock) where t.cvouchtype = '05' and t.breturnflag=0 and t.cdlcode='" + vouchNo + "' "; //order by b." + rowName + " ";
                            break;
                        case "03":  //退货单
                            sql = " SELECT t.cdlcode as vouchno,t." + strFieldName + " as rowName FROM Sales_FHD_T t with(nolock) where t.cvouchtype = '05'  and t.breturnflag=1 and t.cdlcode='" + vouchNo + "' "; //order by b." + rowName + " ";
                            break;
                        case "0303":    //销售出库单
                            sql = " SELECT t.ccode as vouchno,t." + strFieldName + " as rowName FROM KCSaleOutH t with(nolock) where t.ccode='" + vouchNo + "' "; //rdrecord32 order by b." + rowName + " ";
                            break;
                        case "17":  //销售订单
                            sql = " SELECT t.csocode as vouchno,t." + strFieldName + " as rowName FROM SaleOrderQ t with(nolock) where t.csocode='" + vouchNo + "' "; //so_somain order by b." + rowName + " ";
                            break;
                        case "24":      //采购入库单
                            sql = " SELECT t.ccode as vouchno,t." + strFieldName + " as rowName FROM zpurRkdHead t with(nolock) where t.ccode='" + vouchNo + "' "; //RdRecord01 order by b." + rowName + " ";
                            break;
                        case "26":      //采购到货单
                            sql = " SELECT t.cCode as vouchno,t." + strFieldName + " as rowName FROM pu_ArrHead t with(nolock) where t.cCode='" + vouchNo + "' "; //PU_ArrivalVouch order by b." + rowName + " ";
                            break;
                        case "27":  //采购请购单
                            sql = " SELECT t.ccode as vouchno,t." + strFieldName + " as rowName FROM pu_AppHead t with(nolock) where t.ccode='" + vouchNo + "' "; //PU_AppVouch order by b." + rowName + " ";
                            break;
                        case "88":  //采购订单
                            sql = " SELECT t.cpoid as vouchno,t." + strFieldName + " as rowName FROM zpurpoheader t with(nolock) where t.cpoid='" + vouchNo + "' "; //PO_Pomain order by b." + rowName + " ";
                            break;
                        default:
                            break;
                    }
                }
                else                                   //表体
                {
                    switch (cardNo.ToLower())
                    {

                        case "01":  //销售发货单
                            sql = " SELECT t.cdlcode as vouchno,b." + strFieldName + " as rowName, b.idlsid as did FROM Sales_FHD_W b with(nolock) left join Sales_FHD_T t with(nolock) on t.dlid = b.dlid where t.cvouchtype = '05' and t.breturnflag=0 and t.cdlcode='" + vouchNo + "' and b.idlsid ='" + bodydid + "'"; //DispatchLists order by b." + rowName + " ";
                            break;
                        case "03":  //退货单
                            sql = " SELECT t.cdlcode as vouchno,b." + strFieldName + " as rowName, b.idlsid as did FROM Sales_FHD_W b with(nolock) left join Sales_FHD_T t with(nolock) on t.dlid = b.dlid where t.cvouchtype = '05'  and t.breturnflag=1 and t.cdlcode='" + vouchNo + "' and b.idlsid = '" + bodydid + "' "; //order by b." + rowName + " ";
                            break;
                        case "0303":    //销售出库单
                            sql = " SELECT t.ccode as vouchno,b." + strFieldName + " as rowName, b.AutoID as did FROM KCSaleOutB b with(nolock) left join KCSaleOutH t with(nolock) on t.id = b.id where t.ccode='" + vouchNo + "' and  b.AutoID='" + bodydid + "'"; //rdrecords32 order by b." + rowName + " ";
                            break;
                        case "17":  //销售订单
                            sql = " SELECT t.csocode as vouchno,b." + strFieldName + " as rowName, b.isosid as did FROM SaleOrderSQ b with(nolock) left join SaleOrderQ t with(nolock) on t.id = b.id where t.csocode='" + vouchNo + "' and b.isosid ='" + bodydid + "' "; //order by b." + rowName + " ";
                            break;
                        case "24":      //采购入库单
                            sql = " SELECT t.ccode as vouchno,b." + strFieldName + " as rowName, b.AutoID as did FROM zpurRkdTail b with(nolock) left join zpurRkdHead t with(nolock) on t.id = b.id where t.ccode='" + vouchNo + "' and b.autoid ='" + bodydid + "'"; //order by b." + rowName + " ";
                            break;
                        case "26":      //采购到货单
                            sql = " SELECT t.cCode as vouchno,b." + strFieldName + " as rowName, b.Autoid as did FROM pu_ArrBody b with(nolock) left join pu_ArrHead t with(nolock) on t.id = b.id where t.cCode='" + vouchNo + "' and b.icorid ='" + bodydid + "'"; //order by b." + rowName + " ";
                            break;
                        case "27":  //采购请购单
                            sql = " SELECT t.ccode as vouchno,b." + strFieldName + " as rowName, b.autoid as did FROM pu_AppBody b with(nolock) left join pu_AppHead t with(nolock) on t.id = b.id where t.ccode='" + vouchNo + "' and b.autoid = '" + bodydid + "'"; // order by b." + rowName + " ";
                            break;
                        case "88":  //采购订单
                            sql = " SELECT t.cpoid as vouchno,b." + strFieldName + " as rowName, b.id as did FROM zpurpotail b with(nolock) left join zpurpoheader t with(nolock) on t.poid = b.poid where t.cpoid='" + vouchNo + "' and b.id = '" + bodydid + "'"; //order by b." + rowName + " ";
                            break;
                        default:
                            break;
                    }
                }

                ds = dbhelper.Query(sql);
                if (ds.Tables[0].Rows.Count == 0) return "error:函数GetValueByAccVouchnoItemname取值错误:" + "未能取到对应单据";

                return string.Format("b_res,{0}", ds.Tables[0].Rows[0]["rowName"].ToString());

            }
            catch (Exception ex)
            {
                return "error:函数GetValueByAccVouchnoItemname发生异常:" + ex.Message;
            }

        }

        /// <summary>
        /// 递归查找
        /// 查找上游单据的单据号
        /// </summary>
        /// <param name="beforeAcccode"></param>
        /// <param name="beforeCardNo"></param>
        /// <param name="beforeVoucherNo"></param>
        /// <param name="curAcccode"></param>
        /// <param name="curVoucherType"></param>
        /// <param name="BodyDid"></param>
        /// <returns></returns>
        private static DataSet GetBodyDid(string beforeAcccode, string beforeCardNo, string beforeVoucherNo, string curAcccode, string curVoucherType, string BodyDid)
        {
            try
            {
                DataSet dsPre = new DataSet();
                DataTable dt;
                DataRow dr;
                if (string.IsNullOrEmpty(beforeAcccode))
                {
                    if (beforeCardNo.Equals(curVoucherType))
                    {
                        dt = new DataTable();
                        dt.Columns.Add("preAcccode");
                        dt.Columns.Add("PreDid");
                        dt.Columns.Add("preCvouchertype");
                        dr = dt.NewRow();
                        dr[0] = curAcccode;
                        dr[1] = BodyDid;
                        dr[2] = curVoucherType;
                        dt.Rows.Add(dr);
                        dsPre.Tables.Add(dt);
                        return dsPre;
                    }
                }
                else
                {
                    if (beforeAcccode.Equals(curAcccode) && beforeCardNo.Equals(curVoucherType))
                    {
                        dt = new DataTable();
                        dt.Columns.Add("preAcccode");
                        dt.Columns.Add("PreDid");
                        dt.Columns.Add("preCvouchertype");
                        dr = dt.NewRow();
                        dr[0] = curAcccode;
                        dr[1] = BodyDid;
                        dr[2] = curVoucherType;
                        dt.Rows.Add(dr);
                        dsPre.Tables.Add(dt);
                        return dsPre;
                    }
                }

                string sql = "SELECT  R.acccode,DD.accid,DD.cvouchertype,DD.did,  RR.acccode as preAcccode,DD.preAccid,DD.preCvouchertype,DD.PreVoucherno,DD.PreDid FROM HY_DZ_K7_SYNERGISMLOGDID DD WITH (NOLOCK) ";
                sql += " LEFT JOIN HY_DZ_K7_REGIST R WITH(NOLOCK) ON DD.accid = R.accid ";
                sql += " LEFT JOIN HY_DZ_K7_REGIST Rr WITH(NOLOCK) ON DD.preAccid = RR.accid ";
                sql += " WHERE R.acccode ='" + curAcccode + "'  and dd.cvouchertype ='" + curVoucherType + "' and dd.did = '" + BodyDid + "' ";

                dsPre = DbHelperSQL.Query(sql);
                if (string.IsNullOrEmpty(beforeAcccode))
                {
                    if (dsPre.Tables[0].Rows[0]["preCvouchertype"].ToString().Equals(beforeCardNo))
                    {
                        return dsPre;
                    }
                    else
                    {
                        return GetBodyDid(beforeAcccode, beforeCardNo, beforeVoucherNo, dsPre.Tables[0].Rows[0]["preAcccode"].ToString(), dsPre.Tables[0].Rows[0]["preCvouchertype"].ToString(), dsPre.Tables[0].Rows[0]["PreDid"].ToString());
                    }
                }
                else
                {
                    if (dsPre.Tables[0].Rows[0]["preAcccode"].ToString().Equals(beforeAcccode) && dsPre.Tables[0].Rows[0]["preCvouchertype"].ToString().Equals(beforeCardNo))
                    {
                        return dsPre;
                    }
                    else
                    {
                        return GetBodyDid(beforeAcccode, beforeCardNo, beforeVoucherNo, dsPre.Tables[0].Rows[0]["preAcccode"].ToString(), dsPre.Tables[0].Rows[0]["preCvouchertype"].ToString(), dsPre.Tables[0].Rows[0]["PreDid"].ToString());
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("无法追溯到此单据!");
            }
        }


        /// <summary>
        /// 判断存货是否是PE件  added by liuxzha 2015.05.08
        /// </summary> 
        /// <param name="invcode"></param>
        /// <returns> ipesotype pe需求跟踪方式,cpesocode pe需求跟踪号,ipesoseq pe需求跟踪行号 </returns>
        public static string GetSRPolicy(string strAccid, string invcode,string socode,string petracerowno)
        {
            try
            {
                if (string.IsNullOrEmpty(invcode)) return "error:函数GetSRPolicy参数错误:" + "存货编码不能为空";//return "ccontactname,"+""+";cmobilephone,"+""+";cofficephone,"+""+"";

                string sql = string.Empty;

                sql = string.Format("select acccode from HY_dz_k7_regist where accid='{0}'", strAccid);
                strAccid = DbHelperSQL.GetSingle(sql).NullToString();
                if (string.IsNullOrEmpty(strAccid)) return "error:函数GetSRPolicy取值错误:" + "未能取到账套ID";

                U8.Interface.Bus.ApiService.DAL.SynergismLogDt dtdal = new SynergismLogDt();
                U8.Interface.Bus.ApiService.Model.Synergismlogdt dt = new U8.Interface.Bus.ApiService.Model.Synergismlogdt();
                dt.Accid = strAccid;
                U8.Interface.Bus.ApiService.Model.ConnectInfo connectinfo = dtdal.GetConnectInfo(dt);

                DbHelperSQLP dbhelper = new DbHelperSQLP(connectinfo.Constring);
                sql = string.Format(" select csrpolicy from inventory with(nolock) where cInvCode = '{0}'", invcode);
                DataSet ds = dbhelper.Query(sql);
                if (ds.Tables[0].Rows.Count == 0) return "error:函数GetSRPolicy取值错误:" + "未能取到对应的存货编码";

                string csrpolicy = ds.Tables[0].Rows[0]["csrpolicy"].ToString();//PE\LP
                string ipesotype = csrpolicy.ToLower().Equals("pe") ? "1" : "";
                string cpesocode = csrpolicy.ToLower().Equals("pe") ? socode : "";
                string ipesoseq = csrpolicy.ToLower().Equals("pe") ? petracerowno : "";

                return string.Format("ipesotype,{0};cpesocode,{1}"
                    , ipesotype
                    , cpesocode
                    , ipesoseq
                    );

            }
            catch (Exception ex)
            {
                return "error:函数GetSRPolicy发生异常:" + ex.Message;
            }


        }


    }
}
