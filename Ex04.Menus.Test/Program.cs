using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test
{
    class Program
    {
        public static void Main(string[] args)
        {
            InterfaceTest interfaceTest = new InterfaceTest();
            DelegatesTest delegatesTest = new DelegatesTest();

            interfaceTest.Show();
            delegatesTest.Show();
        }
    }
}
