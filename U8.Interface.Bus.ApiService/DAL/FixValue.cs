using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using U8.Interface.Bus.DBUtility;


namespace U8.Interface.Bus.ApiService.DAL
{
    public class FixValue
    {
        string tableName = "MES_CQ_FIXVALUE";

        /// <summary>
        /// 获取固定值
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<Model.Fixvalue> GetModelList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select did, cfromortobill, guid, autoid, cfunid, ctype, accid, cvalue, cno, cfunparareturn, cardsection  ");
            strSql.Append("  from " + tableName + " ");
            strSql.Append(" where ");
            strSql.Append(where);
            strSql.Append(" order by cno");
            List<Model.Fixvalue> list = new List<Model.Fixvalue>();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Model.Fixvalue model = new Model.Fixvalue();
                model.Did = ds.Tables[0].Rows[i]["did"].ToString();
                model.Cfromortobill = ds.Tables[0].Rows[i]["cfromortobill"].ToString();
                model.Guid = ds.Tables[0].Rows[i]["guid"].ToString();
                model.Autoid = ds.Tables[0].Rows[i]["autoid"].ToString();
                model.Cfunid = ds.Tables[0].Rows[i]["cfunid"].ToString();
                model.Ctype = ds.Tables[0].Rows[i]["ctype"].ToString();
                model.Accid = ds.Tables[0].Rows[i]["accid"].ToString();
                model.Cvalue = ds.Tables[0].Rows[i]["cvalue"].ToString();
                if (ds.Tables[0].Rows[i]["cno"].ToString() != "")
                {
                    model.Cno = int.Parse(ds.Tables[0].Rows[i]["cno"].ToString());
                }
                model.Cfunparareturn = ds.Tables[0].Rows[i]["cfunparareturn"].ToString();
                model.Cardsection = ds.Tables[0].Rows[i]["cardsection"].ToString();

                list.Add(model);
            }
            return list;

        }
    }
}
