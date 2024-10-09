using CryptoSphere.Wallet.Application.Common.DTOs.WalletDtos;
using CryptoSphere.Wallet.Application.Repositories.WalletRepository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CryptoSphere.Wallet.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : BaseController
    {
        private readonly IWalletRepository _walletRepository;

        public WalletController(IWalletRepository repo)
        {
            _walletRepository = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _walletRepository.GetAllWallets();
                return Response(result);
            } catch (Exception ex)
            {
                return BadRequest($"Something went wrong! {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var response = await _walletRepository.GetWalletById(id);
                return Response(response);  

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddNewWallet([FromBody] BaseWalletDto walletDto)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null) return BadRequest("No user identified");
                var response = await _walletRepository.AddWallet(userId, walletDto);
                return Response(response);
            }catch(Exception ex)
            {
                return BadRequest($"Something went wrong while adding a new wallet!{ex.Message}");
            }
        }
    }
}
