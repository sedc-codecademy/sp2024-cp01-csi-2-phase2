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


            builder.Property(x => x.CoinSymbol).IsRequired().HasConversion<int>();

            builder.Property(x => x.Quantity).IsRequired().HasPrecision(5, 2);

            builder.Property(x => x.ValueInUSD).IsRequired().HasPrecision(5, 2);

        }
    }
}
