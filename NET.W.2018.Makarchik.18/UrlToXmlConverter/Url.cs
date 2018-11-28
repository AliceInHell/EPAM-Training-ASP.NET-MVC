using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlToXmlConverter
{
    /// <summary>
    /// Class, that contains url information
    /// </summary>
    public class Url
    {       
        /// <summary>
        /// Initializes a new instance of the <see cref="Url"/> class
        /// </summary>
        /// <param name="hostName">Url's host name</param>
        /// <param name="segments">Url's segments</param>
        /// <param name="parameters">Url's parameters</param>
        public Url(string hostName, List<string> segments, Dictionary<string, string> parameters)
        {
            HostName = hostName;
            Segments = segments;
            Parameters = parameters;
        }

        /// <summary>
        /// Url's host
        /// </summary>
        public string HostName { get; private set; }

        /// <summary>
        /// Url's segments
        /// </summary>
        public List<string> Segments { get; private set; }

        /// <summary>
        /// Url's parameters
        /// </summary>
        public Dictionary<string, string> Parameters { get; private set; }
    }
}
