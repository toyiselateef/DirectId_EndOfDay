using Application.DTOs.User;
using Application.Interfaces.Respository;
using Application.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Implementation.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository UserRepository;

        public UserService(IUserRepository UserRepository)
        {
            this.UserRepository = UserRepository;
        }

     
        public async Task<UserInfoDTO> GetUser( )
        {
            IEnumerable<UserInfoDTO> userInfo = await UserRepository.GetUsers();
            return userInfo.FirstOrDefault();
        }

    }
    }