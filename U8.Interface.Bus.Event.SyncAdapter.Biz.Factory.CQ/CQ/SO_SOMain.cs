using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data; 
using MSXML2;



namespace U8.Interface.Bus.Event.SyncAdapter.Biz.Factory.CQ
{
    public class SO_SOMain : U8.Interface.Bus.Event.SyncAdapter.Biz.BizBase
    {

        private string _csocode; 
        SO_SODetails detailBiz;  

        public SO_SOMain( ref ADODB.Connection conn, IXMLDOMDocument2 doc, IXMLDOMDocument2 docbody, string ufConnStr, string _opertype)
            : base(conn, ufConnStr)
        {

            oracleTableName = "MES_CQ_SO_SOMain";   //目标表名
            oraclePriKey = "cSoCode";      //目标表逻辑主键 
            fieldcmpTablename = "MES_CQ_SO_SOMain";
            ufTableName = "SO_SOMain"; // "SaleOrderQ";       //来源表名
            ufPriKey = "cSoCode";          //来源表主键
            this._csocode = ((IXMLDOMElement)doc.selectSingleNode("/xml/rs:data/z:row")).getAttribute("csocode").ToString(); //GetNodeValue(doc, "/so_somain/csocode");
            this.opertype = _opertype; 
        }



        #region 赋值操作

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="doc"></param>
        private void SetData(string csocode)
        {
            lst = MakeMultiLineData(null, fieldcmpTablename, ufTableName, ufPriKey, csocode);
            detailBiz = new SO_SODetails(ref conn, csocode, ufConnStr, opertype);
            detailBiz.lst = detailBiz.MakeMultiLineData(null, detailBiz.fieldcmpTablename, detailBiz.ufTableName, detailBiz.ufPriKey, csocode);
            
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
            string _tempsourcetable = "(select cSoCode,cCusCode,cCusName, cBusType,t.cstcode as cStCode,cStName,t.cDepCode as cDepCode,cDepName,";
            _tempsourcetable += " cPersonCode,p.cPsn_Name as cPersonName   from so_somain t with(nolock) left join department d with(nolock) on t.cDepCode = d.cDepCode ";
            _tempsourcetable += " left join hr_hi_person p with(nolock) on t.cPersonCode = p.cPsn_Num ";
            _tempsourcetable += " left join SaleType st with(nolock) on st.cSTCode = t.cSTCode ) tmpt ";

            string sql = "SELECT " + colNames + " FROM " + _tempsourcetable + "  WHERE csocode ='" + _csocode + "' ";
            DataTable dtValue = new DataTable();
            dtValue = UFSelect(sql);
            return dtValue;
        }



        public override object Insert()
        {
            SetData(_csocode);

            StringBuilder sb = new StringBuilder();
            StringBuilder sbm = new StringBuilder();
            sbm = this.CreateInsertString();
            if (sbm.Length > 0)
            {
                sb.Append(" DECLARE @mainid AS INT ");
                sb.Append(sbm); 
                sb.Append(" SELECT @mainid = @@IDENTITY ");
                sb.Append(detailBiz.CreateInsertString());
                sb.Replace("main|##newguid", Guid.NewGuid().ToString());
            
            } 

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
                StringBuilder sb = new StringBuilder();
                SetData(_csocode);

                sb.Append(this.CreateDeleteString());
                sb.Append(detailBiz.CreateDeleteString());
                if (sb.Length > 0)
                {
                    return ExecSql(sb.ToString());
                }
                return null;
            }
        }


        /// <summary>
        /// 删除中间表数据
        /// </summary>
        /// <returns></returns>
        private object DeleteLog()
        {
            StringBuilder sb = new StringBuilder();
            if (lst.Count == 0)
            {
                SetData(_csocode);
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
