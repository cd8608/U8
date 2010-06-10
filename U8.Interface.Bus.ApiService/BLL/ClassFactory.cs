using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using U8.Interface.Bus.ApiService.Model;
using U8.Interface.Bus.ApiService.DAL;

namespace U8.Interface.Bus.ApiService.BLL
{
    public class ClassFactory
    {

        /// <summary>
        /// 获取数据对象
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static BaseData GetBaseData(Model.Synergismlogdt dt)
        {
            DAL.DLLReflect dal = new DAL.DLLReflect();
            Model.DLLReflect model = dal.GetModel("cvouchertype='" + dt.Cvouchertype + "' and ClassType='data' and tasktype = " + dt.TaskType);
            Common.ErrorMsg(model, "未能取到数据对象");
            return (BaseData)System.Reflection.Assembly.Load(model.Dllpath).CreateInstance(model.Npace + "." + model.ClassName, true, System.Reflection.BindingFlags.CreateInstance, null, new object[] {  model.TaskType }, null, null);
        }


        /// <summary>
        /// 获取操作对象
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static BaseOp GetBaseOp(Model.Synergismlogdt dt)
        {
            DAL.DLLReflect dal = new DAL.DLLReflect();
            string swhere = "cvouchertype='" + dt.Cvouchertype + "' and ClassType='op' and tasktype = " + dt.TaskType;
            Model.DLLReflect model = dal.GetModel(swhere);
            Common.ErrorMsg(model, "未能取到操作类型对象");
            return (BaseOp)System.Reflection.Assembly.Load(model.Dllpath).CreateInstance(model.Npace + "." + model.ClassName);
        }



        /// <summary>
        /// 获取操作对象
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static BaseOp GetBaseOp(Model.Synergismlog dt)
        {
            DAL.DLLReflect dal = new DAL.DLLReflect();
            string swhere = "cvouchertype='" + dt.Cvouchertype + "' and ClassType='op' and tasktype = " + dt.TaskType;
            Model.DLLReflect model = dal.GetModel(swhere);
            Common.ErrorMsg(model, "未能取到操作类型对象");
            return (BaseOp)System.Reflection.Assembly.Load(model.Dllpath).CreateInstance(model.Npace + "." + model.ClassName);
        }





        /// <summary>
        /// 任务Main BLL 工厂
        /// </summary>
        /// <param name="tasktype"></param>
        /// <returns></returns>
        public static BLL.TaskLogFactory.ITaskLogMain GetITaskLogMainBLL(int tasktype)
        {
            BLL.TaskLogFactory.ITaskLogMain logdtbll;
            switch (tasktype)
            {
                case 0:
                    logdtbll = new BLL.TaskLogFactory.CQ.TaskMain();
                    break;
                case 1:
                    logdtbll = new BLL.SynergismLog();
                    break;
                case 2:
                    logdtbll = new BLL.TaskLogFactory.DS.TaskMain();
                    break;
                default:
                    BLL.Common.ErrorMsg(SysInfo.productName, "tasktype" + tasktype + "未适配!");
                    return null;
            }

            return logdtbll;

        }


        /// <summary>
        /// 任务detail BLL 工厂
        /// </summary>
        /// <param name="tasktype"></param>
        /// <returns></returns>
        public static BLL.TaskLogFactory.ITaskLogDetail GetITaskLogDetailBLL(int tasktype)
        {
            BLL.TaskLogFactory.ITaskLogDetail logdtbll;
            switch (tasktype)
            {
                case 0:
                    logdtbll = new BLL.TaskLogFactory.CQ.TaskDetail();
                    break;
                case 1:
                    logdtbll = new BLL.SynergisnLogDT();
                    break;
                case 2:
                    logdtbll = new BLL.TaskLogFactory.DS.TaskDetail();
                    break;
                default:
                    BLL.Common.ErrorMsg(SysInfo.productName, "tasktype" + tasktype + "未适配!");
                    return null;
            }

            return logdtbll;

        }


        /// <summary>
        /// 任务main DAL 工厂
        /// </summary>
        /// <param name="tasktype"></param>
        /// <returns></returns>
        public static DAL.TaskLogFactory.ITaskLogMain GetITaskLogMainDAL(int tasktype)
        {
            DAL.TaskLogFactory.ITaskLogMain logDAL;
            switch (tasktype)
            {
                case 0:
                    logDAL = new DAL.TaskLogFactory.CQ.TaskMain();
                    break;
                case 1:
                    logDAL = new DAL.SynergismLog();
                    break;
                case 2:
                    logDAL = new DAL.TaskLogFactory.DS.TaskMain();
                    break;
                default:
                    BLL.Common.ErrorMsg(SysInfo.productName, "tasktype" + tasktype + "未适配!");
                    return null;
            }

            return logDAL;

        }



        /// <summary>
        /// 任务detail DAL 工厂
        /// </summary>
        /// <param name="tasktype"></param>
        /// <returns></returns>
        public static DAL.TaskLogFactory.ITaskLogDetail GetITaskLogDetailDAL(int tasktype)
        {
            DAL.TaskLogFactory.ITaskLogDetail logdtDAL;
            switch (tasktype)
            {
                case 0:
                    logdtDAL = new DAL.TaskLogFactory.CQ.TaskDetail();
                    break;
                case 1:
                    logdtDAL = new DAL.SynergismLogDt();
                    break;
                case 2:
                    logdtDAL = new DAL.TaskLogFactory.DS.TaskDetail();
                    break;
                default:
                    BLL.Common.ErrorMsg(SysInfo.productName, "tasktype" + tasktype + "未适配!");
                    return null;
            }

            return logdtDAL;

        }



        /// <summary>
        /// fieldcmps 工厂
        /// </summary>
        /// <param name="tasktype"></param>
        /// <returns></returns>
        public static DAL.IFieldcmps GetIFieldcmpsDAL(int tasktype)
        {
            DAL.IFieldcmps dal;
            switch (tasktype)
            {
                case 0:
                    dal = new DAL.CQ.Fieldcmps();
                    break;
                case 1:
                    dal = new DAL.Fieldcmps();
                    break;
                case 2:
                    dal = new DAL.DS.Fieldcmps();
                    break;
                default:
                    BLL.Common.ErrorMsg(SysInfo.productName, "tasktype" + tasktype + "未适配!");
                    return null;
            }

            return dal;

        }

    }
}
