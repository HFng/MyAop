using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

namespace Capinfo.Framework.AOP
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AspectMethodAttibute :Attribute
    {
         public string _aspectname = null;
        /// <summary>
        /// 标示方法内所有数据库操作加入事务控制
        /// </summary>
        public AspectMethodAttibute()//:base("aaa")
        {
            string ss = "";

        }

    }
}
