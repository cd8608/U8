using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data; 
using MSXML2;



namespace U8.Interface.Bus.Event.SyncAdapter.Biz.Factory.CQ
{
    public class GroupVouch : U8.Interface.Bus.Event.SyncAdapter.Biz.BizBase
    {

        private string _ccode;
        GroupVouchs detailBiz;

        public GroupVouch(ref ADODB.Connection conn, IXMLDOMDocument2 doc, IXMLDOMDocument2 docbody, string ufConnStr, string _opertype)
            : base(conn, ufConnStr)
        {

            oracleTableName = "MES_CQ_GroupVouch";   //目标表名
            oraclePriKey = "ccode";      //目标表逻辑主键 
            fieldcmpTablename = "MES_CQ_GroupVouch";
            ufTableName = "GroupVouch"; // "SaleOrderQ";       //来源表名
            ufPriKey = "ccode";          //来源表主键
            this._ccode = ((IXMLDOMElement)doc.selectSingleNode("/xml/rs:data/z:row")).getAttribute("ccode").ToString(); //GetNodeValue(doc, "/GroupVouch/ccode");
            this.opertype = _opertype; 
        }



        #region 赋值操作

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="doc"></param>
        private void SetData(string ccode)
        { 
            detailBiz = new GroupVouchs(ref conn, ccode, ufConnStr, opertype);
            detailBiz.lst = detailBiz.MakeMultiLineData(null, detailBiz.fieldcmpTablename, detailBiz.ufTableName, detailBiz.ufPriKey, ccode);
            
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
            string _tempsourcetable = "(select ccode,cCusCode,cCusName, cBusType,t.cstcode as cStCode,cStName,t.cDepCode as cDepCode,cDepName,";
            _tempsourcetable += " cPersonCode,p.cPsn_Name as cPersonName   from GroupVouch t with(nolock) left join department d with(nolock) on t.cDepCode = d.cDepCode ";
            _tempsourcetable += " left join hr_hi_person p with(nolock) on t.cPersonCode = p.cPsn_Num ";
            _tempsourcetable += " left join SaleType st with(nolock) on st.cSTCode = t.cSTCode ) tmpt ";

            string sql = "SELECT " + colNames + " FROM " + _tempsourcetable + "  WHERE ccode ='" + _ccode + "' ";
            DataTable dtValue = new DataTable();
            dtValue = UFSelect(sql);
            return dtValue;
        }



        public override object Insert()
        {
            SetData(_ccode); 
            StringBuilder sb = new StringBuilder(); 
            sb.Append(detailBiz.CreateInsertString()); 

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
        /// 真正操作为新增删除操作
        /// </summary>
        /// <returns></returns>
        public override object Delete()
        {
            StringBuilder sb = new StringBuilder();
            SetData(_ccode); 
            sb.Append(detailBiz.CreateDeleteString());
            if (sb.Length > 0)
            {
                return ExecSql(sb.ToString());
            }
            return null;
        }


        /// <summary>
        /// 删除中间表数据
        /// </summary>
        /// <returns></returns>
        private object DeleteLog()
        {
            StringBuilder sb = new StringBuilder();
            if (detailBiz.lst.Count == 0)
            {
                SetData(_ccode);
            } 
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
