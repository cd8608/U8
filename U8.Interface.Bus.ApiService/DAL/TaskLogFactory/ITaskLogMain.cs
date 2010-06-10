using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Interface.Bus.ApiService.DAL.TaskLogFactory
{
    public interface ITaskLogMain
    {   
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Model.Synergismlog GetModel(string id,BLL.BaseOp op);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Model.Synergismlog model, BLL.BaseOp op);
         
    }
}
