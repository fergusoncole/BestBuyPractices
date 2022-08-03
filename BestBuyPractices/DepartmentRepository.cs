using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyPractices;

internal class DepartmentRepository : IDepartmentRepository
{
    private readonly IDbConnection _connection;

    public DepartmentRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public IEnumerable<Department> GetAllDepartments()
    {
        return _connection.Query<Department>("SELECT * FROM departments;");
    }

    public Department GetDepartment(int newID)
    {
        return _connection.QuerySingle<Department>("SELECT * FROM departments WHERE DepartmentId = @ID;",
            new { ID = newID});
    }

    public void InsertDepartment(string newDepartmentName)
    {
        _connection.Execute("INSERT INTO departments (Name) VALUES (@departmentname);", 
            new {departmentname = newDepartmentName});
    }

    public void UpdateDepartment(int id, string newName)
    {
       _connection.Execute("UPDATE departments SET NAME = @name WHERE DepartmentID = @id;", 
           new { name = newName, id = id });
    }

    public void DeleteDepartment(int newID)
    {
        _connection.Execute("DELETE FROM departments WHERE DepartmentID = @id;", 
            new {id = newID});
    }

    public Department GetDepartmentBy(int newID)
    {
        throw new NotImplementedException();
    }
    //public void DeleteDepartments(int startPosition, int endPosition)
    //{
    //    _connection.Execute("DELETE FROM departments WHERE DepartmentID BETWEEN @start AND @end;", new { start = startPosition, end = endPosition });
    // }
}



//    public void InsertDepartment(string newDepartmentName)
//    {
//        _connection.Execute("INSERT INTO departments (Name) VALUES (@name);", new {name = newDepartmentName});
//    }
//    public void UpdateDepartment(int id, string newDepartmentName)
//    {
//       _connection.Execute("INSERT INTO departments (Name) VALUES (@name);", new { name = newDepartmentName });
//    }
//    public void DeleteDepartment(int newID)
//    {
//        _connection.Execute("DELETE FROM departments WHERE DepartmentID = @id;", new {id = newID});
//    }
//    public void DeleteDepartments(int startPosition, int endPosition)
//   {
//        _connection.Execute("DELETE FROM departments WHERE DepartmentID BETWEEN @start AND @end;", new { start = startPosition, end = endPosition });
//    }
//}
