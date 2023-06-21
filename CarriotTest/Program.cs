

using CarriotTest.Broker;
using CarriotTest.Db.Entities;
using CarriotTest.Models;
using CarriotTest.Services;
using CarriotTest.Workers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();


builder.Services.AddCors(options => {
    options.AddPolicy("CORSPolicy", builder => builder.AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed((hosts) => true));
});

builder.WebHost.ConfigureServices(services => services.AddHostedService<Worker>());
// Add services to the container.
builder.Services.AddSingleton<IWarningService, WarningRepository>();
builder.Services.AddSingleton<ITempLogService, TempLogRepository>();

builder.Services.AddSingleton<IMQttClient, Client_Connections>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("CORSPolicy");

app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
    endpoints.MapHub<BroadcastHub>("/notify");
});

app.MapFallbackToFile("index.html"); ;

app.Run();
