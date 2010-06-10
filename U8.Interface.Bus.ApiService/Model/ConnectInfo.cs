using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Interface.Bus.ApiService.Model
{
    public class ConnectInfo
    {


        string subId;
        /// <summary>
        /// 模块号
        /// </summary>
        public string SubId
        {
            get { return subId; }
            set { subId = value; }
        }
        string userId;
        /// <summary>
        /// 登陆用户
        /// </summary>
        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        string source;
        /// <summary>
        /// 数据源
        /// </summary>
        public string Source
        {
            get { return source; }
            set { source = value; }
        }

        string accId;
        /// <summary>
        /// 账套号
        /// </summary>
        public string AccId
        {
            get { return accId; }
            set { accId = value; }
        }
        string yearId;
        /// <summary>
        /// 登陆年度
        /// </summary>
        public string YearId
        {
            get { return yearId; }
            set { yearId = value; }
        }
        string password;
        /// <summary>
        /// 登陆密码
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        string date;
        /// <summary>
        /// 登陆日期
        /// </summary>
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        string srv;
        /// <summary>
        /// 数据库服务器
        /// </summary>
        public string Srv
        {
            get { return srv; }
            set { srv = value; }
        }
        string ssrv;
        /// <summary>
        /// 应用服务器 add by wangdd
        /// </summary>
        public string sSrv
        {
            get { return ssrv; }
            set { ssrv = value; }
        }
        string serial;
        /// <summary>
        /// 登陆标识
        /// 一般为MAC地址@0
        /// 每一个不同的标识占用一个登陆站点
        /// </summary>
        public string Serial
        {
            get { return serial; }
            set { serial = value; }
        }

        bool bEnable;
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool BEnable
        {
            get { return bEnable; }
            set { bEnable = value; }
        }

        private string constring;
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string Constring
        {
            get { return constring; }
            set { constring = value; }
        }
    }
}
