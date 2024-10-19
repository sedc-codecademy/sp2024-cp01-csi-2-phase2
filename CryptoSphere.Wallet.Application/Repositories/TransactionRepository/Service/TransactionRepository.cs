
using CryptoSphere.Wallet.Application.Common.DTOs.TransactionDtos;
using CryptoSphere.Wallet.Application.Common.Helpers;
using CryptoSphere.Wallet.Application.Common.Interfaces;
using CryptoSphere.Wallet.Application.Common.Mappers;
using CryptoSphere.Wallet.Application.Repositories.TransactionRepository.Interface;
using CryptoSphere.Wallet.Entities;
using CryptoSphere.Wallet.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace CryptoSphere.Wallet.Application.Repositories.TransactionRepository.Service
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IWalletDbContext _walletDb;

        public TransactionRepository(IWalletDbContext walletDb)
        {
            _walletDb = walletDb;
        }

        public async Task<ResponseModel<TransactionDto>> AddTransaction(string userId, AddTransactionDto addTransactionDto)
        {
            try
            {
                //Fetching and handling the wallet of the user creating the wallet
                var senderWallet = await _walletDb.Wallets.Include(x=> x.Cryptos)
                                            .FirstOrDefaultAsync(w => w.WalletId == addTransactionDto.SenderWalletId);
                if(senderWallet == null) { return new ResponseModel<TransactionDto>("No wallet found!"); }
                if (senderWallet.UserId != userId) { return new ResponseModel<TransactionDto>("You can't add transactions to this wallet"); }

                //Fetching and handling the reciever wallet if Transaction type is Transfer
                Entities.Wallet receiverWallet = null;
                if (addTransactionDto.TransactionType == Entities.Enums.TransactionType.Transfer)
                {
                    receiverWallet = await _walletDb.Wallets.Include(x=>x.Cryptos).FirstOrDefaultAsync(w => w.WalletId == addTransactionDto.RecieverWalletId);
                    if (receiverWallet == null)
                    {
                        return new ResponseModel<TransactionDto>("Receiver wallet does not exist.");
                    }
                }

                //switch statement for different types of transactions
                switch(addTransactionDto.TransactionType)
                {
                    case TransactionType.Buy:

                        if(senderWallet.BalanceUSD < addTransactionDto.Amount) { return new ResponseModel<TransactionDto>("Insufficient balance to buy this coin!"); }

                        senderWallet.BalanceUSD -= addTransactionDto.Amount;
                        
                        break;

                    case TransactionType.Sell:

                        var coin = senderWallet.Cryptos.FirstOrDefault(c => c.CoinSymbol == addTransactionDto.CoinSymbol);
                        if(coin is null) { return new ResponseModel<TransactionDto>("You don't have this coin in your wallet!"); }
                        if(coin.Quantity < addTransactionDto.Amount) { return new ResponseModel<TransactionDto>("Insufficient crypto currency to sell! "); }

                        coin.Quantity -= addTransactionDto.Amount;
                        senderWallet.BalanceUSD += (addTransactionDto.Amount * coin.ValueInUSD);
                        break;

                    case TransactionType.Transfer:

                        var senderCoin = senderWallet.Cryptos.FirstOrDefault(c => c.CoinSymbol == addTransactionDto.CoinSymbol);
                        if (senderCoin is null) { return new ResponseModel<TransactionDto>("You don't have this coin in your wallet!"); }
                        if (senderCoin.Quantity < addTransactionDto.Amount) { return new ResponseModel<TransactionDto>("Insufficient crypto currency to transfer! "); }
                        senderCoin.Quantity -= addTransactionDto.Amount;

                        var receiverCoin = receiverWallet.Cryptos.FirstOrDefault(c => c.CoinSymbol == addTransactionDto.CoinSymbol);

                        if (receiverCoin is null)
                        {
                            receiverWallet.Cryptos.Add(new Entities.CryptoCoin
                            {
                                UserId = receiverWallet.UserId,
                                CoinSymbol = addTransactionDto.CoinSymbol,
                                Quantity = addTransactionDto.Amount,
                            });
                        }
                        else
                        {
                            receiverCoin.Quantity += addTransactionDto.Amount;
                        }

                            break;
                    default:
                        return new ResponseModel<TransactionDto>("Invalid transaction type");

                }

                //Creating the transaction model
                var transaction = new Transaction
                {
                    Wallet = senderWallet,
                    SenderWalletId = senderWallet.WalletId,
                    ReceiverWalletId = addTransactionDto.TransactionType == TransactionType.Transfer
                              ? receiverWallet.WalletId : (int?)null,
                    CoinSymbol = addTransactionDto.CoinSymbol,
                    Amount = addTransactionDto.Amount,
                    TransactionDate = DateTime.UtcNow,
                    TransactionType = addTransactionDto.TransactionType

                };
                //Adding to te DB,Saving,mapping to TransactionDto and returning a validation message
                await _walletDb.Transactions.AddAsync(transaction);

                await _walletDb.SaveChangesAsync();

                var response = transaction.ToTransactionDto();
                return new ResponseModel<TransactionDto>(response) { IsValid = true };

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
                if(transaction == null) { return new ResponseModel<TransactionDto>("Transaction can't be found!"); }
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
