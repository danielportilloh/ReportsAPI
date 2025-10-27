using Reports.Models;
using Reports.Data.Repositories;
using AutoMapper;

namespace Reports.Services;

public class ReportService : IReportService
{
    private readonly ReportRepository _reportRepository;
    private readonly IMapper _mapper;

    public ReportService(ReportRepository reportRepository,
        IMapper mapper)
    {
        _reportRepository = reportRepository;
        _mapper = mapper;
    }
    public async Task<Report> CreateAsync(Report report)
    {
        var reportEntity = _mapper.Map<Data.Models.Report>(report);

        reportEntity = await _reportRepository.AddReportAsync(reportEntity);

        return _mapper.Map<Report>(reportEntity);
    }

    public async Task<IEnumerable<Report>> GetReportByStatusAsync(string status)
    {
        var reports = await _reportRepository.GetReportsAsync(status);
        return _mapper.Map<IEnumerable<Report>>(reports);
    }
}

