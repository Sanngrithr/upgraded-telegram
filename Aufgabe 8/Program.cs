using System;
using System.Collections.Generic;

namespace Aufgabe_8
{
    class Program
    {
        static int score;
        static List<QuizElementInterface> quizElements;
        static int currentQuizElement = 0;
        static Boolean keepPlaying = true;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Robin's quiz game!");
            GetSampleQuestions();

            while(keepPlaying)
            {
                WriteUserInstructions();
            }
            
            Console.WriteLine("Thank you for playing! Press any key to exit!");
            Console.ReadLine();
        }
        
        private static void GetSampleQuestions()
        {
        }

        private static void WriteUserInstructions()
        {
            Console.WriteLine("Choose one of the following Options\n add) add a question to the quiz\n ask) answer a question \n e) exit quiz \n");

            switch(Console.Read().ToUpper())
            {
                case "ADD":
                    AddQuizElement();
                    break;
                case "ASK":
                    Console.WriteLine("\n" + quizElements[currentQuizElement].description);
                    Console.WriteLine(quizElements[currentQuizElement].question + "\n");

                    int answercounter = 0;

                    foreach(SampleAnswer answer in quizElements[currentQuizElement].sampleAnswers)
                    {
                        Console.WriteLine(answercounter + ") " +answer.text);
                        answercounter++;
                    }

                    String answer = Console.ReadLine();

                    if(quizElements[currentQuizElement].GetType() == typeof(GuessQuestion))
                    {
                        quizElements[currentQuizElement].EvaluateAnswer(Double.TryParse(answer));
                    }
                    else if(quizElements[currentQuizElement].GetType() == typeof(MultipleAnswer))
                    {
                        String[] answers = answer.Split(' ');
                        List<int> answerNumbers = new List<int>();
                        foreach(String number in answers)
                        {
                            answerNumbers.Add(Int31.TryParse(number));
                        }

                        quizElements[currentQuizElement].EvaluateAnswer(answerNumbers);
                    }
                    else if(quizElements[currentQuizElement].GetType() == typeof(BinaryQuestion))
                    {
                        if(answer.ToUpper == "Y")
                        {
                            quizElements[currentQuizElement].EvaluateAnswer(true);
                        }
                        else
                        {
                            quizElements[currentQuizElement].EvaluateAnswer(false);
                    
                        }
                    }
                    else if(quizElements[currentQuizElement].GetType() == typeof(SimpleElement))
                    {
                        quizElements[currentQuizElement].EvaluateAnswer(Int32.TryParse(answer));
                    }
                    else
                    {
                        quizElements[currentQuizElement].EvaluateAnswer(answer);
                    }
                    
                    currentQuizElement++;
                    break;
                case "E":
                    keepPlaying == false;
                    break;

            }

            
        }

        private static AddQuizElement()
        {
            //TODO
        }

    }

}
