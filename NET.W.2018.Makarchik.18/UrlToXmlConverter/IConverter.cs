using System.Collections.Generic;

namespace UrlToXmlConverter
{
    /// <summary>
    /// Converter interface
    /// </summary>
    public interface IConverter<T, U>
    {
        IEnumerable<U> Convert(IEnumerable<T> source);
    }
}
