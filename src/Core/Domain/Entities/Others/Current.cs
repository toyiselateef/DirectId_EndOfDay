using System.Collections.Generic;

namespace Domain.Entities.Others
{
    public class Current
    {
        public double Amount { get; set; }
        public string CreditDebitIndicator { get; set; }
        public List<object> CreditLines { get; set; }
    }
}
