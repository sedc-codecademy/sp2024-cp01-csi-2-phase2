
﻿using CryptoSphere.Wallet.Application.Common.DTOs.TransactionDtos;
using CryptoSphere.Wallet.Application.Common.Helpers;
using CryptoSphere.Wallet.Application.Common.Interfaces;
using CryptoSphere.Wallet.Application.Common.Mappers;
using CryptoSphere.Wallet.Application.Repositories.TransactionRepository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Runtime.CompilerServices;

namespace CryptoSphere.Wallet.Application.Repositories.TransactionRepository.Service
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IWalletDbContext _walletDb;

        public TransactionRepository(IWalletDbContext walletDb)
        {
            _walletDb = walletDb;
        }

        public Task<ResponseModel<TransactionDto>> AddTransaction(string userId, BaseTransactionDto addTransactionDto)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> DeleteTransaction(string userId, int id)
        {
            try
            {
                var transaction = await _walletDb.Transactions
                                            .Include(x => x.Wallet)
                                            .FirstOrDefaultAsync(x => x.TransactionId == id);

                if (transaction == null) { return new ResponseModel<TransactionDto>("Transaction cannot be found!"); }
                if(transaction.Wallet.UserId != userId) { return new ResponseModel<TransactionDto>("You can't delete this transaction!"); }
                if (transaction.TransactionStatus == Entities.Enums.TransactionStatus.Completed)
                { return new ResponseModel<TransactionDto>("You can't delete a completed transaction"); }

                 _walletDb.Transactions.Remove(transaction);
                await _walletDb.SaveChangesAsync();
                return new ResponseModel { IsValid = true };
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResponseModel<List<TransactionDto>>> GetAllTransactions()
        {
            try
            {
                var transactionsFromDb = await _walletDb.Transactions.Include(x => x.Wallet).ToListAsync();
                List<TransactionDto> transactions = new List<TransactionDto>();
                foreach(var item in transactionsFromDb) 
                {
                    transactions.Add(item.ToTransactionDto());
                }
                return new ResponseModel<List<TransactionDto>>(transactions);   

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResponseModel<TransactionDto>> GetTransactionById(int id)
        {
            try
            {
                var transaction = await _walletDb.Transactions.Include(x=>x.Wallet).FirstOrDefaultAsync(x=> x.TransactionId == id);
                if(transaction == null) { return new ResponseModel<TransactionDto>("Wallet can't be found!"); }
               var response = transaction.ToTransactionDto();
                return new ResponseModel<TransactionDto>(response);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ResponseModel<TransactionDto>> UpdateTransaction(string userId,int id, UpdateTransactionDto updateTransactionDto)
        {

            try
            {
                var transaction = await _walletDb.Transactions
                                            .Include(x => x.Wallet)
                                            .FirstOrDefaultAsync(x => x.TransactionId == id);

                if (transaction == null) { return new ResponseModel<TransactionDto>("Transaction cannot be found!"); }
                if (transaction.Wallet.UserId != userId) { return new ResponseModel<TransactionDto>("You can't update this transaction!"); }
                if (transaction.TransactionStatus == Entities.Enums.TransactionStatus.Completed)
                { return new ResponseModel<TransactionDto>("You can't update a completed transaction"); }

                transaction.TransactionDate = DateTime.Now;
                transaction.Amount = updateTransactionDto.Amount;
                transaction.TransactionType = updateTransactionDto.TransactionType;

                var response = transaction.ToTransactionDto();
                return new ResponseModel<TransactionDto>(response) { IsValid = true };

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
