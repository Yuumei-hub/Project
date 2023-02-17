using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamLibrary;
using System.Linq;
using System.IO;

namespace ExamTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Company c1 = new Company("Microsoft","United States",234000);
            Company c2 = new Company("Louis Vuitton","France",545000);
            Company c3 = new Company("Hershey","United States",10000);
            Company c4 = new Company("Huawei","China",532400);
            Company c5 = new Company("Mercedes","Germany",404600);

            c1.Display();
            c2.Display();
            c3.Display();
            c4.Display();
            c5.Display();

            List<Company> companies=new List<Company> { c1, c2, c3,c4,c5 };

            Factory f1 = new Factory("Daimler", "Germany",324234, 4000);
            Factory f2 = new Factory("FCA", "Italy",324234, 2300);
            Factory f3 = new Factory("Nestle", "Switzerland",324234, 12000);
            Factory f4 = new Factory("Daimler", "Germany",324234, 4000);

            f1.Display();
            f2.Display();
            f3.Display();
            f4.Display();

            Console.WriteLine("----------");
            Console.WriteLine("----------");
            Console.WriteLine("----------");

            List<Factory> factories= new List<Factory> { f1, f2, f3, f4 };

            var result = from factory in factories
                         orderby factory.Employees descending
                         select factory;

            List<string> linqline = new List<string> { };

            linqline.Add("Sorted by employee numbers...");

            foreach (var item in result)
            {
                string x = $"{item.Name}\t {item.Location}\t {item.Turnover}\t {item.Employees}";
                linqline.Add(x);
                linqline.Add("-------------------------------------------------");
                linqline.Add("");
            }

            foreach (var item in linqline)
            {
                Console.WriteLine(item);
            }

            using (StreamWriter file = new StreamWriter("C:\\Users\\Acer\\Desktop\\ExamLinqTest.txt"))
            {
                foreach (var item in linqline)
                {
                    file.WriteLine(item);
                } 
            }
            Console.ReadLine();
        }
    }
}
