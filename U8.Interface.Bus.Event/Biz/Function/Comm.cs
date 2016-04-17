using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace U8.Interface.Bus.Event.SyncAdapter.Biz.Function
{
    class Comm
    {
        /// <summary>
        /// 1
        /// 传入操作类型，返回操作标识
        /// </summary>
        /// <param name="operflag"></param>
        /// <returns></returns>
        public static string GetFlagByOper(string opertype)
        {
            if (opertype.ToLower().Equals("d"))
            {
                return "D";
            }
            else
            {
                return "W";
            }
        }


        /// <summary>
        /// 2
        /// 获取上层部门编码
        /// </summary>
        /// <param name="cdepcode"></param>
        /// <returns></returns>
        public static string GetUpDept(string cdepcode)
        {
            DataSet ds = new DataSet();
            ds = U8.Interface.Bus.DBUtility.DbHelperSQL.Query(" select t2.cdepcode from Department t2  with(nolock)  where t2.idepgrade = (select iDepGrade-1 from  Department t1   with(nolock)  WHERE cDepCode = '" + cdepcode + "') and '" + cdepcode + "' like (t2.cdepcode + '%')  ");
            string ret = "";
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                ret = ds.Tables[0].Rows[0][0].ToString();
            }
            return ret;
        }

        /// <summary>
        /// 3
        /// 
        /// </summary>
        /// <param name="cdepcode"></param>
        /// <returns></returns>
        public static string GetInventoryClass(string cInvCCode)
        {
            DataSet ds = new DataSet();
            ds = U8.Interface.Bus.DBUtility.DbHelperSQL.Query(" select cInvCCode from InventoryClass where cInvCCode = '" + cInvCCode + "' ");
            string ret = "";
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                ret = ds.Tables[0].Rows[0][0].ToString();
            }
            return ret;
        }



        /// <summary>
        /// 4
        /// 获取计量单位名称
        /// </summary>
        /// <param name="cdepcode"></param>
        /// <returns></returns>
        public static string GetComputationUnit(string cComunitCode)
        {
            DataSet ds = new DataSet();
            ds = U8.Interface.Bus.DBUtility.DbHelperSQL.Query(" select cComUnitName from ComputationUnit where cComunitCode = '" +cComunitCode + "'  ");
            string ret = "";
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                ret = ds.Tables[0].Rows[0][0].ToString();
            }
            return ret;
        }

        /// <summary>
        /// 5
        /// CQ 存货 采购自制属性生成
        /// </summary>
        /// <param name="cdepcode"></param>
        /// <returns></returns>
        public static string GetInvPurType(string bBomMain,string bBomSub, string bPurchase, string bSelf)
        { 
            string ret = "";
            if (bBomSub.ToLower().Equals("1") || bBomSub.ToLower().Equals("true"))
            {
                ret += "0"; //"采购";
            }
            else
            {
                ret += "1"; // "自制";
            }


            //if (bBomMain.ToLower().Equals("1") || bBomMain.ToLower().Equals("true"))
            //{
            //    ret += "自制";
            //}
            //else 
            //{
            //    ret += "采购";
            //}
             
            //if (bPurchase.ToLower().Equals("1") || bPurchase.ToLower().Equals("true")) 
            //{
            //    ret += "采购";
            //}
            //if (bSelf.ToLower().Equals("1") || bSelf.ToLower().Equals("true"))
            //{
            //    ret += "自制";
            //}
            
            return ret;
        }


        /// <summary>
        /// 6
        /// CQ 生成操作符
        /// </summary>
        /// <param name="operflag"></param>
        /// <returns></returns>
        public static string GetCQFlagByOper(string opertype)
        {
            if (opertype.ToLower().Equals("d"))
            {
                return "2";
            }
            else if (opertype.ToLower().Equals("m"))
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }



    }
}
