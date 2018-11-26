using System;
using System.Collections.Generic;

namespace A06 {
    class Program {
        static int score = 0;
        static List<Quizelement> quizelements = new List<Quizelement>();
        static int currentQuizelement = 0;
        static void Main(string[] args) {
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
                new Answer("Chisinau", true),
                    new Answer("Bucharest", false),
                    new Answer("Tiraspol", false),
                    new Answer("Sevastopol", false)
            }));
            quizelements.Add(new Quizelement("Which one is the biggest monotheistic Religion?", new Answer[] {
                new Answer("Chirstianity", true),
                    new Answer("Judaism", false),
                    new Answer("Islam", false),
                    new Answer("Sikhism", false)
            }));
        }
        public static Boolean FollowUserInstruction() {
            // Now let's get the party started! #Cringe
            Console.Clear();
            if (score != 0)
                Console.Write($"\nYour score is {score}\n");

            Console.Write("\nDo you want to:\n\nS) Solve a quiz,\nA) Add a question or\nE) End the program?\n\n> ");

            switch (Console.ReadLine().ToUpper()) {
                case "A":
                    AddQuestion();
                    return true;
                case "E":
                    Console.Clear();
                    Console.Write("You left the game.\n\n");
                    return false;
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