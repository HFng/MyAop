using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Messaging;

namespace Ameinfo.Framework.AOP.Cache
{
   public class AopCache:IMessageSink
    {

        private IMessageSink nextSink; //保存下一个接收器
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="next">接收器</param>
       public AopCache(IMessageSink nextSink)
        {
            this.nextSink = nextSink;
        }
        public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
        {
            return null;
            //throw new NotImplementedException();
        }
        /// <summary>
        /// 下一个接收器
        /// </summary>
        public IMessageSink NextSink
        {
            get { return nextSink; }
        }
        public IMessage SyncProcessMessage(IMessage msg)
        {
            IMessage message = null;

            //方法调用接口
            IMethodCallMessage callMessage = msg as IMethodCallMessage;

            IMethodReturnMessage returnMessage = null;

            //如果被调用的方法没打MyCalculatorMethodAttribute标签
            if (callMessage == null || (Attribute.GetCustomAttribute(callMessage.MethodBase, typeof(AopCacheMethodAttribute))) == null)
            {
                message = nextSink.SyncProcessMessage(msg);
            }
            else
            {
                PreProceed();
                try
                {
                    message = nextSink.SyncProcessMessage(msg);
                }
                catch
                {

                }
                returnMessage = message as System.Runtime.Remoting.Messaging.IMethodReturnMessage;

                //PostProceed(returnMessage.Exception);
                //PostProceed(message);
            }
            return message;
        }
        public virtual void PreProceed()
        {

        }
    }
}
