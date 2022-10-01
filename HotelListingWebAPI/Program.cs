using HotelListing.DataAccess.Data;
using HotelListing.DataAccess.Repository;
using HotelListing.DataAccess.Repository.IRepository;
using HotelListing.Models.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Added For SeriLog
var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();

// Add services to the container.
// Added Newtonsoft Json for ASP .NET MVC Core to remove Object Loop Cycle Bug
builder.Services.AddControllers().AddNewtonsoftJson(
    u => u.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "HotelListing", Version = "v1"}));

// Added For SeriLog
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Added Cross Origin Resourse Sharing Policy CORS (For Communicating with Different Network/Project)
builder.Services.AddCors(c => c.AddPolicy(
    "AllowAll",
    builder => builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader())
);

// Add service to connect to SQL Server Database
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
));

// Added AutoMapper
builder.Services.AddAutoMapper(typeof(MapperInitializer));

// Added Unit Of Work 
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policyName: "AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

try
{
    logger.Information("Application is Starting");
    app.Run();
}
catch (Exception e)
{
    logger.Fatal(e, "Application Failed to Start");
}
finally
{
    Log.CloseAndFlush();
}

