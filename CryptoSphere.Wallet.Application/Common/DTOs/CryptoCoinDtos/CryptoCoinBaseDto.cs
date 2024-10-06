using CryptoSphere.Wallet.Entities.Enums;

namespace CryptoSphere.Wallet.Application.Common.DTOs.CryptoCoinDtos
{
    public class CryptoCoinBaseDto
    {
        public CryptoCoinSymbol CoinSymbol { get; set; }
        public decimal Quantity { get; set; }
        public decimal ValueInUSD { get; set; }
    }
}
