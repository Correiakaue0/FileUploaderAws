using FileUploaderAws.Domain.Interfaces.Repositories;
using FileUploaderAws.Domain.Interfaces.Services;
using FileUploaderAws.Domain.Services;
using FileUploaderAws.Infrastructure.AWS;
using FileUploaderAws.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

//IOC
builder.Services.AddSingleton<AwsConnectionFactory>();
builder.Services.AddTransient<IS3FileService, S3FileService>();
builder.Services.AddTransient<IS3FileRepository, S3FileRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
