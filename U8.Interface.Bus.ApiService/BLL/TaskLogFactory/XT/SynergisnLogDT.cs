using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace U8.Interface.Bus.ApiService.BLL
{
    public class SynergisnLogDT : Task.ITaskLogDetail
    {
        private readonly DAL.SynergismLogDt dal = new DAL.SynergismLogDt();


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Synergismlogdt> DataTableToList(DataTable dt)
        {
            List<Model.Synergismlogdt> modelList = new List<Model.Synergismlogdt>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.Synergismlogdt model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.Synergismlogdt();
                    if (dt.Rows[n]["autoid"].ToString() != "")
                    {
                        model.Autoid = dt.Rows[n]["autoid"].ToString();  //int.Parse(dt.Rows[n]["autoid"].ToString());
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
                        model.Id = dt.Rows[n]["id"].ToString(); //int.Parse(dt.Rows[n]["id"].ToString());
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
                    model.Acc_id = dt.Rows[n]["cacc_id"].ToString();
                    model.Accname = dt.Rows[n]["accname"].ToString();
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
                    if (model.Cstatus == "错误")
                    {
                        model.Opname = "重发";
                    }
                    if (model.Cstatus == "已删除")
                    {
                        model.Opname = "重发";
                    }


                    if (model.Ismanual == 1)
                    {
                        model.Ismanualc = "是";
                    }
                    else model.Ismanualc = "否";


                    if (model.Isaudit == 1)
                    {
                        model.Isauditc = "是";
                    }
                    else model.Isauditc = "否";

                    model.Cvouchertypename = dt.Rows[n]["Cvouchertypename"].ToString();



                    modelList.Add(model);
                }


            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Synergismlogdt> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Synergismlogdt> GetModelList(int Top, string strWhere, string order, string ascOrDesc)
        {
            DataSet ds = dal.GetList(Top, strWhere, order, ascOrDesc);
            return DataTableToList(ds.Tables[0]);
        }

        public List<Model.Synergismlogdt> GetModelListAccname(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToListAccname(ds.Tables[0]);

        }

        public List<Model.Synergismlogdt> DataTableToListAccname(DataTable dt)
        {

            DAL.Regist registdal = new DAL.Regist();

            List<Model.Synergismlogdt> modelList = new List<Model.Synergismlogdt>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.Synergismlogdt model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.Synergismlogdt();
                    if (dt.Rows[n]["autoid"].ToString() != "")
                    {
                        model.Autoid = dt.Rows[n]["autoid"].ToString();  //int.Parse(dt.Rows[n]["autoid"].ToString());
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
                        model.Id = dt.Rows[n]["id"].ToString(); //int.Parse(dt.Rows[n]["id"].ToString());
                    }

                    if (dt.Rows[n]["fatherid"].ToString() != "")
                    {
                        model.Fatherid = int.Parse(dt.Rows[n]["fatherid"].ToString());
                    }

                    if (dt.Rows[n]["ilineno"].ToString() != "")
                    {
                        model.Ilineno = int.Parse(dt.Rows[n]["ilineno"].ToString());
                    }
                    model.Accid = dt.Rows[n]["accid"].ToString();

                    model.Accname = registdal.GetModel(model.Accid).Cacc_id;


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
                    if (model.Cstatus == "错误")
                    {
                        model.Opname = "重发";
                    }
                    if (model.Cstatus == "已删除")
                    {
                        model.Opname = "重发";
                    }


                    if (model.Ismanual == 1)
                    {
                        model.Ismanualc = "是";
                    }
                    else model.Ismanualc = "否";


                    if (model.Isaudit == 1)
                    {
                        model.Isauditc = "是";
                    }
                    else model.Isauditc = "否";

                    model.Cvouchertypename = dt.Rows[n]["Cvouchertypename"].ToString();



                    modelList.Add(model);
                }


            }
            return modelList;
        }



        /// <summary>
        /// 获取主表信息
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public List<Model.Synergismlogdt> GetListFromSynergismlog(Model.Synergismlog log)
        {
            string where = " d.id=" + log.Id;
            return GetModelList(where);

        }


        /// <summary>
        /// 获取第一条数据byfatherid
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public Model.Synergismlogdt GetFrist(Model.Synergismlog log,BLL.BaseOp op)
        {
            List<Model.Synergismlogdt> ldt;
            string where = " fatherid is null and d.id=" + log.Id;
            ldt = GetModelList(where);
            if (ldt.Count == 1) return ldt[0];
            return null;

        }

        /// <summary>
        /// 获取下一条s by fatherid
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<Model.Synergismlogdt> GetNext(Model.Synergismlogdt dt,BLL.BaseOp op)
        {
            List<Model.Synergismlogdt> ldt;
            string where = "fatherid=" + dt.Autoid;
            ldt = GetModelList(where);
            return ldt;

        }



        /// <summary>
        /// 更新到数据库
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int Update(Model.Synergismlogdt dt,BLL.BaseOp op)
        {

            return dal.Update(dt);

        } 

        /// <summary>
        /// 获取上一条 by faherid
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public Model.Synergismlogdt GetPrevious(Model.Synergismlogdt dt,BLL.BaseOp op)
        {
            List<Model.Synergismlogdt> ldt;
            string where = " autoid=" + dt.Fatherid;
            ldt = GetModelList(where);
            if (ldt.Count == 1) return ldt[0];
            return null;
        }





        /// <summary>
        /// 获取第linenoh条
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public Model.Synergismlogdt GetByIlineno(Model.Synergismlogdt dt, int lineno)
        {
            List<Model.Synergismlogdt> ldt;
            string where = " ilineno=" + lineno.ToString() + " and d.id=" + dt.Id;
            ldt = GetModelList(where);
            if (ldt.Count == 1) return ldt[0];
            return null;
        }

    }
}
