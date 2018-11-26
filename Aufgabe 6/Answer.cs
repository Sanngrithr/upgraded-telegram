using System;

namespace A06 {
    public class Answer {
        public String text;
        public Boolean verity;
        public Answer(String text, Boolean verity) {
            this.text = text;
            this.verity = verity;
        }
        public Boolean isTrue() {
            return verity;
        }
    }
}