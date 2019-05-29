using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class Leaf : MenuItem
    {
        public event Action<string> m_ReportClickDelegates;

        public Leaf(string i_Title, Inner i_Parent)
        {
            m_Title = i_Title;
            m_Parent = i_Parent;
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
            m_ReportClickDelegates.Invoke("TODO");
            holdScreen();
        }

        private void holdScreen()
        {
            Console.WriteLine("Press any key to go back to menu...");
            Console.ReadKey();
        }
    }
}
