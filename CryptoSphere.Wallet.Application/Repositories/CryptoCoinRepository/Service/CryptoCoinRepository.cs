
﻿using CryptoSphere.Wallet.Application.Common.DTOs.CryptoCoinDtos;
using CryptoSphere.Wallet.Application.Common.Helpers;
using CryptoSphere.Wallet.Application.Common.Interfaces;
using CryptoSphere.Wallet.Application.Repositories.CryptoCoinRepository.Interface;

namespace CryptoSphere.Wallet.Application.Repositories.CryptoCoinRepository.Service
{
    public class CryptoCoinRepository : ICryptoCoinRepository
    {
        private readonly IWalletDbContext _walletDb;

        public CryptoCoinRepository(IWalletDbContext walletDb)
        {
            _walletDb = walletDb;
        }

        public Task<ResponseModel<CryptoCoinDto>> AddCryptoCoin(string userId, AddCryptoCoinDto addCryptoCoinDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> DeleteCryptoCoin(string userId, int coinId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<CryptoCoinDto>>> GetAllCryptoCoins()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<CryptoCoinDto>> GetCryptoCoinsById(int coinid)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<CryptoCoinDto>> UpdateCryptoCoin(string userId, UpdateCryptoCoinDto updateCryptoCoinDto)
        {
            throw new NotImplementedException();
        }
    }
}