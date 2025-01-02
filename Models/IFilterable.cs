namespace StudentManagementSystem
{
    public interface IFilterable
    {
        List<Student> GetStudentsByGrade(string grade);
        List<Student> GetToppers(int count);
        List<Student> GetStudentsByCourse(string? courseName, List<Enrollment> enrollments, List<Course> courses);
        Dictionary<string, List<Student>> GroupStudentsByCourses(List<Enrollment> enrollments, List<Course> courses);
        List<Student> GetTopScorersByCourse(string courseName, int topCount, List<Enrollment> enrollments, List<Course> courses);
    }
}
