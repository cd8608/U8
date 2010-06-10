using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using U8.Interface.Bus.DBUtility;

namespace U8.Interface.Bus.ApiService.DAL
{
    public class Regist
    {

        string _tableName = "HY_DZ_K7_REGIST";

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Regist GetModel(string acccode)
        { 
            Model.Regist model = new Model.Regist();
            model.Accid = "1000000002";
            model.Acccode = "0000000002";

            model.Cservername = ConfigurationManager.AppSettings["u8servername"];
            model.Cacc_id = ConfigurationManager.AppSettings["u8acccode"];  //"888";
            model.Caccname = ConfigurationManager.AppSettings["dbcatalogname"];   //UFDATA_888_2015
            model.Cpassword = ConfigurationManager.AppSettings["u8pwd"];
            model.Benable = "1";
            model.Cuser_id = ConfigurationManager.AppSettings["u8user"];
            model.Cmaker = ConfigurationManager.AppSettings["u8user"];

            return model;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Regist GetModel_Bak(string acccode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select accid, cpassword, caddress, cdbpwd, datasource, cacc_id, caccname, ibeginyear, cuser_id, benable, cmaker, ddate, cmaketime, cmodifer, dmodifydate, cmodifytime, iprintcount, ivtid, acccode, ufts, cremark, cmacadd, dlogindate, cservername ");
            strSql.Append(" from " + _tableName + " ");
            strSql.Append(" where acccode='" + acccode + "' ");
             
            Model.Regist model = new Model.Regist();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);
            BLL.Common.ErrorMsg(ds, "未能取到账套信息");

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Accid = ds.Tables[0].Rows[0]["accid"].ToString();
                model.Cpassword = ds.Tables[0].Rows[0]["cpassword"].ToString();
                model.Benable = ds.Tables[0].Rows[0]["benable"].ToString();
                model.Cmaker = ds.Tables[0].Rows[0]["cmaker"].ToString();
                if (ds.Tables[0].Rows[0]["ddate"].ToString() != "")
                {
                    model.Ddate = DateTime.Parse(ds.Tables[0].Rows[0]["ddate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cmaketime"].ToString() != "")
                {
                    model.Cmaketime = DateTime.Parse(ds.Tables[0].Rows[0]["cmaketime"].ToString());
                }
                model.Cmodifer = ds.Tables[0].Rows[0]["cmodifer"].ToString();
                if (ds.Tables[0].Rows[0]["dmodifydate"].ToString() != "")
                {
                    model.Dmodifydate = DateTime.Parse(ds.Tables[0].Rows[0]["dmodifydate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cmodifytime"].ToString() != "")
                {
                    model.Cmodifytime = DateTime.Parse(ds.Tables[0].Rows[0]["cmodifytime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iprintcount"].ToString() != "")
                {
                    model.Iprintcount = int.Parse(ds.Tables[0].Rows[0]["iprintcount"].ToString());
                }
                model.Ivtid = ds.Tables[0].Rows[0]["ivtid"].ToString();
                model.Acccode = ds.Tables[0].Rows[0]["acccode"].ToString();

                model.Cremark = ds.Tables[0].Rows[0]["cremark"].ToString();
                model.Caddress = ds.Tables[0].Rows[0]["caddress"].ToString();
                model.Cdbpwd = ds.Tables[0].Rows[0]["cdbpwd"].ToString();
                model.Datasource = ds.Tables[0].Rows[0]["datasource"].ToString();
                model.Cacc_id = ds.Tables[0].Rows[0]["cacc_id"].ToString();
                model.Caccname = ds.Tables[0].Rows[0]["caccname"].ToString();
                if (ds.Tables[0].Rows[0]["ibeginyear"].ToString() != "")
                {
                    model.Ibeginyear = int.Parse(ds.Tables[0].Rows[0]["ibeginyear"].ToString());
                }
                model.Cuser_id = ds.Tables[0].Rows[0]["cuser_id"].ToString();
                model.Cmacadd = ds.Tables[0].Rows[0]["cmacadd"].ToString();
                if (ds.Tables[0].Rows[0]["dlogindate"].ToString() != "")
                {
                    DateTime date = DateTime.Parse(ds.Tables[0].Rows[0]["dlogindate"].ToString());
                    if (date.Year <= 2000 || date.Year >= 2050)
                        model.Dlogindate = null;
                    else
                        model.Dlogindate = date;
                }
                else
                {
                    model.Dlogindate = null;
                }
                model.Cservername = ds.Tables[0].Rows[0]["cservername"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
