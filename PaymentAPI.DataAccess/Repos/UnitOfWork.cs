using PaymentAPI.DataAccess.ApplicationDataBaseContext;
using PaymentAPI.DataAccess.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.DataAccess.Repos
{
    public class UnitOfWork : IUnitOfWork
    {

        private ApplicationDbContext _applicationDbContext;
        public IPaymentDetails PaymentDetailRepository { get; }

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            PaymentDetailRepository = new PaymentDetailsRepository(_applicationDbContext);
        }

        public void SaveChanges() => _applicationDbContext.SaveChanges();
        public Task SaveChangesAsync() => _applicationDbContext.SaveChangesAsync();     
    }
}
