using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace Capinfo.Framework.AOP
{
    public class AopTest:AspectBase
    {
        private IMessageSink nextSink; //保存下一个接收器
        public AopTest(IMessageSink nextSink):base(nextSink)
        {
            this.nextSink = nextSink;
        }
        public override IEnumerable After(IMethodReturnMessage returnMessage)
        {
            string ss = "";
            Console.WriteLine("AopTest之后的返回值"+returnMessage.ReturnValue.ToString());
           
            base.After(returnMessage);
            return "";
        }
        public override IEnumerable Before(IMessage msg)
        {
            IMethodMessage message = (IMethodMessage)msg;
            Console.WriteLine("New Method Start...");
            Console.WriteLine("This Method Is {0}", message.MethodName);
            Console.WriteLine("This Method A Total of {0} Parameters Including:", message.ArgCount);
            for (int i = 0; i < message.ArgCount; i++)
            {
                Console.WriteLine("Parameter{0}：The Args Is {1}.", i + 1, message.Args[i]);
            }
            base.Before(msg);
            List<string> ss = new List<string>();
            return ss;
        }
    }
    public class AopTest1 : AspectBase
    {
        private IMessageSink nextSink; //保存下一个接收器
        public AopTest1(IMessageSink nextSink) : base(nextSink)
        {
            this.nextSink = nextSink;
        }
        public override IEnumerable After(IMethodReturnMessage returnMessage)
        {
            string ss = "";
            Console.WriteLine("AopTest1之后的返回值"+returnMessage.ReturnValue.ToString());
            
            base.After(returnMessage);
            return "";
        }
        public override IEnumerable Before(IMessage msg)
        {
            base.Before(msg);
            IMethodMessage message = (IMethodMessage)msg;
            Console.WriteLine("New Method Start...");
            Console.WriteLine("This Method Is {0}", message.MethodName);
            Console.WriteLine("This Method A Total of {0} Parameters Including:", message.ArgCount);
            if (message.ArgCount == 0)
            {
                return "";
            }
            else
            {
                for (int i = 0; i < message.ArgCount; i++)
                {
                    Console.WriteLine("Parameter{0}：The Args Is {1}.", i + 1, message.Args[i]);
                }
                return "";
            }
            
           
        }
    }
}
