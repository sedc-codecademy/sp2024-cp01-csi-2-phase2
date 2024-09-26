using CryptoSphere.Wallet.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSphere.Wallet.Entities
{
    public class CryptoCoin
    {
        public Guid CoinId { get; set; }
        public CryptoCoinSymbol CoinSymbol {  get; set; }
        public decimal Quantity {  get; set; }
        public decimal ValueInUSD {  get; set; }
        public Guid WalletId { get; set; }
        public Wallet Wallet { get; set; }

        public ICollection<Transaction>? Transactions { get; set; }
    }
}
