using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ExamLibrary
{
    public class Factory:Company
    {
        public Factory(string name, string location, int turnover, int employees):base(name,location,turnover)
        {
            _employees = employees;
        }
        protected int _employees;
        public int Employees 
        {
            get { return _employees; }
            set { _employees = value; }
        }
        public override void Display()
        {
            Console.WriteLine($"Companys\n\t Name: {this.Name}\t Location: {this.Location}\n\t Employee number of this factory: {this.Employees.ToString()}");

        }
    }
}
