using System;
using System.Collections.Generic;
using System.Text;

namespace PayMe.Services
{
    public interface IDeductionService
    {
        decimal KiwiSaverDeduction(decimal totalAmount);
        decimal TaxAmount(decimal totalAmount);
        decimal UnionFees(int employeeId);
        decimal StudentLoanRepay(int employeeId, decimal totalAmount);

    }
}
