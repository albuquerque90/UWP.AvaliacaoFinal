using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.AvaliacaoFinal.Interfaces
{
    public interface IRepository<T>
    {
        Task LoadAll();
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
