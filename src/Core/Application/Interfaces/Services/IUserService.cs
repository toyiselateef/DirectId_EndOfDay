using Application.DTOs.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IUserService
    {

        Task<UserInfoDTO> GetUser();
        
    }
}

