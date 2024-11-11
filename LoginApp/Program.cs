using Microsoft.Extensions.Primitives;
using MyFirstApp.CutstomMiddleware;
using System.IO;

namespace MyFirstApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var app = builder.Build();

            app.UseLoginMiddleware();

            app.Run(async (context) => {
                await context.Response.WriteAsync("No Response\n");
            });

            app.Run();
        }
    }
}
