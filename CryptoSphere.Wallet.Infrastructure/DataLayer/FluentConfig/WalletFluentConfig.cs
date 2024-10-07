<<<<<<< HEAD:CryptoSphere.Wallet/CryptoSphere.Wallet.Infrastructure/DataLayer/FluentConfig/WalletFluentConfig.cs
﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CryptoSphere.Wallet.Infrastructure.DataLayer.FluentConfig
{
    public class WalletFluentConfig : IEntityTypeConfiguration<Wallet.Entities.Wallet>
    {
        public void Configure(EntityTypeBuilder<Entities.Wallet> builder)
        {
            builder.HasKey(x => x.WalletId);

            builder.HasOne(x => x.User)
                .WithOne(x => x.Wallet)
                .HasForeignKey<Entities.Wallet>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.BalanceUSD)
                        .HasPrecision(18, 2)
                            .HasDefaultValue(100000m);

            builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.UtcNow).IsRequired();

            builder.Property(x => x.WalletStatus).IsRequired();

        }
    }
}
=======
﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CryptoSphere.Wallet.Infrastructure.DataLayer.FluentConfig
{
    public class WalletFluentConfig : IEntityTypeConfiguration<Wallet.Entities.Wallet>
    {
        public void Configure(EntityTypeBuilder<Entities.Wallet> builder)
        {
            builder.HasKey(x => x.WalletId);

            builder.HasOne(x => x.User)
                .WithOne(x => x.Wallet)
                .HasForeignKey<Entities.Wallet>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(w => w.Transaction)
           .WithOne(t => t.Wallet)
           .HasForeignKey(t => t.WalletId)
           .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(w => w.Cryptos)
           .WithOne(c => c.Wallet)
           .HasForeignKey(c => c.WalletId)
           .OnDelete(DeleteBehavior.Cascade);


            builder.Property(x => x.BalanceUSD)
                        .HasPrecision(18, 2)
                            .HasDefaultValue(100000m);

            builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.UtcNow).IsRequired();

            builder.Property(x => x.WalletStatus).IsRequired();

        }
    }
}
>>>>>>> fad1f27aac4661842c1464cb3a0a50e8fca9a0c4:CryptoSphere.Wallet.Infrastructure/DataLayer/FluentConfig/WalletFluentConfig.cs
