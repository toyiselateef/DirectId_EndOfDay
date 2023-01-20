using System.Collections.Generic; 

namespace Domain.Entities.Core
{
    public class JsonCustomerData
    {
        public  string ProviderName { get; set; }
        public  string CountryCode { get; set; }
        public  List<Account> Accounts { get; set; } = new List<Account>();
    }
}
