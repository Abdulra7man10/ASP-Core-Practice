using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;

namespace MyFirstApp.CutstomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LoginMiddleware
    {
        private readonly RequestDelegate _next;

        public LoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Method == "POST" && context.Request.Path == "/")
            {
                StreamReader reader = new StreamReader(context.Request.Body);
                string body = await reader.ReadToEndAsync();

                //Parse the request body from string into Dictionary
                Dictionary<string, StringValues> queryDict = QueryHelpers.ParseQuery(body);
                string? email = null, password = null;
                if (queryDict.ContainsKey("email"))
                {
                    email = queryDict["email"][0];
                }
                else
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid input for 'email\n");
                }

                if (queryDict.ContainsKey("password"))
                {
                    password = Convert.ToString(queryDict["password"][0]);
                }
                else
                {
                    if (context.Response.StatusCode == 200)
                        context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid input for 'password'");
                }

                string actualEmail = "admin@example.com", actualPassword = "admin1234";

                if (email == null && password == null) ;

                else if (email == actualEmail && password == actualPassword)
                {
                    await context.Response.WriteAsync("Successful login");
                }

                else
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid login");
                }
            }

            else
                await _next(context);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LoginMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoginMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoginMiddleware>();
        }
    }
}
