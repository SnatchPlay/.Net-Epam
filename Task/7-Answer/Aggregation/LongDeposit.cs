namespace Aggregation
{
    public class LongDeposit : Deposit
    {
        public LongDeposit(decimal amount, int period) : base(amount, period) { }
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