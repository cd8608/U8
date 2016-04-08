using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Interface.Bus.ApiService.BLL.Task
{
    public interface ITaskLogMain 
    {
        int Update(Model.Synergismlog log, BaseOp op);
    }
}
