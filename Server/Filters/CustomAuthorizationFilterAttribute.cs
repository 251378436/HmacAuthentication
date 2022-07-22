using Microsoft.AspNetCore.Mvc.Filters;

namespace Server.Filters
{
    public class CustomAuthorizationFilterAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Console.WriteLine("*****************");
            Console.WriteLine("CustomAuthorizationFilterAttribute:");
            Console.WriteLine("*****************");
        }
    }
}
