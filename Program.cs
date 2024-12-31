using System;
using System.Collections.Generic;

namespace StudentManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            

            var students = new List<Student>
            {
                new Student(1, "Sanika",20,85,"A"),
                new Student(2, "Alice",20,75,"C"),
                new Student(3, "Xyz",21,96,"B"),
                new Student(4, "Bob",20,97,"A"),
                new Student(5, "abcd",21,80,"C")

            };


            StudentSorter ss = new StudentSorter(students);
            var result = new List<Student>();
            result = ss.SortByMarks();

            var studentsSortedByName = new List<Student>();
            studentsSortedByName = ss.SortByName();

            StudentFilter sf = new StudentFilter(students);
            result = sf.GetStudentsByGrade("A");

            result=sf.GetToppers(3);



            foreach (var item in result)
            {
                Console.WriteLine(item.Name+ " "+item.Marks+" "+item.Grade);
            }


        }
    }
}
