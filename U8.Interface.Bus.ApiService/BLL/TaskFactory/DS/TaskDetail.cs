using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using U8.Interface.Bus.DBUtility;
using System.Configuration;


namespace U8.Interface.Bus.ApiService.BLL.Task.Factory.DS
{
    public class TaskDetail:ITaskLogDetail
    {

        /// <summary>
        /// 取首结点
        /// 默认首结点为完成
        /// </summary>
        /// <param name="main"></param>
        /// <returns></returns>
        public Model.Synergismlogdt GetFrist(Model.Synergismlog main,BLL.BaseOp op)
        {
            Model.Synergismlogdt detail = new U8.Interface.Bus.ApiService.Model.Synergismlogdt();
            detail.Cvouchertype = main.Cvouchertype;
            detail.Ilineno = 1;
            detail.Id = main.Id.ToString();
            detail.Cstatus = DAL.Constant.SynergisnLogDT_Cstatus_Complete;
            return detail; 
        }

        /// <summary>
        /// 取下一结点任务
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        public List<Model.Synergismlogdt> GetNext(Model.Synergismlogdt detail,BLL.BaseOp op)
        {
            return op.GetNext(detail); 
        }


        public Model.Synergismlogdt GetPrevious(Model.Synergismlogdt dt,BLL.BaseOp op)
        {
            return op.GetPrevious(dt); 
        }

        /// <summary>
        /// 更新任务状态
        /// 更新到数据库
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int Update(Model.Synergismlogdt dt,BLL.BaseOp op)
        { 
            return op.Update(dt); 
        }



    }
}
