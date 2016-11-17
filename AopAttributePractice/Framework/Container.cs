using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ameinfo.Framework.Xml;
using System.Reflection;
using System.Xml;
using System.IO;
using System.Configuration;

namespace Ameinfo.Framework
{
    public class Container
    {
        public string classname = "";
        public string Namespace = "";
        private string _xmlpath = "";
        public static List<XMLContainer> List = new List<XMLContainer>();

        public Container(string XmlPath)
        {
            string stmp = Assembly.GetExecutingAssembly().Location;
            stmp = stmp.Substring(0, stmp.LastIndexOf('\\'));//删除文件名
            stmp = stmp.Substring(0, stmp.LastIndexOf('\\'));//删除文件名
            stmp = stmp.Substring(0, stmp.LastIndexOf('\\'));
            stmp = stmp + '\\' + ConfigurationManager.AppSettings["Aspect"] + '\\' + XmlPath;
            _xmlpath = Path.GetFullPath(stmp);
            GetXMLContainer();
        }
        #region 输入类名获取类的对象
        private object GetObject(string classname)
        {
            return null;
        }
        private void SetObject()
        {
            
        }
        private List<XMLContainer> GetXMLContainer()
        {
            XmlDocument xmlDoc = new XmlDocument();
            if (File.Exists(_xmlpath) == false)
                return null;
            else
                xmlDoc.Load(_xmlpath);
            for (int i = 0; i < xmlDoc.SelectSingleNode("/Aspect").ChildNodes.Count - 1; i++)
            {
                XMLContainer xmlcontainer = new XMLContainer();
                xmlcontainer.Namespace = xmlDoc.SelectSingleNode("/Aspect").ChildNodes[i].Attributes["Namespace"].Value;
                xmlcontainer.ClassName = xmlDoc.SelectSingleNode("/Aspect").ChildNodes[i].Attributes["ClassName"].Value;
                xmlcontainer.Assembly = xmlDoc.SelectSingleNode("/Aspect").ChildNodes[i].Attributes["Assembly"].Value;
                xmlcontainer.Attibute= xmlDoc.SelectSingleNode("/Aspect").ChildNodes[i].Attributes["Attibute"].Value;
                if (SelectClass(xmlcontainer.ClassName)==null)
                {
                    var assembly = Assembly.LoadFrom(xmlcontainer.Assembly);
                    object o = assembly.CreateInstance(xmlcontainer.Namespace + "." + xmlcontainer.ClassName);
                    xmlcontainer.Obj = o;
                    Type t = o.GetType();
                    System.Reflection.MethodInfo[] methods = t.GetMethods();
                    for (int j = 0; j < methods.Length; j++)
                    {
                        xmlcontainer.MethodName += methods[j].ToString() + "|";
                    }
                    List.Add(xmlcontainer);
                }
                
            }
            return List;
        }
        /// <summary>
        /// 查询是否创建对象
        /// </summary>
        /// <param name="classname"></param>
        /// <returns></returns>
        public static XMLContainer SelectClass(string classname)
        {
            XMLContainer xmlcontainer = List.Find(

            delegate (XMLContainer _xmlcontainer)
            {
                return _xmlcontainer.ClassName== classname;
            });
            if (xmlcontainer != null)
                return xmlcontainer;
            else
                return xmlcontainer;
        }
        /// <summary>
        /// 通过方法创建查询是否创建对象
        /// </summary>
        /// <param name="methods"></param>
        /// <returns></returns>
        public static XMLContainer SelectMethods(string methods)
        {
            XMLContainer xmlcontainer = List.Find(

            delegate (XMLContainer _xmlcontainer)
            {
                return _xmlcontainer.MethodName.Contains(methods);
            });
            if (xmlcontainer != null)
                return xmlcontainer;
            else
                return xmlcontainer;
        }
        #endregion

    }

}
