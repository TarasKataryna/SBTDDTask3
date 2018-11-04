using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderLib
{
    public class Uramaki:Sushi
    {
        public Uramaki()
        {
            Price = 220;
            Name = "Uramaki";
            Description = "Similar to the above, but rice is on the outside and seaweed wraps around the filling";
        }
    }
}
