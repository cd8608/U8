using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Interface.Bus.Event.SyncAdapter.Biz
{


    /// <summary>
    /// 操作实体
    /// </summary>
    public class BaseMode
    {

        /// <summary>
        /// 列名
        /// </summary>
        private string ufColumnName;
        public string UfColumnName
        {
            get { return ufColumnName; }
            set { ufColumnName = value; }
        }


        /// <summary>
        /// 列值
        /// </summary>
        private string ufColumnValue;
        public string UfColumnValue
        {
            get { return ufColumnValue; }
            set { ufColumnValue = value; }
        }


        /// <summary>
        /// 来源表数据类型
        /// </summary>
        private string ufFieldType;
        public string UfFieldType
        {
            get { return ufFieldType; }
            set { ufFieldType = value; }
        }

        /// <summary>
        /// 取值方法
        /// </summary>
        private string valueType;
        public string ValueType
        {
            get { return valueType; }
            set { valueType = value; }
        }


        /// <summary>
        /// 取值表达式
        /// </summary>
        private string domRoute;
        public string DomRoute
        {
            get { return domRoute; }
            set { domRoute = value; }
        }

 
        /// <summary>
        /// 目标数据库列名
        /// </summary>
        private string orColumnName;
        public string OrColumnName
        {
            get { return orColumnName; }
            set { orColumnName = value; }
        }


        /// <summary>
        /// 目标数据库列值
        /// </summary>
        private string orColumnValue;
        public string OrColumnValue
        {
            get { return orColumnValue; }
            set { orColumnValue = value; }
        }

        /// <summary>
        /// 目标表字段数据类型
        /// </summary>
        private string orFieldType;
        public string OrFieldType
        {
            get { return orFieldType; }
            set { orFieldType = value; }
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ufColumnName"></param>
        /// <param name="ufColumnValue"></param>
        /// <param name="domRoute"></param>
        /// <param name="orColumnName"></param>
        /// <param name="orColumnValue"></param>
        public BaseMode(string ufColumnName, string ufColumnValue, string domRoute, string orColumnName, string orColumnValue, string ufFieldType,string orFieldType)
        {
            this.ufColumnName = ufColumnName;
            this.ufColumnValue = ufColumnValue;
            this.domRoute = domRoute;
            this.orColumnName = orColumnName;
            this.orColumnValue = orColumnValue;

            this.ufFieldType = ufFieldType;
            this.orFieldType = orFieldType;
            
        }

    }
}
