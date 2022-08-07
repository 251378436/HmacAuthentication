using Microsoft.AspNetCore.Mvc.Filters;

namespace Server.Filters
{
    public class CustomExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Console.WriteLine("*****************");
            Console.WriteLine("Step 6 - 2: Exception Filter");
            Console.WriteLine("*****************");
        }
    }
}
