using System;
using System.Collections.Generic;

using System.Text;

namespace Capinfo.Framework.AOP.Exception
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AopExecptionMethodAttribute : Attribute
    {
        public AopExecptionMethodAttribute()
        {
            //AppDomain.CurrentDomain.FirstChanceException += (ss, ee) =>
            //{
            //    Console.WriteLine("MyCalculatorMethodAttribute...构造函数" + ee.Exception);
            //};
           
            //
        }
        
        //public string Name;

    }
}
