using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spesa_Test.Handler
{
    internal class Dipendente
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public double Euro { get; set; }
    


        public int Age { get { return DateTime.Now.Year - DateOfBirth.Year; } }

         public Dipendente() { }
        /*
            public Employee(double euro)
        {
            Euro = euro;
        }*/
    }
}

