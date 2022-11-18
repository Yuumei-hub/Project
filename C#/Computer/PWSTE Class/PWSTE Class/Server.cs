using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWSTE_Class
{
    public class Server : Computer
    {
        public string destination;
        public Server(string make, string dest): base(make, dest)
        {
            this.destination = dest;
        }

    }
}
