using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.Models.DTOs
{
    public class PaymentDetailsPostDTO
    {
        public string? CardOwnerName { get; set; }
        public string? CardNumber { get; set; }
        public string? ExpirationDate { get; set; }
        public string? SecurityCode { get; set; }
    }
}
