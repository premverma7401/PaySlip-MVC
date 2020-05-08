﻿using System;
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
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateJoined { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public string NSN { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int PostCode { get; set; }
        public int Phone { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public UnionMember UnionMember { get; set; }
        public StudentLoan StudentLoan { get; set; }
        public List<PaymentRecord> PaymentRecords { get; set; }

    }
}
