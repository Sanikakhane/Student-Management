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
                var students = JsonHelper.LoadJsonData<Student>(GlobalPath.studentDataPath);
                var courses = JsonHelper.LoadJsonData<Course>(GlobalPath.courseDataPath);

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

                CourseManager courseManager = new CourseManager(courses, enrollments);
                try
                {
                   
                    courseManager.AddCourse(104, "Science", "Dr. Smith");

                    courseManager.UpdateCourse(101, "Marathi", "Prof. Johnson");

                    courseManager.DeleteCourse(101);
                    var course = courseManager.GetCourseById(101);
                    if (course != null)
                    {
                        Console.WriteLine($"Course: {course.CourseName}, Instructor: {course.Instructor}");
                    }
                    var allCourses = courseManager.GetAllCourses();
                    Console.WriteLine($"Total Courses: {allCourses.Count}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                }

                StudentManager studentManager = new StudentManager(students);
                try
                {
                    studentManager.AddStudent(5, "Sanu", 21, 98, "A");



                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error : {ex.Message}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Critical error: {ex.Message}");
            }
        }
    }
}
