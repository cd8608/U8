using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace U8.Interface.Bus.ApiService.Model
{
    //XY_DZ_K7_SYNERGISMLOGDT
    public class Synergismlogdt
    {

        /// <summary>
        /// autoid
        /// </summary>		
        private string autoid;
        /// <summary>
        /// 子表id
        /// </summary>
        public string Autoid
        {
            get { return autoid; }
            set { autoid = value; }
        }
        /// <summary>
        /// 主表 id
        /// </summary>		
        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// ilineno
        /// </summary>		
        private int ilineno;
        public int Ilineno
        {
            get { return ilineno; }
            set { ilineno = value; }
        }

        /// <summary>
        /// accid协同平台账套注册编号
        /// </summary>		
        private string accid;
        public string Accid
        {
            get { return accid; }
            set { accid = value; }
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
        /// cpk
        /// </summary>		
        private string cpk;
        public string Cpk
        {
            get { return cpk; }
            set { cpk = value; }
        }
        /// <summary>
        /// dinputtime
        /// </summary>		
        private DateTime dinputtime;
        public DateTime Dinputtime
        {
            get { return dinputtime; }
            set { dinputtime = value; }
        }
        /// <summary>
        /// dmaketime
        /// </summary>		
        private DateTime dmaketime;
        public DateTime Dmaketime
        {
            get { return dmaketime; }
            set { dmaketime = value; }
        }
        /// <summary>
        /// cerrordesc
        /// </summary>		
        private string cerrordesc;
        public string Cerrordesc
        {
            get { return cerrordesc; }
            set { cerrordesc = value; }
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
        /// <summary>
        /// ismanual
        /// </summary>		
        private int ismanual;
        public int Ismanual
        {
            get { return ismanual; }
            set { ismanual = value; }
        }

        private string ismanualc;
        public string Ismanualc
        {
            get { return ismanualc; }
            set { ismanualc = value; }
        }


        /// <summary>
        /// isaudit
        /// </summary>		
        private int isaudit;
        public int Isaudit
        {
            get { return isaudit; }
            set { isaudit = value; }
        }

        /// <summary>
        /// isaudit
        /// </summary>		
        private string isauditc;
        public string Isauditc
        {
            get { return isauditc; }
            set { isauditc = value; }
        }
        /// <summary>
        /// errortimes
        /// </summary>		
        private int errortimes;
        public int Errortimes
        {
            get { return errortimes; }
            set { errortimes = value; }
        }


        /// <summary>
        /// cdealmothed
        /// 处理方式:  0(自动生单/自动审核) 1增 2修改 3删 ..
        /// </summary>		
        private int cdealmothed;
        public int Cdealmothed
        {
            get { return cdealmothed; }
            set { cdealmothed = value; }
        }


        /// <summary>
        /// cdealmothed
        /// 目前的处理方式: 0(自动生单/自动审核) 1增 2修改 3删 ..
        /// </summary>		
        private string cdealmothedc;
        public string Cdealmothedc
        {
            get { return cdealmothedc; }
            set { cdealmothedc = value; }
        }


        private string opname = "";
        public string Opname
        {
            get { return opname; }
            set { opname = value; }
        }

        private string cvouchertypename = "";

        public string Cvouchertypename
        {
            get { return cvouchertypename; }
            set { cvouchertypename = value; }
        }

        private string acc_id;
        /// <summary>
        /// U8账套号  
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

        private int fatherid; 
        public int Fatherid
        {
            get { return fatherid; }
            set { fatherid = value; }
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



        /// <summary>
        /// 任务类型
        /// added by liuxzha 0 mes task 1 coroperation task  2 ds
        /// 默认为协同任务
        /// </summary>
        private int taskType = 1;
        public int TaskType
        {
            get { return taskType; }
            set { taskType = value; }
        }

    }
}

