using financial_management.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace financial_management.DataObjects
{
    public class TransactionDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
        public CategoryDTO Category { get; set; }
        public bool IsRepete { get; set; }
    }
}
