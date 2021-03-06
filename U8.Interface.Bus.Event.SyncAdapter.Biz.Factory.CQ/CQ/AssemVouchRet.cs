﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data; 
using MSXML2;



namespace U8.Interface.Bus.Event.SyncAdapter.Biz.Factory.CQ
{

    /// <summary>
    /// 组装单
    /// </summary>
    public class AssemVouchRet : U8.Interface.Bus.Event.SyncAdapter.Biz.BizBase
    {

        private string _cAVCode; 
        AssemVouchRets detailBiz;

        public AssemVouchRet(ref ADODB.Connection conn, IXMLDOMDocument2 doc, IXMLDOMDocument2 docbody, string ufConnStr, string _opertype)
            : base(conn, ufConnStr)
        {

            oracleTableName = "MES_CQ_AssemVouchRet";   //目标表名
            oraclePriKey = "cAVCode";      //目标表逻辑主键 
            fieldcmpTablename = "MES_CQ_AssemVouchRet";
            ufTableName = "AssemVouch"; // "SaleOrderQ";       //来源表名
            ufPriKey = "cAVCode";          //来源表主键
            this._cAVCode = ((IXMLDOMElement)doc.selectSingleNode("/xml/rs:data/z:row")).getAttribute("cavcode").ToString(); //GetNodeValue(doc, "/so_somain/cAVCode");
            this.opertype = _opertype; 
        }



        #region 赋值操作

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="doc"></param>
        private void SetData(string cAVCode)
        {
            lst = MakeMultiLineData(null, fieldcmpTablename, ufTableName, ufPriKey, cAVCode);
            detailBiz = new AssemVouchRets(ref conn, cAVCode, ufConnStr, opertype);
            detailBiz.lst = detailBiz.MakeMultiLineData(null, detailBiz.fieldcmpTablename, detailBiz.ufTableName, detailBiz.ufPriKey, cAVCode);
            
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
            string _tempsourcetable = "(select cAVCode,dAVDate,cIRdCode,cDepCode,cORdCode,";
            _tempsourcetable += "cDepCode as cODepCode from  AssemVouch with(nolock) ) tmpt ";

            string sql = "SELECT " + colNames + " FROM " + ufTableName + "  WHERE cVouchType = '14' AND cAVCode ='" + _cAVCode + "' ";
            DataTable dtValue = new DataTable();
            dtValue = UFSelect(sql);
            return dtValue;
        }



        public override object Insert()
        {
            SetData(_cAVCode);

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
                SetData(_cAVCode);

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
                SetData(_cAVCode);
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
