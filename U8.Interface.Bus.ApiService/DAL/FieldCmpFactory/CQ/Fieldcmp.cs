using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using U8.Interface.Bus.DBUtility;

namespace U8.Interface.Bus.ApiService.DAL.CQ
{
    public class Fieldcmp : IFieldcmp
    {
        private string _tablename = "MES_CQ_FIELDCMP";
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Fieldcmp GetModel(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, iprintcount, ccode, cname, cfrombillcardnum, ctobillcardnum, vt_id, cmodifer, dmodifydate, ufts  ");
            strSql.Append("  from " + _tablename + " ");
            strSql.Append(" where ");
            strSql.Append(where);
            Model.Fieldcmp model = new Model.Fieldcmp();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Id = ds.Tables[0].Rows[0]["id"].ToString();
                if (ds.Tables[0].Rows[0]["iprintcount"].ToString() != "")
                {
                    model.Iprintcount = int.Parse(ds.Tables[0].Rows[0]["iprintcount"].ToString());
                }
                model.Ccode = ds.Tables[0].Rows[0]["ccode"].ToString();
                model.Cname = ds.Tables[0].Rows[0]["cname"].ToString();
                model.Cfrombillcardnum = ds.Tables[0].Rows[0]["cfrombillcardnum"].ToString();
                model.Ctobillcardnum = ds.Tables[0].Rows[0]["ctobillcardnum"].ToString();
                model.Vt_id = ds.Tables[0].Rows[0]["vt_id"].ToString();
                model.Cmodifer = ds.Tables[0].Rows[0]["cmodifer"].ToString();
                if (ds.Tables[0].Rows[0]["dmodifydate"].ToString() != "")
                {
                    model.Dmodifydate = DateTime.Parse(ds.Tables[0].Rows[0]["dmodifydate"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
