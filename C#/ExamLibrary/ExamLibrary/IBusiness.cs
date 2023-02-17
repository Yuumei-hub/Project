using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ExamLibrary
{
    public interface IBusiness
    {
        void Display();
        string Name { get; set; }
    }
}
