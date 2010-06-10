using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Net;
using System.Management;
using U8.Interface.Bus.DBUtility;
using U8.Interface.Bus.ApiService.BLL;

namespace U8.Interface.Bus.ApiService.DAL
{
    public static class Common
    {

        public static string functionTableName = "MES_CQ_FUNCTION";
        public static string functionsTableName = "MES_CQ_FUNCTIONS";
        public static string fixvalueTableName = "MES_CQ_FIXVALUE";



        /// <summary>
        /// 根据单据号和字段名获取字段类型
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="sFieldName"></param>
        /// <param name="CardNumber"></param>
        /// <returns>0.布尔型 1.字符型 2.整型 3.长整型 4.浮点 5.日期型</returns>
        public static int GetFieldType(string conn, string sFieldName, string CardNumber)
        {
            string sSql = "";

            sSql = "select FieldType from voucheritems_base with(nolock) where FieldName='" + sFieldName + "' and CardNum ='" + CardNumber + "'";
            DbHelperSQLP objDB = new DbHelperSQLP(conn);
            DataSet ds = objDB.Query(sSql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt16(ds.Tables[0].Rows[0]["FieldType"]);
            }
            else
            {
                return 1;
            }
        } 




        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="tablename"></param>
        /// <param name="connectstring"></param>
        /// <returns></returns>
        public static string GetUtfsByID(string ID, string tablename, string connectstring)
        {
            string cmdText = "select convert(nchar,convert(money, ufts),2) as TimeStamp from " + tablename + " with(nolock)  where id = N'" + ID + "' ";
            DbHelperSQLP sql = new DbHelperSQLP(connectstring);
            string ret = sql.GetSingle(cmdText).ToString();
            BLL.Common.ErrorMsg(ret, "未能获取时间戳");
            return ret;
        }

        /// <summary>
        /// 获取API键值对
        /// </summary>
        /// <param name="apidata"></param>
        /// <param name="Type"></param>
        /// <param name="fieldname"></param>
        /// <returns></returns>
        public static Model.U8NameValue GetApiDataValue(Model.APIData apidata, string type, int index, string fieldname)
        {
            Model.U8NameValue nv = new Model.U8NameValue();
            nv.U8FieldName = fieldname;
            nv.U8FieldValue = "";

            if (type.ToUpper() != "B")
            {
                foreach (Model.U8NameValue n in apidata.HeadData)
                {
                    if (n.U8FieldName.ToUpper() == fieldname.ToUpper())
                    {
                        return n;
                    }
                }
            }
            else
            {
                foreach (Model.U8NameValue n in apidata.BodyData[index])
                {
                    if (n.U8FieldName.ToUpper() == fieldname.ToUpper())
                    {
                        return n;
                    }
                }
            }

            return nv;
        }

           
        /// <summary>
        /// 加密检查
        /// </summary>
        /// <returns></returns>
        public static bool QueryEncryption()
        {
            //string servname = BLL.RegistryKeyHelp.getValueRegEdit(BLL.RegistryKeyHelp.u8path, "servername");
            //if (string.IsNullOrEmpty(servname))
            //{
            //    return true;
            //}
            //string dbname = BLL.RegistryKeyHelp.getValueRegEdit(BLL.RegistryKeyHelp.u8path, "dbname");
            //string sql = string.Format("select  acccode from HY_DZ_K7_REGIST where caddress='{0}' and caccname='{1}'",servname,dbname);
            //string accode = DAL.DbHelperSQL.GetSingle(sql).NullToString();
            //if (string.IsNullOrEmpty(accode))
            //{

            //    throw new Exception("未找到主账套信息,请在U8协同模块设置");

            //}
            //DAL.Regist regist=new DAL.Regist();
            //Model.Regist regismodel = regist.GetModel(accode);


            //string subId = "DP";
            //string userId = regismodel.Cuser_id;
            //string accId = regismodel.Cacc_id;
            //string yearId = regismodel.Ibeginyear.ToString();
            //string password =regismodel.Cpassword;
            //string date = DateTime.Now.ToString("yyyy-MM-dd");//"2013-01-01";//
            //string srv = regismodel.Caddress;
            //string serial = "";
            //U8Login.clsLogin u8Login = new U8Login.clsLogin();
            //if (!u8Login.Login(ref subId, ref accId, ref yearId, ref userId, ref password, ref date, ref srv, ref serial))
            //{
            //    string err = u8Login.ShareString;
            //    Marshal.FinalReleaseComObject(u8Login);
            //    throw new Exception("登陆失败，原因：" + err);

            //}


            ////加密设置


            //if (u8Login.TaskExec("K7", 10, 0) == false)
            //{

            //     sql = "select datediff(m,min(starttime),max(starttime)) from HY_DZ_K7_SYNERGISMLOG";
            //    object datediff = DAL.DbHelperSQL.GetSingle(sql);
            //    if (datediff != DBNull.Value&&datediff!=null)
            //    {
            //        int idatediff = int.Parse(datediff.ToString());
            //        if (idatediff >= 2)
            //        {
            //            return false;
            //        }
            //    }

            //}
            return true;



        }
 

        /// <summary>
        /// 获取数据服务器下拉列表
        /// </summary>
        /// <returns></returns>
        public static List<Model.U8NameValue> getAddressList()
        {
            List<Model.U8NameValue> lst = new List<Model.U8NameValue>();
            lst.Add(new Model.U8NameValue() { U8FieldName = "全部", U8FieldValue = "全部" });
            string cmdText = "SELECT DISTINCT caddress FROM HY_DZ_K7_REGIST ";
            DataSet ds = DbHelperSQL.Query(cmdText);
            if (ds == null || ds.Tables[0].Rows.Count <= 0) return lst;
            Model.U8NameValue model;
            foreach ( DataRow dr in ds.Tables[0].Rows)
            {
                model = new Model.U8NameValue();
                model.U8FieldName = dr["caddress"].ToString().ToUpper();
                model.U8FieldValue = dr["caddress"].ToString().ToUpper();
                lst.Add(model);
            }
            return lst;
        }


        /// <summary>
        /// 获取协同分类下拉列表
        /// </summary>
        /// <returns></returns>
        public static List<Model.U8NameValue> getRoutesetName()
        {
            List<Model.U8NameValue> lst = new List<Model.U8NameValue>();
            lst.Add(new Model.U8NameValue() { U8FieldName = "全部", U8FieldValue = "全部" });
            string cmdText = "SELECT DISTINCT [cflowname],1 AS [iorder],'Order' AS [type] FROM [HY_DZ_K7_ROUTESET] WITH(NOLOCK) UNION SELECT DISTINCT [itype] AS [cflowname],2 AS [iorder],'Data' AS [type] FROM [HY_DZ_K7_TYPE] WITH(NOLOCK) ORDER BY [iorder] ";
            DataSet ds = DbHelperSQL.Query(cmdText);
            if (ds == null || ds.Tables[0].Rows.Count <= 0) return lst;
            Model.U8NameValue model;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                model = new Model.U8NameValue();
                model.U8FieldName = dr["cflowname"].ToString();
                model.U8FieldValue = dr["cflowname"].ToString();
                lst.Add(model);
            }
            return lst;
        }


        /// <summary>
        /// 获取单据类型下拉列表
        /// </summary>
        /// <returns></returns>
        public static List<Model.U8NameValue> getOrderType()
        {
            List<Model.U8NameValue> lst = new List<Model.U8NameValue>();
            lst.Add(new Model.U8NameValue() { U8FieldName = "全部", U8FieldValue = "全部" });
            string cmdText = "SELECT cardnum,cbillname FROM (SELECT cardnum,cbillname,1 AS [iorder],'Order' AS [type] FROM HY_DZ_K7_BILLSCOPE WHERE cardnum NOT IN ('0301','0302','0304') UNION SELECT '0' AS cardnum,'基础档案' AS cbillname,2 AS [iorder],'Data' AS [type] ) AS TEMP ORDER BY [iorder],CHARINDEX(cardnum,'17,01,03,0303,27,88,26,24,0304,0302,0301') ";
            DataSet ds = DbHelperSQL.Query(cmdText);
            if (ds == null || ds.Tables[0].Rows.Count <= 0) return lst;
            Model.U8NameValue model;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                model = new Model.U8NameValue();
                model.U8FieldName = dr["cbillname"].ToString();
                model.U8FieldValue = dr["cardnum"].ToString();
                lst.Add(model);
            }
            return lst;
        }


        /// <summary>
        /// 获取支持的单据
        /// </summary>
        public static List<Model.VoucherType> GetVoucherTypeList()
        {
            List<Model.VoucherType> lst = new List<Model.VoucherType>();
            lst.Add(new Model.VoucherType() { VoucherName = "产成品入库单", VoucherClass = "xxx", CardNo = "0411", CardId = "RecordInVouch" });
            return lst; 
        }


        /// <summary>
        /// 根据字段名获取值
        /// </summary>
        /// <param name="list"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string getvalue(List<Model.U8NameValue> list, string name)
        {
            foreach (Model.U8NameValue nv in list)
            {
                if (nv.U8FieldName.ToLower() == name.ToLower()) return nv.U8FieldValue;
            }
            return string.Empty;
        }
              

        public static string ToDataString(this object obj)
        {
            if (obj == null) return string.Empty;
            if (obj is DateTime) return ((DateTime)obj).ToString("yyyy-MM-dd HH:mm:ss");
            return obj.ToString();
        }


        /// <summary>
        /// null转化为string的方法
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string NullToString(this object obj)
        {
            if (obj == null || obj == DBNull.Value) return string.Empty;
            return obj.ToString();
        }
           

        /// <summary>
        /// 获取U8版本
        /// </summary>
        /// <param name="Constring"></param>
        /// <returns></returns>
        public static string GetU8Version(string Constring)
        {
            try
            {
                string sql = "select * from UFSystem..ua_version ";
                DbHelperSQLP dbsql = new DbHelperSQLP(Constring);

                object obj = dbsql.GetSingle(sql);
                if (obj == null || obj == DBNull.Value) return "V11.0";
                string strVersion = obj.ToString();
                if (string.IsNullOrEmpty(strVersion)) return "V11.0";

                if (strVersion.StartsWith("121")) return "V12.1";
                if (strVersion.StartsWith("120")) return "V12.0";
                if (strVersion.StartsWith("111")) return "V11.1";
                return "V11.0";
            }
            catch { return "V11.0"; }
        }

        public static bool readerExists(DataRow dr, string columnName)
        {
            if (string.IsNullOrEmpty(columnName)) return false;

            foreach (DataColumn dc in dr.Table.Columns)
            {
                if (dc.ColumnName.ToUpper() == columnName.ToUpper()) return true;
            }
            return false;
        }
         
         
        /// <summary>
        /// 检查数据是否被使用，是否能够删除
        /// wangdd1 2015-05-16
        /// <param name="sqlData">数据集</param>
        /// <param name="sArchType">档案类型：直接传入表名</param>
        /// <param name="sArchCode">档案主键编码</param>
        /// <param name="sErr">返回的错误值</param>
        /// <returns></returns>
        public static bool CheckIsUsed(string sConn, string sArchType, string sArchCode, out string sErr)
        {
            string sArchTypeName ="";
            DbHelperSQLP Conn = new DbHelperSQLP(sConn);
            Random rd = new Random();
            int rdnum = rd.Next(1, 1000);
            string TmpTable = "tempXT" + rdnum.ToString();
            string sSql = "select top 1 * from tempdb..sysobjects where Id=Object_Id('" + TmpTable + "')  and type=N'U'";
            bool bExistTable = Conn.Exists(sSql);
            if (bExistTable)
            {
                Conn.ExecuteSql("drop table tempdb.." + TmpTable);
            }
            IDataParameter[] Para = new SqlParameter[4];
            Para[0] = new SqlParameter("@cArchType", sArchType);
            Para[1] = new SqlParameter("@cArchCode", sArchCode);
            Para[2] = new SqlParameter("@cTmpTableName", TmpTable);
            Para[3] = new SqlParameter("@FieldName", "cRetVal");
            Conn.RunProcedure("ArchIsUsedProxy", Para);
            DataSet ds = new DataSet();
            ds = Conn.Query("select cRetVal from tempdb.." + TmpTable);
            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                sErr = "";
                Conn.ExecuteSql("drop table tempdb.." + TmpTable);
                return false;
            }
            else
            {
                sErr = "";
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["cRetVal"].ToString()))
                {
                    if (sArchType.ToLower().IndexOf("department") >-1 )
                    {
                        sArchTypeName = "部门档案";
                    }
                    else if ((sArchType.ToLower() == "inventory"))
                    {
                        sArchTypeName = "存货档案";
                    }
                    else if ((sArchType.ToLower() == "bas_part"))
                    {
                        sArchTypeName = "存货物料档案";
                    }
                    else
                    {
                        sArchTypeName = sArchType;
                    }

                    sErr = "[" + sArchTypeName + "]" + "档案[" + sArchCode + "]已经被[" + ds.Tables[0].Rows[0]["cRetVal"].ToString() + "]引用";
                    Conn.ExecuteSql("drop table tempdb.." + TmpTable);
                    return true;
                }
                Conn.ExecuteSql("drop table tempdb.." + TmpTable);
                return false;
            }  
        }


        /// <summary>
        /// 获取审核日期
        /// </summary>
        public static string GetVerifyDate(Model.ConnectInfo ConnectStr, Model.Synergismlogdt dt)
        {
            DbHelperSQLP dsp = new DbHelperSQLP(ConnectStr.Constring);
            string strDefault = DateTime.Now.ToString("yyyy-MM-dd");
            string OrderType = dt.Cvouchertype;
            string OrderCode = dt.Cvoucherno;
            string sql;
            object obj;
            switch (OrderType)
            {
                case "17":      //销售订单
                    sql = "SELECT ISNULL(dverifydate,CONVERT(NVARCHAR(30),GETDATE(),23)) FROM SO_SOMain WHERE cSOCode='" + OrderCode + "'";
                    obj = dsp.GetSingle(sql);
                    break;
                case "01":      //发货单
                    sql = "SELECT ISNULL(dverifydate,CONVERT(NVARCHAR(30),GETDATE(),23)) FROM DispatchList WHERE cDLCode='" + OrderCode + "' and cVouchType='05' and breturnflag=0 ";
                    obj = dsp.GetSingle(sql);
                    break;
                case "03":      //退货单  added by liuxzha 2014.11.27
                    sql = "SELECT ISNULL(dverifydate,CONVERT(NVARCHAR(30),GETDATE(),23)) FROM DispatchList WHERE cDLCode='" + OrderCode + "' and cVouchType='05' and breturnflag=1 ";
                    obj = dsp.GetSingle(sql);
                    break;
                case "0303":    //销售出库单
                    sql = "SELECT ISNULL(dVeriDate,CONVERT(NVARCHAR(30),GETDATE(),23)) FROM RdRecord32 WHERE cCode='" + OrderCode + "'";
                    obj = dsp.GetSingle(sql);
                    break;
                case "27":      //采购请购单
                    sql = "SELECT ISNULL(cAuditDate,CONVERT(NVARCHAR(30),GETDATE(),23)) FROM PU_AppVouch WHERE cCode='" + OrderCode + "'";
                    obj = dsp.GetSingle(sql);
                    break;
                case "88":      //采购订单
                    sql = "SELECT ISNULL(cAuditDate,CONVERT(NVARCHAR(30),GETDATE(),23)) FROM PO_POMain WHERE cPOID ='" + OrderCode + "'";
                    obj = dsp.GetSingle(sql);
                    break;
                case "26":      //采购到货单
                    sql = "SELECT ISNULL(cAuditDate,CONVERT(NVARCHAR(30),GETDATE(),23)) FROM PU_ArrivalVouch WHERE cCode='" + OrderCode + "'";
                    obj = dsp.GetSingle(sql);
                    break;
                case "24":      //采购入库单
                    sql = "SELECT ISNULL(dVeriDate,CONVERT(NVARCHAR(30),GETDATE(),23)) FROM RdRecord01 WHERE cCode='" + OrderCode + "'";
                    obj = dsp.GetSingle(sql);
                    break;
                case "0411":   //产成品入库单
                    sql = "SELECT ISNULL(dVeriDate,CONVERT(NVARCHAR(30),GETDATE(),23)) FROM RdRecord10 WHERE cCode='" + OrderCode + "'";
                    obj = dsp.GetSingle(sql);
                    break;
                default:
                    sql = "SELECT '" + strDefault + "'";
                    Log.WriteWinLog("未获取到单据审核日期,Cvouchertype:" + dt.Cvouchertype + ";Cvoucherno:" + dt.Cvoucherno + ".");
                    return strDefault;
            }

            if (obj == null || obj == DBNull.Value)
            {
                Log.WriteWinLog("未获取到单据审核日期,Cvouchertype:" + dt.Cvouchertype + ";Cvoucherno:" + dt.Cvoucherno + ";sql:" + sql + ".");
                return strDefault;
            }
            return obj.ToString();
        }

        /// <summary>
        /// 设置审核日期
        /// </summary>
        /// <param name="ConnectStr"></param>
        /// <param name="OrderType"></param>
        /// <param name="OrderCode"></param>
        /// <returns></returns>
        public static bool SetVerifyDate(Model.ConnectInfo ConnectStr, Model.Synergismlogdt dt)
        {
            DbHelperSQLP dsp = new DbHelperSQLP(ConnectStr.Constring);
            //string date = GetVerifyData(dt);
            string OrderType = dt.Cvouchertype;
            string OrderCode = dt.Cvoucherno;
            string sql = string.Empty;
            switch (OrderType)
            {
                case "17":      //销售订单
                    //sql = ("UPDATE SO_SOMain SET dverifydate='" + date + "',dverifysystime='" + date + "' WHERE cSOCode='" + OrderCode + "' ");
                    sql = "UPDATE SO_SOMain SET dverifydate=dDate,dverifysystime=dcreatesystime WHERE cSOCode='" + OrderCode + "' ";
                    break;
                case "01":      //发货单
                    //sql = ("UPDATE DispatchList SET dverifydate='" + date + "',dverifysystime='" + date + "' WHERE cDLCode='" + OrderCode + "'");
                    sql = "UPDATE DispatchList SET dverifydate=dDate,dverifysystime=dcreatesystime WHERE cDLCode='" + OrderCode + "' and cVouchType='05' and breturnflag=0";
                    break;
                case "03":      //退货单  added by liuxzha 2014.11.27
                    //sql = ("UPDATE DispatchList SET dverifydate='" + date + "',dverifysystime='" + date + "' WHERE cDLCode='" + OrderCode + "'");
                    sql = "UPDATE DispatchList SET dverifydate=dDate,dverifysystime=dcreatesystime WHERE cDLCode='" + OrderCode + "' and cVouchType='05' and breturnflag=1";
                    break;
                case "0303":    //销售出库单
                    //sql = ("UPDATE RdRecord32 SET dVeriDate='" + date + "',dnverifytime='" + date + "' WHERE cCode='" + OrderCode + "' ");
                    sql = "UPDATE RdRecord32 SET dVeriDate=dDate,dnverifytime=dnmaketime WHERE cCode='" + OrderCode + "' ";
                    break;
                case "27":      //采购请购单
                    //sql = ("UPDATE PU_AppVouch SET cAuditDate='" + date + "',cAuditTime='" + date + "' WHERE cCode='" + OrderCode + "' ");
                    sql = "UPDATE PU_AppVouch SET cAuditDate=dDate,cAuditTime=cMakeTime WHERE cCode='" + OrderCode + "' ";
                    break;
                case "88":      //采购订单
                    //sql = ("UPDATE PO_POMain SET cAuditDate='" + date + "',cAuditTime='" + date + "' WHERE cPOID ='" + OrderCode + "' ");
                    sql = "UPDATE PO_POMain SET cAuditDate=dPODate,cAuditTime=cMakeTime WHERE cPOID ='" + OrderCode + "' ";
                    break;
                case "26":      //采购到货单
                    //sql = ("UPDATE PU_ArrivalVouch SET cAuditDate='" + date + "',cAuditTime='" + date + "' WHERE cCode='" + OrderCode + "' ");
                    sql = "UPDATE PU_ArrivalVouch SET cAuditDate=dDate,cAuditTime=cMakeTime WHERE cCode='" + OrderCode + "' ";
                    break;
                case "24":      //采购入库单
                    //sql = ("UPDATE RdRecord01 SET dVeriDate='" + date + "',dnverifytime='" + date + "' WHERE cCode='" + OrderCode + "' ");
                    sql = "UPDATE RdRecord01 SET dVeriDate=dDate,dnverifytime=dnmaketime WHERE cCode='" + OrderCode + "' ";
                    break;
                default:
                    return false;
            }

            int iResult = dsp.ExecuteSql(sql);
            return iResult >= 1;
        }

        /// <summary>
        /// 设置行号
        /// </summary>
        /// <param name="m"></param>
        /// <param name="constring"></param>
        public static void setirowno(Model.IrownoModel m, string constring, bool barcodeflag)
        {
            string cmdtext = string.Format("select {0} as autoid from {1} where {2}={3}", m.Autoidname, m.Tablename, m.Idname, m.Id);
            DbHelperSQLP sql = new DbHelperSQLP(constring);
            DataSet ds = sql.Query(cmdtext);
            if (ds == null || ds.Tables[0].Rows.Count == 0) return;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (barcodeflag)
                {
                    string barcode = string.Format("||{0}|{1}|{2}", m.Barcodefomat, m.Code, (i + 1).ToString());
                    cmdtext = string.Format("update {0} set {1}={2},{3}='{4}' where  {5}={6}",
                         m.Tablename,
                         m.Fliedname,
                         (i + 1).ToString(),
                         m.Barcodename,
                         barcode,
                         m.Autoidname,
                         ds.Tables[0].Rows[i]["autoid"].ToString()
                        );
                }
                else
                {
                    string barcode = string.Format("||{0}|{1}|{2}", m.Barcodefomat, m.Code, (i + 1).ToString());
                    cmdtext = string.Format("update {0} set {1}={2} where {5}={6}",
                          m.Tablename,
                          m.Fliedname,
                          (i + 1).ToString(),
                          m.Barcodename,
                          barcode,
                          m.Autoidname,
                          ds.Tables[0].Rows[i]["autoid"].ToString()
                         );

                }

                sql.ExecuteSql(cmdtext);

            }

        }


        #region  赋值方式

        /// <summary>
        /// 获取分账套值
        /// </summary>
        /// <param name="did"></param>
        /// <param name="accid"></param>
        /// <returns></returns>
        public static string GetVauleByAccid(string did, string accid)
        {
            string cmdText = string.Format("select isnull(cvalue,'') from " + fixvalueTableName + "  where did='{0}' and accid='{1}' and ctype='1'", did, accid);
            string ret = DbHelperSQL.GetSingle(cmdText).NullToString();
            //ErrorMsg(ret, "分账套取值为空");
            return ret;

        }

        /// <summary>
        /// 获取分路线的函数默认值
        /// 刘忻洲添加    2014.11.20
        /// </summary>
        /// <param name="taskMainId">任务主表ID</param>
        /// <param name="operMainId">协同字段对照表头ID</param>
        /// <param name="operChildId">协同字段对照表体ID</param>
        /// <param name="functionId">函数ID</param>
        /// <returns></returns>
        public static string GetDefaultValueByTaskIdFunctionId(string taskMainId, string operMainId, string operChildId, string functionId)
        {
            string cmdText = string.Format("select isnull(cvalue,'') from hy_dz_k7_rtfDefault d inner join HY_DZ_K7_SYNERGISMLOG t on t.crouteType =d.crouteType and t.id = {0} where cmpOperMainId='{1}' and cmpOperChildId='{2}' and cFunId='{3}'", taskMainId, operMainId, operChildId, functionId);
            string ret = DbHelperSQL.GetSingle(cmdText).NullToString();
            //ErrorMsg(ret, "获取分路线的函数默认值为空");
            return ret;

        }




        /// <summary>
        /// 函数取值
        /// </summary>
        /// <param name="apidata"></param>
        /// <param name="headdata">目标单据表头数据</param>
        /// <param name="bodydata">目标单据表体数据</param>
        /// <param name="dr">来源单据表头数据</param>
        /// <param name="drs">来源单据表体数据</param>
        /// <param name="fd">字段对照信息</param>
        /// <param name="dt">任务表体信息</param>
        /// <param name="rowno">来源单据行号</param>
        /// <returns></returns>
        public static string GetFunValue(Model.APIData apidata, List<Model.U8NameValue> headdata, List<Model.U8NameValue> bodydata, System.Data.DataRow dr, System.Data.DataRow drs, Model.Fieldcmps fd, Model.Synergismlogdt dt, int rowno)
        {
            #region 组织参数

            DAL.FixValue fixdal = new FixValue();
            List<Model.Fixvalue> fixlist = fixdal.GetModelList(" did='" + fd.Autoid + "'");
            if (fixlist.Count == 0)
            {
                throw new Exception("获取字段设置的函数值为空,请检查字段对照中关于字段取值函数的设置！");

            }
            DAL.Function fundal = new Function();
            Model.Function funmodel = fundal.GetModel("cfunid='" + fixlist[0].Cfunid + "' ");
            if (funmodel == null)
            {
                throw new Exception("获取函数信息为空！");
            }

            List<string> templist = new List<string>();   //函数参数
            string ret = string.Empty;
            //数据库链接
            string sqlmode = string.Empty;

            foreach (Model.Fixvalue fv in fixlist)
            {

                if (fv.Ctype == Constant.Fixvalue_Ctype_Constring)//数据库链接
                {

                    sqlmode = fv.Cvalue;
                }

                if (fv.Ctype == Constant.Fixvalue_Ctype_ReturnValue)//返回植
                {
                    ret = fv.Cfunparareturn;
                }

                if (fv.Ctype != Constant.Fixvalue_Ctype_FunctionParam) continue;  //不是函数参数


                switch (fv.Cfromortobill + fv.Cardsection)
                {
                    //来源订单  表头
                    case Constant.Fixvalue_Cfromortobill_Source + Constant.Fixvalue_Cardsection_Title:
                        templist.Add(dr[fv.Cfunparareturn].ToDataString());
                        break;

                    //来源订单  表体
                    case Constant.Fixvalue_Cfromortobill_Source + Constant.Fixvalue_Cardsection_Body:
                        if (fixlist[0].Cfunid == "009" && fv.Cfunparareturn == "cinvcode")
                        {
                            templist.Add(GetInvWhere(drs, bodydata, fv));
                        }
                        else if (fixlist[0].Cfunid == "021")
                        {
                            templist.Add(drs[fv.Cfunparareturn].ToString());  //来源单据存货编码 
                            templist.Add(dr["csocode"].ToString());  //销售订单号
                            templist.Add(drs["iorderrowno"].ToString());  //需求跟踪行号 idemandseq
                        }
                        else
                        {
                            templist.Add(drs[fv.Cfunparareturn].ToString());
                        }
                        break;
                    //目标单据  表头
                    case Constant.Fixvalue_Cfromortobill_Original + Constant.Fixvalue_Cardsection_Title:
                        templist.Add(getvalue(headdata, fv.Cfunparareturn));
                        break;
                    //目标单据  表体
                    case Constant.Fixvalue_Cfromortobill_Original + Constant.Fixvalue_Cardsection_Body:
                        templist.Add(getvalue(bodydata, fv.Cfunparareturn));
                        break;
                    //上游单据  表头  added by liuxzha 2015.03.18
                    case Constant.Fixvalue_Cfromortobill_B + Constant.Fixvalue_Cardsection_Title:
                        if (fixlist[0].Cfunid == "020")
                        {
                            templist.Add("t");
                            templist.Add(fv.Cfunparareturn);
                            templist.Add(rowno.ToString());
                            templist.Add(dt.Autoid.ToString());
                        }
                        else if (fixlist[0].Cfunid == "030")
                        {
                            templist.Add(GetComonValue(apidata, "s_accid", rowno, funmodel.Cfunname));
                            templist.Add(GetComonValue(apidata, "d_accid", rowno, funmodel.Cfunname));
                            templist.Add(drs["iposid"].ToString());
                            templist.Add("t");
                            templist.Add(fv.Cfunparareturn);
                        }
                        break;

                    //上游单据  表体   added by liuxzha 2015.03.18
                    case Constant.Fixvalue_Cfromortobill_B + Constant.Fixvalue_Cardsection_Body:
                        if (fixlist[0].Cfunid == "020")
                        {
                            templist.Add("b");
                            templist.Add(fv.Cfunparareturn);
                            templist.Add(rowno.ToString());
                            templist.Add(dt.Autoid.ToString());

                        }
                        else if (fixlist[0].Cfunid == "030")
                        {
                            templist.Add(GetComonValue(apidata, "s_accid", rowno, funmodel.Cfunname));
                            templist.Add(GetComonValue(apidata, "d_accid", rowno, funmodel.Cfunname));
                            templist.Add(drs["iposid"].ToString());
                            templist.Add("b");
                            templist.Add(fv.Cfunparareturn);
                        }
                        break;

                    //保留字 公共变量
                    case Constant.Fixvalue_Cfromortobill_P + Constant.Fixvalue_Cardsection_V:
                        templist.Add(GetComonValue(apidata, fv.Cfunparareturn, rowno, funmodel.Cfunname));
                        break;

                    //保留字 单据类型
                    case Constant.Fixvalue_Cfromortobill_P + Constant.Fixvalue_Cardsection_P:
                        templist.Add(fv.Cfunparareturn);
                        break;

                    //保留字 固定值
                    case Constant.Fixvalue_Cfromortobill_P + Constant.Fixvalue_Cardsection_S:
                        if (fv.Cfunparareturn.ToLower().Equals("[null]"))
                        {
                            templist.Add("");
                        }
                        else
                        {
                            templist.Add(fv.Cfunparareturn);
                        }
                        break;
                }


            }

            #endregion

            #region 调用函数
            if (funmodel.Cfuntype == Constant.Function_Cfuntype_SQL)//sql
            {

                DAL.SynergismLogDt dtdal = new SynergismLogDt();
                if (sqlmode == string.Empty) sqlmode = DbHelperSQL.connectionString;
                if (sqlmode == Constant.Fixvalue_Cvalue_Master) sqlmode = DbHelperSQL.connectionString;
                if (sqlmode == Constant.Fixvalue_Cvalue_Source)
                {
                    sqlmode = dtdal.GetConnectInfo(apidata.Fristsynergismlogdt).Constring;
                }
                if (sqlmode == Constant.Fixvalue_Cvalue_Destination)
                {
                    sqlmode = apidata.ConnectInfo.Constring;
                }
                DbHelperSQLP sqlp = new DbHelperSQLP(sqlmode);
                string sql = funmodel.Cfunsql;

                sql = string.Format(sql, templist.ToArray());

                DataSet ds = sqlp.Query(sql);
                BLL.Common.ErrorMsg(ds, "函数" + funmodel.Cfunname + "返回值错误,未能取到数据." + sql + "|" + sqlmode);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][ret].ToString();
                }
            }

            if (funmodel.Cfuntype == Constant.Function_Cfuntype_FUN)//fun
            {
                Assembly ass = System.Reflection.Assembly.Load(funmodel.Cfunobject);//类名

                BLL.Common.ErrorMsg(funmodel.Cfunclass.Split('.'), 2, "函数" + funmodel.Cfunname + "必须使用命名空间.类名称的格式");

                Type type = ass.GetType(funmodel.Cfunclass);
                MethodInfo mInfo = null;
                try
                {
                    mInfo = type.GetMethod(funmodel.Cfunname);
                }
                catch
                {
                    BLL.Common.ErrorMsg("", "函数" + funmodel.Cfunname + "方法不正确");
                }



                string returnValue = mInfo.Invoke(null, templist.ToArray()).ToString();

                if (returnValue.Contains("error"))
                {
                    throw new Exception("函数错误:" + returnValue.Replace("error:", ""));

                }
                string[] strretun = returnValue.Split(';');
                foreach (string s in strretun)
                {
                    BLL.Common.ErrorMsg(s.Split(','), 2, "函数" + funmodel.Cfunname + "返回值格式不正确");
                    if (s.Split(',')[0] == ret)
                    {
                        return s.Split(',')[1];
                    }
                }
            }
            #endregion

            return "";
        }

        /// <summary>
        /// 校验订单关联
        /// wangdd1 2015-05-13
        /// </summary>
        /// <param name="apiData"></param>
        /// <returns></returns>
        public static bool SetInBody(Model.APIData apiData)
        {
            //if (apiData.Synergismlogdt.Cvouchertype != "24" && apiData.Synergismlogdt.Cvouchertype != "01") return true;

            BLL.SynergisnLogDT bllDT = new BLL.SynergisnLogDT();
            Model.Synergismlogdt dtPrev;
            dtPrev = bllDT.GetPrevious(apiData.Synergismlogdt,apiData.OP);
            if (dtPrev == null) return false;

            string strVersion = GetU8Version(apiData.ConnectInfo.Constring);
            string sql;

            if (dtPrev.Cvouchertype == "0303" && apiData.Synergismlogdt.Cvouchertype == "24")
            {
                #region 销售出库单-采购入库单（采购入库单 -关联- 采购订单）
                try
                {
                    Model.U8NameValue POID;
                    POID = apiData.HeadData.Find(delegate(Model.U8NameValue temp) { return temp.U8FieldName.ToLower() == "ipurorderid"; });
                    if (POID == null) throw new Exception("获取采购订单POID失败");
                    if (string.IsNullOrEmpty(POID.U8FieldValue)) return false;

                    DbHelperSQLP dsp = new DbHelperSQLP(apiData.ConnectInfo.Constring);
                    sql = "SELECT 1 FROM PO_Podetails WHERE POID='" + POID.U8FieldValue + "' GROUP BY POID,cInvCode HAVING COUNT(1)>=2 ";
                    object obj = dsp.GetSingle(sql);
                    if (obj == null) return true;   // AS ioritaxcost
                    sql = "SELECT cinvcode,ISNULL(iQuantity,0)-ISNULL(iReceivedQTY,0) AS iquantity,ID AS iposid,iorderseq AS iorderseq,iSOsID AS iorderdid,cfree1,cfree2,cfree3,cfree4,cfree5,cfree6,cfree7,cfree8,cfree9,cfree10,cdefine22,cdefine23,cdefine24,cdefine25,cdefine26,cdefine27,cdefine28,cdefine29,cdefine30,cdefine31,cdefine32,cdefine33,cdefine34,cdefine35,cdefine36,cdefine37 FROM PO_Podetails WHERE ISNULL(iQuantity,0)-ISNULL(iReceivedQTY,0)>0 AND POID='" + POID.U8FieldValue + "' ";
                    DataSet ds = dsp.Query(sql);
                    if (ds == null || ds.Tables[0].Rows.Count <= 0) throw new Exception("获取采购订单数据失败，找不到对应采购订单或该采购订单已全部入库");

                    Dictionary<string, int> dicIndex = new Dictionary<string, int>();
                    int index;
                    List<Model.U8NameValue> lst = apiData.BodyData[0];
                    foreach (DataColumn dc in ds.Tables[0].Columns)
                    {
                        index = lst.FindIndex(delegate(Model.U8NameValue temp) { return temp.U8FieldName.ToLower() == dc.ColumnName; });
                        if (index == -1)
                        {
                            foreach (List<Model.U8NameValue> body in apiData.BodyData) body.Add(new Model.U8NameValue() { U8FieldName = dc.ColumnName });
                            index = lst.Count - 1;
                        }
                        dicIndex.Add(dc.ColumnName, index);
                    }
                    int iRow = 0;
                    foreach (List<Model.U8NameValue> body in apiData.BodyData)
                    {
                        iRow++;
                        if (string.IsNullOrEmpty(body[dicIndex["iposid"]].U8FieldValue ))
                        {
                            if (string.IsNullOrEmpty(apiData.Synergismlogdt.Cerrordesc)) apiData.Synergismlogdt.Cerrordesc = "未找到与当前采购入库单对应的采购订单行,请检查单据字段对应关系设置。";
                            string strErr = "未找到与当前采购入库单第" + iRow + "行对应的采购订单行,请检查单据字段对应关系设置。";
                            foreach (KeyValuePair<string, int> keyvalue in dicIndex) strErr += "【" + keyvalue.Key + "】：" + body[keyvalue.Value].U8FieldValue + "；";
                            Log.WriteWinLog(strErr);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("检查采购入库单表体关联数据错误，" + ex.Message);
                }

                #endregion
            }
            else if (dtPrev.Cvouchertype == "24" && apiData.Synergismlogdt.Cvouchertype == "01")
            {
                #region 采购入库单-发货单（发货单 -关联- 销售订单）

                try
                {
                    Model.U8NameValue cSOCode;
                    cSOCode = apiData.HeadData.Find(delegate(Model.U8NameValue temp) { return temp.U8FieldName.ToLower() == "csocode"; });
                    if (cSOCode == null) throw new Exception("获取销售订单cSOCode失败");
                    if (string.IsNullOrEmpty(cSOCode.U8FieldValue)) return false;

                    DbHelperSQLP dsp = new DbHelperSQLP(apiData.ConnectInfo.Constring);
                    sql = "SELECT 1 FROM SO_SODetails WHERE ID=(SELECT TOP 1 ID FROM SO_SOMain WHERE cSOCode='" + cSOCode.U8FieldValue + "') GROUP BY ID,cInvCode HAVING COUNT(1)>=2 ";
                    object obj = dsp.GetSingle(sql);
                    if (obj == null) return true;   // AS iTaxUnitPrice
                    sql = "SELECT cinvcode,ISNULL(iQuantity,0)-ISNULL(iFHQuantity,0) AS iquantity,cSoCode AS cordercode,iRowNo AS iorderrowno,isosid,csocode,cfree1,cfree2,cfree3,cfree4,cfree5,cfree6,cfree7,cfree8,cfree9,cfree10,cdefine22,cdefine23,cdefine24,cdefine25,cdefine26,cdefine27,cdefine28,cdefine29,cdefine30,cdefine31,cdefine32,cdefine33,cdefine34,cdefine35,cdefine36,cdefine37 FROM SO_SODetails WHERE ISNULL(iQuantity,0)-ISNULL(iFHQuantity,0)>0 AND ID=(SELECT TOP 1 ID FROM SO_SOMain WHERE cSOCode='" + cSOCode.U8FieldValue + "') ";
                    DataSet ds = dsp.Query(sql);
                    if (ds == null || ds.Tables[0].Rows.Count <= 0) throw new Exception("获取销售订单数据失败，找不到对应销售订单或该销售订单已全部发货");

                    Dictionary<string, int> dicIndex = new Dictionary<string, int>();
                    int index;
                    List<Model.U8NameValue> lst = apiData.BodyData[0];
                    foreach (DataColumn dc in ds.Tables[0].Columns)
                    {
                        index = lst.FindIndex(delegate(Model.U8NameValue temp) { return temp.U8FieldName.ToLower() == dc.ColumnName; });
                        if (index == -1)
                        {
                            foreach (List<Model.U8NameValue> body in apiData.BodyData) body.Add(new Model.U8NameValue() { U8FieldName = dc.ColumnName });
                            index = lst.Count - 1;
                        }
                        dicIndex.Add(dc.ColumnName, index);
                    }

                    
                    int iRow = 0;
                    foreach (List<Model.U8NameValue> body in apiData.BodyData)
                    {
                        iRow++;
                        if (string.IsNullOrEmpty(body[dicIndex["isosid"]].U8FieldValue)  || string.IsNullOrEmpty(body[dicIndex["iorderrowno"]].U8FieldValue))
                        {
                            if (string.IsNullOrEmpty(apiData.Synergismlogdt.Cerrordesc)) apiData.Synergismlogdt.Cerrordesc = "未找到与当前发货单对应的销售订单行,请检查单据字段对应关系设置。";
                            string strErr = "未找到与当前发货单第" + iRow + "行对应的销售订单行,请检查单据字段对应关系设置。";
                            foreach (KeyValuePair<string, int> keyvalue in dicIndex) strErr += "【" + keyvalue.Key + "】：" + body[keyvalue.Value].U8FieldValue + "；";
                            Log.WriteWinLog(strErr);
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("检查发货单表体关联数据错误，" + ex.Message);
                }
                #endregion
            }
            else if (dtPrev.Cvouchertype == "88" && apiData.Synergismlogdt.Cvouchertype == "88")
            {
                #region 采购订单-采购订单（采购订单 -关联- 采购请购单）

                try
                {
                    Model.U8NameValue cAppCode;
                    //cAppCode = apiData.HeadData.Find(delegate(Model.U8NameValue temp) { return temp.U8FieldName.ToLower() == "cappcode"; });
                    cAppCode = apiData.BodyData[0].Find(delegate(Model.U8NameValue temp) { return temp.U8FieldName.ToLower() == "cupsocode"; });
                    if (cAppCode == null) throw new Exception("获取采购请购单cCode失败");
                    if (string.IsNullOrEmpty(cAppCode.U8FieldValue)) return false;

                    DbHelperSQLP dsp = new DbHelperSQLP(apiData.ConnectInfo.Constring);
                    sql = "SELECT 1 FROM PU_AppVouchs WHERE ID=(SELECT TOP 1 ID FROM PU_AppVouch WHERE cCode='" + cAppCode.U8FieldValue + "') GROUP BY ID,cInvCode HAVING COUNT(1)>=2 ";
                    object obj = dsp.GetSingle(sql);
                    if (obj == null) return true;   // AS itaxprice
                    if (strVersion.StartsWith("V12")) sql = "SELECT cinvcode,ISNULL(fQuantity,0)-ISNULL(iReceivedQTY,0) AS iquantity,autoid AS iappids,ivouchrowno,cfree1,cfree2,cfree3,cfree4,cfree5,cfree6,cfree7,cfree8,cfree9,cfree10,cdefine22,cdefine23,cdefine24,cdefine25,cdefine26,cdefine27,cdefine28,cdefine29,cdefine30,cdefine31,cdefine32,cdefine33,cdefine34,cdefine35,cdefine36,cdefine37 FROM PU_AppVouchs WHERE ISNULL(fQuantity,0)-ISNULL(iReceivedQTY,0)>0 AND ID=(SELECT TOP 1 ID FROM PU_AppVouch WHERE cCode='" + cAppCode.U8FieldValue + "') ";
                    else if (strVersion.StartsWith("V11")) sql = "SELECT cinvcode,ISNULL(fQuantity,0)-ISNULL(iReceivedQTY,0) AS iquantity,autoid AS iappids,cfree1,cfree2,cfree3,cfree4,cfree5,cfree6,cfree7,cfree8,cfree9,cfree10,cdefine22,cdefine23,cdefine24,cdefine25,cdefine26,cdefine27,cdefine28,cdefine29,cdefine30,cdefine31,cdefine32,cdefine33,cdefine34,cdefine35,cdefine36,cdefine37 FROM PU_AppVouchs WHERE ISNULL(fQuantity,0)-ISNULL(iReceivedQTY,0)>0 AND ID=(SELECT TOP 1 ID FROM PU_AppVouch WHERE cCode='" + cAppCode.U8FieldValue + "') ";
                    DataSet ds = dsp.Query(sql);
                    if (ds == null || ds.Tables[0].Rows.Count <= 0) throw new Exception("获取采购请购单数据失败，找不到对应采购请购单或该采购请购单已全部采购");

                    Dictionary<string, int> dicIndex = new Dictionary<string, int>();
                    int index;
                    List<Model.U8NameValue> lst = apiData.BodyData[0];
                    foreach (DataColumn dc in ds.Tables[0].Columns)
                    {
                        index = lst.FindIndex(delegate(Model.U8NameValue temp) { return temp.U8FieldName.ToLower() == dc.ColumnName; });
                        if (index == -1)
                        {
                            foreach (List<Model.U8NameValue> body in apiData.BodyData) body.Add(new Model.U8NameValue() { U8FieldName = dc.ColumnName });
                            index = lst.Count - 1;
                        }
                        dicIndex.Add(dc.ColumnName, index);
                    }

                    int iRow = 0;
                    foreach (List<Model.U8NameValue> body in apiData.BodyData)
                    {
                        iRow++;
                        if (string.IsNullOrEmpty(body[dicIndex["iappids"]].U8FieldValue))
                        {
                            if (strVersion.StartsWith("V12")) body[dicIndex["ivouchrowno"]].U8FieldValue = "";
                            if (string.IsNullOrEmpty(apiData.Synergismlogdt.Cerrordesc)) apiData.Synergismlogdt.Cerrordesc = "未找到与当前采购订单对应的采购请购单行,请检查单据字段对应关系设置。";
                            string strErr = "未找到与当前采购订单第" + iRow + "行对应的采购请购单行,请检查单据字段对应关系设置。";
                            foreach (KeyValuePair<string, int> keyvalue in dicIndex) strErr += "【" + keyvalue.Key + "】：" + body[keyvalue.Value].U8FieldValue + "；";
                            Log.WriteWinLog(strErr);
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("检查采购订单表体关联数据错误，" + ex.Message);
                }
                #endregion
            }
            else if (dtPrev.Cvouchertype == "24" && apiData.Synergismlogdt.Cvouchertype == "24")
            {
                #region 采购入库单-采购入库单（采购入库单 -关联- 采购订单）
                try
                {
                    Model.U8NameValue cPOID;
                    cPOID = apiData.HeadData.Find(delegate(Model.U8NameValue temp) { return temp.U8FieldName.ToLower() == "cordercode"; });
                    if (cPOID == null) throw new Exception("获取采购订单cPOID失败");
                    if (string.IsNullOrEmpty(cPOID.U8FieldValue)) return false;

                    DbHelperSQLP dsp = new DbHelperSQLP(apiData.ConnectInfo.Constring);
                    sql = "SELECT 1 FROM PO_Podetails WHERE POID=(SELECT TOP 1 POID FROM PO_POMain WHERE cPOID='" + cPOID.U8FieldValue + "') GROUP BY POID,cInvCode HAVING COUNT(1)>=2 ";
                    object obj = dsp.GetSingle(sql);
                    if (obj == null) return true;   // AS ioritaxcost
                    sql = "SELECT cinvcode,ISNULL(iQuantity,0)-ISNULL(iReceivedQTY,0) AS iquantity,ID AS iposid,cfree1,cfree2,cfree3,cfree4,cfree5,cfree6,cfree7,cfree8,cfree9,cfree10,cdefine22,cdefine23,cdefine24,cdefine25,cdefine26,cdefine27,cdefine28,cdefine29,cdefine30,cdefine31,cdefine32,cdefine33,cdefine34,cdefine35,cdefine36,cdefine37 FROM PO_Podetails WHERE ISNULL(iQuantity,0)-ISNULL(iReceivedQTY,0)>0 AND POID=(SELECT TOP 1 POID FROM PO_POMain WHERE cPOID='" + cPOID.U8FieldValue + "') ";
                    DataSet ds = dsp.Query(sql);
                    if (ds == null || ds.Tables[0].Rows.Count <= 0) throw new Exception("获取采购订单数据失败，找不到对应采购订单或该采购订单已全部入库");

                    Dictionary<string, int> dicIndex = new Dictionary<string, int>();
                    int index;
                    List<Model.U8NameValue> lst = apiData.BodyData[0];
                    foreach (DataColumn dc in ds.Tables[0].Columns)
                    {
                        index = lst.FindIndex(delegate(Model.U8NameValue temp) { return temp.U8FieldName.ToLower() == dc.ColumnName; });
                        if (index == -1)
                        {
                            foreach (List<Model.U8NameValue> body in apiData.BodyData) body.Add(new Model.U8NameValue() { U8FieldName = dc.ColumnName });
                            index = lst.Count - 1;
                        }
                        dicIndex.Add(dc.ColumnName, index);
                    }
                    int iRow = 0;
                    foreach (List<Model.U8NameValue> body in apiData.BodyData)
                    {
                        iRow++;
                        if (string.IsNullOrEmpty(body[dicIndex["iposid"]].U8FieldValue))
                        {
                            if (string.IsNullOrEmpty(apiData.Synergismlogdt.Cerrordesc)) apiData.Synergismlogdt.Cerrordesc = "未找到与当前采购入库单对应的采购订单行,请检查单据字段对应关系设置。";
                            string strErr = "未找到与当前采购入库单第" + iRow + "行对应的采购订单行,请检查单据字段对应关系设置。";
                            foreach (KeyValuePair<string, int> keyvalue in dicIndex) strErr += "【" + keyvalue.Key + "】：" + body[keyvalue.Value].U8FieldValue + "；";
                            Log.WriteWinLog(strErr);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("关联采购入库单表体关联数据错误，" + ex.Message);
                }

                #endregion
            }

            return true;
        }
         

 
        /// <summary>
        /// 追加存货自定义项筛选条件
        /// </summary>
        /// <param name="drs"></param>
        /// <param name="bodydata"></param>
        /// <param name="fv"></param>
        /// <returns></returns>
        private static string GetInvWhere(System.Data.DataRow drs, List<Model.U8NameValue> bodydata, Model.Fixvalue fv)
        {
            if (drs == null) return drs[fv.Cfunparareturn].ToString();
            if (bodydata == null || bodydata.Count <= 0) return drs[fv.Cfunparareturn].ToString();
            if (fv == null) return drs[fv.Cfunparareturn].ToString();

            StringBuilder cfreeWhere = new StringBuilder();
            StringBuilder cdefineWhere = new StringBuilder();
            StringBuilder cbatchWhere = new StringBuilder();

            Model.U8NameValue u8nv = null;

            string cfree = "cfree";
            for (int i = 1; i <= 10; i++)
            {
                cfree = "cfree" + i.ToString();
                u8nv = bodydata.Find(delegate(Model.U8NameValue temp) { return temp.U8FieldName.ToLower() == cfree; });
                if (u8nv != null)
                {
                    if (string.IsNullOrEmpty(u8nv.U8FieldValue)) //continue;
                        cfreeWhere.Append(string.Format(" AND ISNULL(b.{0},'')='{1}'", cfree, ""));
                    else
                        cfreeWhere.Append(string.Format(" AND ISNULL(b.{0},'')='{1}'", cfree, u8nv.U8FieldValue));
                }
                else
                {
                    //if (readerExists(drs, cfree))
                    //    cfreeWhere.Append(string.Format(" AND (ISNULL(b.{0},'')='{1}'", cfree, drs[cfree]));
                }
            }

            string cdefine = "cdefine";
            for (int i = 22; i <= 37; i++)
            {
                cdefine = "cdefine" + i.ToString();
                u8nv = bodydata.Find(delegate(Model.U8NameValue temp) { return temp.U8FieldName.ToLower() == cdefine; });
                if (u8nv != null)
                {
                    if (string.IsNullOrEmpty(u8nv.U8FieldValue)) //continue;
                        cdefineWhere.Append(string.Format(" AND ISNULL(b.{0},'')='{1}'", cdefine, ""));
                    else
                        cdefineWhere.Append(string.Format(" AND ISNULL(b.{0},'')='{1}'", cdefine, u8nv.U8FieldValue));
                }
                else
                {
                    //if (readerExists(drs, cdefine))
                    //    cdefineWhere.Append(string.Format(" AND (ISNULL(b.{0},'')='{1}'", cdefine, drs[cdefine]));
                }
            }

            string cbatch = "cbatch";
            u8nv = bodydata.Find(delegate(Model.U8NameValue temp) { return temp.U8FieldName.ToLower() == cbatch; });
            if (u8nv != null)
            {
                if (string.IsNullOrEmpty(u8nv.U8FieldValue)) //continue;
                    cbatchWhere.Append(string.Format(" AND ISNULL(b.{0},'')='{1}'", cbatch, ""));
                else
                    cbatchWhere.Append(string.Format(" AND ISNULL(b.{0},'')='{1}'", cbatch, u8nv.U8FieldValue));
            }
            else
            {
                if (readerExists(drs, cbatch))
                    cbatchWhere.Append(string.Format(" AND (ISNULL(b.{0},'')='{1}'", cbatch, drs[cbatch]));
            }

            return string.Format("{0};{1};{2};{3}", drs[fv.Cfunparareturn].ToString(), cfreeWhere.ToString(), cdefineWhere.ToString(), cbatchWhere.ToString());
            //string.Format(" AND (ISNULL(b.cfree1,'')='{0}' AND ISNULL(b.cfree2,'')='{1}' AND ISNULL(b.cfree3,'')='{2}' AND ISNULL(b.cfree4,'')='{3}' AND ISNULL(b.cfree5,'')='{4}' AND ISNULL(b.cfree6,'')='{5}' AND ISNULL(b.cfree7,'')='{6}' AND ISNULL(b.cfree8,'')='{7}' AND ISNULL(b.cfree9,'')='{8}' AND ISNULL(b.cfree10,'')='{9}' AND ISNULL(b.cdefine22,'')='{10}' AND ISNULL(b.cdefine23,'')='{11}' AND ISNULL(b.cdefine24,'')='{12}' AND ISNULL(b.cdefine25,'')='{13}' AND ISNULL(b.cdefine26,'')='{14}' AND ISNULL(b.cdefine27,'')='{15}' AND ISNULL(b.cdefine28,'')='{16}' AND ISNULL(b.cdefine29,'')='{17}' AND ISNULL(b.cdefine30,'')='{18}' AND ISNULL(b.cdefine31,'')='{19}' AND ISNULL(b.cdefine32,'')='{20}' AND ISNULL(b.cdefine33,'')='{21}' AND ISNULL(b.cdefine34,'')='{22}' AND ISNULL(b.cdefine35,'')='{23}' AND ISNULL(b.cdefine36,'')='{24}' AND ISNULL(b.cdefine37,'')='{25}')", drs["cfree1"], drs["cfree2"], drs["cfree3"], drs["cfree4"], drs["cfree5"], drs["cfree6"], drs["cfree7"], drs["cfree8"], drs["cfree9"], drs["cfree10"], drs["cdefine22"], drs["cdefine23"], drs["cdefine24"], drs["cdefine25"], drs["cdefine26"], drs["cdefine27"], drs["cdefine28"], drs["cdefine29"], drs["cdefine30"], drs["cdefine31"], drs["cdefine32"], drs["cdefine33"], drs["cdefine34"], drs["cdefine35"], drs["cdefine36"], drs["cdefine37"])
        }


        /// <summary>
        /// 获取公共变量的值
        /// </summary>
        /// <param name="apidata"></param>
        /// <param name="p">参数值取值字段</param>
        /// <param name="rowno">来源单据行号</param>
        /// <returns></returns>
        private static string GetComonValue(Model.APIData apidata, string p, int rowno, string sfunname)
        {
            //保留字.公共变量.来源单据账套ID
            DAL.Regist registdal = new Regist();
            if (p == "s_accid")
            {
                DAL.SynergismLogDt dals = new SynergismLogDt();
                Model.Synergismlogdt pdt = dals.GetPrevious(apidata.Synergismlogdt);
                Model.Regist regist = registdal.GetModel(pdt.Accid);
                BLL.Common.ErrorMsg(regist, "未能取到保留字.公共变量.来源单据账套ID的值");
                //增加函数判断,因为GetValueByAccVouchnoItemname需要的账套的单据号，而不是id
                //wangdd1 2015-05-14
                if (sfunname != "GetValueByAccVouchnoItemname")
                {
                    return regist.Accid;
                }
                else
                {
                    return regist.Acccode;
                }
            }

            //保留字.公共变量.目标单据账套ID
            if (p == "d_accid")
            {
                Model.Regist regist = registdal.GetModel(apidata.Synergismlogdt.Accid);
                BLL.Common.ErrorMsg(regist, "未能取到保留字.公共变量.目标单据账套ID的值");
                //增加函数判断,因为GetValueByAccVouchnoItemname需要的账套的单据号，而不是id
                //wangdd1 2015-05-14
                if (sfunname != "GetValueByAccVouchnoItemname")
                {
                    return regist.Accid;
                }
                else
                {
                    return regist.Acccode;
                }
            }

            //保留字.公共变量.当前路线号
            if (p == "c_routeid")
            {
                return apidata.Synergismlogdt.Id.ToString();
            }

            //保留字.公共变量.当前行号
            if (p == "c_row")
            {
                return rowno.ToString();
            }

            return null;

        }


        #endregion


        /// <summary>
        /// 状态运算
        /// </summary>
        /// <param name="Status1"></param>
        /// <param name="Status2"></param>
        /// <returns></returns>
        public static string SetLogStatus(string Status1, string Status2)
        {

            if (Status1 == Constant.SynerginsLog_Cstatus_Error || Status2 == Constant.SynerginsLog_Cstatus_Error)
                return Constant.SynerginsLog_Cstatus_Error;

            if (Status1 == Constant.SynerginsLog_Cstatus_Wait || Status2 == Constant.SynerginsLog_Cstatus_Wait)
                return Constant.SynerginsLog_Cstatus_Wait;


            if (Status1 == Constant.SynerginsLog_Cstatus_Complete || Status2 == Constant.SynerginsLog_Cstatus_Complete)
                return Constant.SynerginsLog_Cstatus_Complete;


            return "";

        }


        /// <summary>
        /// 根据名称获取u8namevalue
        /// </summary>
        /// <param name="list"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Model.U8NameValue U8NameValueFind(List<Model.U8NameValue> list, string name)
        {
            Model.U8NameValue uv = list.FindLast(delegate(Model.U8NameValue nv)
            {
                return nv.U8FieldName.ToLower() == name.ToLower();

            });

            //  DAL.Common.ErrorMsg(uv, string.Format("未能根据名称{0}获取字段值",name));
            return uv;

        }




        /// <summary>
        /// 判断是否在范围内
        /// </summary>
        /// <param name="billName"></param>
        /// <returns></returns>
        public static bool IsVoucher(string billName)
        {

            List<Model.U8NameValue> lst = new List<Model.U8NameValue>();
            lst.Add(new Model.U8NameValue() { U8FieldName = "全部", U8FieldValue = "全部" });
            string cmdText = "SELECT 1 FROM HY_DZ_K7_BILLSCOPE where cbillname = '" + billName + "'";
            DataSet ds = DbHelperSQL.Query(cmdText);
            if (ds == null || ds.Tables[0].Rows.Count <= 0) return false;
            return true;
        }



        /// <summary>
        /// 更新协同路线
        /// </summary>
        /// <param name="constring"></param>
        public static void UpdateTeamworkField(string routename, string tablename, string id, string constring)
        {

            string idfield = "id";
            switch (tablename.ToLower())
            {
                case "dispatchlist_extradefine":
                    idfield = "dlid";

                    break;
                case "po_pomain_extradefine":
                    idfield = "poid";
                    break;
            }
            string field = GetTeamworkField(constring);
            DbHelperSQLP sql = new DbHelperSQLP(constring);
            bool tabexits = sql.TabExists(tablename);
            if (!tabexits) return;
            string cmdtext = string.Format("select 1  from {0} with(nolock) where {2}='{1}'", tablename, id, idfield);
            string ret = sql.GetSingle(cmdtext).NullToString();
            if (string.IsNullOrEmpty(ret))
            {
                //insert
                cmdtext = string.Format("insert into {0}   ({4},{1} )  values('{2}','{3}')", tablename, field, id, routename, idfield);
            }
            else
            {
                //update
                cmdtext = string.Format("update {0}   set {1}='{2}' where {4}='{3}'", tablename, field, routename, id, idfield);
            }

            sql.ExecuteSql(cmdtext);



        }


        /// <summary>
        /// 获取协同路线字段名称
        /// </summary>
        /// <returns></returns>
        public static string GetTeamworkField(string constring)
        {
            string cmdText = "select cDicDbName  from userdef  with(nolock) where cItemName = '协同路线' and cClass = '单据头' and ISNULL(cDicDbName,'')<>''";
            DbHelperSQLP sql = new DbHelperSQLP(constring);
            string ret = sql.GetSingle(cmdText).NullToString();
            BLL.Common.ErrorMsg(ret, "未能获取协同路线字段名称");
            return ret;
        }



          
    }
}