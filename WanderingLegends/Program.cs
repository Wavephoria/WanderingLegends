using WanderingLegends.Views.WanderingLegends;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<GameStartVM>();
var app = builder.Build();


app.UseRouting();
app.UseStaticFiles();
app.UseEndpoints(a => a.MapControllers());

app.Run();