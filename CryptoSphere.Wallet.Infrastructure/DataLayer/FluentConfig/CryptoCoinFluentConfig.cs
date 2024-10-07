<<<<<<< HEAD:CryptoSphere.Wallet/CryptoSphere.Wallet.Infrastructure/DataLayer/FluentConfig/CryptoCoinFluentConfig.cs
﻿using CryptoSphere.Wallet.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CryptoSphere.Wallet.Infrastructure.DataLayer.FluentConfig
{
    public class CryptoCoinFluentConfig : IEntityTypeConfiguration<CryptoCoin>
    {
        public void Configure(EntityTypeBuilder<CryptoCoin> builder)
        {
            builder.HasKey(x => x.CoinId);

            builder.HasOne(x=> x.Wallet)
                .WithMany(x=>x.Cryptos)
                .HasForeignKey(x=>x.CoinId)
                .OnDelete(DeleteBehavior.Cascade);  
   
            builder.Property(x => x.CoinSymbol).IsRequired().HasConversion<int>();

            builder.Property(x => x.Quantity).IsRequired().HasPrecision(5, 2);

            builder.Property(x => x.ValueInUSD).IsRequired().HasPrecision(5, 2);

        }
    }
}
=======
﻿using CryptoSphere.Wallet.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CryptoSphere.Wallet.Infrastructure.DataLayer.FluentConfig
{
    public class CryptoCoinFluentConfig : IEntityTypeConfiguration<CryptoCoin>
    {
        public void Configure(EntityTypeBuilder<CryptoCoin> builder)
        {
            builder.HasKey(x => x.CoinId);
   
            builder.Property(x => x.CoinSymbol).IsRequired().HasConversion<int>();

            builder.Property(x => x.Quantity).IsRequired().HasPrecision(5, 2);

            builder.Property(x => x.ValueInUSD).IsRequired().HasPrecision(5, 2);

        }
    }
}
>>>>>>> fad1f27aac4661842c1464cb3a0a50e8fca9a0c4:CryptoSphere.Wallet.Infrastructure/DataLayer/FluentConfig/CryptoCoinFluentConfig.cs
