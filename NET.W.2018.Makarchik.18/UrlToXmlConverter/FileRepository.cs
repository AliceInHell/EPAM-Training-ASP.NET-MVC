using System.Collections.Generic;
using System.IO;

namespace UrlToXmlConverter
{
    /// <summary>
    /// Url repository
    /// </summary>
    public class FileRepository : IRepository<string>
    {
        /// <summary>
        /// Url container
        /// </summary>
        private IEnumerable<string> _elements;

        /// <summary>
        /// Load url's from text file
        /// </summary>
        /// <param name="source"></param>
        public void Load(string source)
        {
            if (!File.Exists(source))
            {
                throw new FileNotFoundException($"File {nameof(source)} not found");
            }

            _elements = File.ReadLines(source);
        }

        /// <summary>
        /// container provide url's
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> Provide()
        {
            return _elements;
        }
    }
}
