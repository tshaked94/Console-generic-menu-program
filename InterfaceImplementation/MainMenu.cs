using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        List<MenuItem> m_AllMenuItems;
        MenuItem m_CurrentItem = new Inner("Main Menu", null);

        public MainMenu()
        {
            m_CurrentItem.Level = 0;
        }

        public MenuItem CurrentItem
        {
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
            int numOfChildren;

            numOfChildren = (i_NewItem.Parent as Inner).Children.Count;
            (i_NewItem.Parent as Inner).Children.Add(numOfChildren + 1, i_NewItem);
        }

        public void Show()
        {
            int userChoice;
            bool continueMenu = true;

            while (continueMenu)
            {
                Console.Clear();
                m_CurrentItem.Print();
                userChoice = getUserInput();
                continueMenu = handleInput(userChoice);
            }
        }

        private int getUserInput()
        {
            bool isUserChoiceValid;
            string userChoice;
            int userChoiceInt;

            Console.WriteLine("Please enter the menu item's index number");
            userChoice = Console.ReadLine();
            isUserChoiceValid = isValidInput(userChoice);
            while (!isUserChoiceValid)
            {
                Console.Clear();
                Console.WriteLine("Invalid input, please enter a valid index of menu item");
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
            bool isValid;
            int userChoiceInt;

            isValid = int.TryParse(i_UserChoice, out userChoiceInt) && isChoiceInRange(userChoiceInt);

            return isValid;
        }

        private bool isChoiceInRange(int i_UserChoiceInt)
        {
            bool isChoiceInRange;

            isChoiceInRange = i_UserChoiceInt >= 0 && i_UserChoiceInt <= (m_CurrentItem as Inner).Children.Count;

            return isChoiceInRange;
        }

        private bool handleInput(int i_UserChoice)
        {
            // the input is already validated, if userChoice is inner change current menu item.
            // if userChoice is a leaf, invoke OnClick() (DON'T change currentMenuItem)
            bool continueMenu = true;

            if(i_UserChoice == 0 && m_CurrentItem.Level ==0)
            {
                continueMenu = false;
            }
            else if(i_UserChoice == 0 && m_CurrentItem.Level != 0)
            {
                m_CurrentItem = m_CurrentItem.Parent;
            }
            else if((m_CurrentItem as Inner).Children[i_UserChoice] is Leaf)
            {
                (((m_CurrentItem as Inner).Children[i_UserChoice])as Leaf).OnClickObserver();
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
