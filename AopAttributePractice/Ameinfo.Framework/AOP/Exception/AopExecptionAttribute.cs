using System;
using System.Collections.Generic;

using System.Text;
using System.Runtime.Remoting.Contexts;

namespace Ameinfo.Framework.AOP.Exception
{
    //贴上类的标签
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class AopExecptionAttribute : ContextAttribute,
        IContributeObjectSink
    {

        public AopExecptionAttribute()
            : base("AopExecptionAttribute-"+Guid.NewGuid().ToString())
        {
            //AppDomain.CurrentDomain.FirstChanceException += (ss, ee) =>
            //{
            //    Console.WriteLine("AopExecptionAttribute...构造函数" + ee.Exception);
            //};
           //Console.WriteLine("MyCalculatorAttribute...构造函数");
        }


        //实现IContributeObjectSink接口当中的消息接收器接口
        public System.Runtime.Remoting.Messaging.IMessageSink GetObjectSink(MarshalByRefObject obj, System.Runtime.Remoting.Messaging.IMessageSink nextSink)
        {
            return new AopExecptionHandler(nextSink);
        }
    }
}
