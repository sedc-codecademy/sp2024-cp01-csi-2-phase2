using CryptoSphere.Wallet.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSphere.Wallet.Infrastructure.DataLayer.FluentConfig
{
    public class TransactionFluentConfig : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(x => x.TransactionId);

            builder.HasOne(w => w.Wallet)
                .WithMany(t => t.Transaction)
                .HasForeignKey(x => x.WalletId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Coin)
                .WithMany(t => t.Transactions)
                .HasForeignKey(x => x.CryptoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Amount)
                .HasPrecision(18, 4)
                .IsRequired();

            builder.Property(x => x.TransactionType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TransactionStatus)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.TransactionDate).HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder.HasIndex(x => x.TransactionDate);

            Transaction transaction = new Transaction()
            {
                TransactionId = Guid.Parse("8418EE6B-90A9-4B0D-9DA3-265DEA4C590E"),
                WalletId = Guid.Parse("0AF009C4-0577-4AA0-AAAA-CDC49D9B4A1C"),
                CryptoId = Guid.Parse("AA81F025-F94E-4F15-B4B8-817338C86962"),
                Amount = 23.50m,
                TransactionDate = DateTime.Now,
                TransactionType = Entities.Enums.TransactionType.Deposit,
                TransactionStatus = Entities.Enums.TransactionStatus.Completed,
            
            };

            builder.HasData(transaction);
        }
    }
}

