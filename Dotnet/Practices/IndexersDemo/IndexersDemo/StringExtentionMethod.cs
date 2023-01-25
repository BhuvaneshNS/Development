using System;
using System.Collections.Generic;
using System.Text;

namespace IndexersDemo
{
    public static class StringExtentionMethod
    {
        public static string ChangeFirstLetterCase(this string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
            {
                return inputString;
            }
             char[] chars = inputString.ToCharArray();

            chars[0]= char.IsUpper(chars[0])?char.ToLower(chars[0]):char.ToUpper(chars[0]);
            return new string(chars);
        }


        public class MainClass
        {
            public static void Main()
            {
                string name = "bhuvanesh";

                Console.WriteLine(name.ChangeFirstLetterCase());
            }
        }
    }
}
