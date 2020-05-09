using System;
using System.Collections.Generic;
using System.Text;

namespace PayMe.Services
{
   public interface ITaxService
    {
        decimal TaxAmount(decimal totalAmount);
    }
}
