using CryptoSphere.Wallet.Application.Common.DTOs.TransactionDtos;
using CryptoSphere.Wallet.Application.Common.Helpers;
using CryptoSphere.Wallet.Application.Common.Interfaces;
using CryptoSphere.Wallet.Application.Repositories.TransactionRepository.Interface;

namespace CryptoSphere.Wallet.Application.Repositories.TransactionRepository.Service
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IWalletDbContext _walletDb;

        public TransactionRepository(IWalletDbContext walletDb)
        {
            _walletDb = walletDb;
        }

        public Task<ResponseModel<TransactionDto>> AddTransaction(string userId, BaseTransactionDto addTransactionDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> DeleteTransaction(string userId, int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<TransactionDto>>> GetAllTransactions()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<TransactionDto>> GetTransactionById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<TransactionDto>> UpdateTransaction(string userId, TransactionDto updateTransactionDto)
        {
            throw new NotImplementedException();
        }
    }
}
