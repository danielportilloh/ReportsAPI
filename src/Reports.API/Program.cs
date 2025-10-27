using Microsoft.EntityFrameworkCore;
using Reports.API.Configuration;
using Reports.Data.Models;
using Reports.Data.Repositories;
using Reports.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Initialize the database
builder.Services.AddSingleton<ISecretProvider, FakeKeyVaultSecretProvider>();
builder.Services.AddDbContext<ReportContext>((p, options) =>
{
    var secretProvider = p.GetRequiredService<ISecretProvider>();
    var conn = secretProvider.GetSecretAsync("ReportsDb").GetAwaiter().GetResult();
    options.UseSqlite(conn ?? "Data Source=reports.db");
});

// Auto Mapper Configurations
builder.Services.AddAutoMapper(c => c.AddProfile<Reports.API.Map.MappingProfile>());

// Dependency Injection
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<ReportRepository>();

var app = builder.Build();

// Seed the database
await ApplicationHelper.SeedDatabase(app);

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

