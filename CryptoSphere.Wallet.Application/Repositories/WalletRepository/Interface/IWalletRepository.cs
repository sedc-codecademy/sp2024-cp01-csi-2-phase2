using CryptoSphere.Wallet.Application.Common.DTOs.WalletDtos;
using CryptoSphere.Wallet.Application.Common.Helpers;

namespace CryptoSphere.Wallet.Application.Repositories.WalletRepository.Interface
{
    public interface IWalletRepository
    {
        Task<ResponseModel<List<WalletDto>>> GetAllWallets();
        Task<ResponseModel<WalletDto>> GetWalletById(int id);
        Task<ResponseModel<WalletDto>> AddWallet(string userId, BaseWalletDto addWalletDto);
        Task<ResponseModel<WalletDto>> UpdateWallet(string userId,int id, UpdateWalletDto updateWalletDto);
        Task<ResponseModel> DeleteWallet(string userId, int walletId);
    }
}
