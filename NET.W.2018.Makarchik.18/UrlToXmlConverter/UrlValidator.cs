using System;
using System.Collections.Generic;
using System.Linq;
namespace UrlToXmlConverter
{
    /// <summary>
    /// Url validator
    /// </summary>
    public class UrlValidator : IValidator<string>
    {
        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="value">Checking value</param>
        /// <returns>True if correct</returns>
        public bool Validate(string value)
        {
            try
            {
                new Uri(value);
            }
            catch 
            {
                return false;
            }

            return true;
        }
    }
}
