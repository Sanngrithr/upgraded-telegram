using System;
using System.Collections.Generic;

namespace Aufgabe_8
{
    public class SimpleElement : QuizElementInterface
    {
        public String question;

        public List<SampleAnswer> sampleAnswers;

        public String description;

        public SimepleElement(String text, List<SampleAnswer> answers)
        {
            this.question = text;
            this.sampleAnswers = answers;

            this.description = "Type the number of the correct answer.";
        }
        public String GetCorrectAnswer()
        {
            
        }

        public int EvaluateAnswer(int answer)
        {
            int points = 0;
            
            if(this.sampleAnswers[answer].isCorrect == true)
            {
                points += 10;
                Console.WriteLine("Correct Answer!");
                return points;
            }
            else
            {
                Console.WriteLine("This Answer is incorrect.");
                return points;
            }
           
        }

        public void AddQuestion();
    }
}