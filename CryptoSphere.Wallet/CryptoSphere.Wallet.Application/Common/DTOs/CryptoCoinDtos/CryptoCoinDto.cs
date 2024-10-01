using CryptoSphere.Wallet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSphere.Wallet.Application.Common.DTOs.CryptoCoinDtos
{
    public class CryptoCoinDto : CryptoCoinBaseDto
    {
       public int CoinId { get; set; }
        public int WalletId {  get; set; }

        public Wallet.Entities.Wallet Wallet {  get; set; }
        public Transaction Transaction { get; set; }
    }
}
