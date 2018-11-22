using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderLib
{
    /// <summary>
    /// Class Nigiri inherit from Sushi
    /// </summary>
    public class Nigiri : Sushi
    {
        public Nigiri()
        {
            Price = 200;
            Name = "Nigiri";
            Description = "A topping, usually fish, served on top of sushi rice";
        }
    }
}
