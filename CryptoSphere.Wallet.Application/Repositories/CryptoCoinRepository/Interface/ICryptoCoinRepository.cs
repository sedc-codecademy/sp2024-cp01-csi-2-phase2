using CryptoSphere.Wallet.Application.Common.DTOs.CryptoCoinDtos;
using CryptoSphere.Wallet.Application.Common.Helpers;

namespace CryptoSphere.Wallet.Application.Repositories.CryptoCoinRepository.Interface
{
    public interface ICryptoCoinRepository
    {
        Task<ResponseModel<List<CryptoCoinDto>>> GetAllCryptoCoins();
        Task<ResponseModel<CryptoCoinDto>> GetCryptoCoinsById(int coinid);
        Task<ResponseModel<CryptoCoinDto>> AddCryptoCoin(string userId, AddCryptoCoinDto addCryptoCoinDto);
        Task<ResponseModel<CryptoCoinDto>> UpdateCryptoCoin(string userId, UpdateCryptoCoinDto updateCryptoCoinDto);

        Task<ResponseModel> DeleteCryptoCoin(string userId, int coinId);

    }
}
