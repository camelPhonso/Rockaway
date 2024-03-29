using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Roackaway.WebApp.Services;
using Rockaway.WebApp.Data;
using Rockaway.WebApp.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSingleton<IStatusReporter>(new StatusReporter());

builder.Services.AddControllersWithViews();

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
var app = builder.Build();

// Create Loggers
ILogger<T> CreateAdHocLogger<T>(){
	var config = new ConfigurationBuilder()
		.AddJsonFile("appsettings.json", false, true)
		.AddEnvironmentVariables()
		.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true, true)
		.Build();
	return LoggerFactory.Create(lb => lb.AddConfiguration(config)).CreateLogger<T>();
}

var logger = CreateAdHocLogger<Program>();

logger.LogInformation("Rockaway is running on {environment} environment", builder.Environment.EnvironmentName);

if (HostEnvironmentExtensions.UseSqlite(builder.Environment)) {
	logger.LogInformation("Using Sqlite database");
	var sqliteConnection = new SqliteConnection("Data Source=:memory:");
	sqliteConnection.Open();
	builder.Services.AddDbContext<RockawayDbContext>(options => options.UseSqlite(sqliteConnection));
} else {
	logger.LogInformation("Using SQL Server database");
	var connectionString = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
	builder.Services.AddDbContext<RockawayDbContext>(options => options.UseSqlServer(connectionString));
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}else{
	app.UseDeveloperExceptionPage();
}

using (var scope = app.Services.CreateScope()) {
	using (var db = scope.ServiceProvider.GetService<RockawayDbContext>()!)
	if(HostEnvironmentExtensions.UseSqlite(app.Environment)){
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
