using Microsoft.AspNetCore.Mvc;
using Reports.Services;

namespace Reports.API.Controllers;

[ApiController]
[Route("api/reports")]
public class ReportsController : ControllerBase
{
    private readonly IReportService _reportService;

    public ReportsController(IReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpGet]
    public async Task<IActionResult> GetReportByStatus([FromQuery]string status)
    {
        var reports = await _reportService.GetReportByStatusAsync(status);

        if (!reports.Any())
        {
            return NotFound($"No reports found for status {status}.");
        }

        return Ok(reports.ToList());
    }

    [HttpPost]
    public async Task<IActionResult> Create(Models.Report report)
    {
        await _reportService.CreateAsync(report);

        return CreatedAtAction(nameof(GetReportByStatus), new { status = report.Status }, report);
    }
}