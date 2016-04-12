using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Interface.Bus.ApiService.Model.TaskLogFactory.CQ
{
    public class ShowLog : Model.ShowLog
    { 

        /// <summary>
        /// 单据号(类型)
        /// </summary>
        private string cvouchertypecode;
        /// <summary>
        /// CardNo
        /// </summary>
        public string CVouchertypeCode
        {
            get { return cvouchertypecode; }
            set { cvouchertypecode = value; }
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        private string cerrordesc;
        public string CErrordesc
        {
            get { return cerrordesc; }
            set { cerrordesc = value; }
        }
    }
}
