using System;

namespace Aufgabe_8
{
    interface QuizElementInterface
    {
        public String question
        {
            get
            {
                return question;
            }
            set
            {
                question = value;
            }
        }

        public List<SampleAnswer> sampleAnswers
        {
            get
            {
                return sampleAnswers;
            }
            set
            {
                sampleAnswers = value;
            }
        }

        public String description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public String GetCorrectAnswer();

        public int EvaluateAnswer();

        public void AddQuestion();
    }

}