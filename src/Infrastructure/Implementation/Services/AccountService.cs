using Application.Exceptions;
using Application.Interfaces.Respository;
using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Entities.Core;
using Domain.Entities.Others; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Implementation.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository AccountRepository;

        public AccountService(IAccountRepository AccountRepository)
        {
            this.AccountRepository = AccountRepository;
        }

        public async Task<IEnumerable<string>> GetAccountNumbers()
        {
            var accountNumbers = await AccountRepository.GetAccountNumbers();
            return accountNumbers;
        }

        public async Task<EODData> GetEODBalances(string accountNumber)
        {
           
            if (string.IsNullOrEmpty(accountNumber))
            {
                throw new BadRequestException("Invalid Account Number supplied");
            }

            var customer_Account = await AccountRepository.GetAccountByAccountNumber(accountNumber);

            if (customer_Account == null)
            {
                throw new NotFoundException("Account", "Id" );
                //return;
            }
            var endDate = customer_Account?.Transactions[0].BookingDate;

            var grouped_Transactions = customer_Account.Transactions
                 .GroupBy(x => Convert.ToDateTime(x.BookingDate.ToShortDateString())).OrderBy(x => x.Key).ToList(); 

            var eod_Data = GetGroupedTransactionsEODBalances(grouped_Transactions, customer_Account);

            
            return eod_Data;

        }






      

        private EODData GetGroupedTransactionsEODBalances(List<IGrouping<DateTime, Transaction>> dailyTransactions, Account customerAccount)
        {

            decimal total_Credit = 0M ;
            decimal total_Debit = 0M;
           

            decimal current_Balance = (decimal)(customerAccount.Balances.Current.CreditDebitIndicator == CreditDebitIndicator.Credit ?(customerAccount.Balances.Current.Amount) : (customerAccount.Balances.Current.Amount * -1)) ;


            var end_Of_Day_Data = new EODData();
            var end_Of_Day_Balances_List = new List<EODBalanceDetail>();
            DateTime day = new DateTime();

            lock (this)
            {
                foreach (var transactions in dailyTransactions)
                {
                    decimal credit = (decimal)(transactions.Where(x => x.CreditDebitIndicator == CreditDebitIndicator.Credit).Sum(x => x.Amount));
                    decimal debit = (decimal)(transactions.Where(x => x.CreditDebitIndicator == CreditDebitIndicator.Debit).Sum(x => x.Amount));
                    
                    current_Balance += (credit - debit); 
                    total_Credit += credit;
                    total_Debit += debit;


                    day = transactions.Key;
                   

                    end_Of_Day_Balances_List.Add(new EODBalanceDetail()
                    {
                        Day = day,
                        EodBalanceType = current_Balance > 0 ? CreditDebitIndicator.Credit : CreditDebitIndicator.Debit,
                        EodBalance = Math.Abs(current_Balance)

                    });

                }
            }
            end_Of_Day_Data = new EODData()
            {
                EODBalanceDetails= end_Of_Day_Balances_List,
                ClosingBalance = current_Balance,
                TotalCredits = total_Credit,
                TotalDebits = total_Debit
            };
            return end_Of_Day_Data;

        }



        
     
    }
    
    }
