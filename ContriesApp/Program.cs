using Microsoft.Extensions.Primitives;
using System.IO;

namespace MyFirstApp
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Country> countries = new List<Country>()
            {
                new Country {Id = 1, Name = "United States"},
                new Country {Id = 2, Name = "Canada"},
                new Country {Id = 3, Name = "United Kingdom"},
                new Country {Id = 4, Name = "India"},
                new Country {Id = 5, Name = "Japan"},
            };
            var builder = WebApplication.CreateBuilder(args);

            var app = builder.Build();

            app.UseRouting();

            app.UseEndpoints(endPoints =>
            {
                endPoints.MapGet("/countries", async context =>
                {
                    foreach (var c in countries)
                        await context.Response.WriteAsync($"{c.Id}, {c.Name}\n");
                });

                endPoints.MapGet("/countries/{countryId:int:range(1,100)}", async context =>
                {
                    int countryId = Convert.ToInt32(context.Request.RouteValues["countryId"]);
                    if (countryId >= 1 && countryId <= 100)
                    {
                        Country c = countries.Where(c => c.Id == countryId).FirstOrDefault();
                        if (c != default)
                            await context.Response.WriteAsync($"{c.Name}\n");
                        else
                        {
                            context.Response.StatusCode = 404;
                            await context.Response.WriteAsync($"[No Country]\n");
                        }
                    }
                    else 
                    {
                        context.Response.StatusCode = 400;
                        await context.Response.WriteAsync($"The CountryId should be between 1 and 100\n");
                    }
                });

                endPoints.Map("/", async context =>
                {
                    await context.Response.WriteAsync("Please Complete the URL :)");
                });
            });

            app.Run();
        }
    }
}
