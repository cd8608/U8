using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Interface.Bus.ApiService.Model
{
    public class ShowLogDt : Synergismlogdt
    {

        private string caddress;
        /// <summary>
        /// 数据服务器
        /// </summary>
        public string Caddress
        {
            get { return caddress; }
            set { caddress = value; }
        }

        private string cDataName;
        /// <summary>
        /// 档案名称
        /// </summary>
        public string CDataName
        {
            get { return cDataName; }
            set { cDataName = value; }
        }

        private string cpkName;
        /// <summary>
        /// 更新方案名
        /// </summary>
        public string CpkName
        {
            get { return cpkName; }
            set { cpkName = value; }
        }
    }
}
