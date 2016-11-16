using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace Capinfo.Framework.AOP
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class AspectAttibute : ContextAttribute, IContributeObjectSink
    {
        public string _aspectname ="";
        private AspectBase _aspect = null;
        public AspectBase AspectName          //属性：Property，对Field进行封装。
        {
            get { return _aspect; }
            set { _aspect = value; }
        }
        public AspectAttibute(string AspectName)
            : base(AspectName)
        {
            _aspectname=Name;
        }
        public AspectAttibute():base("fff")
        {
 
        }
        public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink next)
        { 
            Assembly assembly = Assembly.GetExecutingAssembly(); // 获取当前程序集                                                 
            object[] parameters = new object[1];
            parameters[0] = next;
            object Aspect = assembly.CreateInstance(_aspectname, true, System.Reflection.BindingFlags.Default, null, parameters, null, null);//
            AspectBase aspectbase = Aspect as AspectBase;
            return aspectbase;
        }
    }
}
