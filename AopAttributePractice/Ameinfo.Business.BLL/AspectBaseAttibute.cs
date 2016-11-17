using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace Capinfo.Business.BLL
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class AspectBaseAttibute : ContextAttribute, IContributeObjectSink
    {
        private string _aspectname ="";
        private string _aspectmethodname = "";
        public AspectBaseAttibute(string AspectName, string AspectMethodName)
            : base(AspectName)
        {
            _aspectmethodname = AspectMethodName;
            _aspectname = AspectName;
        }
        public AspectBaseAttibute():base("fff")
        {
 
        }
        public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink next)
        { 
            Assembly assembly = Assembly.GetExecutingAssembly(); // 获取当前程序集                                                 
            object[] parameters = new object[2];
            parameters[0] = next;
            parameters[1] = _aspectmethodname;
            object Aspect = assembly.CreateInstance(_aspectname, true, System.Reflection.BindingFlags.Default, null, parameters, null, null);//
            AspectBase aspectbase = Aspect as AspectBase;
            return aspectbase;
        }
    }
}
