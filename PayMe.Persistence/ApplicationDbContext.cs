using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PayMe.Entity;

namespace PayMe.Persistence
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {}

        public DbSet<Employee> Employees { get; set; }
        public DbSet<PaymentRecord> PaymentRecords { get; set; }
        public DbSet<TaxYear> TaxYears { get; set; }
        public DbSet<PersonalInfoEmployee> PersonalInfoEmployees { get; set; }
        public DbSet<PayInfoEmployee> PayInfoEmployees { get; set; }

    }
}
