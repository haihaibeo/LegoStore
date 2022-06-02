namespace LegoStoreAPI.Exceptions
{
    public class ProductThemeDuplicatedException : Exception
    {
        public string ProductID { get; set; }
        public int ThemeID { get; set; }

        public ProductThemeDuplicatedException(string productID, int themeID, string? message, Exception? innerException = null) : base(message, innerException)
        {
            ProductID = productID;
            ThemeID = themeID;
        }
    }
}
