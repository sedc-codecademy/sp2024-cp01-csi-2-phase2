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
                Cryptos = (List<DTOs.CryptoCoinDtos.CryptoCoinDto>)wallet.Cryptos.Select(x => new DTOs.CryptoCoinDtos.CryptoCoinDto
                {
                    CoinSymbol = x.CoinSymbol,
                    Quantity = x.Quantity,
                    ValueInUSD = x.ValueInUSD,
                    CoinId = x.CoinId,
                    WalletId = x.WalletId,
                }),
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
                    WalletId = (int)x.WalletId, 
                } ).ToList()
                
            };
        }

        public static Entities.Wallet MapToWalletEntity (this WalletDto wallet)
        {
            return new Entities.Wallet
            {
                WalletId = wallet.WalletId,
                UserId = wallet.UserId,
                WalletAddress = wallet.WalletAddress,
                BalanceUSD = wallet.BalanceUSD,
                CreatedAt = wallet.CreatedAt,
                UpdatedAt = wallet.UpdatedAt,
                Cryptos = wallet.Cryptos.Select(x => new Entities.CryptoCoin
                {
                    CoinSymbol = x.CoinSymbol,
                    Quantity = x.Quantity,
                    ValueInUSD = x.ValueInUSD,
                    WalletId = wallet.WalletId
                }).ToList(),
            WalletStatus = wallet.Status
            };
        }
    }
}