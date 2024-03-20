using PaymentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.DataAccess.Repos.Interfaces
{
    public interface IUnitOfWork
    {
        IPaymentDetails PaymentDetailRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();

    }
}
