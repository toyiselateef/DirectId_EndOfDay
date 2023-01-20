using Application.Interfaces.Services; 
using Microsoft.AspNetCore.Mvc; 

namespace DirectId_EOD.Api.Controllers.v1
{
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IAccountService AccountService;
        public AccountController(IAccountService AccountService)
        {
            this.AccountService = AccountService;
        }

        [HttpGet("eod-balances/{accountNumber}")]
        public async Task<IActionResult> GetEODBalance( [FromRoute]string accountNumber)
        {

            var result = await AccountService.GetEODBalances(accountNumber);
            if (result == null) return NoContent();
            return Ok(result);
        }
        
        [HttpGet("get-account-numbers")]
        public async Task<IActionResult> GetAccountNumbers()
        {

            var result = await AccountService.GetAccountNumbers();
            if (result == null) return NoContent();
            return Ok(result);
        }

     
    }
}
