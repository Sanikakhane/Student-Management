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
                new Enrollment(5, 102),
                new Enrollment(6, 103),
                new Enrollment(7, 102),
                new Enrollment(8, 103),

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


            StudentFilter sf = new StudentFilter(students);
            var studentsByCourse = sf.GetStudentsByCourse("History",enrollments,courses);
            foreach (var student in studentsByCourse)
            {
                Console.WriteLine($"{student.Name}");
            }

            var studentGroupByCourse = sf.GroupStudentsByCourses(enrollments, courses);
            foreach(var course in studentGroupByCourse)
            {
                Console.WriteLine("Course Name :- "+course.Key);
                foreach(var student in course.Value)
                {
                    Console.WriteLine($"{student.Name}  {student.Marks}");
                }
            }

            var courseTopper = sf.GetTopScorersByCourse("History", 1, enrollments, courses);
            foreach( var student in courseTopper)
            {
                Console.WriteLine($"Topper is {student.Name}");
            }


        }
    }
}
