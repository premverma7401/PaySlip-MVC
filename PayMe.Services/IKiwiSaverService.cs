using System;
using System.Collections.Generic;
using System.Text;

namespace PayMe.Services
{
    public interface IKiwiSaverService
    {
        decimal KiwiSaverDeduction(decimal totalAmount);

    }
}
