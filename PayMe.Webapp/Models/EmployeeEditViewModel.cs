﻿using Microsoft.AspNetCore.Http;
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
        [Required(ErrorMessage = "Employee Number is required")]
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
        [Display(Name = "Tax Code")]
        public string Designation { get; set; }
        public string Email { get; set; }
        public string NSN { get; set; }
        public string Phone { get; set; }
        public string TaxCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        [Display(Name = "Post Code")]
        public int PostCode { get; set; }
        [Display(Name = "Hourly Rate")]
        public decimal HourlyRate { get; set; }
        [Display(Name = "Overtime Rate")]
        public decimal OverTimeRate { get; set; }
        [Display(Name = "Contracted Hours")]
        public decimal ContractedHours { get; set; }
        public string IRD { get; set; }
        [Display(Name = "Payment Method")]
        public PaymentMethod PaymentMethod { get; set; }
        [Display(Name = "Union Member")]

        public UnionMember UnionMember { get; set; }
        [Display(Name = "Student Loan")]

        public StudentLoan StudentLoan { get; set; }
        [Display(Name = "Contract Type")]
        public ContractType ContractType { get; set; }
        [Display(Name = "Kiwi Saver")]

        public KiwiSaver KiwiSaver { get; set; }
        [Display(Name = "Pay Cycle")]

        public PayCycle PayCycle { get; set; }


    }
}
