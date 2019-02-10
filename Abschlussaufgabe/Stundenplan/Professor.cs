using System;
using System.Collections.Generic;

namespace Stundenplan
{
    [Serializable]
    public class Professor 
    {
        public String name {get; set;}
        public List<Course> courses {get; set;}
        public List<Course> optionalCourses {get; set;}
        public List<int[]> notAvailable {get; set;}
    }
}