using System.Data;
using U8.Interface.Bus.DBUtility;

namespace U8.Interface.Bus.WebService.DAL
{
    public class XmlDAL
    {
        #region 取得画面控件信息
        /// <summary>
        /// 取得画面控件信息
        /// </summary>
        /// <param name="connsecitonstring">数据库连接字符串</param>
        /// <param name="VT_ID">模板ID</param>
        /// <param name="ds">返回数据集</param>
        /// <param name="msg">出错信息</param>
        /// <param name="argFormId">画面Id</param>
        /// <returns></returns>
        public static int GetFormInfo(string connsecitonstring, string[] VT_ID, out DataSet ds, out string msg, string argFormId)
        {
            ds = new DataSet();
            msg = "";
            string id = string.Empty;
            #region sql
            if (VT_ID != null)
            {

                for (int i = 0; i < VT_ID.Length; i++)
                {
                    if (i == 0)
                    {
                        id = VT_ID[i];
                    }
                    else
                    {
                        id += "','" + VT_ID[i];
                    }
                }
            }
            string sql = @"  
            select  distinct
            B.CardNum CardNumber,B.Vt_id as VTID,
            B.FieldName, 
            B.cox, 
            B.coy, 
            B.Width, 
            B.Height, 
            L.cardformula1, 
            B.Pubufts, 
            B.ShowIt, 
            isnull(B.TabIndex,0) as TabIndex, 
            B.MaxLength, 
            B.IsNull, 
            B.CanModify, 
            B.FieldType, 
            B.ReferType,
            B.CardItemNum 
            from voucheritems_base B
            inner join voucheritems_lang L on
                B.CardNum=L.cardnum and B.FieldName=L.fieldname 
                and L.cardsection=B.CardSection and L.localeid='zh-cn'
                and B.ShowIt=1
            where  
        (B.CardNum   in ('PF_CJTM_01','PF_CJTM_02','PF_CJTM_03','PF_CJTM_04','PF_GXLZ_01','PF_GXLZ_02','PF_ZJYL_Z_01','PF_ZJYL_Z_02','PF_ZJYL_Z_03'))";
            if (!argFormId.Equals(string.Empty))
            {
                sql += @"  AND  B.CardNum='" + argFormId + "'";
            }

            #endregion

            return SQLHelper.GetDataset(sql, connsecitonstring, out ds, out msg);
        }
        #endregion
    }
}
