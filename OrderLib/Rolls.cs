using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderLib
{
    /// <summary>
    /// Class Rolls inherit from Sushi
    /// </summary>
    public class Rolls : Sushi
    {
        public Rolls()
        {
            Price = 90;
            Name = "Rolls";
            Description = "Rolls wrapped in steak";
        }
    }
}
