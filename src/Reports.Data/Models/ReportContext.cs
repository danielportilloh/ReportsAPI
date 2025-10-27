using Microsoft.EntityFrameworkCore;

namespace Reports.Data.Models;

public class ReportContext : DbContext
{
    public DbSet<Report> Reports { get; set; } = null!;

    public ReportContext(DbContextOptions<ReportContext> options)
        : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}