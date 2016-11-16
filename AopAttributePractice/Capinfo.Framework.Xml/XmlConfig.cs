using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Configuration;
using System.Reflection;

namespace Capinfo.Framework.Xml
{
    /// <summary>
    /// 说明：程序配置保存帮助类 for XML
    /// 更新：http://www.wxzzz.com/1352.html
    /// </summary>
    public class XmlConfig
    {
        #region 全局变量
        string _xmlPath;        //文件所在路径
        #endregion

        #region 构造函数
        /// <summary>
        /// 初始化一个配置
        /// </summary>
        /// <param name="xmlPath">配置所在路径</param>
        public XmlConfig(string xmlPath)
        {
            //xmlPath = ConfigurationManager.AppSettings["Aspect"];
            string stmp = Assembly.GetExecutingAssembly().Location;
            stmp = stmp.Substring ( 0 , stmp.LastIndexOf ( '\\' ) );//删除文件名
            stmp = stmp.Substring ( 0 , stmp.LastIndexOf ( '\\' ) );//删除文件名
            stmp = stmp.Substring(0, stmp.LastIndexOf('\\'));
            stmp = stmp + '\\' + ConfigurationManager.AppSettings["Aspect"] + '\\' + xmlPath ;
            SetPath(stmp);
            //_xmlPath = Path.GetFullPath(xmlPath);
        }
        private void SetPath(string xmlPath)
        {
            _xmlPath = Path.GetFullPath(xmlPath);
        }
        #endregion

        #region 公有方法
        /// <summary>
        /// 写入配置
        /// </summary>
        /// <param name="value">写入的值</param>
        /// <param name="nodes">节点</param>
        public void Write(string value, params string[] nodes)
        {
            //初始化xml
            XmlDocument xmlDoc = new XmlDocument();
            if (File.Exists(_xmlPath))
                xmlDoc.Load(_xmlPath);
            else
                xmlDoc.LoadXml("<Aspect />");
            XmlNode xmlRoot = xmlDoc.ChildNodes[0];

            //新增、编辑 节点
            string xpath = string.Join("/", nodes);
            XmlNode node = xmlDoc.SelectSingleNode(xpath);
            if (node == null)    //新增节点
            {
                node = makeXPath(xmlDoc, xmlRoot, xpath);
            }
            node.InnerText = value;

            //保存
            xmlDoc.Save(_xmlPath);
        }

        /// <summary>
        /// 读取配置
        /// </summary>
        /// <param name="nodes">节点</param>
        /// <returns></returns>
        public string Read(params string[] nodes)
        {
            XmlDocument xmlDoc = new XmlDocument();
            if (File.Exists(_xmlPath) == false)
                return null;
            else
                xmlDoc.Load(_xmlPath);

            //string xpath = string.Join("/", nodes);
            //xmlDoc.SelectSingleNode("/Aspect/"+nodes[0]+).Attributes[nodes[1]].Value;
            //XmlNode node = xmlDoc.SelectSingleNode("/Aspect/" + xpath);
            //if (node == null)
            //    return null;

            return xmlDoc.SelectSingleNode("/Aspect/"+nodes[0]).Attributes[nodes[1]].Value;
        }
        #endregion

        #region 私有方法
        //递归根据 xpath 的方式进行创建节点
        static private XmlNode makeXPath(XmlDocument doc, XmlNode parent, string xpath)
        {

            // 在XPath抓住下一个节点的名称；父级如果是空的则返回
            string[] partsOfXPath = xpath.Trim('/').Split('/');
            string nextNodeInXPath = partsOfXPath.First();
            if (string.IsNullOrEmpty(nextNodeInXPath))
                return parent;

            // 获取或从名称创建节点
            XmlNode node = parent.SelectSingleNode(nextNodeInXPath);
            if (node == null)
                node = parent.AppendChild(doc.CreateElement(nextNodeInXPath));

            // 加入的阵列作为一个XPath表达式和递归余数
            string rest = String.Join("/", partsOfXPath.Skip(1).ToArray());
            return makeXPath(doc, node, rest);
        }
        #endregion
    }
}
