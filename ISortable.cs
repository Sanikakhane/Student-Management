namespace StudentManagementSystem
{
    public interface ISortable
    {
        List<Student> SortByMarks();
        List<Student> SortByName();
    }
    public interface IFilterable
    {
        IEnumerable<Student> GetStudentsByGrade(string grade);
        IEnumerable<Student> GetToppers(int count);
        
    }

}
