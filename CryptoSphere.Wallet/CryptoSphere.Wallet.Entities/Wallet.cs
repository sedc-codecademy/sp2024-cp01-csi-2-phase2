using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSphere.Wallet.Entities
{
    public class Wallet
    {
        public Guid WalletId { get; set; }
        public Guid UserId { get; set; }
        public decimal BalanceUSD { get; set; }
        public List<CryptoCoin>? Cryptos {  get; set; }
        public string? WalletAddress {  get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt {  get; set; }
    }
}
