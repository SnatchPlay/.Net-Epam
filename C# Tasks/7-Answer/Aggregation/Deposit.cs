namespace Aggregation
{
    public abstract class Deposit
    {
        private readonly decimal _amount;
        private readonly int _period;
        public decimal Amount { get { return _amount; } }
        public int Period { get { return _period; } }
        public Deposit(decimal amount, int period)
        {
            this._amount = amount;
            this._period = period;
        }
        public abstract decimal Income();
    }
}