using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace KybernaFinance.Data
{
    public class Student : IdentityUser
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
    }
}