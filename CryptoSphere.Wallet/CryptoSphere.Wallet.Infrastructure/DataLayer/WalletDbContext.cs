using CryptoSphere.Wallet.Application.Common.Interfaces;
using CryptoSphere.Wallet.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSphere.Wallet.Infrastructure.DataLayer
{
    public class WalletDbContext : IdentityDbContext<ApplicationUser>, IWalletDbContext
    {
        public DbSet<Entities.Wallet> Wallets => Set<Wallet.Entities.Wallet>();
        public DbSet<CryptoCoin> Cryptos => Set<CryptoCoin>();

        public DbSet<Transaction> Transactions => Set<Transaction>();

        public WalletDbContext(DbContextOptions optionsBuilder) : base(optionsBuilder)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-52E2U68\\SQLEXPRESS;Database=CryptoSphereWallet;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(WalletDbContext).Assembly);
            base.OnModelCreating(builder);
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
