namespace StudentManagementSystem.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string? CourseName { get; set; } 
        public string? Instructor { get; set; } 

        public Course(int courseId, string? courseName, string? instructor)
        {
            CourseId = courseId;
            CourseName = courseName;
            Instructor = instructor;
        }
    }
}
