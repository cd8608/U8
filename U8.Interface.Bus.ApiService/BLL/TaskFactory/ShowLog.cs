using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace U8.Interface.Bus.ApiService.BLL
{
    public class ShowLog
    {
        private readonly DAL.ShowLog dal = new DAL.ShowLog();

        /// <summary>
        /// 获得数据列表
        /// </summary>
        private List<Model.ShowLog> DataTableToList(DataTable dt)
        {
            List<Model.ShowLog> modelList = new List<Model.ShowLog>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.ShowLog model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.ShowLog();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.Id = dt.Rows[n]["id"].ToString(); // int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    model.Cserialno = dt.Rows[n]["cserialno"].ToString();
                    model.Croutetype = dt.Rows[n]["croutetype"].ToString();
                    model.Caccid = dt.Rows[n]["caccid"].ToString();
                    model.Cvouchertype = dt.Rows[n]["cvouchertype"].ToString();
                    model.Cvoucherno = dt.Rows[n]["cvoucherno"].ToString();
                    if (dt.Rows[n]["starttime"].ToString() != "")
                    {
                        model.Starttime = DateTime.Parse(dt.Rows[n]["starttime"].ToString());
                    }
                    if (dt.Rows[n]["endtime"].ToString() != "")
                    {
                        model.Endtime = DateTime.Parse(dt.Rows[n]["endtime"].ToString());
                    }
                    model.Cstatus = dt.Rows[n]["cstatus"].ToString();

                    model.Cacc_Id = dt.Rows[n]["Cacc_Id"].ToString();
                    model.Cacc_Name = dt.Rows[n]["Cacc_Name"].ToString();
                    model.Caddress = dt.Rows[n]["Caddress"].ToString();

                    model.CDataName = dal.GetDataName(model.Cvouchertype, model.Cvoucherno);

                    modelList.Add(model);
                }
            }
            return modelList;
        }
        
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.ShowLog> GetModelList(string Top, string strWhere, string order, string ascOrDesc)
        {
            DataSet ds = dal.GetList(Top, strWhere, order, ascOrDesc);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获取导出数据
        /// </summary>
        public DataSet GetOutputInfo(bool isList, string Top, string strWhere, string order, string ascOrDesc)
        {
            return dal.GetOutputInfo(isList, Top, strWhere, order, ascOrDesc);
        }
    }
}
