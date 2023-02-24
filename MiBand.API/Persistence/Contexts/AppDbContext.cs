using MiBand.API.Domain.Models;
using MiBand.API.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MiBand.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sesions { get; set; }
        public DbSet<Box> Boxes { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Spec> Specs { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var configuration = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json")
        //        .Build();

        //    var connectionString = configuration.GetConnectionString("AppDb");
        //    optionsBuilder.UseSqlServer(connectionString);
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //*******************************************//
            /*Employees*/
            //*******************************************//
            builder.Entity<Employee>().ToTable("employees");
            builder.Entity<Employee>().HasKey(p => p.EmployeeId);
            builder.Entity<Employee>().Property(p => p.EmployeeId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Employee>().Property(p => p.Name).IsRequired().HasMaxLength(40);
            builder.Entity<Employee>().Property(p => p.Citizenship).IsRequired().HasMaxLength(40);

            // Apply Naming Convention
            builder.ApplySnakeCaseNamingConvention();
        }
    }
}
