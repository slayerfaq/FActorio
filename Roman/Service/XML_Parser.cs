using System;
using System.Xml;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Roman.Service
{
    class XML_Parser
    {
        public XML_Data ReadXML()
        {
            List<List<string>> inputParams = new List<List<string>>();
            List<List<string>> inputValues = new List<List<string>>();
            List<string> inputTables = new List<string>();

            XDocument doc = XDocument.Load(@"C:/Users/Baker/Downloads/v8(15)/v8/Roman/sample.xml");
            Console.WriteLine(doc.Root.Name.LocalName);
            foreach (XElement el in doc.Root.Elements())
            {
                List<string> tmpParams = new List<string>();
                List<string> tmpValues = new List<string>();
                Console.WriteLine(el.Name.LocalName);
                inputTables.Add(el.Name.LocalName);
                foreach (XElement elem in el.Elements())
                {
                    tmpParams.Add(elem.Name.LocalName);
                    tmpValues.Add(elem.Value);
                    Console.WriteLine(elem.Name.LocalName);
                    Console.WriteLine(elem.Value);
                }
                inputParams.Add(tmpParams);
                inputValues.Add(tmpValues);
            }

            /*XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:/Users/Baker/Downloads/v8(13)/v8/Roman/sample.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("name");
                    if (attr != null)
                        Console.WriteLine(attr.Value);
                }
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "company")
                    {
                        Console.WriteLine($"Компания: {childnode.InnerText}");
                    }
                    if (childnode.Name == "age")
                    {
                        Console.WriteLine($"Возраст: {childnode.InnerText}");
                    }
                }
                Console.WriteLine();
            }*/
            //Console.Read();
            return new XML_Data(inputTables, inputParams, inputValues);
        }
    }
}
