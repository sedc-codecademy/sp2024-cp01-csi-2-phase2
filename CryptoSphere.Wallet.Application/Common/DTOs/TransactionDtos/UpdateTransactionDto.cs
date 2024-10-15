using CryptoSphere.Wallet.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSphere.Wallet.Application.Common.DTOs.TransactionDtos
{
    public class UpdateTransactionDto
    {
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}
