using Microsoft.Extensions.Primitives;
using MyFirstApp.CutstomMiddleware;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseLoginMiddleware();

app.Run(async (context) => {
    await context.Response.WriteAsync("No Response\n");
});

app.Run();
