using CryptoSphere.Wallet.Application.Common.DTOs.WalletDtos;
using CryptoSphere.Wallet.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSphere.Wallet.Application.Repositories.WalletRepository.Interface
{
    public interface IWalletRepository : IGenericInterface<WalletDto>
    {
        Task Add(BaseWalletDto entity);
        Task Update(UpdateWalletDto entity);
    }
}
