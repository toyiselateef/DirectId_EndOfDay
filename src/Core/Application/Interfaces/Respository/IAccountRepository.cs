using Domain.Entities.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Respository
{
    public interface IAccountRepository
    {
        Task<Account> GetAccountByAccountNumber(string accountNumber);
        Task<IEnumerable<string>> GetAccountNumbers();
    }
}
