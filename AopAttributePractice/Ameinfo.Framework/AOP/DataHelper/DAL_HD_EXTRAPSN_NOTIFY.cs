using System;
using System.Collections.Generic;

using System.Text;
using System.Data;

namespace Capinfo.Framework.AOP.DataHelper
{
   public class DAL_HD_EXTRAPSN_NOTIFY
    {
       SqlDALBase sql=new SqlDALBase();
       public DataSet GetIC_NO(string IC_NO)
       {
           StringBuilder sb = new StringBuilder();
           sb.Append("select * from HD_EXTRAPSN_NOTIFY");
           sb.Append(" WHERE IC_NO=" + IC_NO);
           return sql.ExecuteDataset(sb.ToString());
           
       }
       public DataSet GetIC_NOErr(string IC_NO)
       {
           StringBuilder sb = new StringBuilder();
           sb.Append("select * from HD_EXTRAPSN_NOTIFY");
           sb.Append("WHERE IC_NO=" + IC_NO);
           return sql.ExecuteDataset(sb.ToString());

       }
    }
}
