using CryptoSphere.Wallet.Application.Common.DTOs.WalletDtos;
using CryptoSphere.Wallet.Application.Common.Interfaces;
using CryptoSphere.Wallet.Application.Repositories.WalletRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSphere.Wallet.Application.Repositories.WalletRepository.Service
{
    public class WalletRepository : IWalletRepository
    {

        private readonly IWalletDbContext _walletDb;

        public WalletRepository(IWalletDbContext walletDb)
        {
            _walletDb = walletDb;
        }
        public Task Add(BaseWalletDto entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<WalletDto> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<WalletDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(UpdateWalletDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
