using CryptoSphere.Wallet.Entities.Enums;
using System.Text.Json.Serialization;

namespace CryptoSphere.Wallet.Entities
{
    public class CryptoCoin
    {
        public int CoinId { get; set; }
        [JsonIgnore]
        public string UserId {  get; set; }
        public CryptoCoinSymbol CoinSymbol { get; set; }
        public decimal Quantity { get; set; }
        public decimal ValueInUSD { get; set; }
        public int WalletId { get; set; }

        [JsonIgnore]
        public Wallet? Wallet { get; set; }
        [JsonIgnore]
        public IEnumerable<Transaction>? Transactions { get; set; }
    }
}
