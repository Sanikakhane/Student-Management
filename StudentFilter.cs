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
            students = students;
        }

        public IEnumerable<Student> GetStudentsByGrade(string grade)
        {
            return  students.Where(st => st.Grade==grade);
        }

        public IEnumerable<Student> GetToppers(int count)
        {
            return students.OrderByDescending(st => st.Marks).Take(count); 
        }
    }
    public class StudentSorter : ISortable
    {
        private readonly List<Student> students;

        public StudentSorter(List<Student> students)
        {
            this.students = students;
        }

        public List<Student> SortByMarks()
        {
           return students.OrderByDescending(st => st.Marks).ToList();
        }

        public List<Student> SortByName()
        {
            return students.OrderBy(st => st.Name).ToList();
        }
    }
}
