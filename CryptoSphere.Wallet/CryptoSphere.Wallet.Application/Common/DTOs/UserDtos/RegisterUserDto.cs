using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSphere.Wallet.Application.Common.DTOs.UserDtos
{
    public class RegisterUserDto
    {
        public string UserName {  get; set; }
        public string Password { get; set; }
        public string ConfirmPassword {  get; set; }
        public string Email { get; set; }
        public string Country {  get; set; }
        public string PhoneNumber { get; set; }

    }
}
