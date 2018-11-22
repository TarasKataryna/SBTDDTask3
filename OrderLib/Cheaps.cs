using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderLib
{
    /// <summary>
    /// Class Cheaps inherit from Sushi
    /// </summary>
    public class Cheaps : Sushi
    {
        public Cheaps()
        {
            Price = 70;
            Name = "Cheaps";
            Description = "Taste rice cheapses";
        }
    }
}
