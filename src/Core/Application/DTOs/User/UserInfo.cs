using System;
using System.Collections.Generic; 

namespace Application.DTOs.User
{
    public class UserInfo
    {
        // private int _NoOfAccounts;
        public UserInfo()
        {

        }
       
        public string AccountHolderName { get; set; }
        public string DisplayName { get; set; }
        public string Emails { get; set; }
        public string Addresses { get; set; }
        public string Telephones { get; set; }
        
        public Accounts Accounts { get; set; }

    }
    public class UserInfoDTO
    {
        // private int _NoOfAccounts;
       
       
        public string AccountHolderName { get; set; }
        public string DisplayName { get; set; }
        public string Emails { get; set; }
        public string Addresses { get; set; }
        public string Telephones { get; set; }
        public int NoOfAccounts {  get ; set; }

        public List<Accounts> Accounts { get; set; }

    }

    public class Accounts
    {
        public string AccountHolderName { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public string AccountSubType { get; set; }
        public decimal CurrentBalance { get; set; }
        public string CurrentBalanceIndicator { get; set; }
        
    }
}
