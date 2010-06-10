using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace U8.Interface.Bus.Event.SyncAdapter.Biz
{
    public interface ISqlOper
    { 
        object Select();
        object Insert();
        object BatchInsert();
        StringBuilder CreateInsertString();

        object Delete(); 
        object BatchDelete();
        StringBuilder CreateDeleteString();

        object ExecSql(string sql);

        object Update();
        StringBuilder CreateUpdateSql();
        
    }
}
