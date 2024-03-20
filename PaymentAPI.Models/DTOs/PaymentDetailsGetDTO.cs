using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.Models.DTOs
{
    public class PaymentDetailsGetDTO
    {
        public int PaymentDetailId { get; set; }
        public string? CardOwnerName { get; set; } 
        public string? CardNumber { get; set; }
        public string? ExpirationDate { get; set; } 
        public string? SecurityCode { get; set; } 

    }
}
