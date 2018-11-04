using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderLib
{
    public class Maki : Sushi
    {
        public Maki()
        {
            Price = 180;
            Name = "Maki";
            Description = "Rice and filling wrapped in seaweed";
        }
    }
    
}
