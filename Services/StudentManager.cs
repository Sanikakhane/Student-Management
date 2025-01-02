using System;
using System.Collections.Generic;
using System.Linq;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services
{
    public class StudentManager
    {
        private readonly List<Student> students;

        public StudentManager(List<Student> students)
        {
            this.students = students ?? throw new ArgumentNullException(nameof(students), "Student list cannot be null.");
        }

        public void AddStudent(int id, string name, int age, int marks, string grade)
        {
            try
            {
                if (students.Any(s => s.Id == id))
                {
                    Console.WriteLine("A student with this ID already exists.");
                    return;
                }

                students.Add(new Student(id, name, age, marks, grade));
                JsonHelper.SaveJsonData(students, GlobalPath.studentDataPath);
                Console.WriteLine("Student added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding student: {ex.Message}");
            }
        }

        public void UpdateStudent(int id, string name, int age, int marks, string grade)
        {
            try
            {
                var student = students.FirstOrDefault(s => s.Id == id);
                if (student == null)
                {
                    Console.WriteLine("Student not found.");
                    return;
                }

                student.Name = name;
                student.Age = age;
                student.Marks = marks;
                student.Grade = grade;
                JsonHelper.SaveJsonData(students, GlobalPath.studentDataPath);
                Console.WriteLine("Student updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating student: {ex.Message}");
            }
        }

        public void DeleteStudent(int id)
        {
            try
            {
                var student = students.FirstOrDefault(s => s.Id == id);
                if (student == null)
                {
                    Console.WriteLine("Student not found.");
                    return;
                }

                students.Remove(student);
                JsonHelper.SaveJsonData(students, GlobalPath.studentDataPath);
                Console.WriteLine("Student deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting student: {ex.Message}");
            }
        }

        public Student? GetStudentById(int id)
        {
            try
            {
                return students.FirstOrDefault(s => s.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving student: {ex.Message}");
                return null;
            }
        }

        public List<Student> GetAllStudents()
        {
            try
            {
                return students.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving all students: {ex.Message}");
                return new List<Student>();
            }
        }
    }
}
