using System.Collections.Generic;

namespace UrlToXmlConverter
{
    /// <summary>
    /// Repository interface
    /// </summary>
    /// <typeparam name="T">Repository item type</typeparam>
    public interface IRepository<T>
    {
        void Load(string source);

        IEnumerable<T> Provide();
    }
}
