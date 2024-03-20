using Microsoft.EntityFrameworkCore;
using PaymentAPI.DataAccess.ApplicationDataBaseContext;
using PaymentAPI.DataAccess.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.DataAccess.Repos
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly ApplicationDbContext _applicationDbContext;
        internal DbSet<T> _dbSet;

        //Constructor
        public Repository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _dbSet = _applicationDbContext.Set<T>();    
        }

        //Methods
        public async Task<IEnumerable<T>> GetAllElements() => await _dbSet.ToListAsync();

        public async Task<T> GetElementById(int? id) => await _dbSet.FindAsync(id);

        public T GetElementByParams(Expression<Func<T,bool>> filter)
        {
            IQueryable<T> query = _dbSet.Where(filter);
            return query.FirstOrDefault();
        } 

        public void UpdateElement(T element)
        {
            _dbSet.Attach(element);
            _dbSet.Entry(element).State = EntityState.Modified; 
        }

        public void DeleteElement(T element) => _dbSet.Remove(element);

        public async Task AddElement(T element) => await _dbSet.AddAsync(element);
    }
}
