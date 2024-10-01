using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSphere.Wallet.Application.Common.DTOs.CryptoCoinDtos
{
    public class UpdateCryptoCoinDto
    { 
        public int CoinId { get; set; }
        public decimal Quantity { get; set; }
       
    }
}
