using PayMe.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayMe.Webapp.Models
{
    public class EmployeeDetailViewModel
    {
        public int Id { get; set; }
       
        public string EmpId { get; set; }
       
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal OverTimeRate { get; set; }
        public decimal ContractedHours { get; set; }
        public string IRD { get; set; }
        public DateTime DateJoined { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public string NSN { get; set; }
        [Display(Name = "Tax Code")]
        public string TaxCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int PostCode { get; set; }
        public string Phone { get; set; }
        public ContractType ContractType { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public UnionMember UnionMember { get; set; }
        public StudentLoan StudentLoan { get; set; }
        public KiwiSaver KiwiSaver { get; set; }
    }
}
