using System;
using System.Collections.Generic;
using System.Linq;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services
{
    public class CourseManager
    {
        private readonly List<Course> courses;
        private readonly List<Enrollment> enrollments;

        public CourseManager(List<Course> courses, List<Enrollment> enrollments)
        {
            if (courses == null)
                throw new ArgumentNullException(nameof(courses), "Courses list cannot be null.");

            if (enrollments == null)
                throw new ArgumentNullException(nameof(enrollments), "Enrollments list cannot be null.");

            this.courses = courses;
            this.enrollments = enrollments;
        }

        public void AddCourse(int courseId, string courseName, string instructor)
        {
            try
            {
                if (string.IsNullOrEmpty(courseName))
                    throw new ArgumentException("Course name cannot be null or empty.");

                if (courses.Any(c => c.CourseId == courseId))
                    throw new InvalidOperationException($"A course with ID {courseId} already exists.");

                courses.Add(new Course(courseId, courseName, instructor));
                JsonHelper.SaveJsonData(courses, GlobalPath.courseDataPath);
                Console.WriteLine($"Course '{courseName}' added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding course: {ex.Message}");
            }
        }

        public void UpdateCourse(int courseId, string newCourseName, string newInstructor)
        {
            try
            {
                if (string.IsNullOrEmpty(newCourseName))
                    throw new ArgumentException("course name cannot be null or empty.");

                if (string.IsNullOrEmpty(newInstructor))
                    throw new ArgumentException("instructor name cannot be null or empty.");

                var course = courses.FirstOrDefault(c => c.CourseId == courseId);

                if (course == null)
                    throw new KeyNotFoundException($"Course with ID {courseId} not found.");

                course.CourseName = newCourseName;
                course.Instructor = newInstructor;
                JsonHelper.SaveJsonData(courses, GlobalPath.courseDataPath);
                Console.WriteLine($"Course with ID {courseId} updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating course: {ex.Message}");
            }
        }

        public void DeleteCourse(int courseId)
        {
            try
            {
                var course = courses.FirstOrDefault(c => c.CourseId == courseId);

                if (course == null)
                    throw new KeyNotFoundException($"Course with ID {courseId} not found.");

                courses.RemoveAll(c => c.CourseId == courseId);
                enrollments.RemoveAll(e => e.CourseId == courseId);
                JsonHelper.SaveJsonData(courses, GlobalPath.courseDataPath);
                Console.WriteLine($"Course with ID {courseId} deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting course: {ex.Message}");
            }
        }

        public Course? GetCourseById(int courseId)
        {
            try
            {
                var course = courses.FirstOrDefault(c => c.CourseId == courseId);

                if (course == null)
                    throw new KeyNotFoundException($"Course with ID {courseId} not found.");

                return course;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving course by ID: {ex.Message}");
                return null;
            }
        }

        public List<Course> GetAllCourses()
        {
            try
            {
                if (courses.Count == 0)
                    throw new InvalidOperationException("No courses available.");

                return courses;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving all courses: {ex.Message}");
                return new List<Course>();
            }
        }
    }
}
