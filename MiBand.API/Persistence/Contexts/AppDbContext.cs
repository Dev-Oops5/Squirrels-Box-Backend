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
        public DbSet<Shared> Shareds { get; set; }
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

            //*******************************************//
            /*Session*/
            //*******************************************//
            builder.Entity<Session>().ToTable("sessions");
            builder.Entity<Session>().HasKey(p => p.Id);
            builder.Entity<Session>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Session>().Property(p => p.Username).IsRequired();
            builder.Entity<Session>().Property(p => p.Email).IsRequired();
            builder.Entity<Session>().Property(p => p.Password).IsRequired();
            builder.Entity<Session>().Property(p => p.Active).IsRequired();

            //*******************************************//
            /*User*/
            //*******************************************//
            builder.Entity<User>().ToTable("users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Birthday).IsRequired();
            builder.Entity<User>().Property(p => p.BoxCounter).IsRequired();
            builder.Entity<User>().Property(p => p.SessionId).IsRequired();
            builder.Entity<User>().Property(p => p.Active).IsRequired();

            builder.Entity<User>()
                .HasOne(s => s.Session)
                .WithOne(u => u.User)
                .HasForeignKey<User>(s => s.SessionId);

            //*******************************************//
            /*Box*/
            //*******************************************//
            builder.Entity<Box>().ToTable("boxes");
            builder.Entity<Box>().HasKey(p => p.Id);
            builder.Entity<Box>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Box>().Property(p => p.Name).IsRequired();
            builder.Entity<Box>().Property(p => p.Favourite).IsRequired();
            builder.Entity<Box>().Property(p => p.Color).IsRequired();
            builder.Entity<Box>().Property(p => p.PrivateLink).IsRequired();
            builder.Entity<Box>().Property(p => p.Download).IsRequired();
            builder.Entity<Box>().Property(p => p.Active).IsRequired();

            builder.Entity<Box>()
                .HasOne(b => b.User)
                .WithMany(u => u.Boxes)
                .HasForeignKey(b => b.UserId);

            //*******************************************//
            /*Section*/
            //*******************************************//
            builder.Entity<Section>().ToTable("sections");
            builder.Entity<Section>().HasKey(p => p.Id);
            builder.Entity<Section>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Section>().Property(p => p.Name).IsRequired();
            builder.Entity<Section>().Property(p => p.Favourite).IsRequired();
            builder.Entity<Section>().Property(p => p.Color).IsRequired();
            builder.Entity<Section>().Property(p => p.Active).IsRequired();

            builder.Entity<Section>()
                .HasOne(b => b.Box)
                .WithMany(u => u.Sections)
                .HasForeignKey(b => b.BoxId);

            //*******************************************//
            /*Items*/
            //*******************************************//
            builder.Entity<Item>().ToTable("items");
            builder.Entity<Item>().HasKey(p => p.Id);
            builder.Entity<Item>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Item>().Property(p => p.Name).IsRequired();
            builder.Entity<Item>().Property(p => p.Favourite).IsRequired();
            builder.Entity<Item>().Property(p => p.Color).IsRequired();
            builder.Entity<Item>().Property(p => p.Description).IsRequired();
            builder.Entity<Item>().Property(p => p.Amount).IsRequired();
            builder.Entity<Item>().Property(p => p.ItemPhoto).IsRequired();
            builder.Entity<Item>().Property(p => p.Active).IsRequired();

            builder.Entity<Item>()
                .HasOne(b => b.Section)
                .WithMany(u => u.Items)
                .HasForeignKey(b => b.SectionId);

            //*******************************************//
            /*Spec*/
            //*******************************************//
            builder.Entity<Spec>().ToTable("specs");
            builder.Entity<Spec>().HasKey(p => p.Id);
            builder.Entity<Spec>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Spec>().Property(p => p.Name).IsRequired();
            builder.Entity<Spec>().Property(p => p.Favourite).IsRequired();
            builder.Entity<Spec>().Property(p => p.Color).IsRequired();
            builder.Entity<Spec>().Property(p => p.VariableType).IsRequired();
            builder.Entity<Spec>().Property(p => p.Content).IsRequired();
            builder.Entity<Spec>().Property(p => p.Currency).IsRequired();
            builder.Entity<Spec>().Property(p => p.Active).IsRequired();

            builder.Entity<Spec>()
                .HasOne(b => b.Item)
                .WithMany(u => u.Specs)
                .HasForeignKey(b => b.ItemId);

            //*******************************************//
            /*Spec*/
            //*******************************************//
            builder.Entity<Shared>().ToTable("shareds");
            builder.Entity<Shared>().HasKey(p => p.Id);
            builder.Entity<Shared>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Shared>().Property(p => p.OwnerId).IsRequired();
            builder.Entity<Shared>().Property(p => p.ReceiverId).IsRequired();
            builder.Entity<Shared>().Property(p => p.BoxId).IsRequired();
            builder.Entity<Shared>().Property(p => p.Active).IsRequired();

            builder.Entity<Shared>()
                .HasOne(b => b.Owner)
                .WithMany()
                .HasForeignKey(b => b.OwnerId);

            builder.Entity<Shared>()
                .HasOne(b => b.Receiver)
                .WithMany(u => u.Shareds)
                .HasForeignKey(b => b.ReceiverId);

            builder.Entity<Shared>()
                .HasOne(b => b.Box)
                .WithMany(u => u.Shareds)
                .HasForeignKey(b => b.BoxId);

            // Apply Naming Convention
            builder.ApplySnakeCaseNamingConvention();
        }
    }
}
