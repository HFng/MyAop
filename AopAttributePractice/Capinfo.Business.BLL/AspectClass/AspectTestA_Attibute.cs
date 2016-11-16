using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capinfo.Framework.AOP;
using System.Runtime.Remoting.Messaging;
using System.Collections;

namespace Capinfo.Business.BLL.AspectClass
{
    public class AspectTestA_Attibute : AspectMethodBaseAttibute
    {
        //public string AssemblyFillName = "";
        public AspectTestA_Attibute(string Aspectname)
            : base()
            //: base(AspectName, typeof(AspectMethodTestAttibute).Namespace + "."+ typeof(AspectMethodTestAttibute).Name, typeof(AspectTestAttibute).Assembly.GetName().Name+".dll")
        {
        }
        public AspectTestA_Attibute():base()
        {
        }
        public override IEnumerable Before(IMessage msg)
        {
            IMethodMessage message = (IMethodMessage)msg;
            Console.WriteLine("New Method Start...AspectTestA_Attibute");
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
            Console.WriteLine("AspectTestA_Attibute之后的返回值" + returnMessage.ReturnValue.ToString());
            base.After(returnMessage);
            return "";
        }


    }
}
