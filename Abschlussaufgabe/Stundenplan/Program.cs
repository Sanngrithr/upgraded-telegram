using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace Stundenplan
{
    class Program
    {
        static Boolean exitApplication = false;
        static void Main(string[] args)
        {
            Console.WriteLine("Loading data...");
            List<Professor> profList = DataUtils.LoadProfData();
            List<Room> roomList = DataUtils.LoadRoomData();
            Dictionary<String, int> cohortDict = DataUtils.LoadCohortData();

            Console.WriteLine("Generating timetable...");
            Timetable table1 = new Timetable();
            table1.AddOptionalCoursesToTable(profList, roomList, cohortDict);
            table1.FillTable(profList, roomList, cohortDict);

            while(exitApplication == false)
            {
                Console.WriteLine("Press ENTER to continue.");
                Console.ReadLine();
                Console.Clear();
                Console.Write("\nDo you want to:\n\nF) Show complete timetable,\nC) Show timetable for a specific cohort,\nP) Show timetable for a specific professor,\nO)Show optional courses for a cohort or\nE) End the program?\n\n> ");

                switch(Console.ReadLine().ToUpper())
                {
                    case "F":
                        table1.PrintWholeTable();
                        break;
                    case "C":
                        Console.WriteLine("Type in the cohort name (e.g. 'MIB1')");
                        table1.PrintCohortTable(Console.ReadLine());
                        break;
                    case "P":
                        Console.WriteLine("Type in the professor's name (e.g. 'Lasowski')");
                        table1.PrintProfessorTable(Console.ReadLine());
                        break;
                    case "O":
                        Console.WriteLine("Type in the cohort name (e.g. 'MIB1')");
                        table1.PrintAvailableOptionalCourses(Console.ReadLine());
                        break;
                    case "E":
                        exitApplication = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
