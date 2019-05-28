using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class CountDigits : IClickObserver
    {
        public void OnClickObserver()
        {
            string sentence, message;
            int amountOfDigits;

            Console.WriteLine("Please write a sentence");
            sentence = Console.ReadLine();
            amountOfDigits = countDigitsInSentence(sentence);
            message = string.Format("The amount of digits in the sentence is: {0}", amountOfDigits);
            Console.WriteLine(message);
        }

        private int countDigitsInSentence(string i_Sentence)
        {
            int counter = 0;

            foreach(char ch in i_Sentence)
            {
                if(char.IsDigit(ch))
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
