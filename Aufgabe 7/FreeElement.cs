using System;

namespace  Aufgabe_7{

    public class FreeElement{

        public String question;
        public String answer;

        public FreeElement(String question, String answer) {
            this.question = question;
            this.answer = answer;
        }

        public void ShowQuestion() 
        {
            Console.Write($"\n{question}\n\n");
        }
    }
}