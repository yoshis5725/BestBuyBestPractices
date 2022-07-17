namespace BestBuyBestPractices;

public interface IDepartmentRepository
{
    IEnumerable<Department> GetAllDepartments();
}