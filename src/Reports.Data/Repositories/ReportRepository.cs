using Microsoft.EntityFrameworkCore;
using Reports.Data.Models;

namespace Reports.Data.Repositories;

public class ReportRepository : IReportRepository
{
    private readonly ReportContext _reportContext;

    public ReportRepository(ReportContext reportContext)
    {
        _reportContext = reportContext;
    }

    public async Task<IEnumerable<Report>> GetReportsAsync(string status)
    {
        if (string.IsNullOrEmpty(status))
        {
            throw new ArgumentException("Status cannot be null or empty", nameof(status));
        }

        return await _reportContext.Reports
            .Where(r => r.Status.ToLower() == status.ToLower())
            .ToListAsync();
    }

    public async Task<Report> AddReportAsync(Report report)
    {
        _reportContext.Reports.Add(report);
        await _reportContext.SaveChangesAsync();
        return report;
    }
}