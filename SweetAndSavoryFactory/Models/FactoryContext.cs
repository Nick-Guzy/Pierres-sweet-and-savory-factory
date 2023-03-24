using Microsoft.EntityFrameworkCore;

namespace SweetAndSavoryFactory.Models
{
  public class SweetAndSavoryFactoryContext : DbContext
  {
    public DbSet<Engineer> Engineers { get; set; }
    public DbSet<Machine> Machines { get; set; }
    public DbSet<MachineEngineer> MachineEngineer { get; set; }

    public SweetAndSavoryFactoryContext(DbContextOptions options) : base(options) { }
  }
}