using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public class SpecialDeposit : Deposit,IProlongable
    {
        public SpecialDeposit(decimal amount, int period) : base(amount, period) { }

        public bool CanToProlong()
        {
            if (Amount > 1000) { return true; }
            return false;
        }

        public override decimal Income()
        {
            decimal income = 0;
            decimal temp = Amount;
            for (int i = 1; i <= Period; i++)
            {
                income = temp * i / 100;
                temp += income;
            }
            return temp - Amount;
        }
    }
}
