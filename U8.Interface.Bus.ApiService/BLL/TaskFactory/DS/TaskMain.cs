using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Interface.Bus.ApiService.BLL.Task.Factory.DS
{
    public class TaskMain : ITaskLogMain
    {

        public int Update(Model.Synergismlog log,BaseOp op)
        {
            return op.Update(log);
        }

    }
}
