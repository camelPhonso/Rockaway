using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Roackaway.WebApp.Services;
using Rockaway.WebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSingleton<IStatusReporter>(new StatusReporter());

builder.Services.AddControllersWithViews();

builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<RockawayDbContext>();

var sqliteConnection = new SqliteConnection("Data Source=:memory:");
sqliteConnection.Open();
builder.Services.AddDbContext<RockawayDbContext>(options => options.UseSqlite(sqliteConnection));

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
var app = builder.Build();

// Create Loggers
app.Logger.LogTrace("This is a TRACE message.");
app.Logger.LogDebug("This is a DEBUG message.");
app.Logger.LogInformation("This is an INFORMATION message.");
app.Logger.LogWarning("This is a WARNING message.");
app.Logger.LogError("This is an ERROR message.");
app.Logger.LogCritical("This is a CRITICAL message.");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
	using (var db = scope.ServiceProvider.GetService<RockawayDbContext>()!)
	{
		db.Database.EnsureCreated();
	}
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

// run reporter to view app status
app.MapGet("/status", (IStatusReporter reporter) => reporter.GetStatus());

app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.Run();
