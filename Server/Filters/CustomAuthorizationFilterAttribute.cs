using Microsoft.AspNetCore.Mvc.Filters;

namespace Server.Filters
{
    public class CustomAuthorizationFilterAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Console.WriteLine("*****************");
            Console.WriteLine("Step 4 - 1: Authorization Filter");
            Console.WriteLine("*****************");
        }
    }
}
