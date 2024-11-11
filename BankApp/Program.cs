using Microsoft.Extensions.Primitives;
using System.IO;

namespace BankApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            var app = builder.Build();
            app.UseRouting();
            app.MapControllers();

            app.Run();
        }
    }
}
