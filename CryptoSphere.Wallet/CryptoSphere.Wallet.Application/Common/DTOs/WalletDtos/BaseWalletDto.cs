using CryptoSphere.Wallet.Entities;
using CryptoSphere.Wallet.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSphere.Wallet.Application.Common.DTOs.WalletDtos
{
    public class BaseWalletDto
    {
        public decimal BalanceUSD { get; set; }
        public List<CryptoCoin> Cryptos { get; set; }
        public WalletStatus Status { get; set; }
    }
}
