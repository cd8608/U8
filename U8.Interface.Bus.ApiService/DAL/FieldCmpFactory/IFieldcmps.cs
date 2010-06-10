using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Interface.Bus.ApiService.DAL
{
    public interface IFieldcmps
    {
        /// <summary>
        /// 获取字段对照数据
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="pdt"></param>
        /// <returns></returns>
        List<Model.Fieldcmps> GetListFieldcmps(Model.Synergismlogdt dt, Model.Synergismlogdt pdt);
 
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        List<Model.Fieldcmps> GetModelList(string where);
    }
}
