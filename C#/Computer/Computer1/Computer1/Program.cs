using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompTestLib;

namespace Computer1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Computer comp1 = new Computer("comp1","Lenovo","W10",false);
            Computer comp2 = new Computer("comp2", "Lenovo", "W10",false);
            Computer comp3 = new Computer("comp3", "Lenovo", "W10",false);
            Computer comp4 = new Computer("comp4", "Lenovo", "W10",false);
            Computer comp5 = new Computer("comp5", "Lenovo", "W10",false);

            Computer comp6 = new Computer("comp6", "Lenovo", "W10",false);
            Computer comp7 = new Computer("comp7", "Lenovo", "W10",false);

            List<Computer> net = new List<Computer>();
            net.Add(comp1);
            net.Add(comp2);
            net.Add(comp3);
            net.Add(comp4);
            net.Add(comp5);
            net.Add(comp6);
            net.Add(comp7);

            comp1.TurnOn();

            Console.WriteLine("--------------------------------------------------------");

            foreach (var item in net)
            {
                if(item.Status)
                    Console.WriteLine($"{item.Name}'s Status: {item.Status}");
                else
                    Console.WriteLine($"{item.Name}'s Status: {item.Status}");
            }
            Console.WriteLine("-------------------------------------------------------");
            Computer.SendPing(net,comp1,comp2);
            Console.ReadLine();
        }
    }
}
