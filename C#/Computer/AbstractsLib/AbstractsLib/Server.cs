using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractsLib
{
    public class Server: Computer
    {
        public Server(string name, string make, string osystem, bool switched, string dest, string ip) : base(name, make, osystem, switched)
        {
            this.Destination = dest;
            this.Ipaddress = ip;
        }

        // private member variables
        private string _destination;

        // public properties
        public string Destination
        {
            get { return _destination; }
            set { _destination = value; }
        }

        public override void StopDevice()
        {
            Console.WriteLine("************* !!! **************** ");
            Console.Write("You want to shut dowm this server. Are you sure ? (YES/n): ");


            string confirm = Console.ReadLine();
            if (confirm == "YES")
            {
                this.SwitchedOn = false;
                switchedCounter--;
                Console.WriteLine("The comp {0} is shuting down !!!", this.Name);
            }

        }

        public override void StartDevice()
        {
            this.SwitchedOn = true;
            switchedCounter++;
            Console.WriteLine("The comp {0} is starting ...", this.Name);
        }
    }
}
