using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject
{
    internal class BuiltinTypes
    {
        public static void Execute()
        {
            byte Bite = 0;
            sbyte SBite = -20;
            short Short = 0;
            ushort UShort = 0;
            long Long = 0;
            Nullable<int> i;
            int? ii = 0;

            float Float = 100f;

            string num = "100";
            int number = Convert.ToInt32(num);

            Console.WriteLine(typeof(double));
            Console.WriteLine("Min of int {0}", byte.MinValue);
            Console.WriteLine(number);
        }
    }
}
