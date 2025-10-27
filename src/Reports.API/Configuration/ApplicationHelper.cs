using Reports.Data.Models;

namespace Reports.API.Configuration;

public static class ApplicationHelper
{
    public static async Task SeedDatabase(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ReportContext>();
        var logger = app.Services.GetRequiredService<ILogger<Program>>();
        dbContext.Database.EnsureCreated();

        try
        {
            if (!dbContext.Reports.Any())
            {
                dbContext.Add(new Report { Title = "First Report", Content = "This is the content of the first report.", Status = "Open", CreatedDate = DateTime.UtcNow });
                await dbContext.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while seeding the database.");
        }
    }
}