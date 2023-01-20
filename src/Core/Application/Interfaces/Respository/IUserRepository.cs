using Application.DTOs.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Respository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserInfoDTO>> GetUsers();
       
    }
}
