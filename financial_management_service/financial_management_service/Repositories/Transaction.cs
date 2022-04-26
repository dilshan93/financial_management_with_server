using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace financial_management_service.Repositories
{
    [Table("TransactionsDb")]
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
        public bool IsRepete { get; set; }
        [NotMapped]
        public Category Category { get; set; }
    }
}
