using System;
using System.Collections.Generic;
using System.Linq;

namespace No5.Solution.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            List<DocumentPart> docParts = new List<DocumentPart>();
            docParts.Add(new BoldText() { Text = "BOLD_TEXT" });
            docParts.Add(new HyperLink() { Text = "HYPER_LINK_TEXT", Url = "some//url" });
            docParts.Add(new PlainText() { Text = "PLAIN_TEXT" });

            Document newDoc = new Document(docParts.AsEnumerable());

            string xmlDoc = newDoc.Convert(ConvertType.ToXml);
            System.Console.WriteLine(xmlDoc);

            string plainText = newDoc.Convert(ConvertType.ToPlainText);
            System.Console.WriteLine(plainText);

            string laTeXText = newDoc.Convert(ConvertType.ToLaTeX);
            System.Console.WriteLine(laTeXText);

            System.Console.ReadLine();
        }
    }
}
