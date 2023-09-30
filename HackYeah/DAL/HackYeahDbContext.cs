﻿using HackYeah.DAL.Models;
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
        }
    }
}