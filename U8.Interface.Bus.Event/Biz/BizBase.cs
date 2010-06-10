using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MSXML2;
using U8.Interface.Bus.DBUtility;


namespace U8.Interface.Bus.Event.SyncAdapter.Biz
{
    public abstract class BizBase
    {

        public string Synch = "UFOper";  //操作类选择

        /// <summary>
        /// 操作类型
        /// </summary>
        public string opertype = "a"; //操作类型  a新增 d删除 m修改

        /// <summary>
        /// 来源表名
        /// </summary>
        public string ufTableName;       //来源表名
        /// <summary>
        /// 来源表主键
        /// </summary>
        public string ufPriKey;          //来源表主键名
        /// <summary>
        /// 来源表主键值
        /// </summary>
        public string ufPriValue;        //来源数据主键值
        /// <summary>
        /// 来源数据库连接字符串
        /// </summary>
        public string ufConnStr;         //来源库连接字符串

        /// <summary>
        /// 字段配置表
        /// </summary>
        DataTable dtField; //字段对照预置信息 
        public string fieldcmpTablename; //字段对照表tablename

        /// <summary>
        /// 目标数据库连接字符串
        /// </summary>
        public string oraConnStr = "ORASVR";  //链接数据库名称
        /// <summary>
        /// 目标数据库link名称
        /// </summary>
        public static string oraLinkName = null;
        /// <summary>
        /// 目标表名称
        /// </summary>
        public string oracleTableName;   //目标表名
        /// <summary>
        /// 目标表主键
        /// </summary>
        public string oraclePriKey;      //目标表主键


        /// <summary>
        /// 不记录过程,只保留最后的数据
        /// </summary>
        protected bool bNoCase = U8.Interface.Bus.Config.ConfigUtility.LogNoCase;   //只保存最终状态数据,不记录增删改过程

        /// <summary>
        /// 保留操作
        /// 例如删除时，不是删除档案，而是插入删除操作
        /// </summary>
        protected bool bSaveOper = U8.Interface.Bus.Config.ConfigUtility.LogOper;   //只保存最终状态数据,不记录增删改过程


        /// <summary>
        /// 字段
        /// </summary>
        public List<BaseMode> l = new List<BaseMode>();   //操作实体(一行数据)
        /// <summary>
        /// 行数据
        /// </summary>
        public List<List<BaseMode>> lst = new List<List<BaseMode>>(); //多行数据


        protected ADODB.Connection conn;
        public ISqlOper sqlOper;


        UfDBUtility uf = new UfDBUtility();

        public BizBase(ADODB.Connection conn, string ufConnStr)
        {
            this.conn = conn;
            this.ufConnStr = ufConnStr;
            SetLinkName();
        }

        private void SetLinkName()
        {
            //oraLinkName = "ORASVR";
            //if (string.IsNullOrEmpty(oraLinkName))
            //{
            //    try
            //    {
            //        oraLinkName = uf.UFSelect(ufConnStr, "  select cValue from AccInformation where cName= 'DBLinkName' and cSysID= 'TR' ").Rows[0][0].ToString();
            //    }
            //    catch
            //    {
            //        throw new System.Exception("没有在配制表中设置DBLink名称!");
            //    }
            //}

        }
 


        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable UFSelect(string sql)
        {
            return uf.UFSelect(ufConnStr, sql);
        }


        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual object Select()
        {
            if (Synch.Equals("UFOper"))
            {
                sqlOper = new UFOper(oraLinkName, ufConnStr, ufTableName, ufPriKey, oracleTableName, oraclePriKey, l, lst);
                return sqlOper.Select();
            }
            else if (Synch.Equals("LinkOper"))
            {
                sqlOper = new LinkOper(oraLinkName, ufConnStr, ufTableName, ufPriKey, oracleTableName, oraclePriKey, l, lst);
                return sqlOper.Select();
            }
            else
            {
                sqlOper = new OracleOper(oraConnStr, oracleTableName, oraclePriKey, l, lst);
                return sqlOper.Select();
            }
        }

        #region 插入 
        /// <summary>
        /// 插入
        /// </summary>
        /// <returns></returns>
        public virtual object Insert()
        {
            if (Synch.Equals("UFOper"))
            {
                sqlOper = new UFOper(oraLinkName, ufConnStr, ufTableName, ufPriKey, oracleTableName, oraclePriKey, l, lst);
                if (bNoCase)
                {
                    sqlOper.Delete();  //清除旧记录
                }
                return sqlOper.Insert();
            }
            else if (Synch.Equals("LinkOper"))
            {
                sqlOper = new LinkOper(oraLinkName, ufConnStr, ufTableName, ufPriKey, oracleTableName, oraclePriKey, l, lst);
                return sqlOper.Insert();
            }
            else
            {
                sqlOper = new OracleOper(oraConnStr, oracleTableName, oraclePriKey, l, lst);
                return sqlOper.Insert();
            }
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <returns></returns>
        public virtual object BatchInsert()
        {
            if (Synch.Equals("UFOper"))
            {
                sqlOper = new UFOper(oraLinkName, ufConnStr, ufTableName, ufPriKey, oracleTableName, oraclePriKey, l, lst);
                if (bNoCase)
                {
                    sqlOper.Delete();  //清除旧记录
                }
                return sqlOper.BatchInsert();
            }
            else if (Synch.Equals("LinkOper"))
            {
                sqlOper = new LinkOper(oraLinkName, ufConnStr, ufTableName, ufPriKey, oracleTableName, oraclePriKey, l, lst);
                return sqlOper.BatchInsert();
            }
            else
            {
                sqlOper = new OracleOper(oraConnStr, oracleTableName, oraclePriKey, l, lst);
                return sqlOper.BatchInsert();
            }
        }

        /// <summary>
        /// 组织批量插入SQL语句
        /// </summary>
        /// <returns></returns>
        public virtual StringBuilder CreateInsertString()
        {
            if (Synch.Equals("UFOper"))
            {
                sqlOper = new UFOper(oraLinkName, ufConnStr, ufTableName, ufPriKey, oracleTableName, oraclePriKey, l, lst);
                return sqlOper.CreateInsertString();
            }
            else if (Synch.Equals("LinkOper"))
            {
                sqlOper = new LinkOper(oraLinkName, ufConnStr, ufTableName, ufPriKey, oracleTableName, oraclePriKey, l, lst);
                return sqlOper.CreateInsertString();
            }
            else
            {
                sqlOper = new OracleOper(oraConnStr, oracleTableName, oraclePriKey, l, lst);
                return sqlOper.CreateInsertString();
            }
        }


        #endregion

        #region 删除

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public virtual object Delete()
        {
            if (Synch.Equals("UFOper"))
            {
                sqlOper = new UFOper(oraLinkName, ufConnStr, ufTableName, ufPriKey, oracleTableName, oraclePriKey, l, lst);
                if (bNoCase)
                {
                    sqlOper.Delete();  //清除旧记录
                }
                if (bSaveOper)
                {
                    return sqlOper.Insert();
                }
                else
                {
                    return 1;
                }
            }
            else if (Synch.Equals("LinkOper"))
            {
                sqlOper = new LinkOper(oraLinkName, ufConnStr, ufTableName, ufPriKey, oracleTableName, oraclePriKey, l, lst);
                return sqlOper.Delete();
            }
            else
            {
                sqlOper = new OracleOper(oraConnStr, oracleTableName, oraclePriKey, l, lst);
                return sqlOper.Delete();
            }
        }

        /// <summary>
        /// 组织批量删除SQL语句
        /// </summary>
        /// <returns></returns>
        public virtual StringBuilder CreateDeleteString()
        {
            if (Synch.Equals("UFOper"))
            {
                sqlOper = new UFOper(oraLinkName, ufConnStr, ufTableName, ufPriKey, oracleTableName, oraclePriKey, l, lst);
                return sqlOper.CreateDeleteString();
            }
            else if (Synch.Equals("LinkOper"))
            {
                sqlOper = new LinkOper(oraLinkName, ufConnStr, ufTableName, ufPriKey, oracleTableName, oraclePriKey, l, lst);
                return sqlOper.CreateDeleteString();
            }
            else
            {
                sqlOper = new OracleOper(oraConnStr, oracleTableName, oraclePriKey, l, lst);
                return sqlOper.CreateDeleteString();
            }
        }
        #endregion


        public virtual object ExecSql(string sql)
        { 
             if (Synch.Equals("UFOper"))
            {
                sqlOper = new UFOper(oraLinkName, ufConnStr, ufTableName, ufPriKey, oracleTableName, oraclePriKey, l, lst);
                return sqlOper.ExecSql(sql);
            }
            else if (Synch.Equals("LinkOper"))
            {
                sqlOper = new LinkOper(oraLinkName, ufConnStr, ufTableName, ufPriKey, oracleTableName, oraclePriKey, l, lst);
                return sqlOper.ExecSql(sql);
            }
            else
            {
                sqlOper = new OracleOper(oraConnStr, oracleTableName, oraclePriKey, l, lst);
                return sqlOper.ExecSql(sql);
            }
             
        }




        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public virtual object Update()
        {
            if (Synch.Equals("UFOper"))
            {
                sqlOper = new UFOper(oraLinkName, ufConnStr, ufTableName, ufPriKey, oracleTableName, oraclePriKey, l, lst);
                if (bNoCase)
                {
                    sqlOper.Delete();  //清除旧记录
                } 
                return sqlOper.Insert();
            }
            else if (Synch.Equals("LinkOper"))
            {
                sqlOper = new LinkOper(oraLinkName, ufConnStr, ufTableName, ufPriKey, oracleTableName, oraclePriKey, l, lst);
                return sqlOper.Update();
            }
            else
            {
                sqlOper = new OracleOper(oraConnStr, oracleTableName, oraclePriKey, l, lst);
                return sqlOper.Update();
            }
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public virtual StringBuilder CreateUpdateSql()
        {
            if (Synch.Equals("UFOper"))
            {
                sqlOper = new UFOper(oraLinkName, ufConnStr, ufTableName, ufPriKey, oracleTableName, oraclePriKey, l, lst);
                return sqlOper.CreateUpdateSql();
            }
            else if (Synch.Equals("LinkOper"))
            {
                sqlOper = new LinkOper(oraLinkName, ufConnStr, ufTableName, ufPriKey, oracleTableName, oraclePriKey, l, lst);
                throw new NotImplementedException();
            }
            else
            {
                sqlOper = new OracleOper(oraConnStr, oracleTableName, oraclePriKey, l, lst);
                throw new NotImplementedException();
            }
        }



        public virtual object Save()
        {
            return null;
        }


        /// <summary>
        /// 并户
        /// </summary>
        /// <returns></returns>
        public virtual object LinkMerge(IXMLDOMDocument2 doc)
        {
            throw new NotImplementedException();
        }

        #region 档案 组织数据 

        /// <summary>
        /// 获取dom结点值
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="nodeName">/inventory/cinvcode</param>
        /// <returns></returns>
        protected string GetNodeValue(IXMLDOMDocument2 doc, string nodeName)
        {
            try
            {
                return doc.selectSingleNode(nodeName).text;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 获取元素中的属性值
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="nodeName">/inventory/cinvcode</param>
        /// <returns></returns>
        protected string GetNodeAttrib(IXMLDOMElement doc, string attrName)
        {
            try
            {
                return doc.getAttribute(attrName).ToString();
            }
            catch
            {
                return "";
            }
        }


        /// <summary>
        /// 组织字段
        /// </summary>
        /// <param name="doc">事件里传入的dom</param>   
        /// <param name="ctable">字段配置里配置的表名</param>
        /// <param name="sourceTableName">来源表名</param>
        /// <param name="sourceKeyName">来源表主键名</param>
        /// <param name="keyValue"></param>
        /// <returns>多行list.basemode</returns>
        public List<List<BaseMode>> MakeMultiLineData(IXMLDOMDocument2 doc, string ctable, string sourceTableName, string sourceKeyName, string sourceKeyValue) 
        {
            System.Diagnostics.Debug.WriteLine("MakeData begin at" + System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));

            if (string.IsNullOrEmpty(sourceTableName))
            {
                throw new Exception("MakeData:来源表名为空!");
            }
            if (string.IsNullOrEmpty(sourceKeyName))
            {
                throw new Exception("MakeData:来源主键名为空!");
            }
            if (string.IsNullOrEmpty(sourceKeyValue))
            {
                throw new Exception("MakeData:来源主键值为空!");
            }

            string sql = " SELECT cfield,igetvaluetype,igetvalue,cfieldtype FROM [MES_FIELDCMP]  with(nolock)  WHERE ctable = '" + ctable + "'";
            dtField = new DataTable();
            dtField = UFSelect(sql);
            string colNames = "";    //来源表列名
            if (null != dtField && dtField.Rows.Count > 0)
            {
                for (int i = 0; i < dtField.Rows.Count; i++)
                {
                    //0 取自dom,1取自dataset,2固定值,3函数,4以列值为参数作为判断,5接口通用变量, 6目标表不存在的列,但是需要用它取来源
                    if (dtField.Rows[i]["igetvaluetype"] != null && (dtField.Rows[i]["igetvaluetype"].ToString().Equals("1") || dtField.Rows[i]["igetvaluetype"].ToString().Equals("6")))
                    {  
                        string tmpColName = dtField.Rows[i]["igetvalue"].ToString();
                        if (colNames.IndexOf(tmpColName) > -1 && colNames.Substring(colNames.IndexOf(tmpColName)-1, 1) == ",")
                        {
                            continue;
                        } 
                        colNames += "," + dtField.Rows[i]["igetvalue"].ToString();
                        colNames.IndexOf(tmpColName);
                    }
                } 
                colNames = colNames.Substring(1, colNames.Length - 1);
                DataTable dtValue = new DataTable();
                dtValue = GetSourceData(sourceTableName,sourceKeyName,sourceKeyValue,colNames);
                List<BaseMode> tmpl = new List<BaseMode>();
                List<List<BaseMode>> tmplst = new List<List<BaseMode>>();
                if (dtValue.Rows.Count == 0)
                {

                    System.Diagnostics.Debug.WriteLine("MakeData end at" + System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")); 
                    return null;
                }
                else if (dtValue.Rows.Count == 1)
                {
                    tmpl = new List<BaseMode>();
                    tmpl = MakeSingleLineData(doc, dtValue.Rows[0], dtField);
                    tmplst.Add(tmpl);
                }
                else
                {
                    for (int i = 0; i < dtValue.Rows.Count; i++)
                    {
                        tmpl = new List<BaseMode>();
                        tmpl = MakeSingleLineData(doc, dtValue.Rows[i], dtField);
                        tmplst.Add(tmpl);
                    }
                }

                System.Diagnostics.Debug.WriteLine("MakeData end at" + System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")); 
                return tmplst;

            }
            else
            {

                System.Diagnostics.Debug.WriteLine("MakeData end at" + System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")); 
                throw new Exception("MakeData:没有字段对照信息!");
            }
             
        }


        /// <summary>
        /// 获取来源档案数据
        /// </summary>
        /// <param name="sourceTableName"></param>
        /// <param name="sourceKeyName"></param>
        /// <param name="sourceKeyValue"></param>
        /// <param name="colNames"></param>
        /// <returns></returns>
        public virtual DataTable GetSourceData(string sourceTableName, string sourceKeyName, string sourceKeyValue, string colNames)
        {
            string sql = "SELECT " + colNames + " FROM " + sourceTableName + " with(nolock) WHERE " + sourceKeyName + " ='" + sourceKeyValue + "'";
            DataTable dtValue = new DataTable();
            dtValue = UFSelect(sql);
            return dtValue;
        }

        /// <summary>
        /// 组织单行basemode
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="drValue">来源表行</param>
        /// <param name="dtfield">字段对照</param>
        /// <returns></returns>
        protected List<BaseMode> MakeSingleLineData(IXMLDOMDocument2 doc, DataRow drValue, DataTable _dtfield)
        {
            List<BaseMode> tmpl = new List<BaseMode>();
            for (int i = 0; i < _dtfield.Rows.Count; i++)
            {
                string sourceColName = dtField.Rows[i]["igetvalue"].ToString();
                string targetColName = dtField.Rows[i]["cfield"].ToString();
                string getvaluetype = dtField.Rows[i]["igetvaluetype"].ToString();
                string getvalue = dtField.Rows[i]["igetvalue"].ToString();
                string sourceColType = dtField.Rows[i]["cfieldtype"].ToString();
                string colValue;
                string tempOrValue = "";
                switch (getvaluetype)  //0 取自dom,1取自dataset,2固定值,3函数,4以列值为参数作为判断,5接口通用变量, 6目标表不存在的列,但是需要用它取来源
                {
                    case "0":
                        colValue = drValue[getvalue].ToString();
                        tmpl.Add(new BaseMode(targetColName, colValue, getvalue, targetColName, GetNodeValue(doc, getvalue), sourceColType, sourceColType));
                        break;
                    case "1":
                        colValue = drValue[getvalue].ToString();
                        tmpl.Add(new BaseMode(sourceColName, colValue, getvalue, targetColName, drValue[getvalue].ToString(), sourceColType, sourceColType));
                        break;
                    case "2":
                        colValue = drValue[getvalue].ToString();
                        tmpl.Add(new BaseMode(targetColName, colValue, getvalue, targetColName, getvalue, sourceColType, sourceColType));
                        break;
                    case "3":
                        colValue = "";
                        if (getvalue == "1")
                        {
                            tempOrValue = Function.Comm.GetFlagByOper(opertype);
                        }
                        else if (getvalue == "2")
                        {
                            tempOrValue = Function.Comm.GetUpDept(drValue["cDepCode"].ToString());
                        }
                        else if (getvalue == "3")
                        {
                            tempOrValue = Function.Comm.GetInventoryClass(drValue["cInvCCode"].ToString());
                        }
                        else if (getvalue == "4")
                        {
                            tempOrValue = Function.Comm.GetComputationUnit(drValue["cComUnitCode"].ToString());
                        }
                        else if (getvalue == "5")
                        {
                            tempOrValue = Function.Comm.GetInvPurType(drValue["bBomMain"].ToString(), drValue["bBomSub"].ToString(), drValue["bPurchase"].ToString(), drValue["bSelf"].ToString());
                        }
                        tmpl.Add(new BaseMode(targetColName, colValue, getvalue, targetColName, tempOrValue, sourceColType, sourceColType));
                        break;
                    case "4":
                        colValue = drValue[getvalue].ToString();
                        if (getvalue == "1") //根据自身值
                        {
                            tempOrValue = Function.Comm.GetFlagByOper(opertype);
                        }
                        tmpl.Add(new BaseMode(targetColName, colValue, getvalue, targetColName, tempOrValue, sourceColType, sourceColType));
                        break; 
                    case "5":
                        colValue = ""; 
                        if (getvalue == "main|@@identity")
                        {
                            tempOrValue = "@mainid";
                        }
                        else if (getvalue == "##newguid")
                        {
                            tempOrValue = Guid.NewGuid().ToString();
                        }
                        else if (getvalue == "main|##newguid")   //新生成的guid值
                        {
                            tempOrValue = "main|##newguid";
                        }
                        tmpl.Add(new BaseMode(targetColName, colValue, getvalue, targetColName, tempOrValue, sourceColType, sourceColType));
                        break;

                }

            }
            return tmpl;
        }
        #endregion
 
    }
}
