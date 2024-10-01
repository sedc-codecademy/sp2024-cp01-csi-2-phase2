using CryptoSphere.Wallet.Entities.Enums;

namespace CryptoSphere.Wallet.Application.Common.DTOs.TransactionDtos
{
    public class BaseTransactionDto
    {
        public CryptoCoinSymbol CryptoCoinSymbol { get; set; }
        public decimal Amount {  get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionStatus Status { get; set; }
    }
}
