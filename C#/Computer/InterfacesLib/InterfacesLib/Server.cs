using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesLib
{
    public class Server :Computer
    {
        public Server(string name, string make, string osystem, bool switched, string dest, string ip): base(name,make,osystem,switched)
        {
            this.Destination = dest;
            this.IpAddress = ip;
        }
        public override void TurnOff()
        {
            Console.WriteLine("************* !!! **************** ");
            Console.Write("You want to shut dowm this server. Are you sure ? (YES/n): ");


            string confirm = Console.ReadLine();
            if (confirm == "YES")
            {
                this.Status = false;
                switchedCounter--;
                Console.WriteLine("The comp {0} is shuting down !!!", this.Name);
            }

        }
        public override void TurnOn()
        {
            this.Status = true;
            switchedCounter++;
            Console.WriteLine("The comp {0} is starting ...", this.Name);
        }
    }
}
