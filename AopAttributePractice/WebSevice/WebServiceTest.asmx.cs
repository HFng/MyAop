﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebSevice
{
    /// <summary>
    /// WebServiceTest 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceTest : System.Web.Services.WebService
    {
        public class TestModel
        {
            public string ID
            {
                set;
                get;
            }
        }

        [WebMethod]
        public List<TestModel> HelloWorld(TestModel test)
        {
            List<TestModel> list = new List<TestModel>();
            list.Add(test);
            return list;
        }
        [WebMethod]
        public string HelloWorld1()
        {
            return "HelloWorld";
        }
    }
}