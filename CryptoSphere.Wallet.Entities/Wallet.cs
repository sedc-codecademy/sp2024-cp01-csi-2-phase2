using CryptoSphere.Wallet.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CryptoSphere.Wallet.Entities
{
    public class Wallet
    {
        public int WalletId { get; set; }
        public string? UserId { get; set; }
        public decimal BalanceUSD { get; set; }
        [JsonIgnore]
        public List<CryptoCoin>? Cryptos { get; set; }
        [JsonIgnore]
        public string? WalletAddress { get; set; }
        public WalletStatus WalletStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        
        public ICollection<Transaction> Transactions { get; set; }
        [Required]
        [JsonIgnore]
        public ApplicationUser User { get; set; }

    }
}
