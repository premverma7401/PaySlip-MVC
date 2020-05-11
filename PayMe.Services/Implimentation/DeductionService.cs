using PayMe.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayMe.Services.Implimentation
{

   public class DeductionService : IDeductionService
    {

        private decimal studentLoanAmount = 0m;
        private decimal unionFee = 0m;
        private decimal slab1 = 14000m;
        private decimal slab1Percent = .105m;
        private decimal slab2 = 48000m;
        private decimal slab2Percent = .175m;
        private decimal slab3 = 70000m;
        private decimal slab3Percent = .300m;
        private decimal maxPercent = .33m;
        private decimal taxAmount;
        private decimal kiwiSaverRate = .04m;
        private decimal kiwiSaverDeduction;
        private readonly IEmployeeService _employee;

        public DeductionService(IEmployeeService employee)
        {
            _employee = employee;
        }
        public decimal TaxAmount(decimal totalAmount)
        {
            if (totalAmount <= slab1)
            {
                taxAmount = totalAmount * slab1Percent;
            }
            else if (totalAmount > slab1 && totalAmount <= slab2)
            {
                taxAmount = totalAmount * slab2Percent;
            }
            else if (totalAmount > slab2 && totalAmount <= slab3)
            {
                taxAmount = totalAmount * slab3Percent;
            }
            else if (totalAmount > slab3)
            {
                taxAmount = totalAmount * maxPercent;
            }
            return taxAmount;
        }
        public decimal UnionFees(int employeeId)
        {
            var employee = _employee.GetEmployeeById(employeeId);
            if (employee.PayInfoEmployee.UnionMember == UnionMember.Yes)
            {
                unionFee = 100m;
            }
            return unionFee;
        }
        public decimal StudentLoanRepay(int employeeId, decimal totalAmount)
        {
            var employee = _employee.GetEmployeeById(employeeId);
            if (employee.PayInfoEmployee.StudentLoan == StudentLoan.Yes)
            {
                if (totalAmount > 2000 && totalAmount < 4000)
                {
                    studentLoanAmount = 40m;
                }
                else if (totalAmount >= 4000 && totalAmount < 8000)
                {
                    studentLoanAmount = 100m;
                }
                return studentLoanAmount = 0;

            }
            return studentLoanAmount;

        }
        public decimal KiwiSaverDeduction(decimal totalAmount)
        {
            if (totalAmount > slab1)
            {
                kiwiSaverDeduction = totalAmount * kiwiSaverRate;
            }
            return kiwiSaverDeduction;
        }

    }
}
