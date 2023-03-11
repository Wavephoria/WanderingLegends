var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();
app.UseEndpoints(a => a.MapControllers());

app.Run();