using Application.DTOs.User;
using Application;
using Application.Interfaces.Respository;
using Domain.Entities.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {

        public Task<IEnumerable<UserInfoDTO>> GetUsers()
        {
            IEnumerable<Account> account_Detail = CustomerData.Accounts;
           
            var accountsInfo = account_Detail.Select(x => new UserInfo()
            {
                AccountHolderName = x.AccountHolderNames,
                DisplayName = x.DisplayName,
                Addresses = string.Join(",", x.Parties.Select(x => string.Join(",", x.Addresses))),
                Telephones = string.Join(",", x.Parties.Select(x => string.Join(",", x.PhoneNumbers))),
                Emails = string.Join(",", x.Parties.Select(x => x.EmailAddress)),
                Accounts = new Application.DTOs.User.Accounts()
                {
                    AccountHolderName = x.AccountHolderNames,
                    AccountNumber = x.Identifiers.AccountNumber,
                    AccountSubType = x.AccountSubType,
                    AccountType = x.AccountType,
                    CurrentBalance = (decimal)x.Balances.Current.Amount,
                    CurrentBalanceIndicator = x.Balances.Current.CreditDebitIndicator,

                }
            });
            var user_Detail = accountsInfo.GroupBy(x => x.AccountHolderName).ToList();

          
            var finals = user_Detail.Select(x=> new UserInfoDTO()
            {
                AccountHolderName = x.FirstOrDefault().AccountHolderName,
                DisplayName = x.FirstOrDefault().DisplayName,
                Addresses = x.FirstOrDefault().Addresses,
                Telephones = x.FirstOrDefault().Telephones,
                Emails = x.FirstOrDefault().Emails,
                Accounts = x.Select(x=>x.Accounts).ToList()
            });

            return Task.FromResult(finals);
        }
    }
}
