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
        /// </summary>
        /// <param name="operflag"></param>
        /// <returns></returns>
        public static string GetFlagByOper(string operflag)
        {
            if (operflag.ToLower().Equals("d"))
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
        /// </summary>
        /// <param name="cdepcode"></param>
        /// <returns></returns>
        public static string GetInvPurType(string bBomMain,string bBomSub, string bPurchase, string bSelf)
        { 
            string ret = "";
            if (bBomSub.ToLower().Equals("1") || bBomSub.ToLower().Equals("true"))
            {
                ret += "采购";
            }
            else
            {
                ret += "自制";
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




    }
}
