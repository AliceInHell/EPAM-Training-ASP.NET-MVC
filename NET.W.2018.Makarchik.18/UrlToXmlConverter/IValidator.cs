
namespace UrlToXmlConverter
{
    /// <summary>
    /// Value validator
    /// </summary>
    /// <typeparam name="T">Value type</typeparam>
    public interface IValidator<T>
    {
        bool Validate(T value);
    }
}
