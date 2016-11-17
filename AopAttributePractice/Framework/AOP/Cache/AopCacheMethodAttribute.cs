using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ameinfo.Framework.AOP.Cache
{
     [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AopCacheMethodAttribute:Attribute
    {
        /// <summary>
        /// 标示方法内所有数据库操作加入事务控制
        /// </summary>
         public AopCacheMethodAttribute()
        {

        }
    }
}
