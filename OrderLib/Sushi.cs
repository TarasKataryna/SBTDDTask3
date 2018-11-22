using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderLib
{
    /// <summary>
    /// Class Sushs are based class for others
    /// </summary>
    public class Sushi
    {
        public double Price { get; protected set; }
        public string Description { get; protected set; }
        public string Name { get; protected set; }
    }
}
