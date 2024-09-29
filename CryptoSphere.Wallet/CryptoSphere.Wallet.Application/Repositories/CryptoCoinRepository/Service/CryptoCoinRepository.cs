using CryptoSphere.Wallet.Application.Common.DTOs.CryptoCoinDtos;
using CryptoSphere.Wallet.Application.Common.Interfaces;
using CryptoSphere.Wallet.Application.Repositories.CryptoCoinRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSphere.Wallet.Application.Repositories.CryptoCoinRepository.Service
{
    public class CryptoCoinRepository : ICryptoCoinRepository
    {
        private readonly IWalletDbContext _walletDb;

        public CryptoCoinRepository(IWalletDbContext walletDb)
        { 
            _walletDb = walletDb;
        }
        public Task Add(AddCryptoCoinDto addcryptoCoinDto)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CryptoCoinDto> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CryptoCoinDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(UpdateCryptoCoinDto updatecryptoCoinDto)
        {
            throw new NotImplementedException();
        }
    }
}
