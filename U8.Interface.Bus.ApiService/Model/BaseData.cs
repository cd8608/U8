using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 

namespace U8.Interface.Bus.ApiService.Model
{

    /// <summary>
    /// HY_DZ_K7_DLLReflect 中预置的 Data类信息
    /// 包括:连接信息，当前任务结点信息，第一任务节点信息，是否删除标识
    /// </summary>
    public class BaseData
    {

        public BaseData()
        { 
        }

        public BaseData(int tasktype)
        {
            this.tasktype = tasktype;
        }



        private ConnectInfo connectInfo;

        public ConnectInfo ConnectInfo
        {
            get { return connectInfo; }
            set { connectInfo = value; }
        }


        private Model.Synergismlogdt synergismlogdt;

        public Model.Synergismlogdt Synergismlogdt
        {
            get { return synergismlogdt; }
            set { synergismlogdt = value; }
        }

        private Model.Synergismlogdt fristsynergismlogdt;

        public Model.Synergismlogdt Fristsynergismlogdt
        {
            get { return fristsynergismlogdt; }
            set { fristsynergismlogdt = value; }
        }



        /// <summary>
        /// 真为删除单据
        /// </summary>
        private bool dodelete; 
        public bool Dodelete
        {
            get { return dodelete; }
            set { dodelete = value; }
        }


        private string orderPrefix;

        public string OrderPrefix
        {
            get { return orderPrefix; }
            set { orderPrefix = value; }
        }



        /// <summary>
        /// 任务类型  :0 CQ 1 XT 2 DS
        /// </summary>
        private int tasktype;
        public int TaskType
        {
            get { return tasktype; }
            set { tasktype = value; }
        }



    }
}