using CryptoSphere.Wallet.Application.Common.DTOs.CryptoCoinDtos;
using CryptoSphere.Wallet.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSphere.Wallet.Application.Repositories.CryptoCoinRepository.Interface
{
    public interface ICryptoCoinRepository : IGenericInterface<CryptoCoinDto>
    {
        Task Add(AddCryptoCoinDto addcryptoCoinDto);
        Task Update(UpdateCryptoCoinDto updatecryptoCoinDto);
    }
}
