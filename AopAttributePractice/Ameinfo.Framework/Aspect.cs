using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace Capinfo.Framework.AOP
{
    public abstract class AspectBase : IMessageSink
    {

        private IMessageSink nextSink; //保存下一个接收器
       /// <summary>
       /// 构造函数
       /// </summary>
       /// <param name="next">接收器</param>
        public AspectBase(IMessageSink nextSink)
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
            if (callMessage == null || (Attribute.GetCustomAttribute(callMessage.MethodBase, typeof(AspectMethodAttibute))) == null)
            {
                message = nextSink.SyncProcessMessage(msg);
            }
            else
            {

                Before(msg);
                try
                {
                    message = nextSink.SyncProcessMessage(msg);
                }

                catch
                {

                }
                returnMessage = message as System.Runtime.Remoting.Messaging.IMethodReturnMessage;

                After(returnMessage);
                //PostProceed(message);
            }
            return message;
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
