using CryptoSphere.Wallet.Entities.Enums;
using CryptoSphere.Wallet.Entities;
using CryptoSphere.Wallet.Application.Common.DTOs.CryptoCoinDtos;

namespace CryptoSphere.Wallet.Application.Common.DTOs.WalletDtos
{
    public class UpdateWalletDto
    {
        public decimal BalanceUSD { get; set; }
        public List<UpdateCryptoCoinDto>? Cryptos { get; set; }
        public WalletStatus Status { get; set; }
        public int WalletId { get; set; }
    }
}
