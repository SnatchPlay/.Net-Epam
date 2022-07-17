﻿namespace InheritanceTask
{
    public class Employee
    {
        readonly string name;
        private decimal salary;
        private decimal bonus;

        public string Name { get { return name; } }
        public decimal Salary { get { return salary; } set { salary = value; } }
        public Employee(string name, decimal salary)
        {
            this.name = name;
            Salary = salary;
        }
        public virtual void SetBonus(decimal bonus)
        {
            this.bonus = bonus;
        }
        public decimal ToPay()
        {
            return salary + bonus;
        }
    }

}

