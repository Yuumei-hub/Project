using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AbstractsLib
{
    public class Computer : Device
    {
        protected string _ipaddress;
        protected bool _switchedOn;
        protected string _operatingSystem;
        protected static int compCounter = 0;
        protected static int switchedCounter = 0;
        protected static int compInNet = 10;
        public Computer(string name, string make, string osystem, bool switched) : base(name, make)
        {
            this.OperatingSystem = osystem;
            this.SwitchedOn = switched;
            compCounter++;
        }
        public static int CountComps()
        {
            return compCounter;
        }

        public static int CountSwitched()
        {
            return switchedCounter;
        }

        public override void StartDevice()
        {
            this.SwitchedOn = true;
            switchedCounter++;
            this.Ipaddress = GetIpAddress();
            Console.WriteLine("The comp {0} is starting ...", this.Name);
        }

        public override void StopDevice()
        {
            this.SwitchedOn = false;
            switchedCounter--;
            Console.WriteLine("The comp {0} is shuting down !!!", this.Name);
        }

        public string IsSwitched()
        {
            if (this.SwitchedOn)
            { return "switched ON"; }
            else
            { return "switched OFF"; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Ipaddress
        {
            get { return _ipaddress; }
            set { _ipaddress = value; }
        }
        public string Make
        {
            get { return _make; }
            set { _make = value; }
        }
        public string OperatingSystem
        {
            get { return _operatingSystem; }
            set { _operatingSystem = value; }
        }
        public bool SwitchedOn
        {
            get { return _switchedOn; }
            set { _switchedOn = value; }
        }

        public static void ShowComputers(List<Computer> net)
        {
            foreach (Computer comp in net)
            {
                if (comp.SwitchedOn)
                {
                    Type type = comp.GetType();
                    string stringType = type.ToString();
                    Console.Write("{0}\t{1}\t{2}\t\t{3}", comp.Name, comp.Ipaddress, comp.OperatingSystem, comp.Make);
                    int pos = stringType.IndexOf('.');
                    //Console.Write(stringType.Substring(pos+1,4));

                    if (stringType.Substring(pos + 1, 4) == "Serv")
                    {
                        Server serv = (Server)comp;
                        System.Console.WriteLine("\t{0}", serv.Destination);
                    }
                    else
                        Console.WriteLine();
                }

            }
        } // end of ShowComputers

        public static void PingToComputer(List<Computer> net, Computer pingFrom, string pingTo)
        {
            Random rnd = new Random();
            double answer;
            Computer myComp = pingFrom;
            bool found = false;
            Console.WriteLine("\nTrying to ping from the machine{0}({1}) to {2}.", myComp.Name, myComp.Ipaddress, pingTo);
            Console.WriteLine("--------------------------------------------------------------------");
            foreach (Computer comp in net)
            {
                if ((pingTo == comp.Ipaddress) && (comp.SwitchedOn == true))
                {
                    found = true;
                    break;
                }
            } // the end of the loop
            if (found)
            {
                for (int i = 5; i < 15; i++)
                {
                    answer = (float)(rnd.Next(1, 100)) / 100;
                    Console.WriteLine("64 bytes from {0} icmp_seq={1} ttl=64 time={2} ms", myComp.Ipaddress, i.ToString(), answer.ToString());
                }
            }
            else
            {
                Console.WriteLine("Adress {0} not found !!! ", pingTo);
            }
        } //end of PingToComputer method

        public string GetIpAddress()
        {
            string address = "10.0.0." + (++compInNet).ToString();
            return address;
        }
    }
}
