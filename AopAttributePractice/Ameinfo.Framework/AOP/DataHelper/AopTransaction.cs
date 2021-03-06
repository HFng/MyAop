﻿using System;
using System.Collections.Generic;

using System.Text;
using System.Runtime.Remoting.Messaging;
using System.Data.SqlClient;
using System.Data;

namespace Ameinfo.Framework.AOP.DataHelper
{
    public sealed class AopTransaction : IMessageSink
    {
        private IMessageSink nextSink; //保存下一个接收器
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="next">接收器</param>
        public AopTransaction(IMessageSink nextSink, string contextName)
        {
            ContextName = contextName;
            this.nextSink = nextSink;
        }

        /// <summary>
        ///  IMessageSink接口方法，用于异步处理，我们不实现异步处理，所以简单返回null,
        ///  不管是同步还是异步，这个方法都需要定义
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="replySink"></param>
        /// <returns></returns>
        public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
        {
            return null;
        }

        /// <summary>
        /// 下一个接收器
        /// </summary>
        public IMessageSink NextSink
        {
            get { return nextSink; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public IMessage SyncProcessMessage(IMessage msg)
        {
            IMessage retMsg = null;

            IMethodCallMessage call = msg as IMethodCallMessage;

            if (call == null || (Attribute.GetCustomAttribute(call.MethodBase, typeof(AopTransactionMethodAttribute))) == null)
                retMsg = nextSink.SyncProcessMessage(msg);
            else
            {
                //此处换成自己的数据库连接
                //using (IDbConnection Connect = DataBase.GetConnection())
                //{
                //    Connect.Open();
                //    IDbTransaction SqlTrans = Connect.BeginTransaction();

                //    //讲存储存储在上下文
                //    CallContext.SetData(AopTransaction.ContextName, SqlTrans);

                //    //传递消息给下一个接收器 - > 就是指执行你自己的方法
                //    retMsg = nextSink.SyncProcessMessage(msg);

                //    if (SqlTrans != null)
                //    {
                //        IMethodReturnMessage methodReturn = retMsg as IMethodReturnMessage;
                //       System.Exception except = methodReturn.Exception;

                //        if (except != null)
                //        {
                //            SqlTrans.Rollback();
                //            //可以做日志及其他处理
                //        }
                //        else
                //        {
                //            SqlTrans.Commit();
                //        }
                //        SqlTrans.Dispose();
                //        SqlTrans = null;
                //    }
                //}
            }

            return retMsg;
        }

        /// <summary>
        /// 用于提取、存储SqlTransaction
        /// </summary>
        public static string ContextName
        {
            set;
            get;
        }
    }
}
