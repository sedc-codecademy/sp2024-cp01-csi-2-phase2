using CryptoSphere.Wallet.Application.Common.DTOs.CryptoCoinDtos;
using CryptoSphere.Wallet.Application.Common.DTOs.WalletDtos;
using CryptoSphere.Wallet.Entities;
using CryptoSphere.Wallet.Entities.Enums;

namespace CryptoSphere.Wallet.Application.Common.Mappers
{
    public static class WalletMapper
    {
        public static WalletDto ToWalletDto(this Entities.Wallet wallet)
        {
            return new WalletDto
            {
                Cryptos = wallet.Cryptos != null
                ? wallet.Cryptos.Select(x => new DTOs.CryptoCoinDtos.CryptoCoinDto
                {
                    CoinSymbol = x.CoinSymbol,
                    Quantity = x.Quantity,
                    ValueInUSD = x.ValueInUSD,
                    CoinId = x.CoinId,
                    WalletId = x.WalletId,
                }).ToList()
                : new List<DTOs.CryptoCoinDtos.CryptoCoinDto>(),
                CreatedAt = wallet.CreatedAt,
                Status = wallet.WalletStatus,
                UpdatedAt = wallet.UpdatedAt,
                UserId = wallet.UserId,
                WalletAddress = wallet.WalletAddress,
                WalletId = wallet.WalletId,
                BalanceUSD = wallet.BalanceUSD
            };

        }
        public static Entities.Wallet ToAddWalletDto(this BaseWalletDto wallet)
        {
            return new Entities.Wallet
            {
                BalanceUSD = wallet.BalanceUSD,
                WalletStatus = wallet.Status,
                Cryptos =wallet.Cryptos.Select(x => new CryptoCoin
                {
                    CoinSymbol = x.CoinSymbol,
                    Quantity = x.Quantity,
                    ValueInUSD = x.ValueInUSD,
                } ).ToList()
                
            };
        }

        public static Entities.Wallet MapToWalletEntity (this UpdateWalletDto wallet)
        {
            return new Entities.Wallet
            {
                BalanceUSD = wallet.BalanceUSD,
            WalletStatus = wallet.Status
            };
        }
    }
}