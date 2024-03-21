using AdminConsole.Repository.Container;
using AdminConsole.Repository.Repositories.Service;
using ExceptionHandling.Middlewares;
using Hangfire;

using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(15);
});
builder.Services.AddControllersWithViews();

builder.Services.AddCustomContainer(builder.Configuration);
builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
//Hangfire

builder.Services.AddHangfire(x =>
{
    x.UseSqlServerStorage(builder.Configuration.GetConnectionString("DBconnectionCachDB10"));
});

builder.Services.AddHangfireServer();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
// In your Configure method
app.UseHangfireDashboard(); // Optional: Allows access to Hangfire's dashboard for monitoring

// Schedule the recurring job to execute every minute
RecurringJob.AddOrUpdate<MyScheduledTasks>(x => x.SendData(), Cron.MinuteInterval(1));


app.UseRouting();

app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=HirerachyMaster}/{action=AddHirerarchy}/{id?}");

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.Run();
