using System.Collections.Generic;

namespace Domain.Entities.Others
{
    public class Available
    {
        public double amount { get; set; }
        public string creditDebitIndicator { get; set; }
        public List<object> creditLines { get; set; }
    }
}
