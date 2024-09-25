using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSphere.Wallet.Entities
{
    public class ExchangeRate
    {
        public Guid ExchangeRateId { get; set; }
        public Guid CryptoId {  get; set; }
        public decimal RateToUSD {  get; set; }
        public DateTime LastUpdated { get; set; }

        public virtual CryptoCoin Crypto {  get; set; }
    }
}
