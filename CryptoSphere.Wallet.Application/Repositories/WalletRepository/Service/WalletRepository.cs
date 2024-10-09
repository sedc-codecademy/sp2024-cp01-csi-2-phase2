using CryptoSphere.Wallet.Application.Common.DTOs.WalletDtos;
using CryptoSphere.Wallet.Application.Common.Helpers;
using CryptoSphere.Wallet.Application.Common.Interfaces;
using CryptoSphere.Wallet.Application.Repositories.WalletRepository.Interface;
using CryptoSphere.Wallet.Application.Common.Mappers;
using Microsoft.EntityFrameworkCore;
using CryptoSphere.Wallet.Entities;
using CryptoSphere.Wallet.Application.Common.DTOs.CryptoCoinDtos;

namespace CryptoSphere.Wallet.Application.Repositories.WalletRepository.Service
{
    public class WalletRepository : IWalletRepository
    {

        private readonly IWalletDbContext _walletDb;

        public WalletRepository(IWalletDbContext walletDb)
        {
            _walletDb = walletDb;
        }

        public async Task<ResponseModel<WalletDto>> AddWallet(string userId, BaseWalletDto addWalletDto)
        {
            try
            {
                var userCheck = await _walletDb.Wallets.FirstOrDefaultAsync(w => w.UserId == userId);
                if (userCheck != null)
                {
                    return new ResponseModel<WalletDto>() { IsValid = false,ValidationMessage= "You have already created a wallet!" };
                }

                    var wallet = addWalletDto.ToAddWalletDto();
                    wallet.UserId = userId;
                if (wallet.Cryptos != null)
                {
                    foreach (var item in wallet.Cryptos)
                    {
                        item.UserId = userId;
                        item.WalletId = wallet.WalletId; 
                    }
                }
                else
                {
                    wallet.Cryptos = new List<CryptoCoin>();
                }
                wallet.CreatedAt = DateTime.UtcNow;
                    wallet.WalletAddress = Guid.NewGuid().ToString();
                    await _walletDb.Wallets.AddAsync(wallet);
                    await _walletDb.SaveChangesAsync();
                    var walletDto = wallet.ToWalletDto();
                    return new ResponseModel<WalletDto>(walletDto);

            }catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<ResponseModel> DeleteWallet(string userId, int walletId)
        {
            try
            {
                var wallet = await _walletDb.Wallets.FindAsync(walletId);
                if (wallet is null) return new ResponseModel<WalletDto>("Wallet not found!");
                if (wallet.UserId != userId) return new ResponseModel("You can't delete this wallet!");
                _walletDb.Wallets.Remove(wallet);
                await _walletDb.SaveChangesAsync();
                return new ResponseModel() { IsValid = true };
            }catch(Exception ex)
            {
                throw new Exception($"Something went wrong while deleting! {ex.Message}"); 
            };
        }

        public async Task<ResponseModel<List<WalletDto>>> GetAllWallets()
        {
            try
            {
                var walletsFromDb = await _walletDb.Wallets.Include(x => x.Cryptos).ToListAsync();
                List<WalletDto> wallets = new List<WalletDto>();
                foreach (var wallet in walletsFromDb)
                {
                    wallets.Add(wallet.ToWalletDto());
                }
                return new ResponseModel<List<WalletDto>>(wallets);
            }catch(Exception ex)
            {
                throw new Exception($"Something went wrong! {ex.Message}");
            }
        }

        public async Task<ResponseModel<WalletDto>> GetWalletById(int id)
        {
            try
            {
                var wallet = await _walletDb.Wallets.FindAsync(id);
                if (wallet is null) return new ResponseModel<WalletDto>("Wallet not found!");
                var walletDto = wallet.ToWalletDto();
                return new ResponseModel<WalletDto>(walletDto);
            }catch(Exception ex)
            {
                throw new Exception($"Something went wrong! {ex.Message}");
            }
        }

        public async Task<ResponseModel<WalletDto>> UpdateWallet(string userId, int id, UpdateWalletDto updateWalletDto)
        {
            try
            {
                var wallet = await _walletDb.Wallets.Include(w => w.Cryptos).FirstOrDefaultAsync(w => w.WalletId == id);

                if (wallet == null)
                    return new ResponseModel<WalletDto>("Wallet not found");

                if (wallet.UserId != userId)
                    return new ResponseModel<WalletDto>("You can't update this wallet!");

                wallet.BalanceUSD = updateWalletDto.BalanceUSD;
                wallet.WalletId = wallet.WalletId;
                wallet.WalletStatus = updateWalletDto.Status;
                wallet.UpdatedAt = DateTime.UtcNow;

                foreach (var cryptoDto in updateWalletDto.Cryptos)
                {
                    var existingCrypto = wallet.Cryptos.FirstOrDefault(c => c.CoinId == cryptoDto.CoinId);
                    if (existingCrypto != null)
                    { 
                        existingCrypto.Quantity = cryptoDto.Quantity;
                        
                    }
                    else
                    {
                        var newCrypto = new CryptoCoin
                        {
                            Quantity = cryptoDto.Quantity,
                            WalletId = wallet.WalletId
                        };
                        wallet.Cryptos.Add(newCrypto);
                    }
                }

                await _walletDb.SaveChangesAsync();

                var walletDto = wallet.ToWalletDto();
                return new ResponseModel<WalletDto> { IsValid = true, Result = walletDto };
            }
            catch (Exception ex)
            {
                throw new Exception($"Something went wrong while updating! {ex.Message}");
            }
        }


    }
}
