using System.Collections.Generic;

namespace UrlToXmlConverter
{
    /// <summary>
    /// Serializer interface
    /// </summary>
    /// <typeparam name="T">Serializing type</typeparam>
    public interface ISerializer<T>
    {
        void Serialize(IEnumerable<T> source, string filePath);
    }
}
