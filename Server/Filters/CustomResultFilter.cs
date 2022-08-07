using Microsoft.AspNetCore.Mvc.Filters;

namespace Server.Filters
{
    public class CustomResultFilter : Attribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            // Do something before the result executes.
            Console.WriteLine("*****************");
            Console.WriteLine("Step 6 - 2: Result Filter");
            Console.WriteLine("*****************");
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            // Do something after the result executes.
            Console.WriteLine("*****************");
            Console.WriteLine("Step 6 - 3: Result Filter executed");
            Console.WriteLine("*****************");
        }
    }
}
