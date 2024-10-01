using CryptoSphere.Wallet.Application.Common.DTOs.WalletDtos;

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
    }
}
