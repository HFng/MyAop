using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Runtime.Remoting.Messaging;
using System.Collections;

namespace Capinfo.Business.BLL.AspectClass
{
    public class AspectTestAttibute : Capinfo.Framework.AOP.AspectMethodBaseAttibute
    {

        //public string AssemblyFillName = "";
        public AspectTestAttibute(string Aspectname)
            : base()
            //: base(AspectName, typeof(AspectMethodTestAttibute).Namespace + "."+ typeof(AspectMethodTestAttibute).Name, typeof(AspectTestAttibute).Assembly.GetName().Name+".dll")
        {
        }
        public AspectTestAttibute():base()
        {
        }
        public override IEnumerable Before(IMessage msg)
        {
            IMethodMessage message = (IMethodMessage)msg;
            Console.WriteLine("New Method Start...AspectTestAttibute");
            Console.WriteLine("This Method Is {0}", message.MethodName);
            Console.WriteLine("This Method A Total of {0} Parameters Including:", message.ArgCount);
            for (int i = 0; i < message.ArgCount; i++)
            {
                Console.WriteLine("Parameter{0}：The Args Is {1}.", i + 1, message.Args[i]);
            }

            base.Before(msg);
            return "";
        }
        public override IEnumerable After(IMethodReturnMessage returnMessage)
        {
            Console.WriteLine("AspectTestAttibute之后的返回值" + returnMessage.ReturnValue.ToString());
            base.After(returnMessage);
            return "";
        }
    }
}
