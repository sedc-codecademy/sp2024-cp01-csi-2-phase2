using CryptoSphere.Wallet.Entities;
using Microsoft.EntityFrameworkCore;

namespace CryptoSphere.Wallet.Application.Common.Interfaces
{
    public interface IWalletDbContext
    {
        public DbSet<Wallet.Entities.Wallet> Wallets { get; }
        public DbSet<CryptoCoin> Cryptos { get; }
        public DbSet<Transaction> Transactions { get; }

        public Task<int> SaveChangesAsync();
    }
}
