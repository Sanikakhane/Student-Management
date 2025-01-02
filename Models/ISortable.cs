namespace StudentManagementSystem
{
    public interface ISortable
    {
        List<Student> SortByMarks();
        List<Student> SortByName();
    }
}
