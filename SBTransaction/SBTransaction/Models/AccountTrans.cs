using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SBTransactionAPI.Models
{
    public class AccountTrans
    {
        [Key]
        public int ID { get; set; }
        public int TransactionId { get; set; }
        public DataType TransactionDate { get; set; }
        public double AccountNumber { get; set; }
        public float Amount { get; set; }
        public string TransactionType { get; set; }
    }
}