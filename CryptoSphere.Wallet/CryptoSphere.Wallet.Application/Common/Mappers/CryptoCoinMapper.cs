using CryptoSphere.Wallet.Application.Common.DTOs.CryptoCoinDtos;
using CryptoSphere.Wallet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSphere.Wallet.Application.Common.Mappers
{
    public static class CryptoCoinMapper
    {
        public static CryptoCoinDto ToCryptoCoinDto(this CryptoCoin coin)
        {
            return new CryptoCoinDto
            {
                CoinSymbol = coin.CoinSymbol,
                Quantity = coin.Quantity,
                ValueInUSD = coin.ValueInUSD,
                WalletId = coin.WalletId,
                CoinId = coin.CoinId,
                Wallet = new Entities.Wallet()
                {
                    WalletId = coin.WalletId,
                    Cryptos = coin.Wallet.Cryptos,
                    CreatedAt = coin.Wallet.CreatedAt,
                    UpdatedAt = coin.Wallet.UpdatedAt,
                    BalanceUSD = coin.Wallet.BalanceUSD,
                    WalletAddress = coin.Wallet.WalletAddress,
                    WalletStatus = coin.Wallet.WalletStatus,
                    UserId = coin.Wallet.UserId,
                }
            };
        }
    }
}
