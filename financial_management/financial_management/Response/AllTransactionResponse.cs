using financial_management.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace financial_management.Response
{
    public class AllTransactionResponse
    {
        public bool Sucess { get; set; }
        public string Discription { get; set; }
        public TransactionDTO[] ReturnResponse { get; set; }
    }
}
