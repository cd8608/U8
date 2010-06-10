using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;
using UFIDA.U8.MomServiceCommon;
using UFIDA.U8.U8MOMAPIFramework;
using UFIDA.U8.U8APIFramework;
using UFIDA.U8.U8APIFramework.Meta;
using UFIDA.U8.U8APIFramework.Parameter;
using MSXML2;
using System.Data;
using System.Diagnostics;
using U8.Interface.Bus.ApiService.Model;
using U8.Interface.Bus.DBUtility;

namespace U8.Interface.Bus.ApiService.BLL
{
    public abstract class APIOp:BaseOp
    {


        //设置api地址
        public abstract string SetApiAddressAdd();
        public abstract string SetApiAddressAudit();
        public abstract string SetApiAddressCancelAudit();
        public abstract string SetApiAddressDelete();
        public abstract string SetApiAddressLoad();
        public abstract string SetApiAddressUpdate();


        /// <summary>
        /// 当前单据 主表  表名
        /// </summary>
        /// <returns></returns>
        public abstract string SetTableName();
        public abstract void SetApiContext(U8EnvContext envContext); 
        public abstract bool CheckAuditStatus(string strVoucherNo, string strConn);


        //获取上一节点单据 表头 数据
        public abstract DataSet SetFromTabet(Model.Synergismlogdt dt, Model.Synergismlogdt pdt, Model.APIData apidata);
        //获取上一节点单据 表体 数据
        public abstract DataSet SetFromTabets(Model.Synergismlogdt dt, Model.Synergismlogdt pdt, Model.APIData apidata);


        public abstract Model.DealResult BrokerInvoker(U8ApiBroker broker);

        /// <summary>
        /// 获取Login对象
        /// </summary>
        /// <param name="bd"></param>
        /// <param name="u8Login"></param>
        /// <returns></returns>
        public Model.DealResult GetU8Login(Model.APIData bd, U8Login.clsLogin u8Login)
        {
            Model.DealResult dr = new Model.DealResult();

            #region 判断格式
            string strErr = ",请在［账套档案注册］模块中更新!";
            if (string.IsNullOrEmpty(bd.ConnectInfo.UserId))
            {
                dr.ResultMsg = "默认操作员不能为空" + strErr;
                dr.ResultNum = -1;
                Marshal.FinalReleaseComObject(u8Login);
                throw new Exception(dr.ResultMsg);
            }
            if (string.IsNullOrEmpty(bd.ConnectInfo.Source))
            {
                dr.ResultMsg = "数据源不能为空" + strErr;
                dr.ResultNum = -1;
                Marshal.FinalReleaseComObject(u8Login);
                throw new Exception(dr.ResultMsg);
            }
            if (string.IsNullOrEmpty(bd.ConnectInfo.AccId))
            {
                dr.ResultMsg = "账套号不能为空" + strErr;
                dr.ResultNum = -1;
                Marshal.FinalReleaseComObject(u8Login);
                throw new Exception(dr.ResultMsg);
            }
            if (string.IsNullOrEmpty(bd.ConnectInfo.Srv))
            {
                dr.ResultMsg = "服务器地址不能为空" + strErr;
                dr.ResultNum = -1;
                Marshal.FinalReleaseComObject(u8Login);
                throw new Exception(dr.ResultMsg);
            }
            if (string.IsNullOrEmpty(bd.ConnectInfo.YearId))
            {
                dr.ResultMsg = "登陆年度不能为空" + strErr;
                dr.ResultNum = -1;
                Marshal.FinalReleaseComObject(u8Login);
                throw new Exception(dr.ResultMsg);
            }
            else
            {
                try { int.Parse(bd.ConnectInfo.YearId); }
                catch
                {
                    dr.ResultMsg = "登陆年度格式错误：" + bd.ConnectInfo.YearId + strErr;
                    dr.ResultNum = -1;
                    Marshal.FinalReleaseComObject(u8Login);
                    throw new Exception(dr.ResultMsg);
                }
            }
            DbHelperSQLP dsp = new DbHelperSQLP(bd.ConnectInfo.Constring);
            string strSql = "SELECT 1 FROM UFSystem.dbo.UA_AccountDatabase A JOIN UFSystem.dbo.UA_Account B ON A.cAcc_Id=B.cAcc_Id WHERE A.cAcc_Id='" + bd.ConnectInfo.AccId + "' ";
            if (!dsp.Exists(strSql))
            {
                dr.ResultMsg = "登陆失败，原因：账套 " + bd.ConnectInfo.AccId + " 在 " + bd.ConnectInfo.Srv + " 上不存在";
                dr.ResultNum = -1;
                Marshal.FinalReleaseComObject(u8Login);
                throw new Exception(dr.ResultMsg);
            }
            #endregion

            string subId = U8.Interface.Bus.SysInfo.subId;
            string userId = bd.ConnectInfo.UserId;
            string accId = bd.ConnectInfo.Source + "@" + bd.ConnectInfo.AccId;
            string yearId = bd.ConnectInfo.YearId;
            string password = bd.ConnectInfo.Password;
            string date = bd.ConnectInfo.Date;
            string srv = bd.ConnectInfo.sSrv;
            string serial = bd.ConnectInfo.Serial;


            #region 20140814

            #endregion

            if (!u8Login.Login(ref subId, ref accId, ref yearId, ref userId, ref password, ref date, ref srv, ref serial))
            {
                dr.ResultMsg = "登陆失败，原因：" + u8Login.ShareString;
                if (u8Login.ShareString.IndexOf("年度") > 0 || u8Login.ShareString.IndexOf("日期") > 0) dr.ResultMsg += " - " + date;
                dr.ResultNum = -1;
                Marshal.FinalReleaseComObject(u8Login);
                throw new Exception(dr.ResultMsg);
            }

            return dr;
        }



        /// <summary>
        /// 获取apibroker
        /// </summary>
        /// <param name="apidata"></param>
        /// <param name="u8Login"></param>
        /// <param name="broker"></param>
        /// <returns></returns>
        public Model.DealResult GetU8ApiBroker(Model.APIData apidata, U8Login.clsLogin u8Login, out  U8ApiBroker broker, string op)
        {
            broker = null;
            Model.DealResult dr = new Model.DealResult();
            
            switch (op)
            {
                case "add":
                    apidata.ApiAddress = SetApiAddressAdd();
                    break;
                case "delete":
                    apidata.ApiAddress = SetApiAddressDelete();
                    break;
                case "audit":
                    apidata.ApiAddress = SetApiAddressAudit();
                    break;
                case "load":
                    apidata.ApiAddress = SetApiAddressLoad();
                    break;
                case "cancelaudit":
                    apidata.ApiAddress = SetApiAddressCancelAudit();
                    break;
                case "update":
                    apidata.ApiAddress = SetApiAddressUpdate();
                    break;
            }


            try
            {
                U8EnvContext envContext = new U8EnvContext();
                envContext.U8Login = u8Login;
                SetApiContext(envContext);
                U8ApiAddress myApiAddress = new U8ApiAddress(apidata.ApiAddress);
                broker = new U8ApiBroker(myApiAddress, envContext);
            }
            catch (Exception ex)
            {
                dr.ResultNum = -1;
                dr.ResultMsg = ex.ToString();
                throw new Exception(dr.ResultMsg);
            } 
            return dr;
        }


        /// <summary>
        /// 清除Login对象占用任务
        /// </summary>
        /// <param name="strConn"></param>
        protected void ClearUATask(BaseData bd)
        {
            DbHelperSQLP dsp = new DbHelperSQLP(bd.ConnectInfo.Constring);
            string sql = string.Format("DELETE UFSystem..ua_Task WHERE cStation='{0}' AND cUser_Id='{1}' AND cAcc_Id='{2}' ", bd.ConnectInfo.Srv, bd.ConnectInfo.UserId, bd.ConnectInfo.AccId);
            dsp.ExecuteSql(sql);
        }


        /// <summary>
        /// 更新协同路线字段
        /// </summary>
        /// <param name="bd"></param>
        /// <param name="dr"></param>
        protected void UpdateTeamworkField(BaseData bd, Model.DealResult dr)
        {
            if (bd.TaskType == 1)
            {
                DAL.SynergismLog logdal = new DAL.SynergismLog();
                Model.Synergismlog logmdoel = logdal.GetModel(bd.Synergismlogdt.Id);
                string tablename = SetTableName() + "_extradefine";
                DAL.Common.UpdateTeamworkField(logmdoel.Croutetype, tablename, dr.VouchIdRet, bd.ConnectInfo.Constring);

            }
        }



        /// <summary>
        /// 组织数据
        /// </summary>
        /// <param name="dt">当前任务节点信息</param>
        /// <param name="bd">HY_DZ_K7_DLLReflect 中预置的 data类</param>
        /// <returns></returns>
        public override Model.DealResult MakeData(Model.Synergismlogdt dt, BaseData bd)
        {
            Model.DealResult dr = new Model.DealResult();
            Model.APIData apidata = bd as Model.APIData;         //API实体,包括当前任务节点信息
            DAL.TaskLogFactory.ITaskLogDetail dtdal;

            //当前任务节点信息
            switch (apidata.TaskType)
            {
                case 0:
                    dtdal = new DAL.CQTaskDetail();
                    break;
                case 1:
                    dtdal = new DAL.SynergismLogDt();
                    break;
                case 2:
                    dtdal = new DAL.DS.TaskDetail();
                    break;
                default:
                    BLL.Common.ErrorMsg(SysInfo.productName, "tasktype" + apidata.TaskType + "未适配!");
                    dr.Message = "tasktype" + apidata.TaskType + "未适配!";
                    return dr;

            }

            Model.Synergismlogdt pdt = dtdal.GetPrevious(dt);      //上一任务节点信息

            apidata.ConnectInfo = dtdal.GetConnectInfo(dt);   //获取当前结点的数据串连接串
            apidata.Synergismlogdt = dt;

            if (!apidata.Dodelete)
            {
                DataSet rdds = SetFromTabet(dt, pdt, apidata);    //上一节点 单据头信息
                DataSet rdsds = SetFromTabets(dt, pdt, apidata);  //上一节点 单据体信息

                DAL.IFieldcmps fieldcmpdal = ClassFactory.GetIFieldcmpsDAL(apidata.TaskType); //new DAL.Fieldcmps();
                List<Model.Fieldcmps> listfd = fieldcmpdal.GetListFieldcmps(dt, pdt);   //字段对照信息
                BLL.U8NameValue u8namevaluebll = new BLL.U8NameValue();  //字段赋值
                u8namevaluebll.SetHeadData(apidata, rdds, rdsds, listfd, dt);
                u8namevaluebll.SetBodyData(apidata, rdds, rdsds, listfd, dt);

                //设置订单关联    
                DAL.Common.SetInBody(apidata);
                SetNormalValue(apidata, dt);
            }
            return dr;
        }



        /// <summary>
        /// 设置通用变量
        /// </summary>
        /// <param name="apidata"></param>
        /// <param name="dt"></param>
        public virtual void SetNormalValue(Model.APIData apidata, Model.Synergismlogdt dt)
        {
            DAL.APINormal.SetNormalValue(apidata, dt);
        }

  
    }
}
