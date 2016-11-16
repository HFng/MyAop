using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace Capinfo.Framework.AOP
{
    public class AspectBase : IMessageSink
    {
        
        public string aspectbaseattibute = "";
        public IMessageSink nextSink; //保存下一个接收器
        private string _aspectmethodname = "";
        private string _assemblyname = "";
        private string _MethodName = "";
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="next">接收器</param>
        public AspectBase(IMessageSink nextSink, string AspectMethodName, string assemblyname )
        {
            _assemblyname = assemblyname;
             _aspectmethodname = AspectMethodName;
             //_MethodName = MethodName;
            this.nextSink = nextSink;
        }
        public AspectBase()
        {
 
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

            
            var assembly = Assembly.LoadFrom(_assemblyname);
            //obj = assembly.CreateInstance(_aspectmethodname) as AspectBaseAttibute;
            Attribute[] Attributelist = Attribute.GetCustomAttributes(callMessage.MethodBase, false);
            if (Attributelist.Length == 0)
            {
                message = nextSink.SyncProcessMessage(msg);
            }
            else
            {
                IMethodReturnMessage returnMessage=aaa(callMessage,msg, ref message, Attributelist,0);
            }
            return message;
            
        }
        public IMethodReturnMessage aaa(IMethodCallMessage callMessage,  IMessage msg, ref IMessage message, Attribute[] Attributelist,int i)
        {
            IMethodReturnMessage returnMessage = null;
            AspectMethodBaseAttibute obj = null;
            obj = (Attribute.GetCustomAttribute(callMessage.MethodBase, Attributelist[i].GetType())) as AspectMethodBaseAttibute;


                //object o = Activator.CreateInstance(Type.GetType(_aspectmethodname));
                //如果被调用的方法没打MyCalculatorMethodAttribute标签
                if (obj == null)
                {
                    throw new System.Exception("无法找的当前" + _aspectmethodname);
                }
                try
                {
                    if (callMessage == null || (Attribute.GetCustomAttribute(callMessage.MethodBase, Attributelist[i].GetType())) == null)
                    {
                        message = nextSink.SyncProcessMessage(msg);
                    }
                    else
                    {

                        Before(msg, obj);
                        try
                        {
                        if (i == Attributelist.Length-1)
                        {
                            message = nextSink.SyncProcessMessage(msg);
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
                        else
                        {
                            i = i + 1;
                            returnMessage=aaa(callMessage, msg, ref message, Attributelist, i);
                        }
                            
                    }

                        catch
                        {
                            throw new System.Exception("执行的方法中有异常");
                        }
                    
                    After(returnMessage, obj);
                        //break;
                    }


                }
                catch
                {
                    throw new System.Exception();
                }
                finally
                {

                }
            return returnMessage;
        }
        public void Before(IMessage msg,object obj)
        {
            AspectMethodBaseAttibute aspectbaseattibute = obj as AspectMethodBaseAttibute;
            aspectbaseattibute.Before(msg);
            //return "";
        }
        public void After(IMethodReturnMessage returnMessage, object obj)
        {
            AspectMethodBaseAttibute aspectbaseattibute = obj as AspectMethodBaseAttibute;
            aspectbaseattibute.After(returnMessage);
            //return "";
        }
    }
}
