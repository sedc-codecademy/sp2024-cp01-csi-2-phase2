using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSphere.Wallet.Application.Common.DTOs.ExchangeRateDtos
{
    public class ExchangeRateDto
    {
        public decimal RateToUSD {  get; set; }

        public DateTime LastUpdatedAt {  get; set; }
    }
}
