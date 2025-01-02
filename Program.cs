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
                    new Enrollment(6, 101),
                    new Enrollment(7, 103),
                    new Enrollment(8, 104),
                    new Enrollment(9, 104),

                };
                var studentFilter = new StudentFilter(students);
                var courseManager = new CourseManager(courses, enrollments);
                var studentManager = new StudentManager(students);


                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. View Students by Course");
                Console.WriteLine("2. Group Students by Courses");
                Console.WriteLine("3. View Top Scorer by Course");
                Console.WriteLine("4. Add, Update or Delete Course");
                Console.WriteLine("5. Add, Update or Delete Student");
                Console.WriteLine("6. Exit");

                while (true)
                {
                    Console.WriteLine("Enter choice");
                    var choice = Console.ReadLine();

                    switch (choice)
                    {

                        case "1":
                            Console.Write("Enter Course Name: ");
                            var courseName = Console.ReadLine();
                            try
                            {
                                var studentsByCourse = studentFilter.GetStudentsByCourse(courseName, enrollments, courses);
                                foreach (var student in studentsByCourse)
                                {
                                    Console.WriteLine($"{student.Name}");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;
                        case "2":
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
                            break;
                        case "3":
                            try
                            {
                                Console.WriteLine("Enter the course name");
                                var topCourse = Console.ReadLine();
                                Console.WriteLine("Enter the count");
                                var count = int.Parse(Console.ReadLine());
                                Console.WriteLine($"\nTop Scorer in {topCourse}:");
                                var topScorers = studentFilter.GetTopScorersByCourse(topCourse, count, enrollments, courses);
                                foreach (var student in topScorers)
                                {
                                    Console.WriteLine($"{student.Name}");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error in fetching top scorer: {ex.Message}");
                            }
                            break;
                        case "4":
                            courseManager = new CourseManager(courses, enrollments);
                            Console.WriteLine("Enter action: Add, Update, Delete");
                            var courseAction = Console.ReadLine();
                            switch (courseAction.ToLower())
                            {
                                case "add":
                                    Console.Write("Enter Course ID: ");
                                    var courseId = int.Parse(Console.ReadLine());
                                    Console.Write("Enter Course Name: ");
                                    var courseNameToAdd = Console.ReadLine();
                                    Console.Write("Enter Instructor Name: ");
                                    var instructorName = Console.ReadLine();
                                    courseManager.AddCourse(courseId, courseNameToAdd, instructorName);
                                    break;
                                case "update":
                                    Console.Write("Enter Course ID to update: ");
                                    var updateCourseId = int.Parse(Console.ReadLine());
                                    Console.Write("Enter New Course Name: ");
                                    var updateCourseName = Console.ReadLine();
                                    Console.Write("Enter New Instructor Name: ");
                                    var updateInstructor = Console.ReadLine();
                                    courseManager.UpdateCourse(updateCourseId, updateCourseName, updateInstructor);
                                    break;
                                case "delete":
                                    Console.Write("Enter Course ID to delete: ");
                                    var deleteCourseId = int.Parse(Console.ReadLine());
                                    courseManager.DeleteCourse(deleteCourseId);
                                    break;
                                default:
                                    Console.WriteLine("Invalid action.");
                                    break;
                            }
                            break;
                        case "5":
                            studentManager = new StudentManager(students);
                            Console.WriteLine("Enter action: Add, Update, Delete");
                            var studentAction = Console.ReadLine();
                            switch (studentAction.ToLower())
                            {
                                case "add":
                                    Console.Write("Enter Student ID: ");
                                    var studentId = int.Parse(Console.ReadLine());
                                    Console.Write("Enter Student Name: ");
                                    var studentName = Console.ReadLine();
                                    Console.Write("Enter Student Age: ");
                                    var studentAge = int.Parse(Console.ReadLine());
                                    Console.Write("Enter Student Marks: ");
                                    var studentMarks = int.Parse(Console.ReadLine());
                                    Console.Write("Enter Student Grade: ");
                                    var studentGrade = Console.ReadLine();
                                    studentManager.AddStudent(studentId, studentName, studentAge, studentMarks, studentGrade);
                                    break;
                                case "update":
                                    Console.Write("Enter Student ID to update: ");
                                    var updateStudentId = int.Parse(Console.ReadLine());
                                    Console.Write("Enter New Student Name: ");
                                    var updateStudentName = Console.ReadLine();
                                    Console.Write("Enter New Student Age: ");
                                    var updateStudentAge = int.Parse(Console.ReadLine());
                                    Console.Write("Enter New Student Marks: ");
                                    var updateStudentMarks = int.Parse(Console.ReadLine());
                                    Console.Write("Enter New Student Grade: ");
                                    var updateStudentGrade = Console.ReadLine();
                                    studentManager.UpdateStudent(updateStudentId, updateStudentName, updateStudentAge, updateStudentMarks, updateStudentGrade);
                                    break;
                                case "delete":
                                    Console.Write("Enter Student ID to delete: ");
                                    var deleteStudentId = int.Parse(Console.ReadLine());
                                    studentManager.DeleteStudent(deleteStudentId);
                                    break;
                                default:
                                    Console.WriteLine("Invalid action.");
                                    break;
                            }
                            break;

                        case "6":
                            Console.WriteLine("Exiting the system.");
                            return;

                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            break;




                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Critical error: {ex.Message}");
            }
        }
    }
}
