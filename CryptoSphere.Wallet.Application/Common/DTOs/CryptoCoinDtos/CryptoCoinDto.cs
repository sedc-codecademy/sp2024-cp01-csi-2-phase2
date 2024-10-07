using CryptoSphere.Wallet.Entities;

namespace CryptoSphere.Wallet.Application.Common.DTOs.CryptoCoinDtos
{
    public class CryptoCoinDto : CryptoCoinBaseDto
    {
        public int CoinId { get; set; }
        public int WalletId { get; set; }

        public Entities.Wallet Wallet { get; set; }

    }
}
