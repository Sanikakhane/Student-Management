using System;
using System.Collections.Generic;
using StudentManagementSystem.Models;
using StudentManagementSystem.Services;

namespace StudentManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var students = JsonHelper.LoadJsonData<Student>("C:\\Users\\Khan_San\\source\\repos\\Student-Management\\Data\\students.json");
                var courses = JsonHelper.LoadJsonData<Course>("C:\\Users\\Khan_San\\source\\repos\\Student-Management\\Data\\courses.json");

                var enrollments = new List<Enrollment>
                {
                    new Enrollment(1, 101),
                    new Enrollment(2, 102),
                    new Enrollment(3, 103),
                    new Enrollment(4, 101),
                    new Enrollment(5, 102),
                };
                var studentFilter = new StudentFilter(students);

                try
                {
                    Console.WriteLine("Students enrolled in 'History':");
                    var studentsByCourse = studentFilter.GetStudentsByCourse("History", enrollments, courses);
                    foreach (var student in studentsByCourse)
                    {
                        Console.WriteLine($"{student.Name}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in fetching students by course: {ex.Message}");
                }

                try
                {
                    Console.WriteLine("\nGrouped Students by Courses:");
                    var studentGroupByCourse = studentFilter.GroupStudentsByCourses(enrollments, courses);
                    foreach (var course in studentGroupByCourse)
                    {
                        Console.WriteLine($"Course: {course.Key}");
                        foreach (var student in course.Value)
                        {
                            Console.WriteLine($"  - {student.Name} ({student.Marks} marks)");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in grouping students by courses: {ex.Message}");
                }

                try
                {
                    Console.WriteLine("\nTop Scorer in 'History':");
                    var topScorers = studentFilter.GetTopScorersByCourse("History", 1, enrollments, courses);
                    foreach (var student in topScorers)
                    {
                        Console.WriteLine($"{student.Name}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in fetching top scorer: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Critical error: {ex.Message}");
            }
        }
    }
}
