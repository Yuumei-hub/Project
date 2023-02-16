using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesLib
{
    public class Computer:IDevice
    {
        public Computer(string name, string make, string os, bool status)
        {
            this.Name = name;
            this.Make = make;
            this.OS = os;
            this.Status = status;
            compCounter++;
        }
        protected string _name;
        protected string _make;
        protected string _os;
        protected string _ip;
        protected bool _status;
        protected string _destination;
        protected static int compCounter = 0;
        protected static int switchedCounter = 0;
        protected static int compInNet = 10;

        public static int CountComps()
        {
            return compCounter;
        }
        public static int CountSwitched()
        {
            return switchedCounter;
        }
        public virtual void TurnOn()
        {
            this.Status = true;
            switchedCounter++;
            this.IpAddress = GetIpAddress();
            Console.WriteLine($"{this.Name} is booting...");
        }
        public virtual void TurnOff()
        {
            this.Status = false;
            switchedCounter--;
            Console.WriteLine($"{this.Name} is shutting down...");
        }
        public string IsOn()
        {
            if (this.Status)
            { return "ON"; }
            else
            { return "OFF"; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Make
        {
            get { return _make; }
            set { _make = value; }
        }
        public string IpAddress
        {
            get { return _ip; }
            set { _ip = value; }
        }
        public string OS
        {
            get { return _os; }
            set { _os = value; }
        }
        public string Destination
        {
            get { return _destination; }
            set { _destination = value; }
        }
        public bool Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public static void DisplayComputers(List<Computer> net)
        {
            foreach (Computer computer in net)
            {
                Type type = computer.GetType();
                string stringType = type.ToString();
                Console.WriteLine($"{computer.Name}{computer.IpAddress}{computer.OS}{computer.Status}");
                int pos = stringType.IndexOf('.');
            }
        }

        public string GetIpAddress()
        {
            string address = "10.8.47." + (++compInNet).ToString();
            return address;
        }

        public static void SendPing(List<Computer> net, Computer comp1, Computer comp2)
        {
            bool found1 = false;
            bool found2 = false;
            var pingFrom = comp1.IpAddress;
            var pingTo = comp2.IpAddress;
            foreach (var item in net)
            {
                if ((item.IpAddress == comp1.IpAddress) && comp1.Status)
                    found1 = true;
                if ((item.IpAddress == comp2.IpAddress) && comp2.Status)
                    found2 = true;
            }
            if (found1 && found2)
            {
                Console.WriteLine($"Ping has been sent to {comp2.IpAddress} which is adress of : {comp2.Name} from {comp1.Name}");
            }
            else
            {
                Console.WriteLine("Computers are not switched on or don't exist in the current network.");
            }
        }



    }
}
