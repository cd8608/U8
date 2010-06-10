using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace U8.Interface.Bus.ApiService.BLL
{
    public class U8NameValue
    {


        /// <summary>
        /// 设置表头字段值
        /// </summary>
        /// <param name="apidata"></param>
        /// <param name="rdds"></param>
        /// <param name="rdsds"></param>
        /// <param name="listfd"></param>
        /// <param name="dt"></param>
        public void SetHeadData(Model.APIData apidata, System.Data.DataSet rdds, System.Data.DataSet rdsds, List<Model.Fieldcmps> listfd, Model.Synergismlogdt dt)
        {
            //赋植
            apidata.HeadData = new List<Model.U8NameValue>();
            //表头
            foreach (Model.Fieldcmps fd in listfd)
            {
                try
                {
                    if (fd.Cardsection == DAL.Constant.Fixvalue_Cardsection_Title)
                    {
                        Model.U8NameValue u8nv = new Model.U8NameValue();
                        if (dt.Cvouchertype == "FC31" || dt.Cvouchertype == "FC32")
                        {
                            u8nv.U8FieldName = fd.Fieldname;  //生产制造区分大小写 
                        }
                        else
                        {
                            u8nv.U8FieldName = fd.Fieldname.ToLower();
                        }
                            
                        switch (fd.Ctype)
                        {
                            case DAL.Constant.Fieldcmps_Ctype_Const:    // 固定值
                                Common.FieldcmpsHeadConstCheck(fd, dt.Cvouchertype);
                                u8nv.U8FieldValue = fd.Cvalue;
                                break;
                            case DAL.Constant.Fieldcmps_Ctype_Source:   //完全参照
                                Common.ErrorMsg(fd.Cvalue.Split(','), 2, "完全参照格式不正确");
                                BLL.Common.ErrorMsg(fd.Cvalue.Split(',')[1].Split('|'), 2, "完全参照格式不正确");
                                string[] u8value = fd.Cvalue.Split(',')[1].Split('|');


                                if (u8value[0] == DAL.Constant.Fixvalue_Cardsection_Title) u8nv.U8FieldValue = rdds.Tables[0].Rows[0][u8value[1]].ToDataString();
                                if (u8value[0] == DAL.Constant.Fixvalue_Cardsection_Body) u8nv.U8FieldValue = rdsds.Tables[0].Rows[0][u8value[1]].ToDataString();
                                break;
                            case DAL.Constant.Fieldcmps_Ctype_MutiValue:    // 分账套
                                u8nv.U8FieldValue = DAL.Common.GetVauleByAccid(fd.Autoid, dt.Accid);
                                break;
                            case DAL.Constant.Fieldcmps_Ctype_Funtion:  // 函数
                                u8nv.U8FieldValue = DAL.Common.GetFunValue(apidata, apidata.HeadData, null, rdds.Tables[0].Rows[0], rdsds.Tables[0].Rows[0], fd, dt, 0);
                                #region 默认值   刘忻洲添加  2014.11.20
                                if (dt.TaskType == 1)
                                {
                                    if (string.IsNullOrEmpty(u8nv.U8FieldValue))
                                    {
                                        u8nv.U8FieldValue = DAL.Common.GetDefaultValueByTaskIdFunctionId(dt.Id.ToString(), fd.Id, fd.Autoid, fd.Cfunid);
                                    }
                                    if (u8nv.U8FieldValue == "[null]")
                                    {
                                        u8nv.U8FieldValue = "";
                                    }
                                }
                                #endregion

                                break;
                            default:
                                u8nv.U8FieldValue = null;
                                break;
                        }
                        apidata.HeadData.Add(u8nv);
                    }
                }
                catch (Exception ex)
                {

                    string msg = string.Format("表头字段{0}({2})取值发生错误：错误信息：{1}", fd.Carditemname, ex.Message.ToString(), fd.Fieldname);

                    #region 默认值   刘忻洲添加  2014.11.20
                    if (dt.TaskType == 1)
                    {
                        if (fd.Ctype == DAL.Constant.Fieldcmps_Ctype_Funtion)  // 函数
                        {
                            Model.U8NameValue u8nv = new Model.U8NameValue();
                            if (dt.Cvouchertype == "FC31" || dt.Cvouchertype == "FC32")
                            {
                                u8nv.U8FieldName = fd.Fieldname;  //生产制作区分大小写
                            }
                            else
                            {
                                u8nv.U8FieldName = fd.Fieldname.ToLower();
                            }


                            u8nv.U8FieldValue = DAL.Common.GetDefaultValueByTaskIdFunctionId(dt.Id.ToString(), fd.Id, fd.Autoid, fd.Cfunid);

                            if (string.IsNullOrEmpty(u8nv.U8FieldValue))
                            {
                                throw new Exception(msg);
                            }
                            if (u8nv.U8FieldValue == "[null]")
                            {
                                u8nv.U8FieldValue = "";
                            }
                            apidata.HeadData.Add(u8nv);
                        }
                        else
                        {
                            throw new Exception(msg);
                        }
                    }
                    #endregion

                    
                
                }

            }
        }



        /// <summary>
        /// 设置表体字段值
        /// 按fieldcmps autoid 顺序赋值
        /// </summary>
        /// <param name="apidata"></param>
        /// <param name="rdds">上一节点表头信息</param>
        /// <param name="rdsds">上一节点表体信息</param>
        /// <param name="listfd">fieldcmps字段对照信息</param>
        /// <param name="dt"></param>
        public void SetBodyData(Model.APIData apidata, System.Data.DataSet rdds, System.Data.DataSet rdsds, List<Model.Fieldcmps> listfd, Model.Synergismlogdt dt)
        { 
            //赋植
            apidata.BodyData = new List<List<Model.U8NameValue>>();

            //表体
            int rowno = 0;  //来源单据行号
            for (int i = 0; i < rdsds.Tables[0].Rows.Count; i++)
            {
                rowno = i;

                List<Model.U8NameValue> lmu8nv = new List<Model.U8NameValue>();
                foreach (Model.Fieldcmps fd in listfd)
                {

                    try
                    {

                        if (fd.Cardsection == DAL.Constant.Fixvalue_Cardsection_Body)
                        {
                            

                            Model.U8NameValue u8nv = new Model.U8NameValue();

                            if (dt.Cvouchertype == "FC31" || dt.Cvouchertype == "FC32")
                            {
                                u8nv.U8FieldName = fd.Fieldname; //生产制作区分大小写 
                            }
                            else
                            {
                                u8nv.U8FieldName = fd.Fieldname.ToLower(); 
                            }

                            
                            switch (fd.Ctype)
                            {
                                case DAL.Constant.Fieldcmps_Ctype_Const:    //固定值
                                    Common.FieldcmpsBodyConstCheck(fd, dt.Cvouchertype);
                                    u8nv.U8FieldValue = fd.Cvalue;
                                    break;
                                case DAL.Constant.Fieldcmps_Ctype_Source:   // 完全参照
                                    BLL.Common.ErrorMsg(fd.Cvalue.Split(','), 2, "完全参照格式不正确");
                                    BLL.Common.ErrorMsg(fd.Cvalue.Split(',')[1].Split('|'), 2, "完全参照格式不正确");
                                    string[] u8value = fd.Cvalue.Split(',')[1].Split('|');

                                    if (u8value[0] == DAL.Constant.Fixvalue_Cardsection_Title) u8nv.U8FieldValue = rdds.Tables[0].Rows[0][u8value[1]].ToDataString();
                                    if (u8value[0] == DAL.Constant.Fixvalue_Cardsection_Body) u8nv.U8FieldValue = rdsds.Tables[0].Rows[i][u8value[1]].ToDataString();
                                    break;
                                case DAL.Constant.Fieldcmps_Ctype_MutiValue:    // 分账套
                                    u8nv.U8FieldValue = DAL.Common.GetVauleByAccid(fd.Autoid, dt.Accid);
                                    break;
                                case DAL.Constant.Fieldcmps_Ctype_Funtion:  // 函数
                                    u8nv.U8FieldValue = DAL.Common.GetFunValue(apidata, apidata.HeadData, lmu8nv, rdds.Tables[0].Rows[0], rdsds.Tables[0].Rows[i], fd, dt, rowno);
                                    #region 默认值   刘忻洲添加  2014.11.20

                                    if (dt.TaskType == 1)
                                    {
                                        if (string.IsNullOrEmpty(u8nv.U8FieldValue))
                                        {
                                            u8nv.U8FieldValue = DAL.Common.GetDefaultValueByTaskIdFunctionId(dt.Id.ToString(), fd.Id, fd.Autoid, fd.Cfunid);
                                        }
                                        if (u8nv.U8FieldValue == "[null]")
                                        {
                                            u8nv.U8FieldValue = "";
                                        }
                                    }
                                    #endregion
                                    break;
                                default:
                                    u8nv.U8FieldValue = null;
                                    break;
                            }
                            lmu8nv.Add(u8nv);
                        }
                    }
                    catch(Exception ex)
                    {
                         #region 默认值   刘忻洲修改  2014.11.20
                        if (dt.TaskType == 1)
                        {
                            string msg = string.Format("表体第{3}行，字段-{0}({2})取值发生错误,错误信息：{1}", fd.Carditemname, ex.Message.ToString(), fd.Fieldname, i + 1);

                            if (fd.Ctype == DAL.Constant.Fieldcmps_Ctype_Funtion)  // 函数
                            {
                                Model.U8NameValue u8nv = new Model.U8NameValue();
                                if (dt.Cvouchertype == "FC31" || dt.Cvouchertype == "FC32")
                                {
                                    u8nv.U8FieldName = fd.Fieldname;//生产制作区分大小写 
                                }
                                else
                                {
                                    u8nv.U8FieldName = fd.Fieldname.ToLower();
                                }


                                u8nv.U8FieldValue = DAL.Common.GetDefaultValueByTaskIdFunctionId(dt.Id.ToString(), fd.Id, fd.Autoid, fd.Cfunid);
                                if (string.IsNullOrEmpty(u8nv.U8FieldValue))
                                {
                                    throw new Exception(msg);
                                }
                                if (u8nv.U8FieldValue == "[null]")
                                {
                                    u8nv.U8FieldValue = "";
                                }
                                lmu8nv.Add(u8nv);
                            }
                            else
                            {
                                throw new Exception(msg);
                            }
                        }
                        #endregion

                        
                    }

                }
                apidata.BodyData.Add(lmu8nv);
            }
        }

    }
}
