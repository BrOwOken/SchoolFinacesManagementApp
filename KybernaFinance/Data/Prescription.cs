using System;
using System.ComponentModel.DataAnnotations;

namespace KybernaFinance.Data
{
    public class Prescription
    {
        [Key]
        public int Id { get; set; }

        public int Amount { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Student Student { get; set; }
        public PaymentType Type { get; set; }
    }
}