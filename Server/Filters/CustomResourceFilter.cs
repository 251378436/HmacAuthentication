using Microsoft.AspNetCore.Mvc.Filters;

namespace Server.Filters
{
    public class CustomResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            // Do something after the action executes.
            Console.WriteLine("*****************");
            Console.WriteLine("Step 6 - 4: Resource Filter executed");
            Console.WriteLine("*****************");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("*****************");
            Console.WriteLine("Step 4 - 2: Resource Filter");
            Console.WriteLine("*****************");
        }
    }
}
