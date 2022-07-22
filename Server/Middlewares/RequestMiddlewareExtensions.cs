namespace Server.Middlewares
{
    public static class RequestMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestBefore(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestBeforeMiddleware>();
        }

        public static IApplicationBuilder UseRequestAfter(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestAfterMiddleware>();
        }
    }
}
