using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class InterfaceTest
    {
        private MainMenu m_MainMenu = new MainMenu();

        public void Show()
        {
            m_MainMenu.Show();
        }

        public InterfaceTest()
        {
            ShowDate showDateObject = new ShowDate();
            ShowTime showTimeObject = new ShowTime();
            ShowVersion showVersionObject = new ShowVersion();
            CountDigits countDigitsObject = new CountDigits();
            Inner showDateTimeItem = new Inner(@"Show Date/Time", m_MainMenu.CurrentItem);
            Leaf ShowDateItem = new Leaf("Show Date", showDateTimeItem, showDateObject as IClickObserver);
            Leaf ShowTimeItem = new Leaf("Show Time", showDateTimeItem, showTimeObject as IClickObserver);
            Inner VersionAndDigitsItem = new Inner("Version and Digits", m_MainMenu.CurrentItem);
            Leaf CountDigitsItem = new Leaf("Count Digits", VersionAndDigitsItem, countDigitsObject as IClickObserver);
            Leaf ShowVersionItem = new Leaf("Show Version", VersionAndDigitsItem, showVersionObject as IClickObserver);

            m_MainMenu.AddItem(showDateTimeItem);
            m_MainMenu.AddItem(ShowDateItem);
            m_MainMenu.AddItem(ShowTimeItem);
            m_MainMenu.AddItem(VersionAndDigitsItem);
            m_MainMenu.AddItem(CountDigitsItem);
            m_MainMenu.AddItem(ShowVersionItem);
        }
    }
}
