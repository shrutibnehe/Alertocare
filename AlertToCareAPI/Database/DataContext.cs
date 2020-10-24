using AlertToCareAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace AlertToCareAPI.Database
{
    [ExcludeFromCodeCoverage]
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Bed> BedsInfo { get; set; }
        public DbSet<Icu> IcusInfo { get; set; }
        public DbSet<Patient> PatientsInfo { get; set; }
        public DbSet<Vital> VitalsInfo { get; set; }
        public DbSet<Layout> LayoutInfo { get; set; }
    }
}
