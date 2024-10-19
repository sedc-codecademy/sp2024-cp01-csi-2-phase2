
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
                TransactionId = transaction.TransactionId,
                Amount = transaction.Amount,
                TransactionType = transaction.TransactionType,
                Status = transaction.TransactionStatus,
                WalletId = transaction.SenderWalletId,
                ReceiverWalletId = transaction.ReceiverWalletId,
                CoinSymbol = transaction.CoinSymbol,
                TransactionDate = transaction.TransactionDate,
            };
        }
    }
}
