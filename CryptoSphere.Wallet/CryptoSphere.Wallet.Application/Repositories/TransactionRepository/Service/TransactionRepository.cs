using CryptoSphere.Wallet.Application.Common.DTOs.TransactionDtos;
using CryptoSphere.Wallet.Application.Common.Interfaces;
using CryptoSphere.Wallet.Application.Repositories.TransactionRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSphere.Wallet.Application.Repositories.TransactionRepository.Service
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IWalletDbContext _walletDb;

        public TransactionRepository(IWalletDbContext walletDb)
        {
            _walletDb = walletDb;
        }
        public Task Add(TransactionDto transaction)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionDto> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TransactionDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(TransactionDto transaction)
        {
            throw new NotImplementedException();
        }
    }
}
