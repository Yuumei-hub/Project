using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;


namespace PWSTE_Class
{
    class Program
    {
        static string getNum(int limit)
        {
            Random random = new Random();
            int num;
            num = random.Next(1, limit);
            return num.ToString();
        }

        static void Main()
        {
            Computer comp01 = new Computer("alfa", "Windows 10");
            Computer comp02 = new Computer("beta", "Windows 10");
            Computer comp03 = new Computer("delta", "Ubuntu");
            Computer comp04 = new Computer();
            comp01.SwitchOn("10.0." + getNum(128) + "." + getNum(254));
            comp02.SwitchOn("10.0." + getNum(128) + "." + getNum(254));
            comp03.SwitchOn("10.0." + getNum(128) + "." + getNum(254));
            comp02.SwitchOn("10.0." + getNum(128) + "." + getNum(254));
            comp02.SwitchOn("10.0." + getNum(128) + "." + getNum(254));
            comp03.SwitchOn("10.0." + getNum(128) + "." + getNum(254));
            comp03.SwitchOn("10.0." + getNum(128) + "." + getNum(254));

            List<Computer> net = new List<Computer>();
            net.Add(comp01);
            net.Add(comp02);
            net.Add(comp03);
            for (int i = 0; i < net.Count; i++)
            {
                Console.WriteLine(net[i].Name + " " + net[i].IPAddress);
            }
            Console.WriteLine("----------------------------------------------");
            for (int i = 0; i < net.Count; i++)
            {
                Console.WriteLine(net[i].Name + " " + net[i].IPAddress);
            }
            Console.WriteLine("We have {0} computers in our network.", Computer.CountComputers());
            Console.WriteLine("----------------------------------------------");

            //creating server obj and displaying it
            Server server = new Server("beta", "szdfsdfsdf");
            Console.WriteLine(server.Name+" "+server.destination);
        }
    }
}