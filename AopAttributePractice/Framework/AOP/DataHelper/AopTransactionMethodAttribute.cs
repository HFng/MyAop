using System;
using System.Collections.Generic;

using System.Text;

namespace Ameinfo.Framework.AOP.DataHelper
{
    /// <summary>
    /// 标示方法内所有数据库操作加入事务控制
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class AopTransactionMethodAttribute : Attribute
    {
        /// <summary>
        /// 标示方法内所有数据库操作加入事务控制
        /// </summary>
        public AopTransactionMethodAttribute()
        {

        }
    }
}
