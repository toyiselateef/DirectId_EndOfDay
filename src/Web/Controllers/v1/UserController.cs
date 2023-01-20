using Application.DTOs.User;
using Application.Interfaces.Services; 
using Microsoft.AspNetCore.Mvc; 

namespace DirectId_EOD.Api.Controllers.v1
{
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService UserService;
        public UserController(IUserService UserService)
        {
            this.UserService = UserService;
        }

       
        
        
        [HttpGet("get-user")]
        public async Task<IActionResult> GetUsers()
        {

            UserInfoDTO result = await UserService.GetUser();
            if (result == null) return NoContent();
            return Ok(result);
        }
    }
}
