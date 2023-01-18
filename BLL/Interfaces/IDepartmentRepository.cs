using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        #region Without Generic
        //IEnumerable<Department> GetAll();
        //Department Get(int id);
        //int Add(Department department);
        //int Update(Department department);
        //int Delete(Department department);
        #endregion

    }
}
