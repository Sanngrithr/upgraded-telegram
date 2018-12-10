using System;

namespace Aufgabe_8
{
    public class SampleAnswer
    {
        public string text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
            }
        }

        Boolean isCorrect
        {
            get
            {
                return isCorrect;
            }
            set
            {
                isCorrect = value;
            }
        }

        public SampleAnswer(String text, Boolean verity)
        {
            this.text = text;
            this.isCorrect = verity;
        }
    }
    
}