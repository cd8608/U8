using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Interface.Bus.ApiService.Model
{
    public  class DealResult
    {

        private string resultMsg;

        public string ResultMsg
        {
            get { return resultMsg; }
            set { resultMsg = value; }
        }

        private int resultNum;

        public int ResultNum
        {
            get { return resultNum; }
            set { resultNum = value; }
        }

        private string vouchIdRet;

        public string VouchIdRet
        {
            get { return vouchIdRet; }
            set { vouchIdRet = value; }
        }
        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
    }
}
