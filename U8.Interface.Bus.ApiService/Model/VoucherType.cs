using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Interface.Bus.ApiService.Model
{
    public class VoucherType
    {

        /// <summary>
        /// 来源单据类型
        /// </summary>
        string sourceCardNo;
        public string SourceCardNo
        {
            get
            {
                return sourceCardNo;
            }
            set
            {
                sourceCardNo = value;
            }
        }
         
        /// <summary>
        /// 来源单据号
        /// </summary>
        string sourceVoucherNo;
        public string SourceVoucherNo
        {
            get
            {
                return sourceVoucherNo;
            }
            set
            {
                sourceVoucherNo = value;
            }
        }


        string voucherName;
        public string VoucherName
        {
            get
            {
                return voucherName;
            }
            set
            {
                voucherName = value;
            }
        }


        /// <summary>
        /// 单据类型
        /// </summary>
        string cardNo;
        public string CardNo
        {
            get
            {
                return cardNo;
            }
            set
            {
                cardNo = value;
            }
        
        }


        /// <summary>
        /// 单据标识
        /// </summary>
        string cardId;
        public string CardId
        {
            get
            {
                return cardId;
            }
            set 
            {
                cardId = value;
            }
        }

        string voucherClassDllpath;
        public string VoucherClassDllpath
        {
            get
            {
                return voucherClassDllpath;
            }
            set
            {
                voucherClassDllpath = value;
            }
        }

        string voucherClassNamespace;
        public string VoucherClassNamespace
        {
            get {
                return voucherClassNamespace;
            }
            set 
            {
                voucherClassNamespace = value;
            }
        }
        

        /// <summary>
        /// 单据对应的op类
        /// </summary>
        string voucherClass;
        public string VoucherClass
        {
            get
            {
                return voucherClass;
            }
            set
            {
                voucherClass = value;
            }
        
        }
    }
}
