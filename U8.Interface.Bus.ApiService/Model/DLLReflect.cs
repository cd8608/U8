using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Interface.Bus.ApiService.Model
{
    public class DLLReflect
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string cvouchertype;

        public string Cvouchertype
        {
            get { return cvouchertype; }
            set { cvouchertype = value; }
        }

        private string dllpath;

        public string Dllpath
        {
            get { return dllpath; }
            set { dllpath = value; }
        }

        private string npace;

        public string Npace
        {
            get { return npace; }
            set { npace = value; }
        }

        private string className;

        public string ClassName
        {
            get { return className; }
            set { className = value; }
        }

        private string classType;

        public string ClassType
        {
            get { return classType; }
            set { classType = value; }
        }


        private int tasktype;
        public int TaskType
        {
            get { return tasktype; }
            set { tasktype = value; }
        }

    }
}