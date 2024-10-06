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
                Cryptos = wallet.Cryptos,
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
                Cryptos = wallet.Cryptos,
                
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
                Cryptos = wallet.Cryptos,
                WalletStatus = wallet.Status
            };
        }
    }
}