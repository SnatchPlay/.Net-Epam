using System;
using System.Diagnostics.CodeAnalysis;

namespace Interfaces
{

    public abstract class Deposit : IComparable<Deposit>
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

        public int CompareTo([AllowNull] Deposit other)
        {
            return (this._amount + this.Income()).CompareTo(other._amount + other.Income());
        }
    }
}
