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
    public class WalletFluentConfig : IEntityTypeConfiguration<Wallet.Entities.Wallet>
    {
        public void Configure(EntityTypeBuilder<Entities.Wallet> builder)
        {
            builder.HasKey(x => x.WalletId);

            builder.Property(x => x.BalanceUSD)
                        .HasPrecision(18, 2)
                            .HasDefaultValue(100000m); 

            builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.UtcNow).IsRequired();

            builder.Property(x => x.WalletStatus).IsRequired();

            Wallet.Entities.Wallet wallet = new Entities.Wallet()
            {
                WalletId = Guid.Parse("0af009c4-0577-4aa0-aaaa-cdc49d9b4a1c"),
                BalanceUSD = 100000m,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow.AddHours(2),
                WalletStatus = Entities.Enums.WalletStatus.Active,
                UserId = Guid.NewGuid(),
                WalletAddress = "---TestAddress---"

            };
            builder.HasData(wallet);

        }
    }
}
