using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

namespace Ameinfo.Framework.AOP.Cache
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class AopCacheAttribute : ContextAttribute, IContributeObjectSink
    {
        public AopCacheAttribute()
            : base("AopCache")
        { }
        public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink next)
        {
            return new AopCache(next);
        }
    }
}
