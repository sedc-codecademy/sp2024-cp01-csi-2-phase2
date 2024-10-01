using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSphere.Wallet.Application.Common.DTOs.CryptoCoinDtos
{
    public class AddCryptoCoinDto : CryptoCoinBaseDto
    {
        public int WalletId { get; set; }
    }
}
