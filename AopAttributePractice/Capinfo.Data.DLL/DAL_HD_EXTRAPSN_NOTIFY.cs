using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using Capinfo.Data.DLLFactory;
using Capinfo.Framework.AOP.DataHelper;
using Capinfo.Framework.AOP.Exception;

namespace Capinfo.Data.DLL
{
    //[AopExecption]
   
   public class DAL_HD_EXTRAPSN_NOTIFY:SqlDALBase
    {

       
       public DataSet GetIC_NO1()
       {
           DataSet ds = null;
           ds = GetIC_NO("100810861");
           GetIC_NOErr("100810861");
           //ds = GetIC_NO("100810861");
           //GetIC_NOErr("100810861");
           return ds;
       }
        //[AopTransactionMethod]
       public DataSet GetIC_NO(string IC_NO)
       {
           StringBuilder sb = new StringBuilder();
           sb.Append("select * from HD_EXTRAPSN_NOTIFY");
           sb.Append(" WHERE IC_NO=" + IC_NO);

           return base.ExecuteDataset(sb.ToString());
           
       }
        //[AopTransactionMethod]
       public DataSet GetIC_NOErr(string IC_NO)
       {
           StringBuilder sb = new StringBuilder();
           sb.Append("select * from HD_EXTRAPSN_NOTIFY");
           sb.Append("WHERE IC_NO=" + IC_NO);
           return base.ExecuteDataset(sb.ToString());

       }
    }
}
