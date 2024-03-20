using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.DataAccess.Repos.Interfaces
{
    public interface IRepository <T> where T : class
    {
        Task<IEnumerable<T>> GetAllElements();
        Task<T> GetElementById(int? id);
        T GetElementByParams(Expression<Func<T, bool>> filter);
        Task AddElement(T element); 
        void UpdateElement(T element);
        void DeleteElement(T element);

    }
}
