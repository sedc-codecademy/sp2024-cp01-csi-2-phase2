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
    public class ExchangeRateFluentConfig : IEntityTypeConfiguration<ExchangeRate>
    {
        public void Configure(EntityTypeBuilder<ExchangeRate> builder)
        {
            builder.HasKey(x => x.ExchangeRateId);

            builder.Property(x => x.RateToUSD)
                .HasPrecision(18, 4) 
                .IsRequired();

            builder.Property(x => x.LastUpdated)
                .IsRequired();

            builder.HasOne(er => er.Crypto) 
                .WithMany() 
                .HasForeignKey(er => er.CryptoId)
                .OnDelete(DeleteBehavior.Restrict);

            ExchangeRate exchange = new ExchangeRate()
            {
                ExchangeRateId = Guid.NewGuid(),
                CryptoId = Guid.Parse("AA81F025-F94E-4F15-B4B8-817338C86962"),
                RateToUSD = 11002.25m,
                LastUpdated = DateTime.UtcNow,

            };
            builder.HasData(exchange);
        }
    }
}
