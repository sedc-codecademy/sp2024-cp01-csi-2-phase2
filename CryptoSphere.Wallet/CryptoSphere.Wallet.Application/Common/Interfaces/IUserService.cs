using CryptoSphere.Wallet.Application.Common.DTOs.UserDtos;
using CryptoSphere.Wallet.Application.Common.Helpers;
using CryptoSphere.Wallet.Entities;

namespace CryptoSphere.Wallet.Application.Common.Interfaces
{
    public interface IUserService
    {
        Task<ResponseModel> Register(RegisterUserDto registerUser);

        Task<string> Login(LogInUserDto loginUser);

        Task<ApplicationUser> GetUserByUserName(string userName);
    }
}
