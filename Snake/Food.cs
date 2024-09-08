using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Food : Circle
    {
        public bool isEaten { get; set; }
        public bool isBonus { get; set; }
    }
}
