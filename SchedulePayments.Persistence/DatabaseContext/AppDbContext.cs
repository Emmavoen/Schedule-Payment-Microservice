using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchedulePayments.Domain.Entities;
using SchedulePayments.Persistence.Configurations;

namespace SchedulePayments.Persistence.DatabaseContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) 
        {

        }


        public DbSet<SchedulePayment> SchedulePayments {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SchedulePaymentConfiguration());
        }
    }

}