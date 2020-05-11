using PayMe.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace PayMe.Webapp.Models
{
    public class PayCreateViewModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [Display(Name ="Full Name")]
        public string FullName { get; set; }
        public string Nino { get; set; }
        [DataType(DataType.Date), Display(Name ="Pay Date")]
        public DateTime PayDate { get; set; } = DateTime.UtcNow;
        [Display(Name = "Pay Month")]
        public string PayMonth { get; set; } = DateTime.Today.Month.ToString();
        [Display(Name = "Tax Year")]
        public int TaxYearId { get; set; }
        [Display(Name = "Tax Year")]
        public TaxYear TaxYear { get; set; }
        [Display(Name = "Tax Code")]
        public string TaxCode { get; set; } = "M";
        [Display(Name = "Hourly Rate")]
        public decimal HourlyRate { get; set; }
        [Display(Name = "Hours Worked")]
        public decimal HoursWorked { get; set; }
        [Display(Name = "Contracted Hours")]
        public decimal ContractedHours { get; set; }
        [Display(Name = "OverTime Hours")]
        public decimal OverTimeHours { get; set; }
        [Display(Name = "Contracted Earnings")]
        public decimal ContractedEarnings { get; set; }
        [Display(Name = "OverTime Earnings")]
        public decimal OverTimeEarnings { get; set; }
        public decimal TotalEarnings { get; set; }
        public decimal Tax { get; set; }
        public decimal? KiwiSaver { get; set; } // national insurance contribution
        public decimal? UnionFee { get; set; } // optional as everyone is not a union member
        public decimal? StudentLoanRepay { get; set; } // not everyone has loan
        public decimal TotalDeduction { get; set; }
        public decimal NetPayment { get; set; }
    }
}
