using MVC.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.BLL.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        T GetById(int? id);
        IEnumerable<T> GetAll();

        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}
