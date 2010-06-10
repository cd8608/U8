using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using U8.Interface.Bus.Comm;
using U8.Interface.Bus.DBUtility;

namespace U8.Interface.Bus.Function
{
    public static class Acount
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strQty"></param>
        /// <param name="strIUnitPrice"></param>
        /// <returns></returns>
        public static string GetAccount(string strQty, string strTaxUnitPrice)
        {
           
            double dTaxUnitPrice;
            double dSum;
            double dQty;
            double dItax;
            double dMoney;
            double dUnitPrice;

            try 
            {
                //数量
                dQty = double.Parse(strQty);
            }
            catch
            {
                return "error:" + "数量为空或数量格式不正确，请检查配置!" + strQty;
            }

            try
            {
                //含税单价
                dTaxUnitPrice = double.Parse(strTaxUnitPrice);
            }
            catch
            {
                return "itaxunitprice,;isum,;imoney,;itax,;iprice,";
            }


            


                //无税单价
                dUnitPrice = dTaxUnitPrice / 1.17;


                //原币价税合计
                dSum = dTaxUnitPrice * dQty;

            
                //原币无税金额
                dMoney = dUnitPrice * dQty;

            
                //原币税额
                dItax = dUnitPrice * dQty * 0.17;




                return "itaxunitprice" + "," + dTaxUnitPrice.ToString("f8") + ";" +
                       "isum" + "," + dSum.ToString("f8") + ";" + "imoney" + "," + dMoney.ToString("f8") +
                       ";" + "itax" + "," + dItax.ToString("f8") +
                       ";" + "iprice" + "," + dUnitPrice.ToString("f8");
            
            


        }

        /// <summary>
        /// 根据税率获取原币价格体系
        /// </summary>
        /// <param name="strQty"></param>
        /// <param name="strIUnitPrice"></param>
        /// <param name="strITaxRate">税率</param>
        /// <returns></returns>
        public static string GetAccountByITaxRate(string strQty, string strTaxUnitPrice, string strITaxRate)
        {

            double dTaxUnitPrice;
            double dSum;
            double dQty;
            double dItax;
            double dMoney;
            double dUnitPrice;
            double dITaxRate;//税率

            try
            {
                //数量
                dQty = double.Parse(strQty);
            }
            catch
            {
                return "error:" + "数量为空或数量格式不正确，请检查配置!" + strQty;
            }

            try
            {
                //含税单价
                dTaxUnitPrice = double.Parse(strTaxUnitPrice);
            }
            catch
            {
                return "itaxunitprice,;isum,;imoney,;itax,;iprice,";
            }

            try
            {
                if (string.IsNullOrEmpty(strITaxRate))
                {
                    dITaxRate = 0;
                }
                else
                {
                    dITaxRate = (double.Parse(strITaxRate)) / 100;
                }

            }
            catch (System.Exception ex)
            {
                return "error:" + "税率格式不正确，请检查配置!" + strITaxRate;
            }



            //无税单价
            dUnitPrice = dTaxUnitPrice / (1 + dITaxRate);


            //原币价税合计
            dSum = dTaxUnitPrice * dQty;


            //原币无税金额
            dMoney = dUnitPrice * dQty;


            //原币税额
            dItax = dUnitPrice * dQty * dITaxRate;


            string res = "itaxunitprice" + "," + dTaxUnitPrice.ToString("f8") + ";" +
                   "isum" + "," + dSum.ToString("f8") + ";" + "imoney" + "," + dMoney.ToString("f8") +
                   ";" + "itax" + "," + dItax.ToString("f8") +
                   ";" + "iprice" + "," + dUnitPrice.ToString("f8");

            System.Diagnostics.Debug.WriteLine("GetAccountByITaxRate:" + "param-- strQty:" + strQty + "  strTaxUnitPrice: " + strTaxUnitPrice + "  strITaxRate:" + strITaxRate);
            System.Diagnostics.Debug.WriteLine("  res --" + res); 

            return res;




        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strQty"></param>
        /// <param name="strTaxUnitPrice"></param>
        /// <param name="strRate"></param>
        /// <returns></returns>
        public static string GetNatAccount(string strQty, string strTaxUnitPrice,string strRate)
        {


            double dQty;
            double dRate;
            double dTaxUnitPrice;
            double inatsum;
            double inatmoney;
            double inattax;
            double inatunitprice;
            try
            {
                //数量
                dQty = double.Parse(strQty);
            }
            catch
            {
                return "error:" + "数量为空或数量格式不正确，请检查配置!" + strQty;
            }

            try
            {
                //汇率
                dRate = double.Parse(strRate);
            }
            catch
            {
                return "error:" + "汇率为空或数量格式不正确，请检查配置!" + strRate;
            }

            try
            {
                //含税单价
                dTaxUnitPrice = double.Parse(strTaxUnitPrice);
            }
            catch
            {
                return "inatsum,;inatmoney,;inattax,;inatunitprice,";
            }

            //本币价税合计
            inatsum = dQty * dTaxUnitPrice * dRate;

            //本币无税金额
            inatmoney = inatsum / 1.17;

            //本币税额
            inattax = inatsum - inatmoney;
            
            //	本币价税合计
            inatunitprice = dTaxUnitPrice * dRate / 1.17;

            string res = string.Format("inatsum,{0};inatmoney,{1};inattax,{2};inatunitprice,{3}"
                ,inatsum.ToString("f8")
                , inatmoney.ToString("f8")
                , inattax.ToString("f8")
                , inatunitprice.ToString("f8"));

            System.Diagnostics.Debug.WriteLine("GetNatAccount" + res);

            return res;

        }

        /// <summary>
        /// 根据税率获取本币价格体系
        /// </summary>
        /// <param name="strQty"></param>
        /// <param name="strTaxUnitPrice"></param>
        /// <param name="strRate"></param>
        /// <returns></returns>
        public static string GetNatAccountByITaxRate(string strQty, string strTaxUnitPrice, string strRate, string strITaxRate)
        {


            double dQty;
            double dRate;
            double dTaxUnitPrice;
            double inatsum;
            double inatmoney;
            double inattax;
            double inatunitprice;
            double dITaxRate;//税率

            try
            {
                //数量
                dQty = double.Parse(strQty);
            }
            catch
            {
                return "error:" + "数量为空或数量格式不正确，请检查配置!" + strQty;
            }

            try
            {
                //汇率
                dRate = double.Parse(strRate);
            }
            catch
            {
                return "error:" + "汇率为空或数量格式不正确，请检查配置!" + strRate;
            }

            try
            {
                //含税单价
                dTaxUnitPrice = double.Parse(strTaxUnitPrice);
            }
            catch
            {
                return "inatsum,;inatmoney,;inattax,;inatunitprice,";
            }

            try
            {
                if (string.IsNullOrEmpty(strITaxRate))
                {
                    dITaxRate = 0;
                }
                else
                {
                    dITaxRate = (double.Parse(strITaxRate)) / 100;
                }

            }
            catch
            {
                return "error:" + "税率格式不正确，请检查配置!" + strITaxRate;
            }

            //本币价税合计
            inatsum = dQty * dTaxUnitPrice * dRate;

            //本币无税金额
            inatmoney = inatsum / (1 + dITaxRate);

            //本币税额
            inattax = inatsum - inatmoney;

            //	本币价税合计
            inatunitprice = dTaxUnitPrice * dRate / (1 + dITaxRate);

            string res = string.Format("inatsum,{0};inatmoney,{1};inattax,{2};inatunitprice,{3}"
                , inatsum.ToString("f8")
                , inatmoney.ToString("f8")
                , inattax.ToString("f8")
                , inatunitprice.ToString("f8"));

            System.Diagnostics.Debug.WriteLine("GetNatAccountByITaxRate:" + "param-- strQty:" + strQty + "  strTaxUnitPrice: " + strTaxUnitPrice + "  strRate:" + strRate + " strITaxRate:" + strITaxRate );
            System.Diagnostics.Debug.WriteLine("  res --" + res);

            return res; 

        }
    }
}
