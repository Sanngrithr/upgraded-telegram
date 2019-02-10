using System;
using System.Collections.Generic;

namespace Stundenplan
{
    [Serializable]
    public class Room
    {
        public String name {get; set;}
        public List<Equipment> equipment {get; set;}
        public int size {get; set;}
    }
}