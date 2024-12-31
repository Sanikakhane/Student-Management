namespace StudentManagementSystem
{
    public interface ISortable
    {
        List<Student> SortByMarks();
        List<Student> SortByName();
    }
    public interface IFilterable
    {
        List<Student> GetStudentsByGrade(string grade);
        List<Student> GetToppers(int count);
        
    }

}
