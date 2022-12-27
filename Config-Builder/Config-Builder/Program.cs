using Config_Builder.Services.AppConfig;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Call JsonMerger() method from GetAppConfig.cs
var appConfig = GetAppConfig.JsonMerger();

// Build IConfiguration from appConfig string
builder.Configuration.AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(appConfig)));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();