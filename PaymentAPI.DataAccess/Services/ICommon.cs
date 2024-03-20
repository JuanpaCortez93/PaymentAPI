using PaymentAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.DataAccess.Services
{
    public interface ICommon<TGet, TPost, TPut>
    {
        Task<IEnumerable<TGet>> GetAllElements();
        Task<TGet> AddElement(TPost t);
        Task<TGet> EditPaymentDetails(TPut t);
        Task<TGet> DeleteElement(int? id);
    }
}
