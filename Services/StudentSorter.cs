using System.Collections.Generic;
using System.Linq;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services
{
    public class StudentSorter : ISortable
    {
        private readonly List<Student> students;

        public StudentSorter(List<Student> students)
        {
            this.students = students;
        }

        public List<Student> SortByMarks()
        {
            return students?.OrderByDescending(st => st.Marks).ToList() ?? new List<Student>();
        }

        public List<Student> SortByName()
        {
            return students?.OrderBy(st => st.Name).ToList() ?? new List<Student>();
        }
    }
}
