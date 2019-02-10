using System;
using System.Collections.Generic;

namespace Stundenplan
{
    public class Timetable
    {
        public List<Day> weekdays {get; set;}
        private String[] dayNames =new String[]{"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};

        public Timetable()
        {
            weekdays = new List<Day>
            {
                new Day(),
                new Day(),
                new Day(),
                new Day(),
                new Day() 
            };
            
            foreach(Day currentDay in weekdays)
            {
                currentDay.blocks = new List<Block>(){new Block(), new Block(), new Block(), new Block(), new Block(), new Block()};
            }
        }

        public void FillTable(List<Professor> profList, List<Room> roomList, Dictionary<string, int> cohortDict)
        {
           int dayCounter = 0; //currently evaluated day; monday=0, friday=4
           int blockCounter = 0; //currently evaluated block

           // loop over all the courses of all the professors to add them all to the timetable
            foreach(Professor prof in profList)
            {
                foreach(Course course in prof.courses)
                {
                    Room currentRoom = null;
                    while(currentRoom == null)
                    {
                        //find a room that meets requirements
                        currentRoom = this.FindRoom(course, roomList, cohortDict, dayCounter, blockCounter);
                        if(currentRoom == null)
                        {
                            //if no good room is found in this block, move on to the next one
                            NextBlock(ref dayCounter, ref blockCounter);
                        }
                        else //if no room is found there is no point in checking the other requirements
                        {
                        //check if prof is free during this block
                            Boolean profAvailable = true;
                            //check if prof has another course during this block
                            foreach(Tuple<Course, Professor, Room> occupiedRoom in this.weekdays[dayCounter].blocks[blockCounter].occupiedRooms)
                            {
                                //if the professor is in a course in the current block move on to the next block
                                if(prof == occupiedRoom.Item2)
                                {
                                    profAvailable = false;
                                    currentRoom = null;
                                    NextBlock(ref dayCounter, ref blockCounter);
                                    break;
                                }
                            }
                                //check for other appointments
                            foreach(int[] appointment in prof.notAvailable)
                            {
                                if(appointment[0] == dayCounter && appointment[1] == blockCounter)
                                {
                                    profAvailable = false;
                                    currentRoom = null;
                                    NextBlock(ref dayCounter, ref blockCounter);
                                    break;
                                }
                            }

                             //check if cohort is free during this block
                            if(IsCohortAvailable(course, dayCounter, blockCounter) == false)
                            {
                                currentRoom = null;
                                NextBlock(ref dayCounter, ref blockCounter);
                            }
                            else if(IsCohortAvailable(course, dayCounter, blockCounter) && currentRoom!= null && profAvailable)
                            {
                                //if all requirements are met add the course to the timetable
                                this.weekdays[dayCounter].blocks[blockCounter].occupiedRooms.Add(new Tuple<Course, Professor, Room>(course, prof, currentRoom));
                                //reset day and block counters for the next course
                                dayCounter = 0;
                                blockCounter = 0;
                            }
                        }
                    }
                }
            }
        }

        public void AddOptionalCoursesToTable(List<Professor> profList, List<Room> roomList, Dictionary<String, int> cohortDict)
        {
            foreach(Professor prof in profList)
            {
                foreach(Course optCourse in prof.optionalCourses)
                {
                    Room currentRoom = null;
                    currentRoom = FindRoom(optCourse, roomList, cohortDict, optCourse.presetTime[0], optCourse.presetTime[1]);
                    if(currentRoom == null)
                    {
                        Console.WriteLine("Could not find a room for optional course " + optCourse.name);
                        break;
                    }
                    this.weekdays[optCourse.presetTime[0]].blocks[optCourse.presetTime[1]].occupiedRooms.Add(new Tuple<Course, Professor, Room>(optCourse, prof, currentRoom));
                }
            }
        }

        public void PrintWholeTable()
        {
            int dayCounter = 0;
            int blockCounter = 0;

            foreach(Day currentDay in this.weekdays) //loop over all days in the table
            {
                Console.WriteLine("=======" + dayNames[dayCounter].ToString() + "======="); //Write the day
                dayCounter++;
                blockCounter = 0;

                foreach(Block currentBlock in currentDay.blocks) //loop over all blocks in the table
                {
                    Console.WriteLine("-----Block " + (blockCounter +1) + "-----");
                    blockCounter++;

                    foreach(Tuple<Course ,Professor, Room> currentCourse in currentBlock.occupiedRooms)
                    {
                        Console.WriteLine(currentCourse.Item1.name);

                        foreach(String cohortName in currentCourse.Item1.cohort)
                        {
                            Console.Write(cohortName + " ");
                        }
                        Console.WriteLine();
                        Console.WriteLine(currentCourse.Item2.name);
                        Console.WriteLine(currentCourse.Item3.name);
                        Console.WriteLine();
                    }
                }
            }
        }

        public void PrintCohortTable(String cohortName)
        {
            int dayCounter = 0;
            int blockCounter = 0;

            Console.WriteLine("Show timetable for " + cohortName);

            foreach(Day currentDay in this.weekdays)
            {
                Console.WriteLine("=======" + dayNames[dayCounter].ToString() + "======="); //Write the day
                dayCounter++;
                blockCounter = 0;

                foreach(Block currentBlock in currentDay.blocks)
                {
                    Console.WriteLine("-----Block " + (blockCounter +1) + "-----");
                    blockCounter++;

                    foreach(Tuple<Course, Professor, Room> currentCourse in currentBlock.occupiedRooms)
                    {
                        if(currentCourse.Item1.cohort.Contains(cohortName))
                        {
                            Console.WriteLine(currentCourse.Item1.name);

                            foreach(String cohName in currentCourse.Item1.cohort)
                            {
                                Console.Write(cohName + " ");
                            }
                            Console.WriteLine();
                            Console.WriteLine(currentCourse.Item2.name);
                            Console.WriteLine(currentCourse.Item3.name);
                            Console.WriteLine();
                        }
                    }
                }
            }
        }

        public void PrintProfessorTable(String professorName)
        {
            int dayCounter = 0;
            int blockCounter = 0;

            Console.WriteLine("Show timetable for " + professorName);

            foreach(Day currentDay in this.weekdays)
            {
                Console.WriteLine("=======" + dayNames[dayCounter].ToString() + "======="); //Write the day
                dayCounter++;
                blockCounter = 0;

                foreach(Block currentBlock in currentDay.blocks)
                {
                    Console.WriteLine("-----Block " + (blockCounter +1) + "-----");
                    blockCounter++;

                    foreach(Tuple<Course, Professor, Room> currentCourse in currentBlock.occupiedRooms)
                    {
                        if(currentCourse.Item2.name == professorName)
                        {
                            Console.WriteLine(currentCourse.Item1.name);

                            foreach(String cohName in currentCourse.Item1.cohort)
                            {
                                Console.Write(cohName + " ");
                            }
                            Console.WriteLine();
                            Console.WriteLine(currentCourse.Item2.name);
                            Console.WriteLine(currentCourse.Item3.name);
                            Console.WriteLine();
                        }
                    }
                }
            }
        }

        public void PrintAvailableOptionalCourses(String cohortName)
        {
            int dayCounter = 0;
            int blockCounter = 0;

            Console.WriteLine("Show available optional courses for " + cohortName);

            foreach(Day currentDay in this.weekdays)
            {
                Console.WriteLine("=======" + dayNames[dayCounter].ToString() + "======="); //Write the day
                blockCounter = 0;

                foreach(Block currentBlock in currentDay.blocks)
                {
                    Console.WriteLine("-----Block " + (blockCounter+1) + "-----");

                    foreach(Tuple<Course, Professor, Room> currentCourse in currentBlock.occupiedRooms)
                    {
                        if(currentCourse.Item1.cohort.Contains("Optional") && IsCohortAvailable(cohortName, dayCounter, blockCounter))
                        {
                            Console.WriteLine(currentCourse.Item1.name);

                            foreach(String cohName in currentCourse.Item1.cohort)
                            {
                                Console.Write(cohName + " ");
                            }
                            Console.WriteLine();
                            Console.WriteLine(currentCourse.Item2.name);
                            Console.WriteLine(currentCourse.Item3.name);
                            Console.WriteLine();
                        }
                    }
                    blockCounter++;
                }
                dayCounter++;
            }
        }

        private bool IsCohortAvailable(Course course, int dayCounter, int blockCounter)
        {
            foreach(Tuple<Course, Professor, Room> occupiedRoom in this.weekdays[dayCounter].blocks[blockCounter].occupiedRooms)
            {
                foreach(String currentCohort in course.cohort)
                {
                    if(occupiedRoom.Item1.cohort.Contains(currentCohort))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool IsCohortAvailable(String cohortName, int dayCounter, int blockCounter)
        {
            foreach(Tuple<Course, Professor, Room> occupiedRoom in this.weekdays[dayCounter].blocks[blockCounter].occupiedRooms)
            {
                if(occupiedRoom.Item1.cohort.Contains(cohortName))
                {
                    return false;
                }
            }
            return true;
        }

        private void NextBlock(ref int dayCounter, ref int blockCounter)
        {
            blockCounter++;
            if(blockCounter > 5)// A Day should have a maximum of 6 blocks
            {
                dayCounter++;
                blockCounter = 0;

                if(dayCounter == this.weekdays.Count)//the end of days has come, prepare for doooooom
                {
                    //should the end of the table be reached the course could not be added and the counters should reset for the next course
                    dayCounter = 0;
                    blockCounter = 0;
                    Console.WriteLine("Course could not be added to the table.");
                }
            }
        }

       //Method for Roomsearch in a given block
        private Room FindRoom(Course course, List<Room> roomList, Dictionary<string, int> cohortDict, int dayCounter, int blockCounter)
        {
            Boolean roomFound = false; // by default assume the room is not available and check another
            foreach(Room room in roomList)
            {
                roomFound = false; 
                if(CheckRequirements(course, room, course.GetTotalNumberOfStudents(cohortDict)))
                {
                    roomFound = true;
                    //check if room is free during this block
                    foreach(Tuple<Course, Professor, Room> occupiedRoom in this.weekdays[dayCounter].blocks[blockCounter].occupiedRooms)
                    {
                        if(room.name == occupiedRoom.Item3.name)
                        {
                            roomFound = false;
                            break;
                        }
                    }
                }

                if(roomFound)
                {
                    //end the search if the room is good
                    return room;
                }
            }
            return null;
        }


        // Method to check if a room fits all the requirements for a given course
       private bool CheckRequirements(Course course, Room room, int numberOfStudents)
       {
           // by default assume that the room doesn't fit the requirements
           Boolean hasEverything = false;
           // check for roomsize
            if(room.size >= numberOfStudents)
            {
                // check for equipment
                
                int equipmentCount = 0;

                foreach(Equipment courseEquipment in course.neededEquipment)
                {
                    foreach(Equipment roomEquipment in room.equipment)
                    {
                        if(courseEquipment == roomEquipment)
                        {
                            equipmentCount++;
                        }
                    }
                }

                if(equipmentCount == course.neededEquipment.Count)
                {
                    // should the room not have all the needed equipment this will never be set to true
                    hasEverything = true;
                }
            }

            return hasEverything;
       }
    }
}