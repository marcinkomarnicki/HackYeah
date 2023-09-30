using HackYeah.DAL.Models;
using HackYeah.Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HackYeah.DAL
{
    public class HackYeahDbContext : IdentityDbContext<User>
    {
        private readonly string _connectionString;

        public HackYeahDbContext(DbContextOptions<HackYeahDbContext> options,
            IOptions<ConnectionStringsSection> connectionStringsOptions)
            : base(options)
        {
            _connectionString = connectionStringsOptions.Value.HackYeah;
        }

        public DbSet<Demo> Demos { get; set; }

        public DbSet<Encounter> Encounters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString)
                .UseSnakeCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Encounter>()
                .HasOne(x => x.EncounterType)
                .WithMany().HasForeignKey(x => x.EncounterTypeId);

            //SEED
            modelBuilder.Entity<EncounterType>().HasData(
                new EncounterType
                {
                    Id = new Guid("D7E923A8-6781-41B0-9929-005D8B0F01D5"),
                    Code = "Kot"
                },
                new EncounterType
                {
                    Id = new Guid("13C2CA92-6A13-482A-8E0E-62BD6682127B"),
                    Code = "Pies"
                });
        }
    }
}