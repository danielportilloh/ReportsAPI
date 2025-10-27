using Reports.Data.Models;

namespace Reports.Data.Repositories;

public interface IReportRepository
{
    Task<Report> AddReportAsync(Report report);
    Task<IEnumerable<Report>> GetReportsAsync(string status);
}
