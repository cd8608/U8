using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using System.Management;
using U8.Interface.Bus.ApiService.DAL;

namespace U8.Interface.Bus.ApiService.BLL
{
    public static class Common
    {

        #region 错误处理

        /// <summary>
        /// 如果错误...处理
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="Msg"></param>
        public static void ErrorMsg(string str, string Msg)
        {
            if (string.IsNullOrEmpty(str))
                throw new Exception(Msg);
        }

        public static void ErrorMsg<T>(List<T> listT, string Msg)
        {
            if (listT.Count == 0)
                throw new Exception(Msg);
        }
        public static void ErrorMsg(DataSet ds, string Msg)
        {

            if (ds == null) throw new Exception(Msg);
            if (ds.Tables.Count == 0) throw new Exception(Msg);
            if (ds.Tables[0].Rows.Count == 0)
                throw new Exception(Msg);
        }
        public static void ErrorMsg(string[] strlist, int i, string Msg)
        {
            if (strlist.Length < i)
                throw new Exception(Msg);

        }
        public static void ErrorMsg(object obj, string Msg)
        {
            if (obj == null)
                throw new Exception(Msg);
        }

        #endregion


        /// <summary>
        /// 获取本地MAC地址
        /// </summary>
        /// <returns></returns>
        public static string GetLocalMacAddress()
        {
            try
            {
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if (mo["IPEnabled"].ToString() == "True")
                    {
                        return mo["MacAddress"].ToString().Replace(':', '-');
                    }
                }

                return string.Empty;
            }
            catch
            { return string.Empty; }
        }



        /// <summary>
        /// 转换年度
        /// </summary>
        /// <param name="iYear">登录年度</param>
        /// <returns></returns>
        internal static string TransferDate(int iYear)
        {
            string strDate = DateTime.Now.ToString("yyyy-MM-dd").Replace('.', '-').Replace('/', '-');

            if (iYear == DateTime.Now.Year)
                return strDate;

            int index = strDate.IndexOf('-');
            return iYear.ToString() + strDate.Substring(index, strDate.Length - index);
        }

        /// <summary>
        /// 获取U8登录站点标识Serial
        /// </summary>
        /// <returns></returns>
        internal static string GetSerial()
        {
            string strMac = GetLocalMacAddress();

            if (string.IsNullOrEmpty(strMac)) return string.Empty;
            else return strMac + "@0";
        }

        /// <summary>
        /// 获取上游单据审核日期
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetVerifyData(Model.Synergismlogdt dt)
        {
            string strDefault = DateTime.Now.ToString("yyyy-MM-dd").Replace('.', '-').Replace('/', '-');
            if (dt.Ilineno <= 1)
            {
                return strDefault;
            }

            BLL.Task.ITaskLogDetail bllDT = new BLL.SynergisnLogDT();
            DAL.SynergismLogDt dalDT = new SynergismLogDt();
            Model.Synergismlogdt dtPrev;
            dtPrev = bllDT.GetPrevious(dt,dt.OP);
            Model.ConnectInfo ConnectStr = dalDT.getConnectStr(dtPrev);

            return DAL.Common.GetVerifyDate(ConnectStr, dtPrev);
        }


        /// <summary>
        /// 获取最后登录日期
        /// </summary>
        /// <param name="rmdoel">登录账套信息</param>
        /// <returns></returns>
        public static string GetLoginDate(Model.Regist rmdoel)
        {
            string strLoginDate = string.Empty;
            try
            {
                if (rmdoel.Dlogindate != null)
                    strLoginDate = Convert.ToDateTime(rmdoel.Dlogindate).ToString("yyyy-MM-dd").Replace('.', '-').Replace('/', '-');
            }
            catch { strLoginDate = string.Empty; }

            if (string.IsNullOrEmpty(strLoginDate) && rmdoel.Ibeginyear >= 1979) return TransferDate(rmdoel.Ibeginyear);

            return strLoginDate;
        }


        #region 字段值校验
        /// <summary>
        /// 表头固定值检查
        /// </summary>
        /// <param name="fd">固定值信息</param>
        /// <param name="type">单据类型</param>
        public static void FieldcmpsHeadConstCheck(Model.Fieldcmps fd, string type)
        {
            string field = fd.Fieldname.ToLower();
            switch (type)
            {
                case "17":      //销售订单
                    switch (field)
                    {
                        case "ddate":
                            if (string.IsNullOrEmpty(fd.Cvalue))
                                fd.Cvalue = DateTime.Now.ToString("yyyy-MM-dd");
                            break;
                        case "cbustype":
                        case "cstcode":
                        case "ccuscode":
                        case "cdepcode":
                            ErrorMsg(fd.Cvalue, "固定值不能为空");
                            break;
                        case "breturnflag":
                            ErrorMsg(fd.Cvalue, "固定值不能为空");
                            break;
                        default:
                            break;
                    }
                    break;
                case "01":      //发货单
                    switch (field)
                    {
                        case "ddate":
                            if (string.IsNullOrEmpty(fd.Cvalue))
                                fd.Cvalue = DateTime.Now.ToString("yyyy-MM-dd");
                            break;
                        case "cbustype":
                        case "cstcode":
                        case "ccuscode":
                        case "cdepcode":
                            ErrorMsg(fd.Cvalue, "固定值不能为空");
                            break;
                        //case "bfirst":
                        //case "breturnflag":
                        //case "bsettleall":
                        case "iexchrate":
                            ErrorMsg(fd.Cvalue, "固定值不能为空");
                            break;
                        default:
                            break;
                    }
                    break;
                case "03":      //退货单    added by liuxzha  2014.11.27
                    switch (field)
                    {
                        case "ddate":
                            if (string.IsNullOrEmpty(fd.Cvalue))
                                fd.Cvalue = DateTime.Now.ToString("yyyy-MM-dd");
                            break;
                        case "cbustype":
                        case "cstcode":
                        case "ccuscode":
                        case "cdepcode":
                            ErrorMsg(fd.Cvalue, "固定值不能为空");
                            break;

                        case "iexchrate":
                            ErrorMsg(fd.Cvalue, "固定值不能为空");
                            break;
                        default:
                            break;
                    }
                    break;
                case "0303":    //销售出库单
                    switch (field)
                    {
                        case "ddate":
                            if (string.IsNullOrEmpty(fd.Cvalue))
                                fd.Cvalue = DateTime.Now.ToString("yyyy-MM-dd");
                            break;
                        case "cwhcode":
                        case "ccuscode":
                            ErrorMsg(fd.Cvalue, "固定值不能为空");
                            break;
                        //case "bssstqc":
                        //case "brdflag":
                        //case "btransflag":
                        case "iexchrate":
                            ErrorMsg(fd.Cvalue, "固定值不能为空");
                            break;
                        default:
                            break;
                    }
                    break;
                case "27":      //采购请购单
                    switch (field)
                    {
                        case "ddate":
                            if (string.IsNullOrEmpty(fd.Cvalue))
                                fd.Cvalue = DateTime.Now.ToString("yyyy-MM-dd");
                            break;
                        case "":
                            ErrorMsg(fd.Cvalue, "固定值不能为空");
                            break;
                        default:
                            break;
                    }
                    break;
                case "88":      //采购订单
                    switch (field)
                    {
                        case "dpodate":
                            if (string.IsNullOrEmpty(fd.Cvalue))
                                fd.Cvalue = DateTime.Now.ToString("yyyy-MM-dd");
                            break;
                        case "cvencode":
                        case "cexch_name":
                        case "nflat":
                            ErrorMsg(fd.Cvalue, "固定值不能为空");
                            break;
                        default:
                            break;
                    }
                    break;
                case "26":      //采购到货单
                    switch (field)
                    {
                        case "ddate":
                            if (string.IsNullOrEmpty(fd.Cvalue))
                                fd.Cvalue = DateTime.Now.ToString("yyyy-MM-dd");
                            break;
                        case "cbustype":
                        case "cvencode":
                        case "cdepcode":
                        case "cexch_name":
                            ErrorMsg(fd.Cvalue, "固定值不能为空");
                            break;
                        case "iexchrate":
                        case "ibilltype":
                        case "bnegative":
                            ErrorMsg(fd.Cvalue, "固定值不能为空");
                            break;
                        default:
                            break;
                    }
                    break;
                case "24":      //采购入库单
                    switch (field)
                    {
                        case "ddate":
                            if (string.IsNullOrEmpty(fd.Cvalue))
                                fd.Cvalue = DateTime.Now.ToString("yyyy-MM-dd");
                            break;
                        case "cwhcode":
                        case "cvencode":
                        case "cdepcode":
                        case "cexch_name":
                            ErrorMsg(fd.Cvalue, "固定值不能为空");
                            break; 
                        default:
                            break;
                    }
                    break;
                case "0411":   //产成品入库单
                    break;
                default:
                    break;
            }
        }



        /// <summary>
        /// 表体固定值检查
        /// </summary>
        /// <param name="fd">固定值信息</param>
        /// <param name="type">单据类型</param>
        public static void FieldcmpsBodyConstCheck(Model.Fieldcmps fd, string type)
        {
            string field = fd.Fieldname.ToLower();
            switch (type)
            {
                case "17":      //销售订单
                    switch (field)
                    {
                        case "cinvcode":
                        case "iquantity":
                            ErrorMsg(fd.Cvalue, "固定值不能为空");
                            break;
                        case "dpredate":
                        case "dpremodate":
                            if (string.IsNullOrEmpty(fd.Cvalue)) fd.Cvalue = DateTime.Now.ToString("yyyy-MM-dd");
                            break;
                        default:
                            break;
                    }
                    break;
                case "01":      //发货单
                    switch (field)
                    {
                        case "cinvcode":
                        case "iquantity":
                            ErrorMsg(fd.Cvalue, "固定值不能为空");
                            break;
                        //case "bcosting":
                        //case "bsettleall":
                        //case "bqaneedcheck":
                        //case "bqaurgency":
                        //case "bqachecking":
                        //case "bqachecked":
                        //    ErrorMsg(fd.Cvalue, "固定值不能为空");
                        //    break;
                        default:
                            break;
                    }
                    break;
                case "03":      //退货单
                    switch (field)
                    {
                        case "cinvcode":
                        case "iquantity":
                            ErrorMsg(fd.Cvalue, "固定值不能为空");
                            break;
                        default:
                            break;
                    }
                    break;
                case "0303":    //销售出库单
                    switch (field)
                    {
                        case "cinvcode":
                        case "iflag":
                            ErrorMsg(fd.Cvalue, "固定值不能为空");
                            break;
                        default:
                            break;
                    }
                    break;
                case "27":      //采购请购单
                    switch (field)
                    {
                        case "cinvcode":
                        case "fquantity":
                        case "drequirdate":
                            ErrorMsg(fd.Cvalue, "固定值不能为空");
                            break;
                        default:
                            break;
                    }
                    break;
                case "88":      //采购订单
                    switch (field)
                    {
                        case "cinvcode":
                        case "iquantity":
                        case "ipertaxrate":
                        case "darrivedate":
                            ErrorMsg(fd.Cvalue, "固定值不能为空");
                            break;
                        default:
                            break;
                    }
                    break;
                case "26":      //采购到货单
                    switch (field)
                    {
                        case "cinvcode":
                        case "iquantity":
                            ErrorMsg(fd.Cvalue, "固定值不能为空");
                            break;
                        case "itaxrate":
                            ErrorMsg(fd.Cvalue, "固定值不能为空");
                            break;
                        default:
                            break;
                    }
                    break;
                case "24":      //采购入库单
                    switch (field)
                    {
                        case "cinvcode":
                            ErrorMsg(fd.Cvalue, "固定值不能为空");
                            break;
                        case "ibillsettlecount":
                        case "imatsettlestate":
                        case "iflag":
                            ErrorMsg(fd.Cvalue, "固定值不能为空");
                            break;
                        default:
                            break;
                    }
                    break;
                case "0411":
                    break;
                default:
                    break;
            }
        }


        #endregion




        public static string ToDataString(this object obj)
        {
            if (obj == null) return string.Empty;
            if (obj is DateTime) return ((DateTime)obj).ToString("yyyy-MM-dd HH:mm:ss");
            return obj.ToString();
        }


    }
}
