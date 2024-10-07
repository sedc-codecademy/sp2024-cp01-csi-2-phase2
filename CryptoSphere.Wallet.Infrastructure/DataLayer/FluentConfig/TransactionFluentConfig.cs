<<<<<<< HEAD:CryptoSphere.Wallet/CryptoSphere.Wallet.Infrastructure/DataLayer/FluentConfig/TransactionFluentConfig.cs
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
                .WithMany(t=>t.Transaction)
                .HasForeignKey(t=>t.WalletId)
                .OnDelete(DeleteBehavior.Cascade);  

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

=======
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

>>>>>>> fad1f27aac4661842c1464cb3a0a50e8fca9a0c4:CryptoSphere.Wallet.Infrastructure/DataLayer/FluentConfig/TransactionFluentConfig.cs
