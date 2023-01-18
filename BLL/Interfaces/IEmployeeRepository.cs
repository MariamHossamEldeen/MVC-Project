using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        #region Without Generic
        //IEnumerable<Employee> GetAll();
        //Employee Get(int id);
        //int Add(Employee employee);
        //int Update(Employee employee);
        //int Delete(Employee employee);
        #endregion

        IQueryable<Employee> GetEmployeesByDepartmentName(string departmentName);
        IQueryable<Employee> GetEmployeesByName(string name);
    }
}
