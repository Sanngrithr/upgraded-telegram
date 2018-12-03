using System;

namespace  Aufgabe_7{

    public class YesNoElement{

        public String question;
        public Boolean verity;

        public YesNoElement(String question, Boolean verity) {
            this.question = question;
            this.verity = verity;
        }

        public void ShowQuestion() 
        {
            Console.Write($"\n{question}\n\n");
            Console.WriteLine("Type Y for yes and N for no");
        }
    }
}