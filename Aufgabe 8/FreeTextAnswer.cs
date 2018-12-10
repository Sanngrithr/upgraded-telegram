using System;
using System.Collections.Generic;

namespace Aufgabe_8
{
    public class FreeTextAnswer : QuizElementInterface
    {
        public String question;

        public List<SampleAnswer> sampleAnswers;

        public String correctAnswer;

        public String description;

        public FreeTextAnswer(String text, String answer)
        {
            this.question  = text;
            this.correctAnswer = answer;

            this.description = "Type any answer you like, this is not case-sensitive.";
        }

        public String GetCorrectAnswer();

        public int EvaluateAnswer(String answer)
        {
            points = 0;

            if(answer.ToUpper() == this.correctAnswer.ToUpper())
            {
                points += 10;
                Console.WriteLine("Correct answer!");
                return points;
            }
            else
            {
                Console.WriteLine("The answer was incorrect");
                return points;
            }
        }

        public void AddQuestion();
    }
}