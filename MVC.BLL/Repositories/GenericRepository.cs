using MVC.BLL.Interfaces;
using MVC.DAL.Context;
using MVC.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly MVCAppDbContext _context;

        public GenericRepository(MVCAppDbContext context)
        {
            _context = context;
        }
        public int Add(T entity) { 
        
            _context.Set<T>().Add(entity);
            return _context.SaveChanges();
        }

        public int Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
         => _context.Set<T>().ToList();
        public T GetById(int? id)
         => _context.Set<T>().FirstOrDefault(emp => emp.Id == id);


        public int Update(T entity)
        {

            _context.Set<T>().Update(entity);
            return _context.SaveChanges();

        }
    }
}
