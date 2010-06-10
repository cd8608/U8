using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Interface.Bus.ApiService.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class U8NameValue
    {

        string u8FieldName;
        /// <summary>
        /// 字段名
        /// </summary>
        public string U8FieldName
        {
            get { return u8FieldName; }
            set { u8FieldName = value; }
        }

        string u8FieldValue;
        /// <summary>
        /// 字段值
        /// </summary>
        public string U8FieldValue
        {
            get { return u8FieldValue; }
            set { u8FieldValue = value; }
        }

        string u8FieldDefaultValue;
        /// <summary>
        /// 字段值
        /// </summary>
        public string U8FieldDefaultValue
        {
            get { return u8FieldDefaultValue; }
            set { u8FieldDefaultValue = value; }
        }

        bool isNullAble;
        /// <summary>
        /// 能否为NULL
        /// </summary>
        public bool IsNullAble
        {
            get { return isNullAble; }
            set { isNullAble = value; }
        }

        bool isNull;
        /// <summary>
        /// 是否NULL值
        /// </summary>
        public bool IsNull
        {
            get { return isNull; }
            set { isNull = value; }
        }
    }
}
