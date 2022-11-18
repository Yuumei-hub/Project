using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWSTE_Class
{
    public class Computer
    {
        private string _name;
        private string _ipaddress;
        private string _os;
        private static int _counter = 0;
        private static bool _switchOn;
       
        public Computer(string bn, string os)
        {
            Name = bn;
            OS = os;
            _switchOn = false;
            _counter++;
        }
        public Computer() { }
        //proprties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string IPAddress
        {
            get { return _ipaddress; }
            set { _ipaddress = value; }
        }
        public string OS
        {
            get { return _os; }
            set { _os = value; }
        }
        public bool SwitchOnp
        {
            get { return _switchOn; }
            set { _switchOn = value; }
        }
        public static int CountComputers()
        {
            return _counter;
        }
        public bool SwitchOn(String ip)

        {
            if (!SwitchOnp)

            {
                _switchOn = true;
                IPAddress = ip;
            }
            else
            {
                _switchOn = false;
                IPAddress = null;
            }
            return false;
        }
    }
}
