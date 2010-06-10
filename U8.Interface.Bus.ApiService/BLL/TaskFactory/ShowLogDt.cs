using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace U8.Interface.Bus.ApiService.BLL
{
    public class ShowLogDt
    {
        private readonly DAL.ShowLogDt dal = new DAL.ShowLogDt();
        
        /// <summary>
        /// 获得数据列表
        /// </summary>
        private List<Model.ShowLogDt> DataTableToList(DataTable dt)
        {
            List<Model.ShowLogDt> modelList = new List<Model.ShowLogDt>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.ShowLogDt model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.ShowLogDt();
                    if (dt.Rows[n]["autoid"].ToString() != "")
                    {
                        model.Autoid = dt.Rows[n]["autoid"].ToString(); //int.Parse(dt.Rows[n]["autoid"].ToString());
                    }
                    model.Cerrordesc = dt.Rows[n]["cerrordesc"].ToString();
                    model.Cstatus = dt.Rows[n]["cstatus"].ToString();
                    if (dt.Rows[n]["ismanual"].ToString() != "")
                    {
                        model.Ismanual = int.Parse(dt.Rows[n]["ismanual"].ToString());
                    }
                    if (dt.Rows[n]["isaudit"].ToString() != "")
                    {
                        model.Isaudit = int.Parse(dt.Rows[n]["isaudit"].ToString());
                    }
                    if (dt.Rows[n]["errortimes"].ToString() != "")
                    {
                        model.Errortimes = int.Parse(dt.Rows[n]["errortimes"].ToString());
                    }
                    if (dt.Rows[n]["cdealmothed"].ToString() != "")
                    {
                        model.Cdealmothed = int.Parse(dt.Rows[n]["cdealmothed"].ToString());
                    }
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        //model.Id = int.Parse(dt.Rows[n]["id"].ToString());
                        model.Id =  dt.Rows[n]["id"].ToString();
                    }
                    if (dt.Rows[n]["ilineno"].ToString() != "")
                    {
                        model.Ilineno = int.Parse(dt.Rows[n]["ilineno"].ToString());
                    }

                    if (dt.Rows[n]["fatherid"].ToString() != "")
                    {
                        model.Fatherid = int.Parse(dt.Rows[n]["fatherid"].ToString());
                    }
                    model.Accid = dt.Rows[n]["accid"].ToString();
                    model.Cvouchertype = dt.Rows[n]["cvouchertype"].ToString();
                    model.Cvoucherno = dt.Rows[n]["cvoucherno"].ToString();
                    model.Cpk = dt.Rows[n]["cpk"].ToString();
                    if (dt.Rows[n]["dinputtime"].ToString() != "")
                    {
                        model.Dinputtime = DateTime.Parse(dt.Rows[n]["dinputtime"].ToString());
                    }
                    if (dt.Rows[n]["dmaketime"].ToString() != "")
                    {
                        model.Dmaketime = DateTime.Parse(dt.Rows[n]["dmaketime"].ToString());
                    }
                    if (model.Ismanual != 1)
                    {
                        if (model.Cstatus == "错误")
                        {
                            model.Opname = "重发";
                        }
                        else if (model.Cstatus == "已删除")
                        {
                            model.Opname = "重发";
                        }
                    }


                    if (model.Isaudit == 1)
                    {
                        model.Isauditc = "是";
                    }
                    else
                    {
                        model.Isauditc = "否";
                    }

                    if (model.Ismanual == 1)
                    {
                        model.Isauditc = "否";
                        model.Ismanualc = "是";
                    }
                    else
                    {
                        model.Ismanualc = "否";
                    }

                    if (model.Fatherid >= 1)
                    {
                        if (model.Cdealmothed == 0)
                        {
                            if (model.Ismanual == 1)
                            {
                                if (model.Cstatus == "未审核")
                                {
                                    model.Cdealmothedc = "手工审核";
                                }
                                else
                                {
                                    model.Cdealmothedc = "手工生单";
                                }
                            }
                            else
                            {
                                if (model.Isaudit == 1)
                                {
                                    if (model.Cstatus == "未审核")
                                    {
                                        model.Cdealmothedc = "自动审核";
                                    }
                                    else
                                    {
                                        model.Cdealmothedc = "自动生单";
                                    }
                                }
                                else
                                {
                                    if (model.Cstatus == "未审核")
                                    {
                                        model.Cdealmothedc = "手工审核";
                                    }
                                    else
                                    {
                                        model.Cdealmothedc = "自动生单";
                                    }
                                }
                            }
                        }
                        else if (model.Cdealmothed == 1)
                        {
                            model.Cdealmothedc = "新增";
                        }
                        else if (model.Cdealmothed == 2)
                        {
                            model.Cdealmothedc = "修改";
                        }
                        else if (model.Cdealmothed == 3)
                        {
                            model.Cdealmothedc = "删除";
                        }
                        else
                        {
                            model.Cdealmothedc = "";
                        }
                    }

                        model.Cvouchertypename = dt.Rows[n]["Cvouchertypename"].ToString();

                    model.Caddress = dt.Rows[n]["Caddress"].ToString();
                    model.Acc_id = dt.Rows[n]["Acc_id"].ToString();
                    model.Accname = dt.Rows[n]["Accname"].ToString();
                    model.CpkName = dt.Rows[n]["CpkName"].ToString();

                    model.CDataName = dal.GetDataName(model.Cvouchertypename, model.Cvoucherno);

                    modelList.Add(model);
                }


            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.ShowLogDt> GetModelList(string Top, string strWhere, string order, string ascOrDesc)
        {
            DataSet ds = dal.GetList(Top, strWhere, order, ascOrDesc);
            return DataTableToList(ds.Tables[0]);
        }
    }
}
