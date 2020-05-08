using Microsoft.AspNetCore.Http;
using PayMe.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayMe.Webapp.Models
{
    public class EmployeeEditViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Employee Number is required"), RegularExpression(@"^ [A-Z] {3,3}[0-9]{3}$")]
        public string EmpId { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
       
        [DataType(DataType.Date), Display(Name = "Date Of Birth")]
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        [Display(Name = "Photo")]
        public IFormFile ImageUrl { get; set; }
        [DataType(DataType.Date), Display(Name = "Date Joined")]

        public DateTime DateJoined { get; set; } 
        public string Designation { get; set; }
        public string Email { get; set; }
        public string NSN { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int PostCode { get; set; }
        [Display(Name = "Payment Method")]
        public PaymentMethod PaymentMethod { get; set; }
        [Display(Name = "Union Member")]

        public UnionMember UnionMember { get; set; }
        [Display(Name = "Student Loan")]

        public StudentLoan StudentLoan { get; set; }
    }
}
