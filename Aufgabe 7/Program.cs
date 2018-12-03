using System;
using System.Collections.Generic;

namespace Aufgabe_7
{
    class Program
    {
        static int score = 0;
        
        static List<Quizelement> quizelements = new List<Quizelement>();
        static int currentQuizelement = 0;

        static List<YesNoElement> yesnoelements = new List<YesNoElement>();
        static int currentYesNoElement = 0;

        static List<MultipleChoiceElement> multipleChoiceElements = new List<MultipleChoiceElement>();
        static int currentMultipleChoiceElement = 0;

        static List<FreeElement> freeElements = new List<FreeElement>();
        static int currentFreeElement = 0;

        static void Main(string[] args)
        {
            Console.Clear();
            GetDefaultQuestions();

            while (FollowUserInstruction()) { }

            Console.WriteLine($"Your final score is: {score}\nThank you for playing!\n");
        }

        public static void GetDefaultQuestions() {
            // Get some extremely sophisticated questions
            quizelements.Add(new Quizelement("What do you call a negatively charged element of an atom?", new Answer[] {
                new Answer("Electron", true),
                new Answer("Proton", false),
                new Answer("Neutron", false),
                new Answer("Positron", false)
            }));
            quizelements.Add(new Quizelement("What is the capital city of Moldova called?", new Answer[] {
                new Answer("Bucharest", false),
                new Answer("Tiraspol", false),
                new Answer("Chisinau", true),
                new Answer("Sevastopol", false)
            }));
            quizelements.Add(new Quizelement("Which one is the biggest monotheistic Religion?", new Answer[] {
                new Answer("Judaism", false),
                new Answer("Chirstianity", true),
                new Answer("Islam", false),
                new Answer("Sikhism", false)
            }));

            yesnoelements.Add(new YesNoElement("Is a tomato a berry?", true));

            yesnoelements.Add(new YesNoElement("Does a heptagon have 8 sides?", false));

            yesnoelements.Add(new YesNoElement("Is Heliology the study of the sun?", true));

            multipleChoiceElements.Add(new MultipleChoiceElement("Which of the following countries are part of the European Union?", new Answer[] {
                new Answer("Croatia", true),
                new Answer("Serbia", false),
                new Answer("Germany", true),
                new Answer("France", true)
            }, 3));

            multipleChoiceElements.Add(new MultipleChoiceElement("Which of the following superheroes belong to the DC universe?", new Answer[] {
                new Answer("Superman", true),
                new Answer("The Flash", true),
                new Answer("Spiderman", false),
                new Answer("Batman", true)
            }, 3));

            multipleChoiceElements.Add(new MultipleChoiceElement("Which of the following chemical compounds are considered strong acids?", new Answer[] {
                new Answer("CaSo4", false),
                new Answer("NaCl", false),
                new Answer("HNO3", true),
                new Answer("NH3", false),
                new Answer("H2SO4", true)
            }, 3));

            freeElements.Add(new FreeElement("What is Gandhi's full name?", "Mohandas karamchand Ghandi"));

            freeElements.Add(new FreeElement("From which country is the city called 'Batman'?", "Turkey"));

            freeElements.Add(new FreeElement("What company built the so called 'Boring Test Tunnel'?", "The Boring Company"));

        }

         public static Boolean FollowUserInstruction() {
            if (score != 0)
                Console.Write($"\nYour score is {score}\n");

            Console.Write("\nDo you want to:\n\nS) Solve a regular question \nY) Solve a yes/no question \nA) Add a question or\nE) End the program?\n\n> ");

            switch (Console.ReadLine().ToUpper()) {
                case "A":
                    AddQuestion();
                    return true;
                case "E":
                    Console.Clear();
                    Console.Write("You left the game.\n\n");
                    return false;
                case "Y":
                    if (currentYesNoElement < yesnoelements.Count) {
                        SolveYesNoQuestion(yesnoelements[currentYesNoElement]);
                        return true;
                    } else {
                        Console.Clear();
                        Console.Write("There are no questions left.\n\n");
                        return false;
                    }
                case "M":
                    if (currentMultipleChoiceElement < multipleChoiceElements.Count) {
                        SolveMultipleChoiceQuestion(multipleChoiceElements[currentMultipleChoiceElement]);
                        return true;
                    } else {
                        Console.Clear();
                        Console.Write("There are no questions left.\n\n");
                        return false;
                    }
                case "F":
                    if (currentFreeElement < freeElements.Count) {
                        SolveFreeQuestion(freeElements[currentFreeElement]);
                        return true;
                    } else {
                        Console.Clear();
                        Console.Write("There are no questions left.\n\n");
                        return false;
                    }
                default:
                    if (currentQuizelement < quizelements.Count) {
                        SolveAQuestion(quizelements[currentQuizelement]);
                        return true;
                    } else {
                        Console.Clear();
                        Console.Write("There are no questions left.\n\n");
                        return false;
                    }
            }
        }

        public static void SolveAQuestion(Quizelement quizelement) {
            Console.Clear();
            quizelement.ShowQuestion();
            Console.Write("\nYour choice: ");
            if (quizelement.answers[Int32.Parse(Console.ReadLine()) - 1].isTrue()) {
                score += 10;
                Console.Write("\nRight Answer! 10 Points to Gryffindor!");
            } else {
                Console.Write("\nWrong Answer. Sorry for that, bro!");
            }
            currentQuizelement++;
        }

        public static void SolveYesNoQuestion(YesNoElement yesNoElement){
            Console.Clear();
            yesNoElement.ShowQuestion();
            Console.Write("\nYour choice: ");
            switch(Console.ReadLine().ToUpper()){
                case "Y":
                    if(yesNoElement.verity == true){
                        score += 10;
                        Console.Write("\nRight Answer! 10 Points to Gryffindor!");
                    } else {
                        Console.Write("\nWrong Answer. Sorry for that, bro!");
                    }
                    break;
                case "N":
                    if(yesNoElement.verity == false){
                        score += 10;
                        Console.Write("\nRight Answer! 10 Points to Gryffindor!");
                    } else {
                        Console.Write("\nWrong Answer. Sorry for that, bro!");
                    }
                    break;
                default:
                    Console.Write("\nNo valid input selected");
                    break;
            }
            currentYesNoElement++;
        }

        public static void SolveMultipleChoiceQuestion(MultipleChoiceElement multipleChoiceElement)
        {
            int correctAnswers = 0;
            Console.Clear();
            multipleChoiceElement.ShowQuestion();
            Console.Write("\nYour choices (separated by a space): ");
            String[] splitAnswers = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            foreach(var answer in splitAnswers){
                if(multipleChoiceElement.answers[Int32.Parse(answer) - 1].isTrue())
                {
                    correctAnswers++;
                } else {
                    Console.Write("\nA wrong answer has been chosen...");
                    return;
                }
            }
            if(correctAnswers == multipleChoiceElement.correctAnswers)
            {
                score += 10;
                Console.Write("\nRight Answer! 10 Points to Gryffindor!");
            } else {
                Console.Write("\nWrong Answer. Sorry for that, bro!");
            }
        }

        public static void SolveFreeQuestion(FreeElement freeElement)
        {
            Console.Clear();
            freeElement.ShowQuestion();
            Console.Write("\nYour answer (not case-sensitive): ");
            if(Console.ReadLine().ToUpper() == freeElement.answer.ToUpper())
            {
                score += 10;
                Console.Write("\nRight Answer! 10 Points to Gryffindor!");
            } else {
                Console.Write("\nWrong Answer. Sorry for that, bro!");
            }

        }

        public static void AddQuestion() {
            Console.Clear();
            Console.Write("\nType in the Question you want to ask:\n> ");
            String newQuestion = Console.ReadLine();

            Console.Write("\nHow many chooseable answers do you want to give? (2-6)\n> ");
            int answerCount = Int32.Parse(Console.ReadLine());
            Answer[] newAnswers = new Answer[answerCount];

            // Get the first AND true Question
            Console.Write("\nType in your first AND TRUE answer: \n> ");
            newAnswers[0] = new Answer(Console.ReadLine(), true);
            // Get the rest
            for (int i = 1; i < answerCount; i++) {
                Console.Write($"\nType in your {i+1}. answer: \n> ");
                newAnswers[i] = new Answer(Console.ReadLine(), false);
            }
            // Make the Quizelement
            quizelements.Add(new Quizelement(newQuestion, newAnswers));
        }

    }
}
