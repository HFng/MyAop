using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capinfo.Framework.AOP.DataHelper;
using System.Data;
using Capinfo.Framework.AOP;
using System.Runtime.Remoting.Messaging;
using System.Collections;

namespace Capinfo.Data.DLL
{
    [AspectTest]
    [AopTransaction]
    public class Test : ContextBoundObject
    {
        //[AopExecptionMethod]
        [AspectTest]
        [AopTransactionMethod]
        public DataSet GetIC_NO1(string test)
        {
            DataSet ds = null;
          
            DAL_HD_EXTRAPSN_NOTIFY dal_hd_extrapsn_notify = new DLL.DAL_HD_EXTRAPSN_NOTIFY();
            ds = dal_hd_extrapsn_notify.GetIC_NO("100810861");
            dal_hd_extrapsn_notify.GetIC_NOErr("100810861");
            //ds = GetIC_NO("100810861");
            //GetIC_NOErr("100810861");
            return ds;
        }
    }
    public class AspectTest : AspectBaseAttibute
    {
        public AspectTest()
            : base()
        {
            
        }
        public override IEnumerable Before(IMessage msg)
        {
           
            IMethodMessage message = (IMethodMessage)msg;
            Console.WriteLine("New Method Start...AspectTest-------------Attibute");
            Console.WriteLine("This Method Is {0}", message.MethodName);
            Console.WriteLine("This Method A Total of {0} Parameters Including:", message.ArgCount);
            for (int i = 0; i < message.ArgCount; i++)
            {
                Console.WriteLine("Parameter{0}：The Args Is {1}.", i + 1, message.Args[i]);
                Console.WriteLine("Parameter{0}：The Args Name {1}.", i + 1, message.GetArgName(i));
            }
            if (message.GetArgName(0) == "test")
            {
                //yield return "";
                return "";
            }
            base.Before(msg);
            return "";
            
        }
        public override IEnumerable After(IMethodReturnMessage returnMessage)
        {
            Console.WriteLine("AspectTest-------------Attibute之后的返回值" + returnMessage.ReturnValue.ToString());
            base.After(returnMessage);
            return "";
        }
    }
}
