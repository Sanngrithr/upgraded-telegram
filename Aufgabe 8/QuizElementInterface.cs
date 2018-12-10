using System;
using System.Collections.Generic;

namespace Aufgabe_8
{
    public interface QuizElementInterface
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

        String GetCorrectAnswer();

        int EvaluateAnswer();

        void AddQuestion();
    }

}