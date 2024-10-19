
﻿namespace CryptoSphere.Wallet.Application.Common.DTOs.TransactionDtos
{
    public class TransactionDto : BaseTransactionDto
    {
        public int TransactionId {  get; set; }
        public int WalletId { get; set; }
        public int? ReceiverWalletId {  get; set; }
        public DateTime TransactionDate { get; set; }
    }
}

