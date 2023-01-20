using System;
using System.Collections.Generic;

namespace Domain.Entities.Core
{
    public class EODData
    {
        public List<EODBalanceDetail> EODBalanceDetails { get; set; }
        public decimal ClosingBalance { get; set; }
        public decimal TotalCredits { get; set; }
        public decimal TotalDebits { get; set; }
    }

    public class EODBalanceDetail
    {
        public DateTime Day { get; set; }
        public string EodBalanceType { get; set; }
        public decimal   EodBalance { get; set; }

    }

}
