using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Interface.Bus.ApiService.Model
{
   public class IrownoModel
    {
        string tablename;

        public string Tablename
        {
            get { return tablename; }
            set { tablename = value; }
        }
        string idname;

        public string Idname
        {
            get { return idname; }
            set { idname = value; }
        }
        string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        string autoidname;

        public string Autoidname
        {
            get { return autoidname; }
            set { autoidname = value; }
        }
        string fliedname;

        public string Fliedname
        {
            get { return fliedname; }
            set { fliedname = value; }
        }
        string barcodename;

        public string Barcodename
        {
            get { return barcodename; }
            set { barcodename = value; }
        }
        string barcodefomat;

        public string Barcodefomat
        {
            get { return barcodefomat; }
            set { barcodefomat = value; }
        }
        string code;

        public string Code
        {
            get { return code; }
            set { code = value; }
        }
    }
}
