using CryptoSphere.Wallet.Entities;
using System.Text.Json.Serialization;

namespace CryptoSphere.Wallet.Application.Common.DTOs.CryptoCoinDtos
{
    public class CryptoCoinDto : CryptoCoinBaseDto
    {
        public int CoinId { get; set; }
        public int WalletId { get; set; }

        [JsonIgnore]
        public Entities.Wallet Wallet { get; set; }

    }
}
