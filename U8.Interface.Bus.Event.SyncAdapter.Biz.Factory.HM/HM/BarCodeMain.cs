using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MSXML2;


namespace U8.Interface.Bus.Event.SyncAdapter.Biz.Factory.HM
{
    class BarCodeMain : BizBase
    {


        List<List<BaseMode>> lAdd = new List<List<BaseMode>>();    //需要新增的数据
        List<List<BaseMode>> lMod = new List<List<BaseMode>>();    //需要修改的数据
        List<List<BaseMode>>  lDel = new List<List<BaseMode>>();    //需要删除的数据
        List<BaseMode> lTmp;


        public BarCodeMain(ref ADODB.Connection conn, IXMLDOMDocument2 doc, string ufConnStr)
            : base(conn, ufConnStr)
        {

            oracleTableName = "tblerpmcard";
            oraclePriKey = "mcard";
            ufTableName = "HY_BarCodeMain";
            ufPriKey = "BarCode";

            SetData(doc);
        }


        #region 设置数据
        private void SetData(IXMLDOMDocument2 doc)
        {
            foreach (IXMLDOMNode xmlNode in doc.selectNodes("//rs:data")[0].selectNodes("//z:row"))
            {
                //string oper = ((IXMLDOMElement)xmlNode).getAttribute("editprop").ToString().ToUpper();
                string oper = (xmlNode as IXMLDOMElement).getAttribute("editprop").ToString().ToUpper();
                if (oper.Equals("A"))
                {
                    SetAddData(xmlNode as IXMLDOMElement);
                }
                else if (oper.Equals("D"))
                {
                    SetDelData(xmlNode as IXMLDOMElement);
                }
                else if (oper.Equals("M"))
                {
                    SetModData(xmlNode as IXMLDOMElement);
                }
                else
                {
                    SetDelData(xmlNode as IXMLDOMElement);
                }
            }
        }


        /// <summary>
        /// 需要新增的数据
        /// </summary>
        /// <param name="doc"></param>
        private void SetAddData(IXMLDOMElement doc)
        {
            lTmp = new List<BaseMode>();
            lTmp.Add(new BaseMode("barcode", GetNodeAttrib(doc, "barcode"), "barcode", "MCARD", GetNodeAttrib(doc, "barcode"), null, null));
            lTmp.Add(new BaseMode("cinvcode", GetNodeAttrib(doc, "cinvcode"), "cinvcode", "MITEMCODE", GetNodeAttrib(doc, "cinvcode"), null, null));
            //lTmp.Add(new BaseMode("ccuscode", GetNodeValue(doc, "/customer/ccuscode"), "/customer/ccuscode", "VENDORITEMCODE", GetNodeValue(doc, "/customer/ccuscode")));
            //lTmp.Add(new BaseMode("cvencode", GetNodeAttrib(doc, "cvencode"), "cvencode", "VENDORCODE", GetNodeAttrib(doc, "cvencode")));
            //lTmp.Add(new BaseMode("ccuscode", GetNodeValue(doc, "/customer/ccuscode"), "/customer/ccuscode", "VenderLotNO", GetNodeValue(doc, "/customer/ccuscode")));

            //lTmp.Add(new BaseMode("ccusname", GetNodeValue(doc, "/customer/ccusname"), "/customer/ccusname", "DATECODE", GetNodeValue(doc, "/customer/ccusname")));    //生产日期
            //lTmp.Add(new BaseMode("ccuscode", GetNodeValue(doc, "/customer/ccuscode"), "/customer/ccuscode", "TransNO", GetNodeValue(doc, "/customer/ccuscode")));
            //lTmp.Add(new BaseMode("ccusname", GetNodeValue(doc, "/customer/ccusname"), "/customer/ccusname", "TransLine", GetNodeValue(doc, "/customer/ccusname")));
            lTmp.Add(new BaseMode("qty", GetNodeAttrib(doc, "qty"), "qty", "LOTQTY", GetNodeAttrib(doc, "qty"), null, null));     //生产数量
            lTmp.Add(new BaseMode(null, null, null, "Flag", "W", null, null));

            lTmp.Add(new BaseMode(null, null, null, "EDITPROP", "A", null, null));
            lTmp.Add(new BaseMode(null, null, null, "FINISHFLAG", "0", null, null));
            lTmp.Add(new BaseMode(null, null, null, "dModifyDate", System.DateTime.Now.ToString(), null, null));

            lAdd.Add(lTmp);
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        private void SetDelData(IXMLDOMElement doc)
        {
            lTmp = new List<BaseMode>();
            lTmp.Add(new BaseMode("barcode", GetNodeAttrib(doc, "barcode"), "barcode", "MCARD", GetNodeAttrib(doc, "barcode"), null, null));
            lTmp.Add(new BaseMode("cinvcode", GetNodeAttrib(doc, "cinvcode"), "cinvcode", "MITEMCODE", GetNodeAttrib(doc, "cinvcode"), null, null));
            //lTmp.Add(new BaseMode("ccuscode", GetNodeValue(doc, "/customer/ccuscode"), "/customer/ccuscode", "VENDORITEMCODE", GetNodeValue(doc, "/customer/ccuscode")));
            //lTmp.Add(new BaseMode("cvencode", GetNodeAttrib(doc, "cvencode"), "cvencode", "VENDORCODE", GetNodeAttrib(doc, "cvencode")));
            //lTmp.Add(new BaseMode("ccuscode", GetNodeValue(doc, "/customer/ccuscode"), "/customer/ccuscode", "VenderLotNO", GetNodeValue(doc, "/customer/ccuscode")));

            //lTmp.Add(new BaseMode("ccusname", GetNodeValue(doc, "/customer/ccusname"), "/customer/ccusname", "DATECODE", GetNodeValue(doc, "/customer/ccusname")));    //生产日期
            //lTmp.Add(new BaseMode("ccuscode", GetNodeValue(doc, "/customer/ccuscode"), "/customer/ccuscode", "TransNO", GetNodeValue(doc, "/customer/ccuscode")));
            //lTmp.Add(new BaseMode("ccusname", GetNodeValue(doc, "/customer/ccusname"), "/customer/ccusname", "TransLine", GetNodeValue(doc, "/customer/ccusname")));
            lTmp.Add(new BaseMode("qty", GetNodeAttrib(doc, "qty"), "qty", "LOTQTY", GetNodeAttrib(doc, "qty"), null, null));     //生产数量
            lTmp.Add(new BaseMode(null, null, null, "Flag", "W", null, null));


            lTmp.Add(new BaseMode(null, null, null, "EDITPROP", "D", null, null));
            lTmp.Add(new BaseMode(null, null, null, "FINISHFLAG", "0", null, null));
            lTmp.Add(new BaseMode(null, null, null, "dModifyDate", System.DateTime.Now.ToString(), null, null));

            lDel.Add(lTmp);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        private void SetModData(IXMLDOMElement doc)
        {
            lTmp = new List<BaseMode>();
            lTmp.Add(new BaseMode("barcode", GetNodeAttrib(doc, "barcode"), "barcode", "MCARD", GetNodeAttrib(doc, "barcode"), null, null));
            lTmp.Add(new BaseMode("cinvcode", GetNodeAttrib(doc, "cinvcode"), "cinvcode", "MITEMCODE", GetNodeAttrib(doc, "cinvcode"), null, null));
            //lTmp.Add(new BaseMode("ccuscode", GetNodeValue(doc, "/customer/ccuscode"), "/customer/ccuscode", "VENDORITEMCODE", GetNodeValue(doc, "/customer/ccuscode")));
            //lTmp.Add(new BaseMode("cvencode", GetNodeAttrib(doc, "cvencode"), "cvencode", "VENDORCODE", GetNodeAttrib(doc, "cvencode")));
            //lTmp.Add(new BaseMode("ccuscode", GetNodeValue(doc, "/customer/ccuscode"), "/customer/ccuscode", "VenderLotNO", GetNodeValue(doc, "/customer/ccuscode")));

            //lTmp.Add(new BaseMode("ccusname", GetNodeValue(doc, "/customer/ccusname"), "/customer/ccusname", "DATECODE", GetNodeValue(doc, "/customer/ccusname")));    //生产日期
            //lTmp.Add(new BaseMode("ccuscode", GetNodeValue(doc, "/customer/ccuscode"), "/customer/ccuscode", "TransNO", GetNodeValue(doc, "/customer/ccuscode")));
            //lTmp.Add(new BaseMode("ccusname", GetNodeValue(doc, "/customer/ccusname"), "/customer/ccusname", "TransLine", GetNodeValue(doc, "/customer/ccusname")));
            lTmp.Add(new BaseMode("qty", GetNodeAttrib(doc, "qty"), "qty", "LOTQTY", GetNodeAttrib(doc, "qty"), null, null));     //生产数量
            lTmp.Add(new BaseMode(null, null, null, "Flag", "W", null, null));

            lTmp.Add(new BaseMode(null, null, null, "EDITPROP", "M", null, null));
            lTmp.Add(new BaseMode(null, null, null, "FINISHFLAG", "0", null, null));
            lTmp.Add(new BaseMode(null, null, null, "dModifyDate", System.DateTime.Now.ToString(), null, null));


            lMod.Add(lTmp);
        }
        #endregion

        #region  数据库操作
        public override object Save()
        {
            if (lAdd.Count > 0)
            {
                lst = lAdd;
                base.Insert();
            }

            if (lMod.Count > 0)
            {
                lst = lMod;
                base.Insert();
            }
            if (lDel.Count > 0)
            {
                lst = lDel;
                base.Delete();
            }
            return true;
        }


        public override object Delete()
        { 
            if (lDel.Count > 0)
            {
                lst = lDel;
                base.Delete();
            }
            return true;
        }
        #endregion

    }
}
