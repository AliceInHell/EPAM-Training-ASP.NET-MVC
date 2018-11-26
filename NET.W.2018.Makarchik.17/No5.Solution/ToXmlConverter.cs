using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No5.Solution
{
    public static class ToXmlConverter
    {
        public static string ToXml(this BoldText boldText)
        {
            return "<b>" + boldText.Text + "</b>";
        } 
        
        public static string ToXml(this HyperLink hyperLink)
        {
            return "<a href=\"" + hyperLink.Url + "\">" + hyperLink.Text + "</a>";
        }

        public static string ToXml(this PlainText plainText)
        {
            return plainText.Text;
        }
    }
}
