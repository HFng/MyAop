using Capinfo.Business.BLL.AspectClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capinfo.Framework.AOP.DataHelper;
using System.Data;
using Capinfo.Data.DLL;
using Capinfo.Data.DLLFactory;
using Capinfo.Framework.AOP;
using Capinfo.Business.BLL;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            //Container xmlconfig = new Container("XMLFile1.xml");
            //xmlconfig.GetXMLContainer();

            #region 一个方法
            DBTest2 b = new DBTest2();
            b.Get("11", "322");
            Console.Read();
            #endregion
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("");


            #region 一个方法中调用另一个类中方法

            DBTest bb = new DBTest();
            try
            {
                bb.TwoMethod();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("");
            DBTest bb1 = new DBTest();
            try
            {
                bb1.Get("11", "322"); ;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            Console.Read();
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("");

            DBTest2 bbb = new DBTest2();
            bbb.TwoMethod();
            Console.Read();


            DataHelper datahelper = new DataHelper();
            datahelper.select();
            #endregion


        }
    }
    //[AspectTestAttibute()]
    //[AspectTestA_Attibute()]
    [Aspect()]
    //[AopTransaction]
    public class DBTest : ContextBoundObject
    {
        [AspectTestAttibute]
        //[AspectTestA_Attibute]
        //[AopTransactionMethod]
        public string Get(string aa, string bb)
        {


            Console.WriteLine("开始执行DBTest类Get(string aa,string bb)方法");
            Console.WriteLine("结束执行DBTest类Get(string aa,string bb)方法");
            return "DBTest";
        }
        [AspectTestAttibute]
        //[AspectTestA_Attibute]
        public void TwoMethod()
        {
            Console.WriteLine("开始执行DBTest类Get(string aa,string bb)方法");
            DBTest1 test = new DBTest1();
            test.GetDBTest1();
            Console.WriteLine("结束执行DBTest类Get(string aa,string bb)方法");

        }


    }
    [Aspect]
    //[AopTransaction]
    public class DBTest2 : ContextBoundObject
    {

        [TestAttibute]
        [AspectTestAttibute]
        //[AspectTestA_Attibute]
        //[AopTransactionMethod]
        public string Get(string aa, string bb)
        {
            Console.WriteLine("开始执行DBTest类Get(string aa,string bb)方法");
            DBTest2 ss = new DBTest2();
            ss.TwoMethod();
            TwoMethod();
            //DBTest1 test = new DBTest1();
            //test.GetDBTest1();
            Console.WriteLine("结束执行DBTest类Get(string aa,string bb)方法");
            return "DBTest";
        }
        [AspectTestA_Attibute]
        public void TwoMethod()
        {
            Console.WriteLine("开始执行DBTest类Get(string aa,string bb)方法");
            //DBTest1 test = new DBTest1();
            //test.GetDBTest1();
            Console.WriteLine("结束执行DBTest类Get(string aa,string bb)方法");

        }


    }

    [Aspect]
    //[AspectTestA_Attibute]
    public class DBTest1 : ContextBoundObject
    {
        [AspectTestA_Attibute]
        [AspectTestAttibute]
        public string GetDBTest1()
        {
            Console.WriteLine("开始执行DBTest1类Get()方法");
            //DAL_HD_EXTRAPSN_NOTIFY dal_hd_extrapsn_notify = new DAL_HD_EXTRAPSN_NOTIFY();
            //dal_hd_extrapsn_notify.GetIC_NOErr("100810861");
            Console.WriteLine("结束执行DBTest1类Get()方法");
            return "DBTest1";
        }
    }



    #region  数据库操作
    //[AopTransaction]
    public class DataHelper 
    {
        //[AopTransactionMethod]
        public DataSet select ()
        {
            Test dal_hd_extrapsn_notify = new Test();
            try
            {
                dal_hd_extrapsn_notify.GetIC_NO1("111");
            }
            catch
            {
 
            }
            
            return null;
        }
    }
    #endregion

}
