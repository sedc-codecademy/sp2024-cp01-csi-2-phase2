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

            Transaction transaction = new Transaction()
            {
                TransactionId = Guid.Parse("8418EE6B-90A9-4B0D-9DA3-265DEA4C590E"),
                WalletId = Guid.Parse("0AF009C4-0577-4AA0-AAAA-CDC49D9B4A1C"),
                CryptoId = Guid.Parse("AA81F025-F94E-4F15-B4B8-817338C86962"),
                Amount = 23.50m,
                TransactionDate = DateTime.Now,
                TransactionType = Entities.Enums.TransactionType.Deposit,
                TransactionStatus = Entities.Enums.TransactionStatus.Completed,
                CoinSymbol = Entities.Enums.CryptoCoinSymbol.BTC,
            
            };

            builder.HasData(transaction);

            Transaction transaction1 = new Transaction()
            {
                TransactionId = Guid.Parse("621cfe6b-522b-4c4e-8a70-3b4862397fad"),
                WalletId = Guid.Parse("0AF009C4-0577-4AA0-AAAA-CDC49D9B4A1C"),
                CryptoId = Guid.Parse("630EE9D4-3EE7-4E55-A3F4-54F64BEF6ED3"),
                Amount = 60.50m,
                TransactionDate = DateTime.Now,
                TransactionType = Entities.Enums.TransactionType.Withdraw,
                TransactionStatus = Entities.Enums.TransactionStatus.Pending, 
                CoinSymbol = Entities.Enums.CryptoCoinSymbol.XRP,

            };
            builder.HasData(transaction1);
        }
    }
}

