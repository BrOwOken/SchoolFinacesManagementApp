using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace KybernaFinance.Data
{
    public class AppController
    {
        private ApplicationDbContext DbContext { get; set; }
        protected UserManager<Student> UserManager { get; set; }
        private readonly IHttpContextAccessor httpContextAccessor;

        public AppController(UserManager<Student> userManager, ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            DbContext = dbContext;
            UserManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        public Task<Student> GetCurrentUserAsync()
        {
            return UserManager.GetUserAsync(httpContextAccessor.HttpContext.User);
        }

        public List<Prescription> GetCurrentUserPrescriptions(PaymentType type)
        {
            var student = GetCurrentUserAsync().Result;
            var prescriptions = DbContext.Presciptions.Where(p => p.Student == student).ToList();
            if (prescriptions != null)
                return prescriptions.FindAll(p => p.Type == type);
            else return null;

        }

        public List<Payment> GetCurrentUserPayments(PaymentType type)
        {
            var student = GetCurrentUserAsync().Result;
            var payments = DbContext.Payments.Where(p => p.Student == student).ToList();
            if (payments != null)
                return payments.FindAll(p => p.Type == type);
            else return null;
        }

        public List<Payment> GetUserPayments(string id, PaymentType type)
        {
            var student = GetStudentById(id);
            var payments = DbContext.Payments.Where(p => p.Student == student).ToList();
            if (payments != null) return payments.FindAll(p => p.Type == type);
            else return null;
        }

        public List<Prescription> GetUserPrescriptions(string id, PaymentType type)
        {
            var student = GetStudentById(id);
            var prescriptions = DbContext.Presciptions.Where(p => p.Student == student).ToList();
            if (prescriptions != null) return prescriptions.FindAll(p => p.Type == type);
            else return null;
        }

        public void AddPaymentToCurrentUser(PaymentType type)
        {
            var r = new Random();
            var payment = new Payment()
            {
                From = "Deda Vseveda",
                Amount = r.Next(100,50000),
                Date = DateTime.Today,
                Student = GetCurrentUserAsync().Result,
                Type = type
            };
            DbContext.Payments.Add(payment);
            DbContext.SaveChanges();
        }
        public void AddPrescriptionToCurrentUser( PaymentType type)
        {
            var r = new Random();
            var prescription = new Prescription()
            {
                Name = "Test",
                Amount = r.Next(100,50000),
                Date = DateTime.Today,
                Student = GetCurrentUserAsync().Result,
                Type = type
            };
            DbContext.Presciptions.Add(prescription);
            DbContext.SaveChanges();
        }

        public List<Student> SearchStudents(string phrase)
        {
            var result = DbContext.Users.Where(p => p.Email.Contains(phrase));
            if (result != null) return result.ToList();
            else return null;
        }

        public Student GetStudentById(string id)
        {
            return DbContext.Users.FirstOrDefault(s => s.Id == id);
        }
    }
}