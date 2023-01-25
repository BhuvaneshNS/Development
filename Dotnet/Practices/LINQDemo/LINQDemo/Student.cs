using System.Collections.Generic;

namespace LINQDemo
{
    internal class Student
    {

        public string Name { get; set; }
        public string Gender { get; set; }
        public List<string> Subjects { get; set; }
        public int StudentId { get; set; }
        public int TotalMarks { get; set; }

        internal static List<Student> GetStudents()
        {
            return new List<Student>()
            {
                new Student()
                {
                    Name="A",
                    Gender="Male",
                    Subjects= new List<string>(){"ASP.NET", "C#" },
                    StudentId=101,
                    TotalMarks=110
                },
                new Student()
                {
                    Name="B",
                    Gender="Female",
                    Subjects= new List<string>(){ "ADO.NET", "C#", "AJAX" },
                    StudentId=102,
                    TotalMarks=120
                },
                new Student()
                {
                    Name="C",
                    Gender="Female",
                    Subjects= new List<string>(){ "WCF", "SQL Server", "C#" },
                    StudentId=103,
                    TotalMarks=130
                },
                new Student()
                {
                    Name="D",
                    Gender="Male",
                    Subjects= new List<string>(){ "WPF", "LINQ", "ASP.NET" },
                    StudentId=104,
                    TotalMarks=140
                },
                new Student()
                {
                    Name="E",
                    Gender="Female",
                    Subjects= new List<string>(){ "ADO.NET", "C#", "AJAX" },
                    StudentId=105,
                    TotalMarks=150
                },
                new Student()
                {
                    Name="F",
                    Gender="Female",
                    Subjects= new List<string>(){ "WCF", "SQL Server", "C#" },
                    StudentId=106,
                    TotalMarks=160
                },
                new Student()
                {
                    Name="G",
                    Gender="Male",
                    Subjects= new List<string>(){ "WPF", "LINQ", "ASP.NET" },
                    StudentId=107,
                    TotalMarks=170
                }, new Student()
                {
                    Name="H",
                    Gender="Male",
                    Subjects= new List<string>(){ "WPF", "LINQ", "ASP.NET" },
                    StudentId=108,
                    TotalMarks=180
                },
                new Student()
                {
                    Name="I",
                    Gender="Female",
                    Subjects= new List<string>(){ "ADO.NET", "C#", "AJAX" },
                    StudentId=109,
                    TotalMarks=190
                },
                new Student()
                {
                    Name="J",
                    Gender="Female",
                    Subjects= new List<string>(){ "WCF", "SQL Server", "C#" },
                    StudentId=110,
                    TotalMarks=200
                },
                new Student()
                {
                    Name="K",
                    Gender="Male",
                    Subjects= new List<string>(){ "WPF", "LINQ", "ASP.NET" },
                    StudentId=111,
                    TotalMarks=210
                }
            };
        }
    }
}
