using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Runtime.Remoting.Messaging;

namespace Ameinfo.Business.BLL.AspectClass
{
    public class TestAttibute : Ameinfo.Framework.AOP.AspectMethodBaseAttibute
    { public TestAttibute(string Aspectname)
            : base()
            //: base(AspectName, typeof(AspectMethodTestAttibute).Namespace + "."+ typeof(AspectMethodTestAttibute).Name, typeof(AspectTestAttibute).Assembly.GetName().Name+".dll")
        {
        }
    public TestAttibute()
        : base()
        {
        }
    public override IEnumerable Before(IMessage msg)
    {
        IMethodMessage message = (IMethodMessage)msg;
        Console.WriteLine("New Method Start...TestAttibute");
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
        Console.WriteLine("TestAttibute之后的返回值" + returnMessage.ReturnValue.ToString());
        base.After(returnMessage);
        return "";
    }
    }
}
