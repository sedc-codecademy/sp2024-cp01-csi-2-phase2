using CryptoSphere.Wallet.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSphere.Wallet.Application.Common.DTOs.TransactionDtos
{
    public class TransactionDto
    {
        public CryptoCoinSymbol CryptoCoinSymbol { get; set; }
        public decimal Amount {  get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionStatus Status { get; set; }
    }
}
