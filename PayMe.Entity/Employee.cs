using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PayMe.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string EmpId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public PersonalInfoEmployee PersonalInfoEmployee { get; set; }
        public PayInfoEmployee PayInfoEmployee { get; set; }

        public List<PaymentRecord> PaymentRecords { get; set; }

    }
}
