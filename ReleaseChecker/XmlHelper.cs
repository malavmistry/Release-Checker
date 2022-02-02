using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ReleaseChecker
{
    class XmlHelper
    {
        public static List<Dictionary<string, string>> ReadXml(string file, string node)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(file);
            XmlNodeList aNodes = xmldoc.SelectNodes(node);
            List<Dictionary<string, string>> fileData = new List<Dictionary<string, string>>();
            foreach (XmlNode aNode in aNodes[0].ChildNodes)
            {
                var dict = new Dictionary<string, string>();
                foreach (XmlAttribute attribute in aNode.Attributes)
                {
                    dict.Add(attribute.Name, attribute.Value);
                }
                fileData.Add(dict);
            }
            return fileData;
        }
        public static void SaveXml(string file, string node, KeyValuePair<string, string> data)
        {
            var fileData = ReadXml(file, node);
            if (fileData.Any(x => x["key"] == data.Value))
                throw new ApplicationException($"Token name: {data.Value} already exists");

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(file);
            XmlNodeList aNodes = xmldoc.SelectNodes(node);
            XmlElement token = xmldoc.CreateElement("add");
            token.SetAttribute("key", data.Key);
            token.SetAttribute("value", data.Value);
            xmldoc.LastChild.AppendChild(token);
            xmldoc.Save(file);
        }
        public static void CreateNewXmlFile(string filePath, string node)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml($"<{node}></{node}>");

            using (XmlTextWriter writer = new XmlTextWriter(filePath, null))
            {
                writer.Formatting = Formatting.Indented;
                doc.Save(writer);
            }
        }
        public static void DeleteXmlRecord(string file, string node, string value)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(file);
            XmlNodeList aNodes = xmldoc.SelectNodes(node);
            foreach (XmlNode aNode in aNodes[0].ChildNodes)
            {
                foreach (XmlAttribute attribute in aNode.Attributes)
                {
                    if (attribute.Value == value) {
                        aNodes[0].RemoveChild(aNode);
                        break;
                    }
                }
            }
            xmldoc.Save(file);
        }
    }
}
