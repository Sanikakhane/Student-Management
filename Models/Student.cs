namespace StudentManagementSystem.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; } 
        public int Age { get; set; }
        public int Marks { get; set; }
        public string? Grade { get; set; }

        public Student(int id, string? name, int age, int marks, string? grade)
        {
            Id = id;
            Name = name;
            Age = age;
            Marks = marks;
            Grade = grade;
        }
    }
}
