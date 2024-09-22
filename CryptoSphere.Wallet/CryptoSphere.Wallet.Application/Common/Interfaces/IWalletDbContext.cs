using Microsoft.EntityFrameworkCore;
using CryptoSphere.Wallet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSphere.Wallet.Application.Common.Interfaces
{
    public interface IWalletDbContext
    {
        public DbSet<Wallet.Entities.Wallet> Wallets { get; }

        public DbSet<CryptoCoin> Cryptos { get; }

        public Task<int> SaveChangesAsync();
    }
}
