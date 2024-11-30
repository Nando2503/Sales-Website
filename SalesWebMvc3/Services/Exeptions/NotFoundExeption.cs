namespace SalesWebMvc3.Services.Exeptions
{
    public class NotFoundExeption : ApplicationException
    {

        public NotFoundExeption(string message) : base(message)
        {

        }
    }
}
