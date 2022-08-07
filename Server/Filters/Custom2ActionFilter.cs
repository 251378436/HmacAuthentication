using Microsoft.AspNetCore.Mvc.Filters;

namespace Server.Filters
{
    public class Custom2ActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Do something before the action executes.
            Console.WriteLine("*****************");
            Console.WriteLine("Step 4 - 4 - 2: Action Filter 2");
            Console.WriteLine("*****************");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something after the action executes.
            Console.WriteLine("*****************");
            Console.WriteLine("Step 6 - 1 - 2: Action Filter 2 executed");
            Console.WriteLine("*****************");
        }
    }
}
