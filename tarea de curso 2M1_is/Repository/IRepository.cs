using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarea_de_curso_2M1_is
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(object dto);
        Task<bool> UpdateAsync(int id, object dto);
        Task<bool> DeleteAsync(int id);
    }
}
