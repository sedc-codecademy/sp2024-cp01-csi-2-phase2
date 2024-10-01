using CryptoSphere.Wallet.Application.Common.DTOs.WalletDtos;
using CryptoSphere.Wallet.Application.Common.Helpers;
using CryptoSphere.Wallet.Application.Common.Interfaces;
using CryptoSphere.Wallet.Application.Repositories.WalletRepository.Interface;

namespace CryptoSphere.Wallet.Application.Repositories.WalletRepository.Service
{
    public class WalletRepository : IWalletRepository
    {

        private readonly IWalletDbContext _walletDb;

        public WalletRepository(IWalletDbContext walletDb)
        {
            _walletDb = walletDb;
        }

        public Task<ResponseModel<WalletDto>> AddWallet(string userId, BaseWalletDto addWalletDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> DeleteWallet(string userId, int walletId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<WalletDto>>> GetAllWallets()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<WalletDto>> GetWalletById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<WalletDto>> UpdateWallet(string userId, UpdateWalletDto updateWalletDto)
        {
            throw new NotImplementedException();
        }
    }
}
