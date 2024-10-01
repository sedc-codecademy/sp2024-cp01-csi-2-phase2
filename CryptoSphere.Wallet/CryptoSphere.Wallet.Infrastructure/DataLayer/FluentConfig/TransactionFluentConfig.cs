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

            builder.Property(x => x.CoinSymbol).IsRequired();

            builder.Property(x => x.TransactionStatus)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.TransactionDate).HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder.HasIndex(x => x.TransactionDate);

        }
    }
}

