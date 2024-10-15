

using CryptoSphere.Wallet.Entities.Enums;
using System.Text.Json.Serialization;

namespace CryptoSphere.Wallet.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int WalletId { get; set; }

        public int CryptoCoinId {  get; set; }
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionStatus TransactionStatus { get; set; }

        [JsonIgnore]
        public CryptoCoin? CryptoCoin { get; set; }
        [JsonIgnore]
        public Wallet? Wallet { get; set; }

    }
}