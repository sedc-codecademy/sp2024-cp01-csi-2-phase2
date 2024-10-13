
﻿using CryptoSphere.Wallet.Application.Common.DTOs.CryptoCoinDtos;
using CryptoSphere.Wallet.Application.Common.Helpers;
using CryptoSphere.Wallet.Application.Common.Interfaces;
using CryptoSphere.Wallet.Application.Common.Mappers;
using CryptoSphere.Wallet.Application.Repositories.CryptoCoinRepository.Interface;
using CryptoSphere.Wallet.Entities;
using Microsoft.EntityFrameworkCore;

namespace CryptoSphere.Wallet.Application.Repositories.CryptoCoinRepository.Service
{
    public class CryptoCoinRepository : ICryptoCoinRepository
    {
        private readonly IWalletDbContext _walletDb;

        public CryptoCoinRepository(IWalletDbContext walletDb)
        {
            _walletDb = walletDb;
        }

        public async Task<ResponseModel<CryptoCoinDto>> AddCryptoCoin(string userId, AddCryptoCoinDto addCryptoCoinDto)
        {
            try
            {

                var wallet = await _walletDb.Wallets.Include(c => c.Cryptos)
                    .FirstOrDefaultAsync(w => w.UserId == userId);

                if(wallet is null) { return new ResponseModel<CryptoCoinDto>("You need to create a wallet first!"); }
                if (wallet.Cryptos.Any(c => c.CoinSymbol == addCryptoCoinDto.CoinSymbol))
                { return new ResponseModel<CryptoCoinDto>("You already have this crypto currency"); }

                var coin = addCryptoCoinDto.ToAddCoinDto();
                coin.UserId = wallet.UserId;
                coin.WalletId = wallet.WalletId;

                await _walletDb.Cryptos.AddAsync(coin);
                await _walletDb.SaveChangesAsync();

                var response = coin.ToCryptoCoinDto();
                return new ResponseModel<CryptoCoinDto>(response);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResponseModel> DeleteCryptoCoin(string userId, int coinId)
        {
            try
            {
                var coin = await _walletDb.Cryptos
                      .Include(c => c.Wallet)
                      .FirstOrDefaultAsync(c => c.CoinId == coinId);

                if (coin is null) { return new ResponseModel<CryptoCoinDto>("Coin not found!"); }
                if (coin.Wallet.UserId != userId){ return new ResponseModel<CryptoCoinDto>("You can't delete this coin! It doesn't belong to your wallet."); }

                    _walletDb.Cryptos.Remove(coin);
                await _walletDb.SaveChangesAsync();
                return new ResponseModel { IsValid = true };

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResponseModel<List<CryptoCoinDto>>> GetAllCryptoCoins()
        {
            try
            {
                var coinFromDb = await _walletDb.Cryptos.Include(x => x.Wallet).ToListAsync();
                List<CryptoCoinDto> coins = new List<CryptoCoinDto>();
                foreach(CryptoCoin coin in coinFromDb) 
                {
                    coins.Add(coin.ToCryptoCoinDto());
                }
                return new ResponseModel<List<CryptoCoinDto>>(coins);    

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResponseModel<CryptoCoinDto>> GetCryptoCoinsById(int coinid)
        {
            try
            {
                var coin = await _walletDb.Cryptos
                    .Include(w => w.Wallet)
                    .FirstOrDefaultAsync(x=> x.CoinId == coinid);
                if(coin == null) { return new ResponseModel<CryptoCoinDto>("The coin can't be found!"); }

                var response = coin.ToCryptoCoinDto();
                return new ResponseModel<CryptoCoinDto>(response);
                
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResponseModel<CryptoCoinDto>> UpdateCryptoCoin(string userId, UpdateCryptoCoinDto updateCryptoCoinDto)
        {
            try
            {
                var coin = await _walletDb.Cryptos
                       .Include(c => c.Wallet)
                       .FirstOrDefaultAsync(c => c.CoinId == updateCryptoCoinDto.CoinId);

                if (coin is null){ return new ResponseModel<CryptoCoinDto>("Coin not found!"); }
                if (coin.Wallet.UserId != userId){ return new ResponseModel<CryptoCoinDto>("You can't change this coin! It doesn't belong to your wallet."); }

                coin.Quantity = updateCryptoCoinDto.Quantity;

                await _walletDb.SaveChangesAsync();

                var response = coin.ToCryptoCoinDto();
                return new ResponseModel<CryptoCoinDto>(response) { IsValid = true};

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}