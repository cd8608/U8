using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using U8.Interface.Bus.DBUtility;

namespace U8.Interface.Bus.ApiService.DAL.DS
{
    /// <summary>
    /// HY_DZ_K7_SYNERGISMLOGDT
    /// 
    /// </summary>
    public partial class TaskMain : DAL.TaskLogFactory.ITaskLogMain
    {
 
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.Synergismlog model, BLL.BaseOp op)
        {
            return op.Update(model);
        }
 
        /// <summary>
        ///  
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public Model.Synergismlog GetModel(string autoid,BLL.BaseOp op)
        { 
            return op.GetLogModel(autoid);
        }

         

    }
}

