using Microsoft.Extensions.Primitives;
using MyFirstApp.CutstomMiddleware;
using System.IO;
using MyFirstApp.CustomConstraints;
using Microsoft.Extensions.FileProviders;
using MyFirstApp.Controllers;
using MyFirstApp.CustomModelsBinders;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(options => 
{
    //options.ModelBinderProviders.Insert(0, new PersonBinderProvider());
});
            
var app = builder.Build();
app.UseRouting();
app.MapControllers();

app.Run();
