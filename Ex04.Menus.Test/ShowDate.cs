using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowDate : IClickObserver
    {
        public void OnClickObserver()
        {
            string currentDate;

            currentDate = DateTime.Now.ToString("MM/dd/yyyy");
            Console.WriteLine(currentDate);
        }
    }
}
