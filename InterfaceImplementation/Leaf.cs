using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class Leaf : MenuItem
    {
        private IClickObserver m_ClickObserver;

        public Leaf(string i_Title, Inner i_Parent, IClickObserver i_ClickObserver)
        {
            m_Title = i_Title;
            m_Parent = i_Parent;
            m_ClickObserver = i_ClickObserver;
        }

        public IClickObserver ClickObserver
        {
            get
            {
                return m_ClickObserver;
            }

            set
            {
                m_ClickObserver = value;
            }
        }
        public override void Print()
        {
            string backOrExit, backOrExitStringFormat;

            printLevel();
            printTitle();
            Console.WriteLine();
            backOrExit = m_Level == 0 ? "Exit" : "Back";
            backOrExitStringFormat = string.Format("0. {0}", backOrExit);
            Console.WriteLine(backOrExitStringFormat);
        }

        public void OnClickObserver()
        {
            Console.Clear();
            m_ClickObserver.OnClickObserver();
            holdScreen();
        }

        private void holdScreen()
        {
            Console.WriteLine("Press any key to go back to menu...");
            Console.ReadKey();
        }
    }
}
