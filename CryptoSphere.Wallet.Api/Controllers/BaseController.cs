using CryptoSphere.Wallet.Application.Common.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoSphere.Wallet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult Response<TResult>(ResponseModel<TResult> response) where TResult : new()
        {
            if (!response.IsValid)
                return BadRequest(response);
            return Ok(response.Result);
        }

        protected IActionResult Response(ResponseModel response)
        {
            if (!response.IsValid)
                return BadRequest(response);
            return Ok();
        }
    }
}
