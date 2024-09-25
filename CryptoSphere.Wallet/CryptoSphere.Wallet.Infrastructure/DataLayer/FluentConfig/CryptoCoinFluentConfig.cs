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
    public class CryptoCoinFluentConfig : IEntityTypeConfiguration<CryptoCoin>
    {
        public void Configure(EntityTypeBuilder<CryptoCoin> builder)
        {
            builder.HasKey( x => x.CoinId);

            builder.HasOne(x => x.Wallet)
                .WithMany(x => x.CryptoCoins)
                .HasForeignKey(x => x.WalletId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x=> x.CoinSymbol).IsRequired().HasMaxLength(5);

            builder.Property(x => x.Quantity).IsRequired().HasPrecision(5, 2);

            builder.Property(x => x.ValueInUSD).IsRequired().HasPrecision(5, 2);


            CryptoCoin coin = new CryptoCoin()
            {
                CoinId = Guid.Parse("AA81F025-F94E-4F15-B4B8-817338C86962"),
                CoinSymbol = "TST",
                Quantity = 1,
                ValueInUSD = 20.05m,
                WalletId = Guid.Parse("0af009c4-0577-4aa0-aaaa-cdc49d9b4a1c")
            };

            builder.HasData(coin);
        }
    }
}
