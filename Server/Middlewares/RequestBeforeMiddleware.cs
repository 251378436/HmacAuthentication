﻿using System.Text;

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
            using var reader = new StreamReader(
        context.Request.Body,
        encoding: Encoding.UTF8,
        detectEncodingFromByteOrderMarks: false,
        leaveOpen: true);

            string bodyString = await reader.ReadToEndAsync();
            Console.WriteLine("*****************");
            //Console.WriteLine("RequestBeforeMiddleware:" + bodyString);
            Console.WriteLine("Step 1: before middleware");
            Console.WriteLine("*****************");
            context.Request.Body.Position = 0;

            // Call the next delegate/middleware in the pipeline.
            await _next(context);

            Console.WriteLine("*****************");
            Console.WriteLine("Step 7 - 2: before middleware executed");
            Console.WriteLine("*****************");
        }
    }
}