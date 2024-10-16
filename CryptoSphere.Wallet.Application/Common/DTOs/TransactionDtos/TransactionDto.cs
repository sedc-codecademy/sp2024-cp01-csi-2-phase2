
﻿namespace CryptoSphere.Wallet.Application.Common.DTOs.TransactionDtos
{
    public class TransactionDto : BaseTransactionDto
    {
        public int WalletId { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}

