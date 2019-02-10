using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace Stundenplan
{
    public class DataUtils
    {

        public static List<Professor> LoadProfData()
        {
            List<Professor> profList = new List<Professor>();

            XmlSerializer ser = new XmlSerializer(typeof(Professor));
            String path = Directory.GetCurrentDirectory() + "/data/professors";

            foreach(var prof in Directory.GetFiles(path))
            {
                StreamReader reader = new StreamReader(prof);
                profList.Add((Professor)ser.Deserialize(reader));
                reader.Close();
            }

            return profList;
        }

        public static List<Room> LoadRoomData()
        {
            List<Room> roomList = new List<Room>();
            List<Room> currentRooms = new List<Room>();

            XmlSerializer ser = new XmlSerializer(typeof(List<Room>));
            String path = Directory.GetCurrentDirectory() + "/data/rooms";

            foreach(var room in Directory.GetFiles(path))
            {
                StreamReader reader = new StreamReader(room);
                currentRooms = (List<Room>)ser.Deserialize(reader);
                reader.Close();
                roomList.AddRange(currentRooms);
            }

            return roomList;
        }

        public static Dictionary<string, int> LoadCohortData()
        {
            List<Cohort> cohortList = new List<Cohort>();

            XmlSerializer ser = new XmlSerializer(typeof(Cohort));
            String path = Directory.GetCurrentDirectory() + "/data/cohorts";

            foreach(var dir in Directory.GetDirectories(path))
            {
                foreach(var cohort in Directory.GetFiles(dir))
                {
                    StreamReader reader = new StreamReader(cohort);
                    cohortList.Add((Cohort)ser.Deserialize(reader));
                    reader.Close();
                }
            }

            Dictionary<String, int> cohortDict = new Dictionary<string, int>();

            foreach(Cohort cohort in cohortList)
            {
                cohortDict.Add(cohort.name, cohort.numberOfStundents);
            }

            return cohortDict;
        }

        
    }
}