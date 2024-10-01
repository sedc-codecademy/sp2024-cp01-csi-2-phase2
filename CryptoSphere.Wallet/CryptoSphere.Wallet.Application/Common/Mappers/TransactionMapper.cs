using CryptoSphere.Wallet.Application.Common.DTOs.TransactionDtos;
using CryptoSphere.Wallet.Entities;

namespace CryptoSphere.Wallet.Application.Common.Mappers
{
    public static class TransactionMapper
    {
        public static TransactionDto ToTransactionDto(this Transaction transaction) 
        {
            return new TransactionDto
            {
                CryptoCoinSymbol = transaction.CoinSymbol,
                Amount = transaction.Amount,
                TransactionType = transaction.TransactionType,
                TransactionDate = transaction.TransactionDate,
                Status = transaction.TransactionStatus,
                WalletId = transaction.WalletId
            };
        }
    }
}
