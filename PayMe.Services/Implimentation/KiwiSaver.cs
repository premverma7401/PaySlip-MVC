using System;
using System.Collections.Generic;
using System.Text;

namespace PayMe.Services.Implimentation
{
    public class KiwiSaver : IKiwiSaverService
    {

        private decimal kiwiSaverRate = .04m;
        private decimal slab1 = 14000;
        private decimal kiwiSaverDeduction;
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
