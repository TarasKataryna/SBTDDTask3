using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderLib
{
    public static class OrderN
    {
        public static uint OrderNum { get; set; }
        static OrderN()
        {
            OrderNum = 0;
        }
        public static double getOrderNum()
        {
            OrderNum++;
            return OrderNum;
        }
    }
}
