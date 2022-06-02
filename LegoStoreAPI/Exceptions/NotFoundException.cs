namespace LegoStoreAPI.Exceptions
{
    public class NotFoundException : Exception
    {
        public string ObjectId { get;set;}
        public NotFoundException(string objectId, string? message, Exception? innerException = null) : base(message, innerException)
        {
            ObjectId = objectId;
        }
    }
}
