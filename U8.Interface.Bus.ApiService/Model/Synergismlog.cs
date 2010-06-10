using System;
using System.Text;
using System.Collections.Generic;
using System.Data;


namespace U8.Interface.Bus.ApiService.Model
{
    //XY_DZ_K7_SYNERGISMLOG
    public class Synergismlog
    {

        /// <summary>
        /// id
        /// </summary>		
        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// cserialno
        /// </summary>		
        private string cserialno;
        public string Cserialno
        {
            get { return cserialno; }
            set { cserialno = value; }
        }
        /// <summary>
        /// croutetype
        /// </summary>		
        private string croutetype;
        public string Croutetype
        {
            get { return croutetype; }
            set { croutetype = value; }
        }
        /// <summary>
        /// caccid
        /// </summary>		
        private string caccid;
        public string Caccid
        {
            get { return caccid; }
            set { caccid = value; }
        }
        /// <summary>
        /// cvouchertype
        /// </summary>		
        private string cvouchertype;
        public string Cvouchertype
        {
            get { return cvouchertype; }
            set { cvouchertype = value; }
        }
        /// <summary>
        /// cvoucherno
        /// </summary>		
        private string cvoucherno;
        public string Cvoucherno
        {
            get { return cvoucherno; }
            set { cvoucherno = value; }
        }
        /// <summary>
        /// starttime
        /// </summary>		
        private DateTime starttime;
        public DateTime Starttime
        {
            get { return starttime; }
            set { starttime = value; }
        }
        /// <summary>
        /// endtime
        /// </summary>		
        private DateTime endtime;
        public DateTime Endtime
        {
            get { return endtime; }
            set { endtime = value; }
        }
        /// <summary>
        /// cstatus
        /// </summary>		
        private string cstatus;
        public string Cstatus
        {
            get { return cstatus; }
            set { cstatus = value; }
        }

        private string opname;

        public string Opname
        {
            get { return opname; }
            set { opname = value; }
        }

        private string acc_id;
        /// <summary>
        /// 账套号
        /// </summary>
        public string Acc_id
        {
            get { return acc_id; }
            set { acc_id = value; }
        }

        private string accname;
        /// <summary>
        /// 账套名
        /// </summary>
        public string Accname
        {
            get { return accname; }
            set { accname = value; }
        }

        /// <summary>
        /// 任务类型
        /// added by liuxzha 0 mes task 1 coroperation task
        /// 默认为协同任务
        /// </summary>
        private int taskType = 1;
        public int TaskType
        {
            get { return taskType; }
            set { taskType = value; }
        }

        /// <summary>
        /// 任务类名
        /// </summary>
        private string opClass;
        public string OPClass
        {
            get { return opClass; }
            set { opClass = value; }
        }

        /// <summary>
        /// 任务操作对象
        /// </summary>
        private BLL.BaseOp op;
        public BLL.BaseOp OP
        {
            get { return op; }
            set { op = value; }
        }
    }
}

