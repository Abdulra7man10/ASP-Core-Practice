var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
bul

var app = builder.Build();
app.UseStaticFiles();
app.MapControllers();


app.Run();
