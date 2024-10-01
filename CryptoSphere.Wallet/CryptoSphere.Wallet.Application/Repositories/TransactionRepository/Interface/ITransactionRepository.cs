using CryptoSphere.Wallet.Application.Common.DTOs.TransactionDtos;
using CryptoSphere.Wallet.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSphere.Wallet.Application.Repositories.TransactionRepository.Interface
{
    public interface ITransactionRepository : IGenericInterface<BaseTransactionDto>
    {
        Task Add(BaseTransactionDto transaction);
        Task Update (BaseTransactionDto transaction);
    }
}
