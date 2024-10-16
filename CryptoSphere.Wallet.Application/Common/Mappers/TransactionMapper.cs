
﻿using CryptoSphere.Wallet.Application.Common.DTOs.TransactionDtos;
using CryptoSphere.Wallet.Entities;

namespace CryptoSphere.Wallet.Application.Common.Mappers
{
    public static class TransactionMapper
    {
        public static TransactionDto ToTransactionDto(this Transaction transaction)
        {
            return new TransactionDto
            {  
                Amount = transaction.Amount,
                TransactionType = transaction.TransactionType,
                Status = transaction.TransactionStatus,
                WalletId = transaction.SenderWalletId,
                CoinSymbol = transaction.CoinSymbol,
                TransactionDate = transaction.TransactionDate,
            };
        }
    }
}
