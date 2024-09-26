using CryptoSphere.Wallet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Transaction = CryptoSphere.Wallet.Entities.Transaction;

namespace CryptoSphere.Wallet.Application.Common.DTOs.WalletDtos
{
    public class WalletDto : BaseWalletDto
    {
        public Guid WalletId { get; set; }
        public Guid UserId {  get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set;}

        public string WalletAddress {  get; set; }

        public Transaction Transaction { get; set; }

        public CryptoCoin CryptoCoin { get; set; }
    }
}
