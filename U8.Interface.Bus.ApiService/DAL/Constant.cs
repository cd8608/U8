using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace U8.Interface.Bus.ApiService.DAL
{
    public static class Constant
    {

        ///调试模式
        public static bool DeBugMode = true;

        public const string SynergisnLogDT_Cstatus_Complete = "完成";
        public const string SynergisnLogDT_Cstatus_Error = "错误";
        public const string SynergisnLogDT_Cstatus_NoDeal = "未处理";
        public const string SynergisnLogDT_Cstatus_Delete = "已删除";
        public const string SynergisnLogDT_Cstatus_NoAudit = "未审核";

        public const string SynerginsLog_Cstatus_Dealing = "处理中";
        public const string SynerginsLog_Cstatus_Complete = "完成";
        public const string SynerginsLog_Cstatus_Error = "错误";
        public const string SynerginsLog_Cstatus_NoDeal = "未处理";
        public const string SynerginsLog_Cstatus_Wait = "等待中";
        public const string SynerginsLog_Cstatus_Scrap = "已作废";



        ///手工单
        public const int SynergisnLogDT_Ismanual_True = 1;
        ///不是手工单
        public const int SynergisnLogDT_Ismanual_False = 0;

        ///审核
        public const int SynergisnLogDT_Isaudit_True = 1;
        ///不审核
        public const int SynergisnLogDT_Isaudit_False = 0;

        ///没有错误
        public const int ResultNum_NoError = 0;
        ///一般错误
        public const int ResultNum_NormalError = -1;

        ///数据库链接
        public const string Fixvalue_Ctype_Constring = "4";
        ///返回值
        public const string Fixvalue_Ctype_ReturnValue = "3";
        ///函数参数
        public const string Fixvalue_Ctype_FunctionParam = "2";
        ///分张套取值
        public const string Fixvalue_Ctype_MutiValue = "1";

        ///来源单据
        public const string Fixvalue_Cfromortobill_Source = "S";
        ///目标单据
        public const string Fixvalue_Cfromortobill_Original = "D";
        ///保留字
        public const string Fixvalue_Cfromortobill_P = "P";
        ///上游单据   2015.03.18 added by liuxzha
        public const string Fixvalue_Cfromortobill_B = "B";

        ///表头
        public const string Fixvalue_Cardsection_Title = "T";
        ///表体
        public const string Fixvalue_Cardsection_Body = "B";
        ///公共变量
        public const string Fixvalue_Cardsection_V = "V";
        ///单据类型
        public const string Fixvalue_Cardsection_P = "P";
        ///固定值   2015.03.18 added by liuxzha
        public const string Fixvalue_Cardsection_S = "S";

        ///sql
        public const string Function_Cfuntype_SQL = "1";
        ///函数
        public const string Function_Cfuntype_FUN = "2";

        ///来源单据
        public const int Fieldcmps_Ctype_Source = 0;
        ///固定值
        public const int Fieldcmps_Ctype_Const = 1;
        ///函数
        public const int Fieldcmps_Ctype_Funtion = 2;
        ///分账套
        public const int Fieldcmps_Ctype_MutiValue = 3;

        ///主账套
        public const string Fixvalue_Cvalue_Master = "M";
        ///目标账套
        public const string Fixvalue_Cvalue_Destination = "D";
        ///来源账套
        public const string Fixvalue_Cvalue_Source = "S";

    }

}