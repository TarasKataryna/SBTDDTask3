using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderLib
{
    public class Sushi
    {
        public double Price { get; protected set; }
        public string Description { get; protected set; }
        public string Name { get; protected set; }
    }
}
