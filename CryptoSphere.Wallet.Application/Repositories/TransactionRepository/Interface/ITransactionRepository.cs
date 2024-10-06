using CryptoSphere.Wallet.Application.Common.DTOs.TransactionDtos;
using CryptoSphere.Wallet.Application.Common.Helpers;

namespace CryptoSphere.Wallet.Application.Repositories.TransactionRepository.Interface
{
    public interface ITransactionRepository
    {
        Task<ResponseModel<List<TransactionDto>>> GetAllTransactions();
        Task<ResponseModel<TransactionDto>> GetTransactionById(int id);
        Task<ResponseModel<TransactionDto>> AddTransaction(string userId, BaseTransactionDto addTransactionDto);
        Task<ResponseModel<TransactionDto>> UpdateTransaction(string userId, TransactionDto updateTransactionDto);
        Task<ResponseModel> DeleteTransaction(string userId, int id);
    }
}
