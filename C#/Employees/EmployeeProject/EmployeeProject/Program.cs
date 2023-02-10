using EmployeeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            Employee e1 = new Employee(1, "John", "Smith", new DateTime(2002, 01, 14), 2200);
            Employee e2 = new Employee(2, "Anna", "Bula", new DateTime(1998, 04, 24), 2100);
            Employee e3 = new Employee(3, "Onat", "Gumus", new DateTime(2001, 04, 06), 2100);
            Employee e4 = new Employee(4, "Wiktor", "Kuduk", new DateTime(2000, 01, 13), 2400);
            Employee e5 = new Employee(5, "Ema", "Maxfield", new DateTime(2003, 07, 06), 2300);
            Employee e6 = new Employee(6, "Lenny", "Oxton", new DateTime(1999, 12, 24), 2000);
            Employee e7 = new Employee(7, "Lenny", "Oxton", new DateTime(1999, 12, 24), 2000);

            e2.DateOfBirth = new DateTime(2002, 02, 14);

            Employee e8 = new Employee(8, "Kaz", "Kotek", new DateTime(1992, 02, 13), 3140);

            List<Employee> listOfEmployees = new List<Employee>();
            Employee.ShowEmployess(listOfEmployees);

            listOfEmployees.Add(e1);
            listOfEmployees.Add(e2);
            listOfEmployees.Add(e3);
            listOfEmployees.Add(e4);
            listOfEmployees.Add(e5);
            listOfEmployees.Add(e6);
            listOfEmployees.Add(e7);

            ShowEmployers(listOfEmployees);
            Console.WriteLine("---------------------------------------------------");

            CalculateSalary(listOfEmployees, 5);
            ShowEmployers(listOfEmployees);
            Console.WriteLine("---------------------------------------------------");

            RemoveEmployee(listOfEmployees, e1);
            ShowEmployers(listOfEmployees);
            Console.WriteLine("---------------------------------------------------");

            DisplaySalaries(listOfEmployees);
            Console.WriteLine("---------------------------------------------------");

            DisplaySalaryStats(listOfEmployees);
            Console.WriteLine("----------------------------------------------------");

            ShowBiggerThanAvr(listOfEmployees);
            Console.WriteLine("-----------------------------------------------------");



            Console.ReadLine();
        }
        public static void ShowEmployers(List<Employee> listOfEmployees)
        {
            foreach (Employee empl in listOfEmployees)
            {
                Type type = empl.GetType();
                string stringType = type.ToString();
                DateTime birthDate = empl.DateOfBirth;
                string bd = birthDate.ToString().Substring(0, 10);
                Console.WriteLine("{0} {1} {2} {3}", empl.LastName, empl.FirstName, bd, empl.Salary);
            }

        }
        public static void DisplaySalaries(List<Employee> employees)
        {
            foreach (Employee item in employees)
            {
                Type type = item.GetType();
                string stringType = type.ToString();
                Console.WriteLine("{0} {1} {2}", item.LastName, item.FirstName, item.Salary);
            }
        }
        public static void CalculateSalary(List<Employee> employees, int hour)
        {
            foreach (Employee employee in employees)
            {
                employee.Salary *= hour;
            }
        }

        public static List<Employee> RemoveEmployee(List<Employee> employees, Employee employee)
        {
            employees.Remove(employee);
            return employees;
        }
        public static void DisplaySalaryStats(List<Employee> employees)
        {
            double sum_of_salaries = 0;
            double min =9999999999999999;
            double max = 0;
            foreach (Employee item in employees)
            {
                if (item.Salary > max)
                    max = item.Salary;
                if (item.Salary < min)
                    min = item.Salary;
                sum_of_salaries+=item.Salary;
            }
            double average_salary = sum_of_salaries / employees.Count();
            Console.WriteLine($"Min salary: {min}\t Max Salary: {max}\t Average Salary: {average_salary}");
        }
        public static double CalcAverage(List<Employee> employees)
        {
            double sum = 0;
            foreach (var item in employees)
            {
                sum += item.Salary;
            }
            return sum / employees.Count();
        }
        public static void ShowBiggerThanAvr(List<Employee> employees) 
        {
            var result = from e in employees
                         where e.Salary > CalcAverage(employees)//calculates average salary
                         select e;

            Console.WriteLine("Bigger salaries than average: ");

            foreach (var item in result)
            {
                Console.WriteLine($"{item.FirstName}\t{item.LastName}\t{item.Salary}");
            }

            Console.WriteLine("Bigger salaries than average: (With different type of LINQ Query) ");
            var result2 = employees.Where(e => e.Salary > CalcAverage(employees));
            foreach (var item in result2)
            {
                Console.WriteLine($"{item.FirstName}\t{item.LastName}\t{item.Salary}");

            }

        }
    }
}
