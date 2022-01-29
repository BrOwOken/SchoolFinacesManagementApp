using System;
using System.ComponentModel.DataAnnotations;

namespace KybernaFinance.Data
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public string From { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public Student Student { get; set; }
        public PaymentType Type { get; set; }
    }
}