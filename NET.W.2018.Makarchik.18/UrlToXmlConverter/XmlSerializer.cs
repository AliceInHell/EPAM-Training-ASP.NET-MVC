using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace UrlToXmlConverter
{
    /// <summary>
    /// Xml serializer
    /// </summary>
    public class XmlSerializer : ISerializer<Url>
    {
        public void Serialize(IEnumerable<Url> source, string filePath)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"{nameof(source)} can't be null");
            }

            if (filePath == null || filePath == string.Empty)
            {
                throw new ArgumentException();
            }

            var xml = new XElement(
                "urlAddresses",
                source.Select(
                    x => new XElement(
                        "urlAddress",
                        new XElement(
                            "host",
                             new XAttribute(
                                 "name", 
                                 x.HostName)),
                        new XElement(
                            "uri", 
                            x.Segments.Select(
                                y =>
                                    new XElement(
                                        "segment", 
                                        y))),
                        new XElement(
                            "parameters", 
                            x.Parameters?.Select(
                                y =>
                                    new XElement(
                                        "parameter",
                                        new XAttribute("value", y.Value),
                                        new XAttribute("key", y.Key)))))));

            xml.Elements("urlAddress")
                .Where(x => x.Element("parameters").IsEmpty)
                .AsParallel()
                .ForAll(x => x.Element("parameters")
                .Remove());

            XDocument xDoc = new XDocument(xml);
            xDoc.Save(filePath);
        }
    }
}
