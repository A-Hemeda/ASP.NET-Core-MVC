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
    public class EmployeeRepository : GenericRepository<Employee>,IEmployeeRepository
    {

        private readonly MVCAppDbContext _context;

        public EmployeeRepository(MVCAppDbContext context):base(context) 
        {
            _context = context;
        }

        public IEnumerable<Employee> Search(string name)
            => _context.Employees.Where(e => e.Name.Trim().ToLower().Contains(name.Trim().ToLower()));

        //public int Add(Employee employee)
        //{
        //    _context.Employees.Add(employee);
        //    return _context.SaveChanges();
        //}

        //public int Delete(Employee employee)
        //{
        //    _context.Employees.Remove(employee);
        //    return _context.SaveChanges();
        //}

        //public IEnumerable<Employee> GetAll()
        // => _context.Employees.ToList();


        //public Employee GetById(int? id)
        // => _context.Employees.FirstOrDefault(emp => emp.Id == id);


        //public int Update(Employee employee)
        //{

        //    _context.Employees.Update(employee);
        //    return _context.SaveChanges();

        //}


    }
}
