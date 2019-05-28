using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public abstract class MenuItem
    {
        protected string m_Title;
        protected int m_Level;
        protected MenuItem m_Parent;

        public MenuItem Parent
        {
            // a propertie for m_Parent
            get
            {

                return m_Parent;
            }

            set
            {
                m_Parent = value;
            }
        }

        public int Level
        {
            // a propertie for m_Level
            get
            {

                return m_Level;
            }

            set
            {
                m_Level = value;
            }
        }

        public string Title
        {
            // a propertie for m_Title
            get
            {

                return m_Title;
            }

            set
            {
                m_Title = value;
            }
        }

        public abstract void Print();

        public void printTitle()
        {
            Console.WriteLine(Title);
        }

        public void printLevel()
        {
            string levelString;

            levelString = string.Format("{0} ", m_Level);
            Console.Write(levelString);
        }
    }
}
