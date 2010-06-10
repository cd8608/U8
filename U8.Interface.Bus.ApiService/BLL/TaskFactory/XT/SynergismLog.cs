using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;


namespace U8.Interface.Bus.ApiService.BLL
{
    public class SynergismLog : Task.ITaskLogMain
    {
        private readonly DAL.SynergismLog dal = new DAL.SynergismLog();
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Synergismlog> DataTableToList(DataTable dt)
        {
            List<Model.Synergismlog> modelList = new List<Model.Synergismlog>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.Synergismlog model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.Synergismlog();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.Id = dt.Rows[n]["id"].ToString(); //int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    model.Cserialno = dt.Rows[n]["cserialno"].ToString();
                    model.Croutetype = dt.Rows[n]["croutetype"].ToString();
                    model.Caccid = dt.Rows[n]["caccid"].ToString();
                    model.Acc_id = dt.Rows[n]["cacc_id"].ToString();
                    model.Accname = dt.Rows[n]["accname"].ToString();
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
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Synergismlog> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Synergismlog> GetModelList(int Top, string strWhere, string order, string ascOrDesc)
        {
            DataSet ds = dal.GetList(Top, strWhere, order, ascOrDesc);
            return DataTableToList(ds.Tables[0]);
        }

        public int Update(Model.Synergismlog log,BaseOp op)
        {
            return dal.Update(log);
        }


        /// <summary>
        /// 获得服务数据列表
        /// </summary>
        public List<Model.Synergismlog> GetServiceList(string strWhere)
        {
            DataSet ds = dal.GetServiceList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
    }
}
