<<<<<<< HEAD:CryptoSphere.Wallet/CryptoSphere.Wallet.Infrastructure/UserService/UserService.cs
﻿using CryptoSphere.Wallet.Application.Common.DTOs.UserDtos;
using CryptoSphere.Wallet.Application.Common.Helpers;
using CryptoSphere.Wallet.Application.Common.Interfaces;
using CryptoSphere.Wallet.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CryptoSphere.Wallet.Infrastructure.UserService
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserService(IConfiguration configuration, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<ApplicationUser> GetUserByUserName(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<string> Login(LogInUserDto loginUser)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(loginUser.UserName, loginUser.Password, false, false);

            if (signInResult.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(loginUser.UserName);

                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, loginUser.UserName),
                    new Claim(ClaimTypes.Country , user.Country),
                    new Claim(ClaimTypes.NameIdentifier , user.Id)
                };

                var signInKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretKey")));

                var signInCredentials = new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                    (
                         signingCredentials: signInCredentials,
                         expires: DateTime.Now.AddMinutes(20),
                         claims: claims
                    );
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            else
            {
                return String.Empty;
            }
        }

        public async Task<ResponseModel> Register(RegisterUserDto registerUser)
        {
            ApplicationUser user = new();
            user.Email = registerUser.Email;
            user.PhoneNumber = registerUser.PhoneNumber;
            user.UserName = registerUser.UserName;
            user.Country = registerUser.Country;

            var validationModel = await Validate(registerUser, user);

            if (validationModel.IsValid)
            {
                IdentityResult identityResult = await _userManager.CreateAsync(user, registerUser.Password);

                if (identityResult.Errors.Any())
                {
                    var errors = string.Empty;

                    foreach (var error in identityResult.Errors)
                    {
                        errors += error.Description = ";";
                    }

                    return new ResponseModel()
                    {
                        IsValid = false
                    };
                }

                return new ResponseModel()
                {
                    IsValid = true,
                    ValidationMessage = "Registered Succesfully!"
                };
            }
            else
            {
                return new ResponseModel()
                {
                    IsValid = false,
                    ValidationMessage = validationModel.ValidationMessage
                };
            }
        }

        private async Task<ResponseModel> Validate(RegisterUserDto model, ApplicationUser user)
        {
            if (string.IsNullOrEmpty(model.Email) ||
            string.IsNullOrEmpty(model.Password) ||
            string.IsNullOrEmpty(model.Country) ||
             string.IsNullOrEmpty(model.UserName))
            {
                return new ResponseModel()
                {
                    IsValid = false,
                    ValidationMessage = "Some of the fields are empty.Registration failed!"
                };
            }

            var email = await _userManager.FindByEmailAsync(model.Email);

            if (email is not null)
            {
                return new ResponseModel()
                {
                    IsValid = false,
                    ValidationMessage = "Email already exists!"
                };
            }

            var existingUser = await _userManager.FindByNameAsync(model.UserName);
            if (existingUser is not null)
            {
                return new ResponseModel()
                {
                    IsValid = false,
                    ValidationMessage = "Username already exists!"
                };
            }

            if (model.Password != model.ConfirmPassword)
            {
                return new ResponseModel()
                {
                    IsValid = false,
                    ValidationMessage = "Passwords do not match!"
                };
            }

            return new ResponseModel()
            {
                IsValid = true
            };
        }
    }
}
=======
﻿using CryptoSphere.Wallet.Application.Common.DTOs.UserDtos;
using CryptoSphere.Wallet.Application.Common.Helpers;
using CryptoSphere.Wallet.Application.Common.Interfaces;
using CryptoSphere.Wallet.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CryptoSphere.Wallet.Infrastructure.UserService
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserService(IConfiguration configuration, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<ApplicationUser> GetUserByUserName(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<string> Login(LogInUserDto loginUser)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(loginUser.UserName, loginUser.Password, false, false);

            if (signInResult.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(loginUser.UserName);

                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, loginUser.UserName),
                    new Claim(ClaimTypes.Country , user.Country),
                    new Claim(ClaimTypes.NameIdentifier , user.Id)
                };

                var signInKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretKey")));

                var signInCredentials = new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                    (
                         signingCredentials: signInCredentials,
                         expires: DateTime.Now.AddMinutes(20),
                         claims: claims
                    );
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            else
            {
                return String.Empty;
            }
        }

        public async Task<ResponseModel> Register(RegisterUserDto registerUser)
        {
            ApplicationUser user = new();
            user.Email = registerUser.Email;
            user.PhoneNumber = registerUser.PhoneNumber;
            user.UserName = registerUser.UserName;
            user.Country = registerUser.Country;

            var validationModel = await Validate(registerUser, user);

            if (validationModel.IsValid)
            {
                IdentityResult identityResult = await _userManager.CreateAsync(user, registerUser.Password);

                if (identityResult.Errors.Any())
                {
                    var errors = string.Empty;

                    foreach (var error in identityResult.Errors)
                    {
                        errors += error.Description = ";";
                    }

                    return new ResponseModel()
                    {
                        IsValid = false
                    };
                }

                return new ResponseModel()
                {
                    IsValid = true,
                    ValidationMessage = "Registered Succesfully!"
                };
            }
            else
            {
                return new ResponseModel()
                {
                    IsValid = false,
                    ValidationMessage = validationModel.ValidationMessage
                };
            }
        }

        private async Task<ResponseModel> Validate(RegisterUserDto model, ApplicationUser user)
        {
            if (string.IsNullOrEmpty(model.Email) ||
            string.IsNullOrEmpty(model.Password) ||
            string.IsNullOrEmpty(model.Country) ||
             string.IsNullOrEmpty(model.UserName))
            {
                return new ResponseModel()
                {
                    IsValid = false,
                    ValidationMessage = "Some of the fields are empty.Registration failed!"
                };
            }

            var email = await _userManager.FindByEmailAsync(model.Email);

            if (email is not null)
            {
                return new ResponseModel()
                {
                    IsValid = false,
                    ValidationMessage = "Email already exists!"
                };
            }

            var existingUser = await _userManager.FindByNameAsync(model.UserName);
            if (existingUser is not null)
            {
                return new ResponseModel()
                {
                    IsValid = false,
                    ValidationMessage = "Username already exists!"
                };
            }

            if (model.Password != model.ConfirmPassword)
            {
                return new ResponseModel()
                {
                    IsValid = false,
                    ValidationMessage = "Passwords do not match!"
                };
            }

            return new ResponseModel()
            {
                IsValid = true
            };
        }
    }
}
>>>>>>> fad1f27aac4661842c1464cb3a0a50e8fca9a0c4:CryptoSphere.Wallet.Infrastructure/UserService/UserService.cs
