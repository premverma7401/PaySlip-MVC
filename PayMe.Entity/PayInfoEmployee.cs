using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayMe.Entity
{
    public class PayInfoEmployee
    {
        public int Id { get; set; }
        public ContractType ContractType { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal HourlyRate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal OverTimeRate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ContractedHours { get; set; }
        public string IRD { get; set; }
        public DateTime DateJoined { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public UnionMember UnionMember { get; set; }
        public StudentLoan StudentLoan { get; set; }
        public KiwiSaver KiwiSaver { get; set; }
    }

    // employee info like active and emp id type
    // personalInfo
    // PayInfo
    // Sites info and security type model impliment.
}
