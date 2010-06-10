using System;

using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using U8.Interface.Bus.DBUtility;

namespace U8.Interface.Bus.ApiService.DAL.CQ
{
    public class Fieldcmps:IFieldcmps
    {  
        private string _tablename = "MES_CQ_FIELDCMPS";

        /// <summary>
        /// 获取字段对照数据
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="pdt"></param>
        /// <returns></returns>
        public List<Model.Fieldcmps> GetListFieldcmps(Model.Synergismlogdt dt, Model.Synergismlogdt pdt)
        {
            DAL.CQ.Fieldcmp fddal = new DAL.CQ.Fieldcmp();
            Model.Fieldcmp fdmodel = fddal.GetModel(string.Format("cfrombillcardnum='{0}' and ctobillcardnum='{1}'", pdt.Cvouchertype, dt.Cvouchertype));
            BLL.Common.ErrorMsg(fdmodel, "未能取字段对照数据");
            // 模扳数据
            List<Model.Fieldcmps> listfd = GetModelList(string.Format("id='{0}'   order by seq desc,ctype ,cremark desc,autoid asc", fdmodel.Id));
            BLL.Common.ErrorMsg(listfd, "未能取字段对照数据");
            return listfd;
        }
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public List<Model.Fieldcmps> GetModelList(string where)
        {
            List<Model.Fieldcmps> fieldList = new List<Model.Fieldcmps>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select autoid, isnull, cremark, guid, id, ccode, ctype, cvalue, cfunid, cardsection, fieldname, carditemname  ");
            strSql.Append("  from " + _tablename + " ");
            strSql.Append(" where  ");
            strSql.Append(where);
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Model.Fieldcmps model = new Model.Fieldcmps();
                    model.Autoid = dr["autoid"].ToString();
                    if (dr["isnull"].ToString() != "")
                    {
                        if ((dr["isnull"].ToString() == "1") || (dr["isnull"].ToString().ToLower() == "true"))
                        {
                            model.Isnull = true;
                        }
                        else
                        {
                            model.Isnull = false;
                        }
                    }
                    model.Cremark = dr["cremark"].ToString();
                    model.Guid = dr["guid"].ToString();
                    model.Id = dr["id"].ToString();
                    model.Ccode = dr["ccode"].ToString();
                    if (dr["ctype"].ToString() != "")
                    {
                        model.Ctype = int.Parse(dr["ctype"].ToString());
                    }
                    model.Cvalue = dr["cvalue"].ToString();
                    model.Cfunid = dr["cfunid"].ToString();
                    model.Cardsection = dr["cardsection"].ToString();
                    model.Fieldname = dr["fieldname"].ToString();
                    model.Carditemname = dr["carditemname"].ToString();
                    fieldList.Add(model);  
                }

                return fieldList;
            }
            else
            {
                return null;
            }
        }
    }
}
