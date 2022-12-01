using API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Profilling> Profillings { get; set; }
        public DbSet<University> Universities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>()
                .HasOne(e => e.Account)
                .WithOne(a => a.Employee)
                .HasForeignKey<Account>(a => a.NIK);

            builder.Entity<Account>()
                .HasOne(a => a.Profilling)
                .WithOne(p => p.Account)
                .HasForeignKey<Profilling>(a => a.NIK);

            builder.Entity<Education>()
                .HasOne(u => u.University)
                .WithMany(e => e.Educations);

            builder.Entity<Profilling>()
                .HasOne(p => p.Education)
                .WithOne(e => e.Profilling)
                .HasForeignKey<Profilling>(p => p.Education_Id);

        }
    }
}
