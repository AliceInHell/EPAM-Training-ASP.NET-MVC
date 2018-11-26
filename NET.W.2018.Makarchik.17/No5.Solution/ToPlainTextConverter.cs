using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No5.Solution
{
    public static class ToPlainTextConverter
    {
        public static string ToPlainText(this BoldText boldText)
        {
            return boldText.Text;
        }

        public static string ToPlainText(this HyperLink hyperLink)
        {
            return hyperLink.Text + " [" + hyperLink.Url + "]";
        }

        public static string ToPlainText(this PlainText plainText)
        {
            return "**" + plainText.Text + "**";
        }
    }
}
