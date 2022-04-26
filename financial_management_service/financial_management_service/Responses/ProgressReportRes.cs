using financial_management_service.DTO;
using System.Collections.Generic;

namespace financial_management_service.Responses
{
    public class ProgressReportRes : GenaralResponse
    {
        
        public List<RecentTransaction> RecentTransactions { get; set; }
        public string NextWeekExpense { get; set; }
        public string NextWeekIncome { get; set; }
    }
}
