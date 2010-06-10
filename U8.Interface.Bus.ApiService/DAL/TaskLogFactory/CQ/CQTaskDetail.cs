using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using U8.Interface.Bus.DBUtility;

namespace U8.Interface.Bus.ApiService.DAL
{
    /// <summary>
    /// HY_DZ_K7_SYNERGISMLOGDT
    /// 
    /// </summary>
    public partial class CQTaskDetail : DAL.TaskLogFactory.ITaskLogDetail
    {
          

        public string getConnStr(Model.Synergismlogdt dt)
        {
            DAL.Regist rdal = new Regist();
            Model.Regist rmdoel = rdal.GetModel(dt.Accid);
            if (rmdoel != null)
            {
                return string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID=sa;Password={2};Current Language=Simplified Chinese", rmdoel.Caddress, rmdoel.Caccname, rmdoel.Cdbpwd);
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 获取当前结点的数据串连接串
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public Model.ConnectInfo GetConnectInfo(Model.Synergismlogdt dt)
        {
            Model.Regist rmdoel = new U8.Interface.Bus.ApiService.Model.Regist();
            rmdoel.Cservername = U8.Interface.Bus.Config.ConfigUtility.U8AppSrv;  //string dbname = Comm.RegistryKeyHelp.getValueRegEdit(SysInfo.u8path, "dbname");
            rmdoel.Cacc_id = U8.Interface.Bus.Config.ConfigUtility.U8AppAcc;  //"888";
            rmdoel.Cuser_id = U8.Interface.Bus.Config.ConfigUtility.U8AppUser;  // string username = Comm.RegistryKeyHelp.getValueRegEdit(SysInfo.u8path, "username");
            rmdoel.Cmaker = U8.Interface.Bus.Config.ConfigUtility.U8AppUser;  
            rmdoel.Cpassword = U8.Interface.Bus.Config.ConfigUtility.U8AppPwd;  // Comm.RegistryKeyHelp.getValueRegEdit(SysInfo.u8path, "pwd");   pwd = Comm.DESEncrypt.Decrypt(pwd);
            rmdoel.Benable = "1";
            rmdoel.Datasource = "(default)";

            rmdoel.Caccname = U8.Interface.Bus.Config.ConfigUtility.DataBaseCatalog; // ConfigurationManager.AppSettings["dbcatalogname"];   //UFDATA_888_2015
            rmdoel.Cdbpwd = U8.Interface.Bus.Comm.DESEncrypt.Decrypt(U8.Interface.Bus.Config.ConfigUtility.DataBasePwd); // ConfigurationManager.AppSettings["dbpwd"];
            rmdoel.Caddress = U8.Interface.Bus.Config.ConfigUtility.DataBaseSrv; // ConfigurationManager.AppSettings["dbserver"];

            if (rmdoel != null)
            {

                Model.ConnectInfo cimodel = new Model.ConnectInfo();
                cimodel.AccId = rmdoel.Cacc_id;
                cimodel.Source = rmdoel.Datasource;
                cimodel.Password = rmdoel.Cpassword;
                cimodel.Srv = rmdoel.Caddress;
                //应用服务器 add by wangdd
                cimodel.sSrv = rmdoel.Cservername;
                cimodel.SubId = "DP";  //测试
                cimodel.UserId = rmdoel.Cuser_id;
                cimodel.YearId = DateTime.Now.ToString("yyyy"); //rmdoel.Ibeginyear.ToString();
                cimodel.Serial = BLL.Common.GetSerial();
                cimodel.BEnable = rmdoel.Benable == "1" || rmdoel.Benable == "是";
                cimodel.Constring = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID=sa;Password={2};Current Language=Simplified Chinese", rmdoel.Caddress, rmdoel.Caccname, rmdoel.Cdbpwd);
                //cimodel.Date = BLL.Common.GetVerifyData(dt);
                //if (cimodel.Date == DateTime.Now.ToString("yyyy-MM-dd")) cimodel.Date = BLL.Common.GetLoginDate(rmdoel);
                cimodel.Date = DateTime.Now.ToString("yyyy-MM-dd");
                return cimodel;

            }
            return null;

        }

         

        public Model.ConnectInfo getConnectStr(Model.Synergismlogdt dt)
        {

            DAL.Regist rdal = new Regist();
            Model.Regist rmdoel = rdal.GetModel(dt.Accid);
            if (rmdoel != null)
            {

                Model.ConnectInfo cimodel = new Model.ConnectInfo();
                cimodel.AccId = rmdoel.Cacc_id;
                cimodel.Source = rmdoel.Datasource;
                cimodel.Password = rmdoel.Cpassword;
                cimodel.Srv = rmdoel.Caddress;
                //应用服务器 add by wangdd
                cimodel.sSrv = rmdoel.Cservername;
                cimodel.SubId = "DP";  //测试
                cimodel.UserId = rmdoel.Cuser_id;
                cimodel.YearId = rmdoel.Ibeginyear.ToString();
                cimodel.Serial = BLL.Common.GetSerial();
                cimodel.BEnable = rmdoel.Benable == "1" || rmdoel.Benable == "是";
                cimodel.Constring = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID=sa;Password={2};Current Language=Simplified Chinese", rmdoel.Caddress, rmdoel.Caccname, rmdoel.Cdbpwd);

                return cimodel;

            }
            return null;


        }



        /// <summary>
        /// 获取上一条
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public Model.Synergismlogdt GetModel(string autoid, BLL.BaseOp op)
        { 
            return op.GetModel(autoid);
        }


        /// <summary>
        /// 获取上一条
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public Model.Synergismlogdt GetPrevious(Model.Synergismlogdt dt)
        {
            return dt.OP.GetPrevious(dt);
        }

        /// <summary>
        /// 获取第一条数据
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public Model.Synergismlogdt GetFirst(Model.Synergismlogdt dt)
        {
            return dt.OP.GetFirst(dt);
        }

        /// <summary>
        /// 获取第一条数据
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int Update(Model.Synergismlogdt dt)
        {
            return dt.OP.Update(dt);
        }


    }
}

