using System.Linq;

namespace Aggregation
{
    public class Client
    {
        readonly Deposit[] deposits;
        public Client()
        {
            this.deposits = new Deposit[10];
        }
        public bool AddDeposit(Deposit deposit)
        {
            for (int i = 0; i < deposits.Length; i++)
            {
                if (deposits[i] == null)
                {
                    deposits[i] = deposit;
                    return true;
                }
            }
            return false;
        }
        public decimal TotalIncome()
        {
            decimal totalIncome = 0;
            foreach (Deposit deposit in deposits)
            {
                if (deposit != null) { totalIncome += deposit.Income(); }
            }
            return totalIncome;
        }
        public decimal MaxIncome()
        {
            decimal[] incomes = new decimal[deposits.Length];
            for (int i = 0; i < incomes.Length; i++)
            {
                incomes[i] = (deposits[i] != null) ? deposits[i].Income() : 0;
            }
            return incomes.Max();
        }
        public decimal GetIncomeByNumber(int number)
        {
            if (number - 1 == 0) { return 0; }
            var tmp = deposits[number - 1];

            if (tmp == null) { return 0; }

            return deposits[number - 1].Income();
        }
    }
}
    
