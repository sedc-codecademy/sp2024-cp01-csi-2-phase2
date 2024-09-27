using CryptoSphere.Wallet.Application.Common.DTOs.ExchangeRateDtos;
using CryptoSphere.Wallet.Entities;

namespace CryptoSphere.Wallet.Application.Common.Mappers
{
    public static class ExchangeRateMapper
    {
        public static ExchangeRateDto ToExchangeRateDto(this ExchangeRate exchange)
        {
            return new ExchangeRateDto
            {
                RateToUSD = exchange.RateToUSD,
                LastUpdatedAt = exchange.LastUpdated,
            };
        }
    }
}
