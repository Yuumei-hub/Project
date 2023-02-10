using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLib
{
    public class Employee
    {
        private int id;
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private double salary;
        public Employee()
        {
            Counter++;
        } //default constructor

        public Employee(int p_id, string p_firstName, string p_lastName, DateTime p_dateOfBirth, double p_salary)
        {
            id = p_id;
            firstName = p_firstName;
            lastName = p_lastName;
            dateOfBirth = p_dateOfBirth;
            salary = p_salary;
            Counter++;
        }

        //Properties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        private static int Counter = 0; //counts emplyoess

        public static int CountEmplyoess()
        {
            return Counter;
        }

        public void promotion(double rise)
        {
            Salary = salary * (1 + rise / 100);
        }

        public static void ShowEmployess(List<Employee> listOfEmployees)
        {
            foreach (Employee empl in listOfEmployees)
            {
                DateTime birthDate = empl.DateOfBirth;
                string bd = birthDate.ToString().Substring(0, 10);
                Console.WriteLine("{0, -10} {1, 5} {2, 15 } {3, 10}", empl.LastName, empl.FirstName, bd, empl.Salary);
            }

        }
    } 

}
