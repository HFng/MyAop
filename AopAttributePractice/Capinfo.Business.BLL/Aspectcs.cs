using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capinfo.Framework.AOP;
using System.Collections;
using System.Runtime.Remoting.Messaging;

namespace Capinfo.Business.BLL
{
    public class Aspect : AspectBaseAttibute
    {//public IMessageSink nextSink; //保存下一个接收器
        public Aspect(string Aspectname)
            : base(Aspectname)
        //: base(AspectName, typeof(AspectMethodTestAttibute).Namespace + "."+ typeof(AspectMethodTestAttibute).Name, typeof(AspectTestAttibute).Assembly.GetName().Name+".dll")
        {
        }
        public Aspect()
            : base()
        {

        }
        public override IEnumerable Before(IMessage msg)
        {
            return "";
        }
        public override IEnumerable After(IMethodReturnMessage returnMessage)
        {
            return "";
        }
    }
}
