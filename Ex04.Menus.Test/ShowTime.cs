using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowTime : IClickObserver
    {
        public void OnClickObserver()
        {
            string currentTime;

            currentTime = DateTime.Now.ToString("HH:mm:ss");
            Console.WriteLine(currentTime);
        }
    }
}
