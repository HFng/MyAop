using System;
using System.Collections.Generic;

using System.Text;
using System.Runtime.Remoting.Messaging;

namespace Capinfo.Framework.AOP.Exception
{
    //AOP方法处理类,实现了IMessageSink接口,以便返回给IContributeObjectSink接口的GetObjectSink方法
    public sealed class AopExecptionHandler : IMessageSink
    {
        private IMessageSink nextSink;

        public AopExecptionHandler(IMessageSink nextSink)
        {
            this.nextSink = nextSink;
        }


        public IMessageSink NextSink
        {
            get { return nextSink; }
        }
        //同步处理方法
        public IMessage SyncProcessMessage(IMessage msg)
        {

            IMessage message = null;

            //方法调用接口
            IMethodCallMessage callMessage = msg as IMethodCallMessage;

            IMethodReturnMessage returnMessage = null;

            //如果被调用的方法没打MyCalculatorMethodAttribute标签
            if (callMessage == null || (Attribute.GetCustomAttribute(callMessage.MethodBase, typeof(AopExecptionMethodAttribute))) == null)
            {
                message = nextSink.SyncProcessMessage(msg);
            }
            else
            {
                //PreProceed(msg);
                try
                {
                    message = nextSink.SyncProcessMessage(msg);
                }
                catch
                {

                }
                returnMessage = message as System.Runtime.Remoting.Messaging.IMethodReturnMessage;

                System.Exception except = returnMessage.Exception;

                if (except != null)
                {
                    //可以做日志及其他处理
                }
                else
                {

                }
            }
            return message;
        }

        //异步处理方法
        public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
        {
            //Console.WriteLine("异步处理方法...");
            return null;
        }

        //方法执行前
        public void PreProceed(IMessage msg)
        {
            //IMethodMessage message = (IMethodMessage)msg;
            //Console.WriteLine("New Method Start...");
            //Console.WriteLine("This Method Is {0}", message.MethodName);
            //Console.WriteLine("This Method A Total of {0} Parameters Including:", message.ArgCount);
            //for (int i = 0; i < message.ArgCount; i++)
            //{
            //    Console.WriteLine("Parameter{0}：The Args Is {1}.",i+1,message.Args[i]);
            //}
        }

        //方法执行后
        public void PostProceed(System.Exception ex)
        {
            //IMethodReturnMessage message = (IMethodReturnMessage)msg;

            //Console.WriteLine("The Return Value Of This Method Is {0}", message.ReturnValue);
            //Console.WriteLine("Method End\n");
            Console.Write(ex);
        }



    }
}
