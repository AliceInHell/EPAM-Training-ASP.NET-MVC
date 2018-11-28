using System;
using System.Collections.Generic;
using NLog;

namespace UrlToXmlConverter
{
    /// <summary>
    /// Converting logic
    /// </summary>
    public class UrlConverter : IConverter<string, Url>
    {
        /// <summary>
        /// String validator
        /// </summary>
        private IValidator<string> _validator;

        /// <summary>
        /// Logger
        /// </summary>
        private ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UrlConverter"/> class
        /// </summary>
        /// <param name="validator"></param>
        public UrlConverter(IValidator<string> validator, ILogger logger)
        {
            _validator = validator;
            _logger = logger;
        }

        /// <summary>
        /// Convert string to Url
        /// </summary>
        /// <param name="source">String source</param>
        /// <returns>Converted to Url strings</returns>
        public IEnumerable<Url> Convert(IEnumerable<string> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"{nameof(source)} can't be null");
            }

            foreach (string url in source)
            {
                if (!_validator.Validate(url))
                {
                    _logger.Error($"{url} can't be converting");
                    continue;
                }

                yield return ParseUrl(url);
            }
        }

        /// <summary>
        /// Parsing logic
        /// </summary>
        /// <param name="url">Parsing string</param>
        /// <returns>Url</returns>
        private Url ParseUrl(string url)
        {
            Uri uri = new Uri(url);

            return new Url(uri.Host, GetSegments(uri.Segments), GetParameters(uri.Query));
        }

        /// <summary>
        /// Get segments as List
        /// </summary>
        /// <param name="segments">Segments</param>
        /// <returns>Segments as List</returns>
        private List<string> GetSegments(string[] segments)
        {
            if (segments == null)
            {
                throw new ArgumentNullException($"{nameof(segments)} can't be null");
            }

            if (segments.Length == 1)
            {
                return null;
            }

            List<string> resultList = new List<string>();
            for (int i = 1; i < segments.Length; i++)
            {
                if (i == segments.Length - 1)
                {
                    resultList.Add(segments[i]);
                    continue;
                }

                resultList.Add(segments[i].Substring(0, segments[i].Length - 1));
            }

            return resultList;
        }

        /// <summary>
        /// Get parameters as Dictionary
        /// </summary>
        /// <param name="parameters">Parameters</param>
        /// <returns>Parameters as Dictionary</returns>
        private Dictionary<string, string> GetParameters(string parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException($"{nameof(parameters)} can't be null");
            }

            if (parameters == string.Empty)
            {
                return null;
            }

            Dictionary<string, string> result = new Dictionary<string, string>();
            string resultString = parameters.Substring(1, parameters.Length - 1);
            string[] query = resultString.Split('&');

            for (int i = 0; i < query.Length; i++)
            {
                string[] parameter = query[i].Split('=');
                result.Add(parameter[0], parameter[1]);
            }

            return result;
        }
    }
}
