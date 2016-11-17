using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ameinfo.Framework
{
    public class XMLContainer
    {
        /// <summary>
        /// 命名空间
        /// </summary>
        public string Namespace
        { set; get; }
        /// <summary>
        /// 类名
        /// </summary>
        public string ClassName
        { set; get; }
        /// <summary>
        ///  方法名
        /// </summary>
        public string MethodName
        {
            set;
            get;
        }
        /// <summary>
        /// 程序集
        /// </summary>
        public string Assembly
        {
            set;
            get;
        }
        public object Obj
        {
            set;
            get;
        }
        public string Attibute
        {
            set;get;
        }

    }
}
