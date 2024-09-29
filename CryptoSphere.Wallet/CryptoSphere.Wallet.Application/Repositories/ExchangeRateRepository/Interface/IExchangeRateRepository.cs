using CryptoSphere.Wallet.Application.Common.DTOs.ExchangeRateDtos;
using CryptoSphere.Wallet.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSphere.Wallet.Application.Repositories.ExchangeRateRepository.Interface
{
    public interface IExchangeRateRepository : IGenericInterface<ExchangeRateDto>
    {
        Task Add(ExchangeRateDto exchange);

        Task Update(ExchangeRateDto exchange);
    }
}
