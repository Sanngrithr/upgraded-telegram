using System;
using System.Collections.Generic;

namespace Aufgabe_8
{
    public class GuessQuestion : QuizElementInterface
    {
        public String question;

        public List<SampleAnswer> sampleAnswers;

        public String description;

        public double correctAnswer;

        public GuessQuestion(String text, double value)
        {
            this.question = text;
            this.correctAnswer = value;

            this.description = "Take a guess and type a number as your answer.";
        }

        public String GetCorrectAnswer();

        public int EvaluateAnswer(double answer)
        {
            int points = 0;

            if(calculateDiversity(answer) <= 0.05)
            {
                points += 10;
            }
            else if(calculateDiversity(answer) <= 0.1)
            {
                points += 5;
            }
            else
            {
                Console.WriteLine("The answer was incorrect");
                return points;
            }
        }

        public double calculateDiversity(double answer)
        {
            if(answer >= this.correctAnswer)
            {
            return answer/this.correctAnswer - 1;
            }
            else
            {
                return 1 - answer/this.correctAnswer;
            }
        }

        public void AddQuestion();
    }
}