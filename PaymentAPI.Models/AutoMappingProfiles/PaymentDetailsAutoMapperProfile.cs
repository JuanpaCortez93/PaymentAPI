using AutoMapper;
using PaymentAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.Models.AutoMappingProfiles
{
    public class PaymentDetailsAutoMapperProfile : Profile
    {
        public PaymentDetailsAutoMapperProfile()
        {
            CreateMap<PaymentDetails,PaymentDetailsGetDTO>();
            CreateMap<PaymentDetailsPostDTO,PaymentDetails>();
            CreateMap<PaymentDetailsPutDTO, PaymentDetails>();
        }
    }
}
