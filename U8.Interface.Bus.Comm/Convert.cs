using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Interface.Bus.Comm
{
    public class Convert
    {


        #region  

        /// <summary>
        /// 根据字段在数据库中的类型,装饰字段值
        /// </summary>
        /// <param name="fieldValue">数据库数据类型</param>
        /// <param name="fieldType"></param>
        /// <returns></returns>
        public static string ConvertDbValueString(string fieldValue,string fieldType)
        {
            string res = "";
            switch (fieldType)
            {
                case "bit":
                    if (fieldValue.ToLower().Equals("true") || fieldValue.ToLower().Equals("1"))
                    {
                        res = "1";
                    }
                    else
                    {
                        res = "0";
                    }
                    break;

                case "float":
                case "int":
                case "numeric":
                case "tinyint":
                    if (string.IsNullOrEmpty(fieldValue))
                    {
                        res = "null";
                    }
                    else
                    {
                        res = "'" + fieldValue + "'";
                    }
                    break;

                case "uniqueidentifier":
                    if (string.IsNullOrEmpty(fieldValue))
                    {
                        res = "null";
                    }
                    else
                    {
                        res = "'" + fieldValue + "'";
                    }
                    break; 
                case "@@":  //数据库变量
                    res = fieldValue;
                    break;
                case "##":  //程序变量
                    res = "'" + fieldValue + "'";
                    break;

                default:    //datetime  nchar  nvarchar ufmedia ufreference uniqueidentifier
                    res = "'" + fieldValue + "'";
                    break;
            }

            return res;
        }

        /// <summary>
        /// 组织where语句
        /// </summary>
        /// <param name="colNames"></param>
        /// <param name="colValues"></param>
        /// <returns></returns>
        public static string ConvertDbWhere(string colNames, string colValues)
        {
            string where = "";
            string[] colNameArray = colNames.Split(',');

            if (colNameArray.Length > 1)
            {
                string[] colValueArray = colValues.Split(',');
                if (colNameArray.Length != colValueArray.Length)
                    throw new System.Exception("删除列与传入值个数不匹配");
                where = "";
                for (int i = 0; i < colNameArray.Length; i++)
                {
                    where += (where.Equals("") ? "" : " AND ") + " " + colNameArray[i] + "= '" + colValueArray[i] + "'";
                }
            }
            else
            {
                where = colNames + " = '" + colValues + "' ";
            }

            return where;
        }

        #endregion

        /// <summary>
        /// 根据字段在程序中的类型,装饰字段值
        /// </summary>
        /// <param name="fieldValue">数据库数据类型</param>
        /// <param name="fieldType"></param>
        /// <returns></returns>
        public static string ConvertDbValueFromPro(string fieldValue, string fieldType)
        {
            string res = "";
            switch (fieldType)
            {  
                case "string":
                    if (string.IsNullOrEmpty(fieldValue))
                    {
                        res = "null";
                    }
                    else if (fieldValue.ToLower().Equals("true"))
                    {
                        res = "1";
                    }
                    else if (fieldValue.ToLower().Equals("false"))
                    {
                        res = "0";
                    }
                    else
                    {
                        res = "'" + fieldValue + "'";
                    }
                    break;
                     
                case "int":
                case "float":
                case "decimal":
                    if (string.IsNullOrEmpty(fieldValue))
                    {
                        res = "null";
                    }
                    else
                    {
                        res = "'" + fieldValue + "'";
                    }
                    break; 
                case "guid":
                    if (string.IsNullOrEmpty(fieldValue))
                    {
                        res = "null";
                    }
                    else
                    {
                        res = "'" + fieldValue + "'";
                    }
                    break;
                case "@@":  //数据库变量
                    res = fieldValue;
                    break;
                case "##":  //程序变量
                    res = "'" + fieldValue + "'";
                    break;
                default:    //datetime  nchar  nvarchar ufmedia ufreference uniqueidentifier
                    res = "'" + fieldValue + "'";
                    break;
            }

            return res;
        }


    }
}
