using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayMe.Entity
{
    public class PaymentRecord
    {
        public int Id { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string FullName { get; set; }
        public string Nino { get; set; }
        public DateTime PayDate { get; set; }
        public string PayMonth { get; set; }
        [ForeignKey("TaxYear")]
        public int TaxYearId { get; set; }
        public TaxYear TaxYear { get; set; }
        public string TaxCode { get; set; }
        [Column(TypeName = "money")]
        public decimal HourlyRate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal HoursWorked { get; set; }
        [Column(TypeName = "decimal(18,2)")]

        public decimal ContractedHours { get; set; }
        [Column(TypeName = "decimal(18,2)")]

        public decimal OverTimeHours { get; set; }
        [Column(TypeName = "money")]

        public decimal ContractedEarnings { get; set; }
        [Column(TypeName = "money")]

        public decimal OverTimeEarnings { get; set; }
        [Column(TypeName = "money")]

        public decimal TotalEarnings { get; set; }
        [Column(TypeName = "money")]

        public decimal Tax { get; set; }
        [Column(TypeName = "money")]

        public decimal NIC { get; set; } // national insuranse contribution
        [Column(TypeName = "money")]

        public decimal? UnionFee { get; set; } // optional as everyone is not a union member
        [Column(TypeName = "money")]
        public decimal? StudentLoanRepay { get; set; } // not everyone has loan
        [Column(TypeName = "money")]
        public decimal TotalDeduction { get; set; }
        [Column(TypeName = "money")]
        public decimal NetPayment { get; set; }

    }

}
