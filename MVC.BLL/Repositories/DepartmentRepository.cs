using MVC.BLL.Interfaces;
using MVC.DAL.Context;
using MVC.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.BLL.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>,IDepartmentRepository
    {
        private readonly MVCAppDbContext _context;

        public DepartmentRepository(MVCAppDbContext context):base(context)
        {
            _context = context;
        }
        //public int Add(Department department)
        //{
        //    _context.Departments.Add(department);
        //    return _context.SaveChanges();
        //}

        //public int Delete(Department department)
        //{
        //    _context.Departments.Remove(department);
        //    return _context.SaveChanges();
        //}

        //public IEnumerable<Department> GetAll()
        //=>_context.Departments.ToList();

        //public Department GetById(int? Id)
        //=> _context.Departments.FirstOrDefault(dept => dept.Id==Id);

        //public int Update(Department department)
        //{
        //    _context.Departments.Update(department);
        //    return _context.SaveChanges();
        //}
    }
}
