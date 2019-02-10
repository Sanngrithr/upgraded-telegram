using System;
using System.Collections.Generic;

namespace Stundenplan
{
    public class Block
    {
        public List<Tuple<Course, Professor, Room>> occupiedRooms {get; set;}

        public Block()
        {
            occupiedRooms = new List<Tuple<Course, Professor, Room>>();
        }
    }
}