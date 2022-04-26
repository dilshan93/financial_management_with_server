using financial_management.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace financial_management.Response
{
    public class ReportResponse
    {
        public bool Sucess { get; set; }
        public string Discription { get; set; }
        public List<ReportDTO> RecentTransactions { get; set; }
        public string NextWeekExpense { get; set; }
        public string NextWeekIncome { get; set; }
    }
}
