using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Interface.Bus.ApiService.Model
{
    public class ShowLog : Synergismlog
    {
        private string cacc_Id;
        /// <summary>
        /// 账套号
        /// </summary>
        public string Cacc_Id
        {
            get { return cacc_Id; }
            set { cacc_Id = value; }
        }

        private string cacc_Name;
        /// <summary>
        /// 账套名
        /// </summary>
        public string Cacc_Name
        {
            get { return cacc_Name; }
            set { cacc_Name = value; }
        }

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


    }
}
