using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using U8.Interface.Bus.DBUtility;

namespace U8.Interface.Bus.ApiService.DAL
{
    public static class APINormal
    {


        /// <summary>
        /// 设置通用变量
        /// </summary>
        /// <param name="apidata"></param>
        /// <param name="dt"></param>
        public static void SetNormalValue(Model.APIData apidata, Model.Synergismlogdt dt)
        {
            string vt_id = "vt_id";
            Model.U8NameValue nv = DAL.Common.U8NameValueFind(apidata.HeadData, vt_id);
            if (nv != null)
            {
                if (string.IsNullOrEmpty(nv.U8FieldValue))
                {
                    DbHelperSQLP help = new DbHelperSQLP(apidata.ConnectInfo.Constring);
                    string sql = string.Format("select   def_id from vouchers_base  with(nolock)  where CardNumber='{0}'", dt.Cvouchertype);
                    nv.U8FieldValue = help.GetSingle(sql).NullToString();
                }
            }

  
            string iinvexchrate = "iinvexchrate";
            foreach (List<Model.U8NameValue> list in apidata.BodyData)
            {
                Model.U8NameValue nv_iinvexchrate = DAL.Common.U8NameValueFind(list, iinvexchrate);
                if (nv_iinvexchrate != null)
                {
                    if (string.IsNullOrEmpty(nv_iinvexchrate.U8FieldValue))
                    {
                        nv_iinvexchrate.U8FieldValue = "0";
                    }
                }
            }
             
        }
    }
}
