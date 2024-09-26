using CryptoSphere.Wallet.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSphere.Wallet.Application.Common.DTOs.CryptoCoinDtos
{
    public class CryptoCoinBaseDto
    {
        public CryptoCoinSymbol CoinSymbol { get; set; }
        public decimal Quantity {  get; set; }
        public decimal ValueInUSD {  get; set; }
    }
}
