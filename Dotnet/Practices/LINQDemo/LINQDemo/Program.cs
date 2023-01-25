using LINQDemo.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LINQDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //IEnumerable<int> ints = new List<int>() { 1, 2, 3, 4, 5, 6 };
            //System.Console.WriteLine(ints.ElementAt(1));

            //int? result = null;

            //foreach (int number in numbers)
            //{
            //    if (!result.HasValue || number < result)
            //    {
            //        result = number;
            //    }
            //}

            //result = numbers.Aggregate((a, b) => a + b);
            //result = numbers.Aggregate((a, b) => a * b);
            ////result = numbers.Min();

            //Console.WriteLine(result);


            //Select operator


            //IEnumerable<int> employeeIds = Employee.GetEmployees().Select(employee => employee.EmployeeID);

            //foreach (int employeeId in employeeIds)
            //{
            //    System.Console.WriteLine(employeeId);
            //}

            //System.Console.WriteLine(Employee.GetEmployees().Where(employee => employee.FirstName == "Bhuvanesh").ElementAt(1));

            //var result = Employee.GetEmployees().Where(employee => employee.AnnualSalary > 3000).Select(employee => new { Name = employee.FirstName, AnnualSalary = employee.AnnualSalary, Bonus = employee.AnnualSalary * 0.1 });

            //foreach (var emp in result)
            //{
            //    System.Console.WriteLine(emp.Name + " - " + emp.AnnualSalary + " - " + emp.Bonus);
            //}

            //IEnumerable<string> subjects = Student.GetStudents().SelectMany(s => s.Subjects).Distinct();
            //IEnumerable<string> subjects = (from student in Student.GetStudents()
            //                                from subject in student.Subjects
            //                                select subject).Distinct();

            //var result = Student.GetStudents().SelectMany(s => s.Subjects, (student, subject) => new { Name = student.Name, Subject = subject });

            //var result = from student in Student.GetStudents()
            //             from subject in student.Subjects
            //             select new { Name = student.Name, Subject = subject };

            //foreach (var v in result)
            //{
            //    System.Console.WriteLine(v.Name + " - " + v.Subject);
            //}            //var result = from student in Student.GetStudents()
            //             from subject in student.Subjects
            //             select new { Name = student.Name, Subject = subject };

            //foreach (var v in result)
            //{
            //    System.Console.WriteLine(v.Name + " - " + v.Subject);
            //}

            //string[] strings = new string[]
            //{
            //    "Bhuvanesh",
            //    "9482269833"
            //};
            //IEnumerable<char> chars = strings.SelectMany(s => s);
            //IEnumerable<char> chars = from str in strings
            //                          from c in str
            //                          select c;

            //foreach (char c in chars) { Console.WriteLine(c); }



            //foreach (Student student in Student.GetStudents())
            //{
            //    foreach (string subject in student.Subjects)
            //    {
            //        Console.WriteLine(subject);
            //    }
            //}

            //IEnumerable<List<string>> subjectList = Student.GetStudents().Select(s => s.Subjects);

            //foreach (List<string> subjects in subjectList)
            //{
            //    foreach (string subject in subjects)
            //    {
            //        Console.WriteLine(subject);
            //    }
            //}

            //Console.WriteLine("Student Names before sorting");

            //List<Student> students = Student.GetStudents();

            //foreach (Student student in students)
            //{
            //    Console.WriteLine(student.Name);
            //}

            //Console.WriteLine("Student names after sorting");
            ////Student.GetStudents().OrderBy(x => x.Name).ToList().ForEach(x => Console.WriteLine(x.Name));
            ////Console.WriteLine();
            //IEnumerable<Student> sortedStudents = Student.GetStudents().OrderByDescending(student => student.Name);
            ////IEnumerable<Student> sortedStudents = from student in Student.GetStudents()
            ////                                      orderby student.Name descending
            ////                                      select student;
            //foreach (Student student in sortedStudents)
            //{
            //    Console.WriteLine(student.Name);
            //}
            //}


            //IEnumerable<Student> students = from s in Student.GetStudents()
            //                                orderby s.TotalMarks ascending, s.Name, s.StudentId descending
            //                                select s;
            ////IEnumerable<Student> students = Student.GetStudents().OrderBy(s => s.TotalMarks).ThenBy(s => s.Name).ThenByDescending(s => s.StudentId);

            //foreach (Student student in students)
            //{
            //    Console.WriteLine(student.StudentId + "\t" + student.Name + "\t" + student.TotalMarks);
            //}


            //Console.WriteLine("Students before reversing");

            //IEnumerable<Student> students = Student.GetStudents();
            //foreach (Student student in students)
            //{
            //    Console.WriteLine(student.StudentId + "\t" + student.Name + "\t" + student.TotalMarks);
            //}
            //Console.WriteLine("Students After reversing");

            //IEnumerable<Student> studentsReversed = ((IEnumerable<Student>)Student.GetStudents()).Reverse();
            //foreach (Student student in studentsReversed)
            //{
            //    Console.WriteLine(student.StudentId + "\t" + student.Name + "\t" + student.TotalMarks);
            //}



            //List<string> countries = new List<string> { "India", "USA", "Japan", "Nepal", "Bhuthan" };
            //string[] countriesArray = (from country in countries
            //                           orderby country
            //                           select country).ToArray();
            ////string[] countriesArray = countries.OrderByDescending(c => c).ToArray();

            //foreach (string country in countriesArray)
            //{
            //    Console.WriteLine(country);
            //}


            //IEnumerable<string> result = countries.Take(3);
            //IEnumerable<string> result = (from country in countries
            //                              select country).Take(3); 

            //IEnumerable<string> result = countries.Skip(3);
            //IEnumerable<string> result = (from country in countries
            //                              select country).Skip(3);


            //IEnumerable<string> result = countries.TakeWhile(c => c.Length > 3);
            //foreach (string country in result)
            //{
            //    Console.WriteLine(country);
            //}



            //do
            //{
            //    IEnumerable<Student> students = Student.GetStudents();
            //    int pageNumber = 0;
            //    Console.WriteLine("Enter page number to display");

            //    if (int.TryParse(Console.ReadLine(), out pageNumber) && pageNumber > 0 && pageNumber < 5)
            //    {
            //        int pageSize = 3;
            //        IEnumerable<Student> filteredStudent = students.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            //        Console.WriteLine("\n\nDisplaying page {0}\n", pageNumber);
            //        Console.WriteLine("ID\tName\tTotal Marks");
            //        foreach (Student student in filteredStudent)
            //        {
            //            Console.WriteLine(student.StudentId + "\t" + student.Name + "\t" + student.TotalMarks);
            //        }
            //        Console.WriteLine("\n");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Enter page number between 1 to 4\n");
            //    }

            //} while (true);


            //List<Student> students = new List<Student>() {
            //    new Student()
            //    {
            //        StudentId = 1,
            //        Name="Bhuvanesh",
            //        TotalMarks=100
            //    },
            //    new Student()
            //    {
            //        StudentId = 2,
            //        Name="Shalini",
            //        TotalMarks=200
            //    },
            //    new Student()
            //    {
            //        StudentId = 3,
            //        Name="Savitha",
            //        TotalMarks=200
            //    },
            //};

            //Student[] res = students.ToArray();

            //IEnumerable<Student> requiredStudents = students.Where(s => s.TotalMarks >= 200).ToList();

            //students.Add(new Student()
            //{
            //    StudentId = 4,
            //    Name = "Shashi",
            //    TotalMarks = 200
            //});

            //foreach (Student student in res)
            //{
            //    Console.WriteLine(student.StudentId + "\t" + student.Name + "\t\t" + student.TotalMarks);
            //}

            //Dictionary<int, string> studentDictionary = Student.GetStudents().ToDictionary(x => x.StudentId, x => x.Name);

            //foreach (KeyValuePair<int, string> studentKeyValuePair in studentDictionary)
            //{
            //    Console.WriteLine(studentKeyValuePair.Key + "\t" + studentKeyValuePair.Value);
            //}
            //Dictionary<int, Student> studentDictionary = Student.GetStudents().ToDictionary(x => x.StudentId);

            //foreach (KeyValuePair<int, Student> studentKeyValuePair in studentDictionary)
            //{
            //    Console.WriteLine(studentKeyValuePair.Key + "\t" + studentKeyValuePair.Value.Name + "\t" + studentKeyValuePair.Value.TotalMarks);
            //}


            //ILookup<string, Student> studentByGender = Student.GetStudents().ToLookup(s => s.Gender);

            //foreach (IGrouping<string, Student> student in studentByGender)
            //{
            //    Console.WriteLine(student.Key);
            //    foreach (Student groupedStudent in studentByGender[student.Key])
            //    {
            //        Console.WriteLine("\t" + groupedStudent.Name);
            //    }
            //}

            //IEnumerable<TestClass> testClasses = Student.GetStudents().Select(s => new TestClass() { ID = s.StudentId, Name = s.Name });

            //foreach (TestClass testClass in testClasses)
            //{
            //    Console.WriteLine(testClass.ID + "\t" + testClass.Name);
            //}


            //ArrayList numbers = new ArrayList();

            //numbers.Add(1);
            //numbers.Add(2);
            //numbers.Add(3);
            //numbers.Add("4");
            //numbers.Add("Bhuva");

            //IEnumerable<int> numsList = numbers.OfType<int>();
            ////IEnumerable<int> numsList = numbers.Cast<int>();
            //foreach (int num in numsList)
            //{
            //    Console.WriteLine(num);
            //}

            //EmployeeContext employeeContext = new EmployeeContext();

            //var employeeGrpups = employeeContext.Employees.AsEnumerable().GroupBy(e => e.Department);
            //var employeeGrpups = from employee in employeeContext.Employees
            //                     group employee by employee.Department;

            //foreach (var employeeGroup in employeeGrpups)
            //{
            //    Console.WriteLine(employeeGroup.Key + "   -   " + employeeGroup.Count());

            //    foreach (var emp in employeeGroup)
            //    {
            //        Console.WriteLine(emp.Name);
            //    }
            //}

            //using (EmployeeContext context = new EmployeeContext())
            //{
            //    var employeeGroups = context.Employees
            //                                .AsEnumerable()
            //                                .GroupBy(e => new { e.Department, e.Gender })
            //                                .OrderBy(g => g.Key.Department)
            //                                .ThenBy(g => g.Key.Gender)
            //                                .Select(g => new
            //                                {
            //                                    Department = g.Key.Department,
            //                                    Gender = g.Key.Gender,
            //                                    Employees = g.OrderBy(e => e.Name)

            //                                }
            //                                );

            //    foreach (var group in employeeGroups)
            //    {
            //        Console.WriteLine("{0} department {1} employees count-{2}", group.Department, group.Gender, group.Employees.Count());
            //        Console.WriteLine("---------------------------------------------------");

            //        foreach (var emp in group.Employees)
            //        {
            //            Console.WriteLine("{0}\t{1}\t{2}", emp.Name, emp.Gender, emp.Department);
            //        }
            //        Console.WriteLine();
            //    }

            //};


            //List<int> numbers = new List<int>() { 1 };
            //int result = numbers.ElementAtOrDefault(1);
            //Console.WriteLine(result);



            //var empByDepartment = Department.GetAllDepartments()
            //                                .GroupJoin(Employee.GetAllEmployees(),
            //                                d => d.ID,
            //                                e => e.DepartmentID,
            //                                (department, employees) => new
            //                                {
            //                                    Department = department,
            //                                    Employees = employees
            //                                }
            //                                );

            //var empByDepartment = from d in Department.GetAllDepartments()
            //                      join e in Employee.GetAllEmployees()
            //                      on d.ID equals e.DepartmentID into eGroup
            //                      select new
            //                      {
            //                          Department = d,
            //                          Employees = eGroup
            //                      };

            //foreach (var department in empByDepartment)
            //{
            //    Console.WriteLine(department.Department.Name);
            //    foreach (var employee in department.Employees)
            //    {
            //        Console.WriteLine("     {0}", employee.Name);
            //    }
            //    Console.WriteLine();
            //}


            var employeeByDepartment = Employee.GetAllEmployees()
                                                .Join(Department.GetAllDepartments(),
                                                e => e.DepartmentID,
                                                d => d.ID,
                                                (emp, dept) => new
                                                {
                                                    Dept = dept,
                                                    Emps = emp
                                                }
                                                );

            foreach (var department in employeeByDepartment)
            {
                Console.WriteLine(department.Dept.Name + " " + department.Emps.Name);

            }
        }

        //public class TestClass
        //{
        //    public int ID { get; set; }
        //    public string Name { get; set; }
        //}
    }
}
