using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using PayMe.Entity;
using PayMe.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayMe.Services.Implimentation
{
    public class PayService : IPayService
    {
        private readonly ApplicationDbContext _context;
        private decimal contractualEarnings;
        private decimal overTimeHours;
        private decimal overTimeRate;
        private decimal overTimeHourRate;
        private decimal overTimeEarnings;
        private decimal netPay;
        private decimal totalEarnings;

        public PayService(ApplicationDbContext context)
        {
            _context = context;
        }
        public decimal ContractualEarnings(decimal hoursWorked, decimal contractualHours, decimal hourlyRate)
        {
            if (hoursWorked < contractualHours)
            {
                contractualEarnings = hoursWorked * hourlyRate;
            }
            else
            {
                contractualEarnings = contractualHours * hourlyRate;
            }
            return contractualEarnings;
        }
        public async Task CreateAsync(PaymentRecord paymentRecord)
        {
            await _context.PaymentRecords.AddAsync(paymentRecord);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<PaymentRecord> GetAll() => _context.PaymentRecords.OrderBy(p => p.EmployeeId);
        public IEnumerable<SelectListItem> GetAllTaxYears()
        {
            var allTaxYears = _context.TaxYears.Select(taxyears => new SelectListItem
            {
                Text = taxyears.YearOfTax,
                Value = taxyears.Id.ToString()
            });
            return allTaxYears;
        }
        public PaymentRecord GetById(int id) => _context.PaymentRecords.Where(p => p.Id == id).FirstOrDefault();
        public TaxYear GetTaxYearById(int id) => _context.TaxYears.Where(x => x.Id == id).FirstOrDefault();
        public decimal NetPay(decimal totalEarnings, decimal totalDeductions)
        {
            netPay = totalEarnings - totalDeductions;
            return netPay;
        }
        public decimal OverTimeEarnings(decimal overTimeRate, decimal overTimeHours)
        {
            overTimeEarnings = overTimeHours * overTimeRate;

            return overTimeEarnings;
        }
        public decimal OverTimeHours(decimal hoursWorked, decimal contractualHours)
        {
           
            if (hoursWorked <= contractualHours)
            {
                overTimeHours = 0.00m;
            }
            else if (hoursWorked > contractualHours)
            {
                overTimeHours = hoursWorked - contractualHours;
            }
            return overTimeHours;
        }
        public decimal OverTimeRate(decimal hourlyRate)
        {
            overTimeRate = hourlyRate * 1.5m;
            return overTimeRate;

        }
        public decimal TotalDeductions(decimal tax, decimal nic, decimal studentLoanRepayment, decimal unionFee)
            => tax + nic + studentLoanRepayment + unionFee;
        public decimal TotalEarnings(decimal overTimeEarnings, decimal contractualEarnings)
        {
            totalEarnings = overTimeEarnings + contractualEarnings;
            return totalEarnings;
        }
    }
}
