using System;
using System.Collections.Generic;
using System.Text;

namespace IndexersDemo
{
    public class AnonymousMethods
    {

        public delegate string GreetingsDelegate(string name);
        public static void Main()
        {
            GreetingsDelegate gDel = delegate (string name)
            {
                return "Hello " + name;
            };

            Console.WriteLine(gDel("Bhuvanesh"));
        }
    }
}
