using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Interface.Bus.ApiService.BLL.Task
{
    public interface ITaskLogDetail
    {

        Model.Synergismlogdt GetFrist(Model.Synergismlog main, BLL.BaseOp op);

        List<Model.Synergismlogdt>  GetNext(Model.Synergismlogdt detail,BLL.BaseOp op);

        Model.Synergismlogdt GetPrevious(Model.Synergismlogdt dt,BLL.BaseOp op);


        /// <summary>
        /// 更新到数据库
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        int Update(Model.Synergismlogdt dt, BLL.BaseOp op);
         
    }
}
