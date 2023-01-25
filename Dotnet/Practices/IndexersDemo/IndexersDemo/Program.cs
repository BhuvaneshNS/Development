using System;

namespace IndexersDemo
{
    internal class Employee
    {
        int _id;
        string _name;

        public Employee(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public object this[int index]
        {
            get
            {
                if(index == 0)
                {
                    return _id;
                }
                else if(index == 1)
                {
                    return _name;
                }
                else
                {
                    return null;    
                }
            }

            set
            {
                if (index == 1)
                {
                    _name =(string) value;
                }
            }
        }
        
        public object this[string name]
        {
            get
            {
                if(name.ToLower() == "id")
                {
                    return _id;
                }
                else if(name.ToLower() == "name")
                {
                    return _name;
                }
                else
                {
                    return null;    
                }
            }

            set
            {
                if (name.ToLower() == "name")
                {
                    _name =(string) value;
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee(100,"Bhuvanesh");            
            Console.WriteLine("Employee Id: {0} and Name: {1}", employee[0], employee[1]);
            employee[1] = "Shadakshari";
            Console.WriteLine("Employee Id: {0} and Name: {1}", employee[0], employee[1]); 

            employee["name"] = "Savitha";
            Console.WriteLine("Employee Id: {0} and Name: {1}", employee["id"], employee["name"]);
        }
    }
}
