using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class Inner : MenuItem
    {
        private Dictionary<int, MenuItem> m_Children = new Dictionary<int, MenuItem>();

        public Inner(string i_Title, MenuItem i_Parent)
        {
            m_Title = i_Title;
            m_Parent = i_Parent; 
            m_Level = m_Parent == null ? 0 : m_Parent.Level + 1;
        }
        public Dictionary<int, MenuItem> Children
        {
            get
            {

                return m_Children;
            }

            set
            {
                m_Children = value;
            }
        }

        public override void Print()
        {
            int childrenIndex = 0;
            string childrenIndexFormat;
            string backOrExit, backOrExitStringFormat;
            
            printLevel();
            printTitle();
            Console.WriteLine();
            backOrExit = m_Level == 0 ? "Exit" : "Back";
            backOrExitStringFormat = string.Format("0. {0}", backOrExit);
            Console.WriteLine(backOrExitStringFormat);
            foreach (KeyValuePair<int, MenuItem> children in m_Children)
            {
                childrenIndex++;
                childrenIndexFormat = string.Format("{0}. ", childrenIndex);
                Console.Write(childrenIndexFormat);
                children.Value.printTitle();
            }
        }
    }
}
