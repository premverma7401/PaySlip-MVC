using PayMe.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayMe.Webapp.Models
{
    public class PayDetailViewModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [Display(Name = "Employee")]
        public string FullName { get; set; }
        [Display(Name ="IRD ")]
        public string Nino { get; set; }
        [DataType(DataType.Date), Display(Name = "Pay Date")]
        public DateTime PayDate { get; set; } 
        [Display(Name = "Pay Month")]
        public string PayMonth { get; set; }
        public int TaxYearId { get; set; }
        [Display(Name = "Tax Year")]
        public TaxYear TaxYear { get; set; }
        public string Year { get; set; }
        [Display(Name = "Tax Code")]
        public string TaxCode { get; set; }
        [Display(Name = "Hourly Rate")]
        public decimal HourlyRate { get; set; }
        [Display(Name = "Hours Worked")]
        public decimal HoursWorked { get; set; }
        [Display(Name = "Contracted Hours")]
        public decimal ContractedHours { get; set; }
        [Display(Name = "OverTime Hours")]
        public decimal OverTimeHours { get; set; }
        [Display(Name ="OverTime Rate")]
        public decimal OverTimeRate { get; set; }
        [Display(Name = "Contracted Earnings")]
        public decimal ContractedEarnings { get; set; }
        [Display(Name = "OverTime Earnings")]
        public decimal OverTimeEarnings { get; set; }
        [Display(Name = "Total Earnings")]

        public decimal TotalEarnings { get; set; }
        public decimal Tax { get; set; }
        [Display(Name = "Kiwi Saver")]

        public decimal? KiwiSaver { get; set; } // national insurance contribution
        [Display(Name = "Union Fee")]

        public decimal? UnionFee { get; set; } // optional as everyone is not a union member
        [Display(Name = "Student Loan")]

        public decimal? StudentLoanRepay { get; set; } // not everyone has loan
        [Display(Name = "Total Deduction")]

        public decimal TotalDeduction { get; set; }
        [Display(Name = "Net Payment")]

        public decimal NetPayment { get; set; }
    }
}
