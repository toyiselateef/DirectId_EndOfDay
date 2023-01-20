using System.Collections.Generic;

namespace Domain.Entities.Core
{
    public static class CustomerData
    {
        public static string ProviderName { get; set; }
        public static string CountryCode { get; set; }
        public static List<Account> Accounts { get; set; } = new List<Account>();
    }
}
