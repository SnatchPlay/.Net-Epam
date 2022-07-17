using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{

    public class LongDeposit : Deposit,IProlongable
    {
        public LongDeposit(decimal amount, int period) : base(amount, period) { }

        public bool CanToProlong()
        {
            if (Period <= 36) { return true; }
            return false;
        }

        public override decimal Income()
        {
            decimal income = 0;
            decimal temp = Amount;
            if (Period > 6)
            {
                for (int i = 1; i <= Period - 6; i++)
                {
                    income = temp * 15 / 100;
                    temp += income;
                }
            }
            return temp - Amount;
        }
    }

}
