using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

namespace Capinfo.Business.BLL
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class AspectMethodBaseAttibute :Attribute
    {
         public string _aspectname = null;
        /// <summary>
        /// 标示方法内所有数据库操作加入事务控制
        /// </summary>
        public AspectMethodBaseAttibute()//:base("aaa")
        {
            string ss = "";

        }

    }
}
