using System;
using System.Collections.Generic;

namespace Stundenplan
{
    public class Day
    {
        public List<Block> blocks {get; set;}

        public Day()
        {
            blocks = new List<Block>{};
        }
    }
}