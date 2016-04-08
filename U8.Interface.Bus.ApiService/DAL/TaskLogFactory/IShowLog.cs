using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace U8.Interface.Bus.ApiService.DAL.TaskLogFactory
{
    /// <summary>
    /// 主日志
    /// </summary>
    public interface IShowLog
    { 
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        /// <param name="Top"></param>
        /// <param name="strWhere"></param>
        /// <param name="order"></param>
        /// <param name="ascOrDesc"></param>
        /// <returns></returns>
        DataSet GetList(string Top, string strWhere, string order, string ascOrDesc);

        /// <summary>
        /// 获取导出数据
        /// </summary>
        /// <param name="isList"></param>
        /// <param name="Top"></param>
        /// <param name="strWhere"></param>
        /// <param name="order"></param>
        /// <param name="ascOrDesc"></param>
        /// <returns></returns>
        DataSet GetOutputInfo(bool isList, string Top, string strWhere, string order, string ascOrDesc);

        /// <summary>
        /// 获取档案名称
        /// </summary>
        /// <param name="cVoucerType"></param>
        /// <param name="cVoucherNo"></param>
        /// <returns></returns>
        string GetDataName(string cVoucerType, string cVoucherNo);

    }
}
