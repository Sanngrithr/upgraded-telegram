using System;
using System.Collections.Generic;

namespace Aufgabe_8
{
    public class BinaryQuestion : QuizElementInterface
    {
        public String question;

        public List<SampleAnswer> sampleAnswers;

        public String description;

        public Boolean isCorrect;

        public BinaryQuestion(String text, Boolean verity)
        {
            this.question = text;
            this.isCorrect = verity;

            this.description = "Type 'y' for yes or 'n' for no.";
        }

        public String GetCorrectAnswer();

        public int EvaluateAnswer(Boolean answer)
        {
            int points = 0;

            if(answer == this.verity)
            {
                points += 10;
                Console.WriteLine("Correct Answer");
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