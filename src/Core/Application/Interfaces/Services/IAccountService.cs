using Domain.Entities.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IAccountService
    {
        
        Task<IEnumerable<string>> GetAccountNumbers();
         Task<EODData> GetEODBalances(string accountNumber);
       
    }
}

