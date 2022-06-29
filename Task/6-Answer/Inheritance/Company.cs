using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace InheritanceTask
{
    public class Company
    {
        readonly Employee[] employees;
        public Company(Employee[] employees)
        {
            this.employees = employees;
        }
        public void GiveEverybodyBonus(decimal companyBonus)
        {
            foreach (Employee employee in employees)
            {
                employee.SetBonus(companyBonus);
            }
        }
        public decimal TotalToPay()
        {
            decimal totalToPay = 0;
            foreach(Employee employee in employees)
            {
                totalToPay += employee.ToPay();
            }
            return totalToPay;
        }
        public string NameMaxSalary()
        {
            decimal[] salaries= new decimal[employees.Length];
            for(int i = 0; i < employees.Length; i++)
            {
                salaries[i]= employees[i].ToPay();
            }
            foreach(Employee employee in employees)
            {
                if(employee.ToPay()== salaries.Max())
                {
                    return employee.Name;
                }
            }
            return null;
             
        }
    }
    
}
