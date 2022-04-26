using financial_management.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace financial_management.Response
{
    internal class AllCategoryResponse
    {
        public bool Sucess { get; set; }
        public string Discription { get; set; }
        public CategoryDTO[] ReturnResponse { get; set; }
    }
}
