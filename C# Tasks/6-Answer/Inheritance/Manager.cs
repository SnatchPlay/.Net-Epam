namespace InheritanceTask
{
    public class Manager : Employee
    {
        readonly int quantity;

        public Manager(string name, decimal salary, int clientAmount) : base(name, salary)
        {
            this.quantity = clientAmount;

        }
        public override void SetBonus(decimal bonus)
        {
            if (quantity > 150) { base.SetBonus(1000 + bonus); }
            else if (quantity > 100) { base.SetBonus(500 + bonus); }
            else { base.SetBonus(bonus); }
        }
    }

}

