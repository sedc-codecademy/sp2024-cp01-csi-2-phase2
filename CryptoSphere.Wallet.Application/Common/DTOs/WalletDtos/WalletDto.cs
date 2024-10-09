using CryptoSphere.Wallet.Application.Common.DTOs.CryptoCoinDtos;
using CryptoSphere.Wallet.Entities.Enums;
using CryptoSphere.Wallet.Entities;

namespace CryptoSphere.Wallet.Application.Common.DTOs.WalletDtos
{
    public class WalletDto 
    {
        public int WalletId { get; set; }
        public string UserId { get; set; }
        public decimal BalanceUSD { get; set; }
        public List<CryptoCoinDto> Cryptos { get; set; }
        public WalletStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string WalletAddress { get; set; }
    }
}
