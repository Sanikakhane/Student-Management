using System;
using System.Collections.Generic;

namespace StudentManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var students = JsonHelper.LoadJsonData<Student>("C:\\Users\\Khan_San\\source\\repos\\Student-Management\\data\\students.json");
            var courses = JsonHelper.LoadJsonData<Course>("C:\\Users\\Khan_San\\source\\repos\\Student-Management\\data\\courses.json");
            var enrollments = new List<Enrollment>
            {
                new Enrollment(1, 101),
                new Enrollment(2, 102),
                new Enrollment(3, 103),
                new Enrollment(4, 101),
                new Enrollment(5, 102)
            };

            foreach(var student in students)
            {
                Console.WriteLine($"{student.Id}  {student.Name}  {student.Age}  {student.Marks} {student.Grade}");
            }


        }
    }
}
