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

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Id}  {student.Name}  {student.Age}  {student.Marks} {student.Grade}");
            }


            var studentCourseDetails = students.Join(enrollments,
                                       student => student.Id,
                                       enrollment => enrollment.StudentId,
                                       (student, enrollment) => new { student.Name, enrollment.CourseId }).Join(courses,
                                                      result => result.CourseId,
                                                      course => course.CourseId,
                                                      (result, course) => new
                                                      {
                                                        result.Name,
                                                        course.CourseName,
                                                        course.Instructor
                                                      });

            Console.WriteLine("Student-Course Details:");
            foreach (var detail in studentCourseDetails)
            {
                Console.WriteLine($"{detail.Name} is enrolled in {detail.CourseName} (Instructor: {detail.Instructor})");
            }


        }
    }
}
