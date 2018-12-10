using System;
using System.Collections.Generic;

namespace Aufgabe_8
{
    public class MultipleAnswer : QuizElementInterface
    {
        public String question;

        public List<SampleAnswer> sampleAnswers;

        public String description;

        public MultipleAnswer(String text, List<SampleAnswer> answers)
        {
            this.question = text;
            this.sampleAnswers = answers;

            this.description = "Multiple answers may be correct. Type the numbers of all correct answers, separated by a space.";
        }
        public String GetCorrectAnswer()
        {

        }

        public int EvaluateAnswer(List<int> answers)
        {
            int points = 0;

            foreach(int answer in answers)
            {
                if(sampleAnswers[answer].isCorrect == true)
                {
                    points += 10;
                }
                else
                {
                    points -= 10;
                }
            }

            return points;
        }

        public void AddQuestion();
    }
}