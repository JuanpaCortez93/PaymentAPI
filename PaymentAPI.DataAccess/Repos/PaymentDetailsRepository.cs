using PaymentAPI.DataAccess.ApplicationDataBaseContext;
using PaymentAPI.DataAccess.Repos.Interfaces;
using PaymentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.DataAccess.Repos
{
    public class PaymentDetailsRepository : Repository<PaymentDetails>, IPaymentDetails
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PaymentDetailsRepository(ApplicationDbContext _applicationDbContext) : base(_applicationDbContext)
        {
            
        }
    }
}
