using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Interface.Bus.ApiService.DAL
{
    public interface IFieldcmp
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Model.Fieldcmp GetModel(string where);
    }
}
