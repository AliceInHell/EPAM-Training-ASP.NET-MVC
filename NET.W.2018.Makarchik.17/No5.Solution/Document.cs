using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No5.Solution
{
    public class Document
    {
        private readonly List<DocumentPart> parts;        

        public Document(IEnumerable<DocumentPart> parts)
        {
            if (parts == null)
            {
                throw new ArgumentNullException(nameof(parts));
            }
            this.parts = new List<DocumentPart>(parts);
        }

        public string Convert(ConvertType convertType)
        {
            string output = string.Empty;

            switch (convertType)
            {
                case ConvertType.ToXml:
                    foreach (dynamic part in parts)
                    {                        
                        output += ToXmlConverter.ToXml(part);
                    }
                    break;
                case ConvertType.ToPlainText:
                    foreach (dynamic part in parts)
                    {
                        output += ToPlainTextConverter.ToPlainText(part);
                    }
                    break;
                case ConvertType.ToLaTeX:
                    foreach (dynamic part in parts)
                    {
                        output += ToLaTeXConverter.ToLaTeX(part);
                    }
                    break;
                default:
                    foreach (dynamic part in parts)
                    {
                        output += part.Text;
                    }                    
                    break;
            }

            return output;
        }
    }
}
