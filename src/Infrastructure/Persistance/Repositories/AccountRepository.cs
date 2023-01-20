using Application.Interfaces.Respository;
using Domain.Entities.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public Task<Account> GetAccountByAccountNumber(string accountNumber)
        {
            Account account_Info = CustomerData.Accounts.FirstOrDefault(x => x.Identifiers.AccountNumber == accountNumber);
            return Task.FromResult(account_Info);
        }

        public Task<IEnumerable<string>> GetAccountNumbers()
        {
            IEnumerable<string> account_Numbers = CustomerData.Accounts.Select(x => x.Identifiers.AccountNumber);
            return Task.FromResult(account_Numbers);
        }
    }
}
