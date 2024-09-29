using CryptoSphere.Wallet.Application.Common.DTOs.ExchangeRateDtos;
using CryptoSphere.Wallet.Application.Common.Interfaces;
using CryptoSphere.Wallet.Application.Repositories.ExchangeRateRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSphere.Wallet.Application.Repositories.ExchangeRateRepository.Service
{
    public class ExchangeRateRepository : IExchangeRateRepository
    {
        private readonly IWalletDbContext _walletDb;

        public ExchangeRateRepository(IWalletDbContext walletDb)
        {
            _walletDb = walletDb;
        }
        public Task Add(ExchangeRateDto exchange)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ExchangeRateDto> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ExchangeRateDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(ExchangeRateDto exchange)
        {
            throw new NotImplementedException();
        }
    }
}
