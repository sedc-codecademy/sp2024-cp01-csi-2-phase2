using CryptoSphere.Wallet.Application.Common.DTOs.CryptoCoinDtos;
using CryptoSphere.Wallet.Entities;
using System.Security.Cryptography.X509Certificates;

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
                CoinId = coin.CoinId,
                WalletId = coin.WalletId,
                Wallet = new Entities.Wallet()
                {
                    CreatedAt = coin.Wallet.CreatedAt,
                    UpdatedAt = coin.Wallet.UpdatedAt,
                    BalanceUSD = coin.Wallet.BalanceUSD,
                    WalletStatus = coin.Wallet.WalletStatus,
                    UserId = coin.Wallet.UserId,
                }
            };
        }
        public static CryptoCoin ToAddCoinDto(this AddCryptoCoinDto coin) 
        {
            return new CryptoCoin
            {
                CoinSymbol = coin.CoinSymbol,
                Quantity = coin.Quantity,
                ValueInUSD = coin.ValueInUSD
            };
        }
    }
}
