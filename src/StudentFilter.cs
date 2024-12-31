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
           this.students = students;
        }

        public List<Student> GetStudentsByGrade(string grade)
        {
            return  students.Where(st => st.Grade==grade).ToList();
        }

        public List<Student> GetToppers(int count)
        {
            return students.OrderByDescending(st => st.Marks).Take(count).ToList(); 
        }
        public List<Student> GetStudentsByCourse(string? courseName, List<Enrollment> enrollments, List<Course> courses)
        {
           var courseId = courses.FirstOrDefault(c => c.CourseName == courseName).CourseId;
            if (courseId != null) 
            {
                return new List<Student>();
            }
            return students.Where(st => enrollments.Any(e => e.StudentId ==st.Id && e.CourseId ==courseId)).ToList();
        }
        public Dictionary<string, List<Student>> GroupStudentsByCourses(List<Enrollment> enrollments, List<Course> courses)
        {
            return courses.ToDictionary(
                course => course.CourseName,
                course => students.Where(st => enrollments.Any(e => e.StudentId == st.Id && e.CourseId == course.CourseId)).ToList()
            );
        }
        public List<Student> GetTopScorersByCourse(string courseName, int topCount, List<Enrollment> enrollments, List<Course> courses)
        {
            var courseId = courses.FirstOrDefault(c => c.CourseName == courseName)?.CourseId;

            if (courseId == null)
                return new List<Student>();

            return students
                .Where(st => enrollments.Any(e => e.StudentId == st.Id && e.CourseId == courseId))
                .OrderByDescending(st => st.Marks)
                .Take(topCount)
                .ToList();
        }


    }
}



