using Microsoft.EntityFrameworkCore;
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
