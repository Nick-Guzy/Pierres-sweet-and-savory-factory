using Microsoft.EntityFrameworkCore;

namespace SweetAndSavoryFactory.Models
{
  public class SweetAndSavoryFactoryContext : DbContext
  {
    public DbSet<Treat> Treats { get; set; }
    public DbSet<Flavor> Flavors { get; set; }
    public DbSet<FlavorTreat> FlavorTreat { get; set; }

    public SweetAndSavoryFactoryContext(DbContextOptions options) : base(options) { }
  }
}