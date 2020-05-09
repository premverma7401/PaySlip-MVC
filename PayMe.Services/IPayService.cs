using Microsoft.AspNetCore.Mvc.Rendering;
using PayMe.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayMe.Services
{
   public interface IPayService
    {
        Task CreateAsync(PaymentRecord paymentRecord);
        PaymentRecord GetById(int id);
        IEnumerable<PaymentRecord> GetAll();
        IEnumerable<SelectListItem> GetAllTaxYears();
        TaxYear GetTaxYearById(int id);
        decimal OverTimeHours(decimal hoursWorked, decimal contractualHours);
        decimal ContractualEarnings(decimal hoursWorked, decimal contractualHours, decimal hourlyRate);
        decimal OverTimeEarnings(decimal overTimeRate, decimal overTimeHours);
        decimal OverTimeRate(decimal hourlyRate);
        decimal TotalEarnings(decimal overTimeEarnings, decimal contractualEarnings);
        decimal TotalDeductions(decimal tax, decimal nic, decimal studentLoanRepayment, decimal unionFee);
        decimal NetPay(decimal totalEarnings, decimal totalDeductions);

    }
}
