using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchedulePayments.Domain.Entities;

namespace SchedulePayments.Persistence.Configurations
{
    public class SchedulePaymentConfiguration : IEntityTypeConfiguration<SchedulePayment>
    {
        public void Configure(EntityTypeBuilder<SchedulePayment> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
            .HasMaxLength(20).ValueGeneratedOnAdd();
            entity.Property(e => e.Amount)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.BeneficiaryAccountNumber).IsRequired()
            .HasMaxLength(10);
            entity.Property(e => e.BeneficiaryName).IsRequired()
            .HasMaxLength(50);
            entity.Property(e => e.DateUpdated).IsRequired();
            entity.Property(e => e.EndDate).IsRequired();
            entity.Property(e => e.Narration).IsRequired();
            entity.Property(e => e.NoOfPayment).IsRequired();
            entity.Property(e => e.PaymentFrequency).IsRequired();
            entity.Property(e => e.SenderAccount).IsRequired().HasMaxLength(10);
            entity.Property(e => e.SenderName).IsRequired()
            .HasMaxLength(50);
            entity.Property(e => e.StartDate).IsRequired();
            entity.Property(e => e.DateCreated).IsRequired();
        }
    }
}