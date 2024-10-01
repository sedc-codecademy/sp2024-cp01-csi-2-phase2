using CryptoSphere.Wallet.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSphere.Wallet.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int WalletId { get; set; }
        public int CryptoId { get; set; }
        public CryptoCoinSymbol CoinSymbol { get; set; }  
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime TransactionDate {  get; set; }
        public TransactionStatus TransactionStatus { get; set; }

        public Wallet? Wallet { get; set; }
        public CryptoCoin? Coin { get; set; }

    }
}
