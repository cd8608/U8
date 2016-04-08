using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace U8.Interface.Bus.ApiService.BLL.TaskLogFactory
{
    /// <summary>
    /// 日志查看器 主日志BLL
    /// </summary>
    public interface IShowLog
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        List<Model.ShowLog> GetModelList(string Top, string strWhere, string order, string ascOrDesc);
        /// <summary>
        /// 获取导出数据
        /// </summary>
        DataSet GetOutputInfo(bool isList, string Top, string strWhere, string order, string ascOrDesc);
    }
}
