using System;
using System.Collections.Generic;
using System.Text;
using KybernaFinance.Data.Migrations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KybernaFinance.Data
{
    public class ApplicationDbContext : IdentityDbContext<Student>
    {
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Prescription> Presciptions  { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}