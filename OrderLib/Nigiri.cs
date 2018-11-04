using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderLib
{
    public class Nigiri:Sushi
    {
        public Nigiri()
        {
            Price = 200;
            Name = "Nigiri";
            Description = "A topping, usually fish, served on top of sushi rice";
        }
    }
}
