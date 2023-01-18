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
    public class DepartmentRepository : GenericRepository<Department> , IDepartmentRepository
    {
        #region Without Generic
        //private readonly MVCAppDbContext _dbContext;
        //public DepartmentRepository(MVCAppDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}
        //public int Add(Department department)
        //{
        //    _dbContext.Departments.Add(department);
        //    return _dbContext.SaveChanges();
        //}

        //public int Delete(Department department)
        //{
        //    _dbContext.Departments.Remove(department);
        //    return _dbContext.SaveChanges();
        //}

        //public Department Get(int id)
        //{
        //    return _dbContext.Departments.Where(D => D.Id == id).FirstOrDefault();
        //}

        //public IEnumerable<Department> GetAll()
        //{
        //    return _dbContext.Departments.ToList();
        //}

        //public int Update(Department department)
        //{
        //    _dbContext.Departments.Update(department);
        //    return _dbContext.SaveChanges();
        //}
        #endregion

        public DepartmentRepository(MVCAppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
