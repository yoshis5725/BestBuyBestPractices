using System.Data;
using Dapper;

namespace BestBuyBestPractices;

public class DapperDepartmentRepository : IDepartmentRepository
{
    // fields
    private readonly IDbConnection _connection;
    
    
    // constructor
    public DapperDepartmentRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    
    
    // methods
    
    /// <summary>
    /// Returning all department categories from the Db
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Department> GetAllDepartments()
    {
        return _connection.Query<Department>("SELECT * FROM Departments;");
    }

    /// <summary>
    /// Inserting a new department into the Db
    /// </summary>
    /// <param name="newDepartmentName"></param>
    public void InsertDepartment(string newDepartmentName)
    {
        _connection.Execute("INSERT INTO Departments (Name) VALUES (@departmentName);",
        new { departmentName = newDepartmentName });
    }
}