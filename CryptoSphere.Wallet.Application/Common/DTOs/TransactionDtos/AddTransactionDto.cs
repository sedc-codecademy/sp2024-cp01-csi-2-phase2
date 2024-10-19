using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSphere.Wallet.Application.Common.DTOs.TransactionDtos
{
    public class AddTransactionDto : BaseTransactionDto
    {
        public int SenderWalletId { get; set; }
        public int? RecieverWalletId {  get; set; }
    }
}
