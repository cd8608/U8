using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Interface.Bus.ApiService.BLL.TaskLogFactory
{
    /// <summary>
    /// 日志查看器 详细日志BLL
    /// </summary>
    public interface IShowLogDt
    {

        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Model.ShowLogDt> GetModelList(string Top, string strWhere, string order, string ascOrDesc);
    }
}
