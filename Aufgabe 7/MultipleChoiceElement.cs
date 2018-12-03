using System;

namespace Aufgabe_7{

    public class MultipleChoiceElement{

        public String question;
        public Answer[] answers;
        public int correctAnswers;

        public MultipleChoiceElement(String question, Answer[] answers, int correctAnswers) {
            this.question = question;
            this.answers = answers;
            this.correctAnswers = correctAnswers;
        }

        public void ShowQuestion() 
        {
            Console.Write($"\n{question}\n\n");

            for (int i = 0; i < answers.Length; i++) 
            {
                Console.WriteLine($"{i+1}) {answers[i].text}");
            }
        }
    }
}