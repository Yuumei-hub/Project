using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamLibrary
{
    public class Company: IBusiness
    {
        protected string _name;
        protected string _location;
        protected int _turnover;
        public Company(string name, string location, int turnover)
        {
            _name = name;
            _location = location;
            _turnover = turnover;
        }

        public string Name 
        { 
            get { return _name; }
            set { _name = value; }
        }
        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }
        public int Turnover
        {
            get { return _turnover; }
            set { _turnover = value; }
        }

        public virtual void Display()
        {
            Console.WriteLine("--------------");
            Console.WriteLine($"Companys\n\t Name: {this.Name}\t Location: {this.Location}\n\t Turnover:{Convert.ToString(this.Turnover)}");
            Console.WriteLine("--------------");
        }
    }
}
