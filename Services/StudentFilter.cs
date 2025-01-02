using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem
{
    public class StudentFilter : IFilterable
    {
        private readonly List<Student> students;

        public StudentFilter(List<Student> students)
        {
            if (students == null || students.Count == 0)
                throw new ArgumentException("Student list cannot be null or empty.");

            this.students = students;
        }

        public List<Student> GetStudentsByGrade(string grade)
        {
            try
            {
                return students.Where(st => st.Grade == grade).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetStudentsByGrade: {ex.Message}");
                return new List<Student>();
            }
        }

        public List<Student> GetToppers(int count)
        {
            try
            {
                if (count <= 0)
                    throw new ArgumentException("Count must be greater than zero.");

                return students.OrderByDescending(st => st.Marks).Take(count).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetToppers: {ex.Message}");
                return new List<Student>();
            }
        }

        public List<Student> GetStudentsByCourse(string? courseName, List<Enrollment> enrollments, List<Course> courses)
        {
            try
            {
                if (string.IsNullOrEmpty(courseName))
                    throw new ArgumentException("Course name cannot be null or empty.");

                var courseId = courses.FirstOrDefault(c => c.CourseName == courseName)?.CourseId;

                if (courseId == null)
                    throw new ArgumentException($"Course '{courseName}' does not exist.");

                return students.Where(st => enrollments.Any(e => e.StudentId == st.Id && e.CourseId == courseId)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetStudentsByCourse: {ex.Message}");
                return new List<Student>();
            }
        }

        public Dictionary<string, List<Student>> GroupStudentsByCourses(List<Enrollment> enrollments, List<Course> courses)
        {
            try
            {
                if (courses == null || courses.Count == 0)
                    throw new ArgumentException("Course list cannot be null or empty.");

                return courses.ToDictionary(
                    course => course.CourseName,
                    course => students.Where(st => enrollments.Any(e => e.StudentId == st.Id && e.CourseId == course.CourseId)).ToList()
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GroupStudentsByCourses: {ex.Message}");
                return new Dictionary<string, List<Student>>();
            }
        }

        public List<Student> GetTopScorersByCourse(string courseName, int topCount, List<Enrollment> enrollments, List<Course> courses)
        {
            try
            {
                if (string.IsNullOrEmpty(courseName))
                    throw new ArgumentException("Course name cannot be null or empty.");

                if (topCount <= 0)
                    throw new ArgumentException("Top count must be greater than zero.");

                var courseId = courses.FirstOrDefault(c => c.CourseName == courseName)?.CourseId;

                if (courseId == null)
                    throw new ArgumentException($"Course '{courseName}' does not exist.");

                return students
                    .Where(st => enrollments.Any(e => e.StudentId == st.Id && e.CourseId == courseId))
                    .OrderByDescending(st => st.Marks)
                    .Take(topCount)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetTopScorersByCourse: {ex.Message}");
                return new List<Student>();
            }
        }
    }
}
