using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Collections;

namespace Ameinfo.Framework.AOP
{
    [AttributeUsage(AttributeTargets.Method| AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public abstract class AspectBaseAttibute : ContextAttribute, IContributeObjectSink
    {
        
        public string AssemblyFillName = "";
        public string Aspectname ="";
        public string MethodName = "";
        private string _aspectmethodname = "";
        private string _assemblyname = "";
        private AspectBaseAttibute(string AspectName, string AspectMethodName, string AssemblyName)
            : this(AspectName, AspectMethodName)
        {
            _assemblyname = AssemblyName;
            
        }
        private AspectBaseAttibute(string AspectName, string AspectMethodName)
            : this(AspectName)
        {
            _aspectmethodname = AspectMethodName;

        }
        public AspectBaseAttibute(string AspectName)
                : base(AspectName)
        {
            XMLContainer xmlcontainer=Container.SelectClass(AspectName);
            string aspectmethodname = "";
            string assemblydll = "";
            if (xmlcontainer != null)
            {
                aspectmethodname = xmlcontainer.Attibute;
                assemblydll = xmlcontainer.Assembly;
                AssemblyFillName = xmlcontainer.Namespace + "." + AspectName;

            }
            else
            {
                Aspectname = AspectName;
                assemblydll = (((GetType().Assembly)).ManifestModule).Name;
                AssemblyFillName = AspectName;
                aspectmethodname = GetType().Namespace + "." + GetType().Name;
            }
            Aspectname = AspectName;
            _assemblyname = assemblydll;
            _aspectmethodname = aspectmethodname;
        }
        public AspectBaseAttibute()
            : base("AspectBaseAttibute-" +Guid.NewGuid().ToString())
        {
            string aspectmethodname = "";
            string assemblydll = "";
            assemblydll = (((GetType().Assembly)).ManifestModule).Name;
            aspectmethodname = GetType().Namespace + "." + GetType().Name;
            _assemblyname = assemblydll;
            _aspectmethodname = aspectmethodname;
            string _methodname = MethodName;
        }
        public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink next)
        {
            //var assembly = Assembly.LoadFrom(_assemblyname);                                              
            //object[] parameters = new object[3];
            //parameters[0] = next;
            //parameters[1] = _aspectmethodname;
            //parameters[2] = _assemblyname;
            ////parameters[3] = MethodName;
            //object Aspect = assembly.CreateInstance(AssemblyFillName, true, System.Reflection.BindingFlags.Default, null, parameters, null, null);//
            AspectBase aspectbase = new AspectBase(next, _aspectmethodname, _assemblyname);
            if (aspectbase == null)
            {
                throw new System.Exception("无法找的当前" + Aspectname);
            }
            return aspectbase;
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
