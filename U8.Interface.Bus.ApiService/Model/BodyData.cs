using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace U8.Interface.Bus.ApiService.Model
{
    public class BodyRow
    {
        private List<Model.U8NameValue>  bodycols = new List<U8NameValue>();
        public List<Model.U8NameValue> BodyCols
        {
            get { return bodycols; }
            set { bodycols = value; }
        }

        private List<List<Model.U8NameValue>> childData = new List<List<U8NameValue>>();
        public List<List<Model.U8NameValue>> ChildData 
        {
            get { return childData; }
            set { childData = value; }
        }

    }
}