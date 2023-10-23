namespace Entities.Exceptions
{
    public abstract partial class NotFound : Exception
    {
        protected NotFound(string message) : base(message)
        {
            
        }
    }
}
