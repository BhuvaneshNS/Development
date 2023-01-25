using PracticeProject;
using System;

class Program
{
    static void Main()
    {
        //BuiltinTypes.Execute();
        //Arrays.Execute();

        int j = 0;
        Test t = new Test();

        Console.WriteLine(t.i);
        Console.WriteLine("j={0}", j);
    }
}

class Test
{
    public int i;
}