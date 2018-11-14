namespace BookService
{
    public class TitleAuthorAndPriceFormat : IToStringFormat
    {
        public string ToString(Book b)
        {
            return string.Format("{0} record: {1}, {2}, {3}", b.GetType().Name, b.Author, b.Title, b.Price);
        }
    }
}
