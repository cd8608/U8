using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Interface.Bus.ApiService.Model
{
    public class Task
    {
        public VoucherType VouchType;
        public string id; // public int id;   //任务主表id
        public int OperType;   //增删改 0 1 2
        public int taskType;   //任务类型  0 CQ接口任务, 1 协同任务  2 DS任务
        public BLL.BaseOp op;  //任务操作对象
    }
}
