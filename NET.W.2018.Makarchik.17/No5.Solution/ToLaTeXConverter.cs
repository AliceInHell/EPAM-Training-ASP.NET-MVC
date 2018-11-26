using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No5.Solution
{
    public static class ToLaTeXConverter
    {
        public static string ToLaTeX(this BoldText boldText)
        {
            return "\\textbf{" + boldText.Text + "}";
        }

        public static string ToLaTeX(this HyperLink hyperLink)
        {
            return "\\href{" + hyperLink.Url + "}{" + hyperLink.Text + "}";
        }

        public static string ToLaTeX(this PlainText plainText)
        {
            return plainText.Text;
        }
    }
}
