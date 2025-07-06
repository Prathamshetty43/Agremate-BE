using Agremate.Domain.Samples;
using Microsoft.EntityFrameworkCore;

namespace Agremate.EntityFramework;

public class AgremateDbContext : DbContext
{
    public AgremateDbContext(DbContextOptions<AgremateDbContext> options) : base(options) { }
    public DbSet<Sample> Samples { get; set; }
}
