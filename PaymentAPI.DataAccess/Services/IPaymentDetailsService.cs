using PaymentAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.DataAccess.Services
{
    public interface IPaymentDetailsService : ICommon<PaymentDetailsGetDTO, PaymentDetailsPostDTO, PaymentDetailsPutDTO>
    {
    }
}
