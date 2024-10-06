using CryptoSphere.Wallet.Entities;
using CryptoSphere.Wallet.Entities.Enums;

namespace CryptoSphere.Wallet.Application.Common.DTOs.WalletDtos
{
    public class BaseWalletDto
    {
        public decimal BalanceUSD { get; set; }
        public List<CryptoCoin> Cryptos { get; set; }
        public WalletStatus Status { get; set; }
    }
}
