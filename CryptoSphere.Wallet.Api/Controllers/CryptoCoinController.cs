using CryptoSphere.Wallet.Application.Common.DTOs.CryptoCoinDtos;
using CryptoSphere.Wallet.Application.Common.Helpers;
using CryptoSphere.Wallet.Application.Repositories.CryptoCoinRepository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System.Security.Claims;

namespace CryptoSphere.Wallet.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CryptoCoinController : BaseController
    {
        private readonly ICryptoCoinRepository _cryptoCoinRepository;

        public CryptoCoinController(ICryptoCoinRepository repo)
        {
            _cryptoCoinRepository = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _cryptoCoinRepository.GetAllCryptoCoins();
                return Response(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var response = await _cryptoCoinRepository.GetCryptoCoinsById(id);
                return Response(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddCryptoCoin([FromBody] AddCryptoCoinDto coinDto)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null) return BadRequest("No user found!");
                var response = await _cryptoCoinRepository.AddCryptoCoin(userId, coinDto);
                return Response(response);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCoin([FromBody] UpdateCryptoCoinDto coinDto)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null) return BadRequest("No user found!");
                var response = await _cryptoCoinRepository.UpdateCryptoCoin(userId, coinDto);
                return Response(response);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{coinId}")]
        public async Task<IActionResult> DeleteCoin(int coinId)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null) return BadRequest("No user found!");
                var response = await _cryptoCoinRepository.DeleteCryptoCoin(userId, coinId);
                return Response(response);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

