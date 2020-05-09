using System;
using System.Collections.Generic;
using System.Text;

namespace PayMe.Services.Implimentation
{
    public class TaxService : ITaxService
    {
        private decimal slab1 = 14000m;
        private decimal slab1Percent = .105m;
        private decimal slab2 = 48000m;
        private decimal slab2Percent = .175m;
        private decimal slab3 = 70000m;
        private decimal slab3Percent = .300m;
        private decimal maxPercent = .33m;
        private decimal taxAmount;
        public decimal TaxAmount(decimal totalAmount)
        {
            if (totalAmount<= slab1)
            {
                taxAmount = totalAmount * slab1Percent;
            }
           else if (totalAmount > slab1 && totalAmount<=slab2)
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
    }
}

// for now added a flat rate of tax but needs to discuss the logic...if its progressive tax then revisit it.

//Up to $14,000	10.5%
//Over $14,000 and up to $48,000	17.5%
//Over $48,000 and up to $70,000	30%
//Remaining income over $70,000	33%