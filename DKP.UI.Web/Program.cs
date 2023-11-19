using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;

using DKP.Infra.Mappings;
using DKP.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.GetConnectionString("DKP");

InjectionDependencyCore.ConfigureServices(builder.Services);
// Add services to the container.
builder.Services.AddControllersWithViews();


var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


FluentMapper.Initialize(config =>
{
    config.AddMap(new ClienteMapping());
    config.ForDommel();
});




app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "DKP",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
