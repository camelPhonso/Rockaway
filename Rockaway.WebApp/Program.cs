using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Rockaway.WebApp.Data;
using Roackaway.WebApp.Hosting;
using Roackaway.WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSingleton<IStatusReporter>(new StatusReporter());

builder.Services.AddControllersWithViews();

builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<RockawayDbContext>();

builder.Services.AddRazorPages(options => options.Conventions.AuthorizeAreaFolder("admin","/"));

// Create Loggers
ILogger<T> CreateAdHocLogger<T>()
{
	var config = new ConfigurationBuilder()
		.AddJsonFile("appsettings.json", false, true)
		.AddEnvironmentVariables()
		.AddJsonFile(
			$"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
			true,
			true
		)
		.Build();
	return LoggerFactory.Create(lb => lb.AddConfiguration(config)).CreateLogger<T>();
}

var logger = CreateAdHocLogger<Program>();

logger.LogInformation(
	"Rockaway is running on {environment} environment",
	builder.Environment.EnvironmentName
);

if (HostEnvironmentExtentions.UseSqlite(builder.Environment))
{
	logger.LogInformation("Using Sqlite Database");
	var sqliteConnection = new SqliteConnection("Data Source=:memory:");
	sqliteConnection.Open();
	builder.Services.AddDbContext<RockawayDbContext>(options =>
		options.UseSqlite(sqliteConnection)
	);
}
else
{
	logger.LogInformation("Using SQL Server database");
	var connectionString = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
	builder.Services.AddDbContext<RockawayDbContext>(options =>
		options.UseSqlServer(connectionString)
	);
}

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsProduction())
{
	app.UseExceptionHandler("/Error");
	app.UseHsts();
}
else
{
	app.UseDeveloperExceptionPage();
}

using (var scope = app.Services.CreateScope())
{
	using (var db = scope.ServiceProvider.GetService<RockawayDbContext>()!)
	{
		if(HostEnvironmentExtentions.UseSqlite(app.Environment)){
			db.Database.EnsureCreated();
		}
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

app.MapAreaControllerRoute(
	name:"admin",
	areaName: "Admin",
	pattern:"Admin/{controller=Home}/{action=Index}/{id?}"
).RequireAuthorization();


app.Run();
