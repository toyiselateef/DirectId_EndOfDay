using Domain.Entities.Core;
using Newtonsoft.Json; 

namespace Persistance
{
    public class DataSeeder
    {
        public static void SeedAccountData() {
            //string file_Name = "apollo-carter.json";
            string file_Name = "account.json";
            string read_Data = ResourceManager.GetString(file_Name);
            var customer_data = JsonConvert.DeserializeObject<JsonCustomerData>(read_Data);
            Seed(customer_data);
        }
        static void Seed(JsonCustomerData? customerData)
        {
            if (customerData == null)
            {
                return;
            }

            CustomerData.ProviderName = customerData.ProviderName;
            CustomerData.CountryCode = customerData.CountryCode;
            CustomerData.Accounts = customerData.Accounts;
        }
    }
}
