using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DataSerializerApp
{
    [Serializable]
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { set; get; }
        public long MobileNumber { set; get; }

        public Person() : this(null, 0, 0)
        {
        }

        public Person(string name, int age, long mobileNumber)
        {
            Name = name;
            Age = age;
            MobileNumber = mobileNumber;
        }



        public static void Display(List<Person> people)
        {
            if (people != null && people.Count > 0)
            {
                foreach (Person person in people)
                {
                    Console.WriteLine("[ {0}, {1}, {2} ]", person.Name, person.Age, person.MobileNumber);
                }
            }
            else
            {
                Console.WriteLine("Nothing display");
            }
            Console.WriteLine();
        }
        //Implementation of IComparable compateto method
        public int CompareTo(Person other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }

    public class SortByAge : IComparer<Person>
    {
        public int Compare([AllowNull] Person x, [AllowNull] Person y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }
}