using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    class DelegatesTest
    {
        private MainMenu m_MainMenu = new MainMenu();

        public void Show()
        {
            m_MainMenu.Show();
        }

        public DelegatesTest()
        {
            Inner showDateTimeItem = new Inner(@"Show Date/Time", m_MainMenu.CurrentItem);
            Leaf ShowDateItem = new Leaf("Show Date", showDateTimeItem);
            Leaf ShowTimeItem = new Leaf("Show Time", showDateTimeItem);
            Inner VersionAndDigitsItem = new Inner("Version and Digits", m_MainMenu.CurrentItem);
            Leaf CountDigitsItem = new Leaf("Count Digits", VersionAndDigitsItem);
            Leaf ShowVersionItem = new Leaf("Show Version", VersionAndDigitsItem);



            ShowDateItem.m_ReportClickDelegates += ShowDate;
            ShowTimeItem.m_ReportClickDelegates += ShowTime;
            CountDigitsItem.m_ReportClickDelegates += CountDigits;
            ShowVersionItem.m_ReportClickDelegates += ShowVersion;
            m_MainMenu.AddItem(showDateTimeItem);
            m_MainMenu.AddItem(ShowDateItem);
            m_MainMenu.AddItem(ShowTimeItem);
            m_MainMenu.AddItem(VersionAndDigitsItem);
            m_MainMenu.AddItem(CountDigitsItem);
            m_MainMenu.AddItem(ShowVersionItem);
        }

        private void ShowDate(string i_String)
        {
            string currentDate;

            currentDate = DateTime.Now.ToString("MM/dd/yyyy");
            Console.WriteLine(currentDate);
        }


        public void ShowTime(string i_String)
        {
            string currentTime;

            currentTime = DateTime.Now.ToString("HH:mm:ss");
            Console.WriteLine(currentTime);
        }
        public void ShowVersion(string i_String)
        {
            Console.WriteLine("Version: 19.2.4.32");
        }
        public void CountDigits(string i_String)
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

            foreach (char ch in i_Sentence)
            {
                if (char.IsDigit(ch))
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}