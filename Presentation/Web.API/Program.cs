using Application;
using Extensions;
using Serilog;
using Persistance;
using Shared;

//Read Configuration from appSettings
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json",
        optional: false,
        reloadOnChange: true)
    .AddJsonFile($"appsettings.{(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development" ? "Development" : (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Staging" ? "Staging" : string.Empty))}.json",
        optional: true,
        reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

//Initialize Logger
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

// create builder
var builder = WebApplication.CreateBuilder(args);

// use Serilog instead of default .Net Logger
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

// Add services to the container.
builder.Services.AddApiVersioningExtension();
builder.Services.AddApplicationLayer();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHealthChecks();
builder.Services.AddPersistenceInfrastructure(configuration);
builder.Services.AddSharedInfrastructure(configuration);
builder.Services.AddSwaggerExtension();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .Build();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
    app.UseHttpsRedirection();
}

app.UseRouting();
app.UseCors("AllowOrigin");
app.UseHttpLogging();
app.UseSwaggerExtension();
app.UseErrorHandlingMiddleware();
app.UseHealthChecks("/health");

app.MapControllers();

// default reply for testing
app.MapGet("/", () => "Hello, You have reached Pay Your Parking WebAPI!!!");

// start app
try
{
    // start app
    await app.RunAsync();

    // log info
    Log.Information("Pay Your Parking(API) started successfuly");
}
catch (Exception ex)
{
    // log info
    Log.Fatal(ex, "Pay Your Parking(API) terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
