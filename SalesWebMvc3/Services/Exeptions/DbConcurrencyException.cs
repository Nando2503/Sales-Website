namespace SalesWebMvc3.Services.Exeptions
{
    public class DbConcurrencyException : ApplicationException
    {

        public DbConcurrencyException(string message) : base(message)
        {

        }

    }
}
