using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowVersion : IClickObserver
    {
        public void OnClickObserver()
        {
            Console.WriteLine("Version: 19.2.4.32");
        }
    }
}
