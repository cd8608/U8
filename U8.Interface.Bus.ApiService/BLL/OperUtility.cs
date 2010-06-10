using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using U8.Interface.Bus.ApiService;
using U8.Interface.Bus.ApiService.DAL;
using U8.Interface.Bus.ApiService.Model;

namespace U8.Interface.Bus.ApiService.BLL
{
    public class TaskOperator
    {
        /// <summary>
        /// 获取任务队列
        /// </summary>
        /// <returns></returns>
        public TaskList GetTask()
        {

            DataSet ds = U8.Interface.Bus.DBUtility.DbHelperSQL.Query("SELECT * FROM MES_Comm_DLLReflect WITH(NOLOCK) WHERE ClassType='op' "); 

            TaskList mtasklist = new TaskList();
            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                return mtasklist;
            }

            List<VoucherType> vl = new List<VoucherType>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                vl.Add(new VoucherType() {
                    CardNo = ds.Tables[0].Rows[i]["cvouchertype"].ToString(),
                    VoucherName ="", // "产成品入库单",
                    SourceCardNo ="", // "MO21",
                    SourceVoucherNo = "" , //"00001",

                    VoucherClassDllpath = ds.Tables[0].Rows[i]["Dllpath"].ToString(),
                    VoucherClassNamespace = ds.Tables[0].Rows[i]["Namespace"].ToString(),
                    VoucherClass = ds.Tables[0].Rows[i]["ClassName"].ToString()

                });
            }
            for (int i = 0; i < vl.Count; i++)
            {
                BaseOp tmpOp = (BaseOp)System.Reflection.Assembly.Load(vl[i].VoucherClassDllpath).CreateInstance(vl[i].VoucherClassNamespace + "." + vl[i].VoucherClass);
                TaskList tmpTaskList = new TaskList();
                tmpTaskList = tmpOp.GetTask();
                if (null == tmpTaskList || tmpTaskList.Count == 0)
                {
                }
                else
                {
                    mtasklist.AddRange(tmpTaskList);
                }
            }
            return mtasklist;
        }




        /// <summary>
        /// 多线程 入口函数
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public void Run(object log)
        {
            Model.Synergismlog tmplog = log as Model.Synergismlog;
            Run(tmplog);
            
        }

        /// <summary>
        /// XTLibrary 入口函数
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public void Run(Model.Synergismlog log)
        {
            log.OPClass = log.OPClass;
            log.OP = ClassFactory.GetBaseOp(log);
            DealResult dr = new DealResult();
            dr.ResultNum = Constant.ResultNum_NoError;

            BLL.Task.ITaskLogDetail logdtbll = ClassFactory.GetITaskLogDetailBLL(log.TaskType); 
            BLL.Task.ITaskLogMain logbll = ClassFactory.GetITaskLogMainBLL(log.TaskType); 

            Model.Synergismlogdt fdt = logdtbll.GetFrist(log, log.OP);
            //挂起主表(置于等待中)
            if (fdt.Cstatus == Constant.SynergisnLogDT_Cstatus_NoAudit)
            {
                log.Cstatus = Constant.SynerginsLog_Cstatus_Wait;
                log.Endtime = DateTime.Now;
                logbll.Update(log, log.OP);
                //return dr;
            }

            //把记录设为处理中
            log.Cstatus = Constant.SynerginsLog_Cstatus_Dealing;
            log.Endtime = DateTime.Now;
            logbll.Update(log, log.OP);

            //预置为完成
            log.Cstatus = Constant.SynerginsLog_Cstatus_Complete;

            //获取下一节点(节点数可能大于1)
            List<Model.Synergismlogdt> listnext = logdtbll.GetNext(fdt, log.OP);
             
            //协同操作
            dr = MakeLogDT(log, dr, logdtbll, logbll, fdt, listnext);

            //发送消息


            //更新最终状态
            log.Endtime = DateTime.Now;
            logbll.Update(log, log.OP);

            // return dr;

        }


        /// <summary>
        /// 生单\审核 主函数
        /// </summary>
        /// <param name="log">任务主表信息</param>
        /// <param name="dr"></param>
        /// <param name="logdtbll">任务子表信息</param>
        /// <param name="logbll">任务主表BLL</param>
        /// <param name="fdt">首节点信息</param>
        /// <param name="listnext">当前任务节点信息,档案同步时有可能存在多个子结点</param>
        /// <returns></returns>
        private DealResult MakeLogDT(Synergismlog log, DealResult dr, BLL.Task.ITaskLogDetail logdtbll, BLL.Task.ITaskLogMain logbll, Model.Synergismlogdt fdt, List<Model.Synergismlogdt> listnext)
        {

            for (int i = 0; i < listnext.Count; i++)
            {
                Synergismlogdt preDt;
                Model.Synergismlogdt nextdt = listnext[i];

                ////处理数据开始 
                try
                {

                    BaseData bd = ClassFactory.GetBaseData(nextdt);
                    bd.Fristsynergismlogdt = fdt;
                    bd.Synergismlogdt = nextdt;

                    BaseOp op = ClassFactory.GetBaseOp(nextdt);
                    nextdt.OP = op;
                    preDt = logdtbll.GetPrevious(nextdt, nextdt.OP);
                    if (op == null)
                    {
                        throw new Exception("插件安装错误");
                    }

                    if (nextdt.Cdealmothed == 3)  //删除
                    {
                        TaskOperator t = new TaskOperator();
                        return t.DeleteVouch(0, nextdt);
                    }
                    else if (nextdt.Cdealmothed == 2)  //修改
                    { 
                       
                    }



                    dr = op.MakeData(nextdt, bd);

                    string ccode;
                    if (nextdt.Cstatus != DAL.Constant.SynergisnLogDT_Cstatus_NoAudit)
                    {
                        if (nextdt.Cdealmothed == 2)
                        {
                            dr = op.MakeUpdate(bd);
                            return dr;
                        }

                        dr = op.MakeVouch(bd);  //生单、档案协同

                        if (dr.ResultNum == DAL.Constant.ResultNum_NormalError)
                        {
                            throw new Exception("API错误：" + dr.ResultMsg);
                        }

                        ccode = op.GetCodeorID(dr.VouchIdRet, bd, "code");

                        nextdt.Cstatus = DAL.Constant.SynergisnLogDT_Cstatus_NoAudit;
                        nextdt.Dmaketime = DateTime.Now;
                        nextdt.Cvoucherno = ccode;
                        logdtbll.Update(nextdt, nextdt.OP);
                    }
                    else
                    {
                        ccode = nextdt.Cvoucherno;
                    }

                    if (string.IsNullOrEmpty(ccode))
                    {
                        //throw new Exception("获取上游单据失败");

                        if (nextdt.Cstatus != DAL.Constant.SynergisnLogDT_Cstatus_NoAudit) nextdt.Cstatus = DAL.Constant.SynerginsLog_Cstatus_NoDeal;
                        nextdt.Dmaketime = DateTime.Now;
                        nextdt.Cvoucherno = ccode;
                        logdtbll.Update(nextdt, nextdt.OP);
                        break;
                    }

                    if (nextdt.Isaudit == DAL.Constant.SynergisnLogDT_Isaudit_True)
                    {
                        nextdt.Cstatus = DAL.Constant.SynergisnLogDT_Cstatus_Complete;
                        dr = op.MakeAudit(bd, nextdt);   //审核单据
                    }
                    else
                    {
                        nextdt.Cstatus = DAL.Constant.SynergisnLogDT_Cstatus_NoAudit;

                    }
                    //nextdt.Cstatus = Constant.SynergisnLogDT_Cstatus_Complete;
                    nextdt.Dmaketime = DateTime.Now;
                    nextdt.Cvoucherno = ccode;
                    logdtbll.Update(nextdt, nextdt.OP);

                    //log.Cstatus = DAL.Common.SetLogStatus(log.Cstatus, Constant.SynerginsLog_Cstatus_Complete);
                    if (nextdt.Isaudit == DAL.Constant.SynergisnLogDT_Isaudit_True)
                    {
                        log.Cstatus = DAL.Common.SetLogStatus(log.Cstatus, DAL.Constant.SynerginsLog_Cstatus_Complete);
                    }
                    else
                    {
                        log.Cstatus = DAL.Common.SetLogStatus(log.Cstatus, DAL.Constant.SynerginsLog_Cstatus_Wait);
                        break;
                    }
                    List<Model.Synergismlogdt> listnl = logdtbll.GetNext(nextdt, nextdt.OP);
                    MakeLogDT(log, dr, logdtbll, logbll, fdt, listnl);

                }
                catch (Exception ex)
                {
                    dr.ResultNum = DAL.Constant.ResultNum_NormalError;
                    dr.ResultMsg = ex.Message;
                    Log.WriteWinLog(ex.ToString());
                    nextdt.Cstatus = DAL.Constant.SynergisnLogDT_Cstatus_Error;
                    nextdt.Cerrordesc = ex.Message;
                    nextdt.Errortimes++;
                    nextdt.Dmaketime = DateTime.Now;
                    logdtbll.Update(nextdt, nextdt.OP);
                    preDt = logdtbll.GetPrevious(nextdt, nextdt.OP);

                    log.Cstatus = DAL.Common.SetLogStatus(log.Cstatus, DAL.Constant.SynerginsLog_Cstatus_Error);

                }
            }

            return dr;

        }


        /// <summary>
        /// 重做
        /// </summary>
        /// <param name="autoid"></param>
        /// <param name="id"></param>
        public void ReDo(string autoid, string id)
        {
            DAL.SynergismLogDt dal = new DAL.SynergismLogDt();
            Model.Synergismlogdt dt = dal.GetModel(autoid);
            dt.Cstatus = Constant.SynergisnLogDT_Cstatus_NoDeal;
            dt.Cerrordesc = string.Empty;

            //如果有单号,先删除再重发
            if (string.IsNullOrEmpty(dt.Cvoucherno))
            {
                DeleteSyncDt(1,autoid, id);
            }

            dal.Update(dt);
            DAL.SynergismLog logdal = new DAL.SynergismLog();
            Model.Synergismlog log = logdal.GetModel(id);
            log.Cstatus = Constant.SynerginsLog_Cstatus_Dealing;
            logdal.Update(log);
        }

        /// <summary>
        /// 报废
        /// </summary>
        /// <param name="id"></param>
        public void DoScrap(string id)
        {
            DAL.SynergismLog logdal = new DAL.SynergismLog();
            Model.Synergismlog log = logdal.GetModel(id);
            log.Cstatus = Constant.SynerginsLog_Cstatus_Scrap;
            log.Endtime = DateTime.Now;
            logdal.Update(log);
        }


        /// <summary>
        /// 还原 for setting   added by liuxzha 2015.04.10
        /// </summary>
        /// <param name="id"></param>
        public void DoRecover(string id)
        {
            DAL.SynergismLog logdal = new DAL.SynergismLog();
            Model.Synergismlog log = logdal.GetModel(id);
            log.Cstatus = Constant.SynerginsLog_Cstatus_NoDeal;
            log.Endtime = DateTime.Now;
            logdal.Update(log);
        }

        /// <summary>
        /// 判断日志中记录的单据在账套中是否真的存在    added by liuxzha 2015.03.23
        /// 日志查询界面使用
        /// </summary>
        /// <param name="autoid"></param>
        /// <returns> 0 本节点没有生成，子结点也没生成;
        ///           10 本节点生成，子结点没有生成,单据为未审核状态
        ///           11 本节点生成，子结点没有生成,单据为已审核状态
        ///           100 本节点没有生成，子结点已经生成
        ///           110 本节点生成，子结点也已经生成,单据为未审核状态
        ///           111 本节点生成，子结点也已经生成,单据为已审核状态</returns>
        public int ChkExistsInData(string autoid)
        {

            int res = 0;
            //bool bHasCreateChild = false; //在日志中是否已生成子节点

            DAL.SynergismLogDt daldt = new SynergismLogDt();
            BLL.SynergisnLogDT logdtbll = new SynergisnLogDT();
            Model.Synergismlogdt dt = daldt.GetModel(autoid);

            List<Model.Synergismlogdt> nextlist = logdtbll.GetNext(dt, null);

            foreach (Model.Synergismlogdt next in nextlist)
            {
                if (!string.IsNullOrEmpty(next.Cvoucherno))
                {
                    //bHasCreateChild = true;
                    res += 100;
                }

            }

            BaseData bd = ClassFactory.GetBaseData(dt);
            bd.Dodelete = true;
            bd.Synergismlogdt = dt;
            bd.Fristsynergismlogdt = daldt.GetFirst(dt);
            BaseOp op = ClassFactory.GetBaseOp(dt);
            op.MakeData(dt, bd);
            Model.APIData apidata = bd as Model.APIData;
            string vouchid = op.GetCodeorID(dt.Cvoucherno, bd, "id");

            if (!string.IsNullOrEmpty(vouchid))
            {
                res += 10;   //本节点已生成
                if (((APIOp)op).CheckAuditStatus(dt.Cvoucherno, apidata.ConnectInfo.Constring))
                {
                    res += 1;
                }
            }

            return res;
        }



        /// <summary>
        /// 删除
        /// </summary> 
        /// <param name="taskType">任务类别 0 CQ 1 XT</param>
        /// <param name="autoid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public DealResult DeleteSyncDt(int tasktype, string autoid, string id)
        {
            DealResult dr = new DealResult();
            try
            {

                DAL.TaskLogFactory.ITaskLogDetail daldt = ClassFactory.GetITaskLogDetailDAL(tasktype);

                BLL.SynergisnLogDT logdtbll = new SynergisnLogDT();

                Model.Synergismlogdt dt = daldt.GetModel(autoid, null);


                #region 协同 校验
                if (tasktype.Equals("1"))
                {
                    List<Model.Synergismlogdt> nextlist = logdtbll.GetNext(dt, null);

                    foreach (Model.Synergismlogdt next in nextlist)
                    {
                        if (!string.IsNullOrEmpty(next.Cvoucherno))
                        {
                            dr.ResultNum = -1;
                            dr.ResultMsg = "下游单据未删除,请先删除下游单据";
                            return dr;
                        }

                    }
                }
                #endregion

                BaseData bd = ClassFactory.GetBaseData(dt);
                bd.Dodelete = true;
                bd.Synergismlogdt = dt;
                bd.Fristsynergismlogdt = daldt.GetFirst(dt);
                BaseOp op = ClassFactory.GetBaseOp(dt);
                op.MakeData(dt, bd);

                string vouchid = op.GetCodeorID(dt.Cvoucherno, bd, "id");

                if (!string.IsNullOrEmpty(vouchid))
                {
                    dr = op.UndoMake(bd, dt);
                }

                if (dr.ResultNum < Constant.ResultNum_NoError) return dr;
                dt.Cstatus = Constant.SynergisnLogDT_Cstatus_Delete;
                dt.Cvoucherno = string.Empty;
                daldt.Update(dt);
                DAL.SynergismLog logdal = new DAL.SynergismLog();
                Model.Synergismlog log = logdal.GetModel(id);
                log.Cstatus = Constant.SynerginsLog_Cstatus_Wait;
                logdal.Update(log);
            }
            catch (Exception ex)
            {
                dr.ResultMsg = ex.ToString();
                dr.ResultNum = -1;

            }
            return dr;

        }




        /// <summary>
        /// 删除
        /// added by liuxzha 2016.03.08
        /// </summary> 
        /// <param name="taskType">任务类别 0 CQ 1 XT</param>
        /// <param name="autoid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public DealResult DeleteVouch(int tasktype, Synergismlogdt dt)
        {
            DealResult dr = new DealResult();
            try
            {

                DAL.TaskLogFactory.ITaskLogDetail daldt = ClassFactory.GetITaskLogDetailDAL(tasktype); 
                BLL.SynergisnLogDT logdtbll = new SynergisnLogDT();
 


                #region 协同 校验
                if (tasktype.Equals("1"))
                {
                    List<Model.Synergismlogdt> nextlist = logdtbll.GetNext(dt, null);

                    foreach (Model.Synergismlogdt next in nextlist)
                    {
                        if (!string.IsNullOrEmpty(next.Cvoucherno))
                        {
                            dr.ResultNum = -1;
                            dr.ResultMsg = "下游单据未删除,请先删除下游单据";
                            return dr;
                        }

                    }
                }
                #endregion

                BaseData bd = ClassFactory.GetBaseData(dt);
                bd.Dodelete = true;
                bd.Synergismlogdt = dt;
                bd.Fristsynergismlogdt = daldt.GetFirst(dt);
                BaseOp op = ClassFactory.GetBaseOp(dt);
                op.MakeData(dt, bd);

                string vouchid = op.GetCodeorID(dt.Cvoucherno, bd, "id");

                if (!string.IsNullOrEmpty(vouchid))
                {
                    dr = op.UndoMake(bd, dt);
                }

                if (dr.ResultNum < Constant.ResultNum_NoError) return dr;
                dt.Cstatus = Constant.SynergisnLogDT_Cstatus_Delete;
                dt.Cvoucherno = string.Empty;
                daldt.Update(dt);
                DAL.TaskLogFactory.ITaskLogMain logdal = ClassFactory.GetITaskLogMainDAL(tasktype);
                 
 
                Model.Synergismlog log = logdal.GetModel(dt.Id,dt.OP);
                log.Cstatus = Constant.SynerginsLog_Cstatus_Wait;
                logdal.Update(log,dt.OP);
            }
            catch (Exception ex)
            {
                dr.ResultMsg = ex.ToString();
                dr.ResultNum = -1;

            }
            return dr;

        }



    }
}
