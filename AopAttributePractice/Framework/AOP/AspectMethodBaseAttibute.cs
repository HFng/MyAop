using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Collections;

namespace Capinfo.Framework.AOP
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AspectMethodBaseAttibute : Attribute
    {
         public string _aspectname = null;
        /// <summary>
        /// 标示方法内所有数据库操作加入事务控制
        /// </summary>
         public AspectMethodBaseAttibute()
             : base()
        {
            string ss = "";

        }
        public virtual IEnumerable Before(IMessage msg)
        {
            return "";
        }
        public virtual IEnumerable After(IMethodReturnMessage returnMessage)
        {
            return "";
        }

    }
}
