using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using U8.Interface.Bus.DBUtility;

namespace U8.Interface.Bus.ApiService.DAL
{
    public class Function
    {
        private string _tablename = "MES_CQ_FUNCTION";

        public Model.Function GetModel(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, accid, cfunid, cfunesc, cfuntype, cfunobject, cfunclass, cfunname, cfunsql, cfunvba  ");
            strSql.Append("  from " + _tablename + " ");
            strSql.Append(" where ");
            strSql.Append(where);
            Model.Function model = new Model.Function();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.Accid = ds.Tables[0].Rows[0]["accid"].ToString();
                model.Cfunid = ds.Tables[0].Rows[0]["cfunid"].ToString();
                model.Cfunesc = ds.Tables[0].Rows[0]["cfunesc"].ToString();
                model.Cfuntype = ds.Tables[0].Rows[0]["cfuntype"].ToString();
                model.Cfunobject = ds.Tables[0].Rows[0]["cfunobject"].ToString();
                model.Cfunclass = ds.Tables[0].Rows[0]["cfunclass"].ToString();
                model.Cfunname = ds.Tables[0].Rows[0]["cfunname"].ToString();
                model.Cfunsql = ds.Tables[0].Rows[0]["cfunsql"].ToString();
                model.Cfunvba = ds.Tables[0].Rows[0]["cfunvba"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

    }
}
