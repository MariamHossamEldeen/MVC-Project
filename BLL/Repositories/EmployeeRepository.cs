using BLL.Interfaces;
using DAL.Contexts;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly MVCAppDbContext _dbContext;

        #region Without Generic
        //private readonly MVCAppDbContext _dbContext;
        //public EmployeeRepository(MVCAppDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}
        //public int Add(Employee employee)
        //{
        //    _dbContext.Employees.Add(employee);
        //    return _dbContext.SaveChanges();
        //}

        //public int Delete(Employee employee)
        //{
        //    _dbContext.Employees.Remove(employee);
        //    return _dbContext.SaveChanges();
        //}

        //public Employee Get(int id)
        //{
        //    return _dbContext.Employees.Where(E => E.Id == id).FirstOrDefault();
        //}

        //public IEnumerable<Employee> GetAll()
        //{
        //    return _dbContext.Employees.ToList();
        //}

        //public int Update(Employee employee)
        //{
        //    _dbContext.Employees.Update(employee);
        //    return _dbContext.SaveChanges();
        //}

        #endregion


        public EmployeeRepository(MVCAppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<Employee> GetEmployeesByDepartmentName(string departmentName)
        {
            return null;
        }

        public IQueryable<Employee> GetEmployeesByName(string name)
        {
            return _dbContext.Employees.Where(e => e.Name.Contains(name));
        }
    }
}
