﻿using HackYeah.DAL.Models;
using HackYeah.Infrastructure.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HackYeah.DAL
{
    public class HackYeahDbContext : IdentityDbContext<User>
    {
        private readonly string _connectionString;

        public HackYeahDbContext(IOptions<ConnectionStringsSection> connectionStringsOptions)
        {
            _connectionString = connectionStringsOptions.Value.HackYeah;
        }

        public DbSet<Demo> Demos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }
    }
}
