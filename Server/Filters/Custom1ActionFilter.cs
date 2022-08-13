using Microsoft.AspNetCore.Mvc.Filters;

namespace Server.Filters
{
    public class Custom1ActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var parameter = context.ActionArguments.FirstOrDefault().Value;
            if (parameter == null)
                return;


            // Do something before the action executes.
            Console.WriteLine("*****************");
            Console.WriteLine("Step 4 - 4 - 1: Action Filter 1");
            Console.WriteLine("*****************");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something after the action executes.
            Console.WriteLine("*****************");
            Console.WriteLine("Step 6 - 1 - 1: Action Filter 1 executed");
            Console.WriteLine("*****************");
        }
    }
}
