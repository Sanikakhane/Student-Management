namespace StudentManagementSystem.Models
{
    public interface ISortable
    {
        List<Student> SortByMarks();
        List<Student> SortByName();
    }
}
