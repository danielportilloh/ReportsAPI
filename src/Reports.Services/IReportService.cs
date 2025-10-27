using Reports.Models;

namespace Reports.Services;

public interface IReportService
{
    Task<IEnumerable<Report>> GetReportByStatusAsync(string status);
    Task<Report> CreateAsync(Report report);
}

