using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace U8.Interface.Bus.ApiService.Model
{
    public class BodyRow
    {
        private List<Model.U8NameValue>  bodycols;
        public List<Model.U8NameValue> BodyCols
        {
            get { return BodyCols; }
            set { BodyCols = value; }
        }

        private List<List<Model.U8NameValue>> childData;
        public List<List<Model.U8NameValue>> ChildData 
        {
            get { return childData; }
            set { childData = value; }
        }

    }
}