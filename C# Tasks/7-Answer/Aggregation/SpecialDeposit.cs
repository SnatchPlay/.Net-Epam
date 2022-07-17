namespace Aggregation
{
    public class SpecialDeposit : Deposit
    {
        public SpecialDeposit(decimal amount, int period) : base(amount, period) { }
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