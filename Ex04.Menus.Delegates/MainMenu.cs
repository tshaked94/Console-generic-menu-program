using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        private MenuItem m_CurrentItem = new Inner("Main Menu", null);

        public MainMenu()
        {
            // MainMenu c'tor
            m_CurrentItem.Level = 0;
        }

        public MenuItem CurrentItem
        {
            // propertie for m_CurrentItem
            get
            {
                return m_CurrentItem;
            }

            set
            {
                m_CurrentItem = value;
            }
        }

        public void AddItem(MenuItem i_NewItem)
        {
            // this method get a MenuItem to add and adding it to the MainMenu.
            int numOfChildren;

            numOfChildren = (i_NewItem.Parent as Inner).Children.Count;
            (i_NewItem.Parent as Inner).Children.Add(numOfChildren + 1, i_NewItem);
        }

        public void Show()
        {
            // this method is showing the menu that the user made
            int userChoice;
            bool continueMenu = true;
            string message;

            message = string.Format("Please enter a number of an option from the menu below: {0}", Environment.NewLine);
            while (continueMenu)
            {
                Console.Clear();
                Console.WriteLine(message);
                m_CurrentItem.Print();
                userChoice = getUserInput();
                continueMenu = handleInput(userChoice);
            }
        }

        private int getUserInput()
        {
            // this method get the user's choice input
            bool isUserChoiceValid;
            string userChoice, message;
            int userChoiceInt;

            userChoice = Console.ReadLine();
            isUserChoiceValid = isValidInput(userChoice);
            message = string.Format("Invalid input, please enter a number of an option from the menu below: {0}", Environment.NewLine);
            while (!isUserChoiceValid)
            {
                Console.Clear();
                Console.WriteLine(message);
                m_CurrentItem.Print();
                userChoice = Console.ReadLine();
                isUserChoiceValid = isValidInput(userChoice);
            }

            // at this moment we know that the parse will success.
            userChoiceInt = int.Parse(userChoice);

            return userChoiceInt;
        }

        private bool isValidInput(string i_UserChoice)
        {
            // this method get a string represents the user choice and return true if its valid
            bool isValid;
            int userChoiceInt;

            isValid = int.TryParse(i_UserChoice, out userChoiceInt) && isChoiceInRange(userChoiceInt);

            return isValid;
        }

        private bool isChoiceInRange(int i_UserChoiceInt)
        {
            // this method get a number represents the user choice and return true if the number is in range(of menuItem indices)
            bool isChoiceInRange;

            isChoiceInRange = i_UserChoiceInt >= 0 && i_UserChoiceInt <= (m_CurrentItem as Inner).Children.Count;

            return isChoiceInRange;
        }

        private bool handleInput(int i_UserChoice)
        {
            // this method get a number represents user choice and handling the input, return true if loop should keep going(user didnt chose Exit).
            // At this stage the input is already validated.
            bool continueMenu = true;

            if(i_UserChoice == 0 && m_CurrentItem.Level == 0)
            {
                continueMenu = false;
            }
            else if(i_UserChoice == 0 && m_CurrentItem.Level != 0)
            {
                m_CurrentItem = m_CurrentItem.Parent;
            }
            else if((m_CurrentItem as Inner).Children[i_UserChoice] is Leaf)
            {
                ((m_CurrentItem as Inner).Children[i_UserChoice] as Leaf).OnClickObserver();
            }
            else
            {
                // current item is inner
                m_CurrentItem = (m_CurrentItem as Inner).Children[i_UserChoice];
            }

            return continueMenu;
        }
    }
}
