using System;
using System.Collections.Generic;

using System.Text;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Contexts;

namespace Capinfo.Framework.AOP.DataHelper
{
    /// <summary>
    /// 标注类某方法内所有数据库操作加入事务控制
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class AopTransactionAttribute : ContextAttribute, IContributeObjectSink
    {
        public string contextname = "";
        /// <summary>
        /// 标注类某方法内所有数据库操作加入事务控制，请使用TransactionMethodAttribute同时标注
        /// </summary>
        public AopTransactionAttribute(string ContextName)
            : base(ContextName)
        {
            contextname = ContextName;
        }
        public AopTransactionAttribute()
            : base("AopTransactionAttribute-" + Guid.NewGuid().ToString())
        {

            contextname = base.AttributeName;
        }
        public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink next)
        {
            return new AopTransaction(next, contextname);
        }
    }
}
