using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyPractices
{
    internal interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAllDepartments();
        public Department GetDepartmentBy(int newID);
        public void InsertDepartment(string newDepartmentName);
        public void UpdateDepartment(int id, string newDepartmentName);
        public void DeleteDepartment(int newID);
     //   public void DeleteDepartments(int startPosition, int endPosition);
   

    }
}
