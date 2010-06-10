using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Interface.Bus.Event.SyncAdapter.Biz.Factory.DS 
{
    /// <summary>
    /// 生产订单工序资料
    /// 未完成,生产订单工序资料没有事件
    /// </summary>
    public class Sfc_morouting : BizBase
    {
        //sfc_moroutingdetail

        public Sfc_morouting(ref ADODB.Connection conn, int bomId, string ufConnStr, string _opertype)
            : base(conn, ufConnStr)
        {
            oracleTableName = "MES_Sfc_proutingdetail";   //目标表名
            oraclePriKey = "PRoutingId";      //目标表主键 
            fieldcmpTablename = "Sfc_proutingdetail";
            ufTableName = "Sfc_proutingdetail";       //来源表名
            ufPriKey = "PRoutingId";          //来源表主键
        }
    }
}
