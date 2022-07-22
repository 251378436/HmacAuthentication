using System.Text;

namespace Server.Middlewares
{
    public class RequestBeforeMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestBeforeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.EnableBuffering();
            string bodyString;
            using (var reader = new StreamReader(
        context.Request.Body,
        encoding: Encoding.UTF8,
        detectEncodingFromByteOrderMarks: false,
        leaveOpen: true))
            {
                bodyString = await reader.ReadToEndAsync();
                Console.WriteLine("*****************");
                Console.WriteLine("RequestBeforeMiddleware:" + bodyString);
                Console.WriteLine("*****************");
                context.Request.Body.Position = 0;
            }

            // Call the next delegate/middleware in the pipeline.
            await _next(context);
        }
    }
}
