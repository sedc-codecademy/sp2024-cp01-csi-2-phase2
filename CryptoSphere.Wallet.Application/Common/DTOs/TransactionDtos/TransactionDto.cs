
﻿namespace CryptoSphere.Wallet.Application.Common.DTOs.TransactionDtos
{
    public class TransactionDto : BaseTransactionDto
    {
        public int WalletId { get; set; }
        public int CryptoCoinId { get; set; }

        public string? Description {  get; set; }
    }
}

