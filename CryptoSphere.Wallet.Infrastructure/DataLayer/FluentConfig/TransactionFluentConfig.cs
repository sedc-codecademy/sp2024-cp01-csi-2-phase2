
﻿using CryptoSphere.Wallet.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CryptoSphere.Wallet.Infrastructure.DataLayer.FluentConfig
{
    public class TransactionFluentConfig : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(x => x.TransactionId);

            builder.HasOne(w=>w.Wallet)
                .WithMany(t=>t.Transactions)
               .HasForeignKey(t=>t.ReceiverWalletId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.CryptoCoin)
                .WithMany(t => t.Transactions)
                .HasForeignKey(x => x.CryptoCoinId)
           .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Amount)
                .HasPrecision(18, 4)
                .IsRequired();

            builder.Property(x => x.TransactionType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.CryptoCoinId).IsRequired();

            builder.Property(x => x.TransactionStatus)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.TransactionDate)
                .IsRequired();

            builder.HasIndex(x => x.TransactionDate);

        }
    }
}
