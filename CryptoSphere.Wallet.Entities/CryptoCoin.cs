using CryptoSphere.Wallet.Entities.Enums;

namespace CryptoSphere.Wallet.Entities
{
    public class CryptoCoin
    {
        public int CoinId { get; set; }
        public string UserId {  get; set; }
        public CryptoCoinSymbol CoinSymbol { get; set; }
        public decimal Quantity { get; set; }
        public decimal ValueInUSD { get; set; }
        public int WalletId { get; set; }

        public Wallet? Wallet { get; set; }
        public IEnumerable<Transaction>? Transactions { get; set; }
    }
}
