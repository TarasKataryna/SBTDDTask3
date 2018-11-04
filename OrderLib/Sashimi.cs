using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderLib
{
    public class Sashimi:Sushi
    {
        public Sashimi()
        {
            Price = 150;
            Name = "Sashimi";
            Description = "Fish or shellfish served alone (no rice)";
        }
    }
}
