using System;
using System.Collections.Generic;

namespace Stundenplan
{
    [Serializable]
    public class Course
    {
        public String name {get; set;}
        public List<String> cohort {get; set;}
        public List<Equipment> neededEquipment {get; set;}
        public int[] presetTime{get; set;}


        public int GetTotalNumberOfStudents(Dictionary<String, int> cohortDict)
        {
            int students = 0;
            foreach(String c in cohort)
            {
                if(cohortDict.ContainsKey(c))
                {
                    students += cohortDict[c];
                }
            }
            return students;
        }
    }
}