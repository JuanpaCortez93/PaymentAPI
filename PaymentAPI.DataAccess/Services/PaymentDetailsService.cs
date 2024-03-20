using AutoMapper;
using FluentValidation;
using PaymentAPI.DataAccess.Repos.Interfaces;
using PaymentAPI.Models;
using PaymentAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.DataAccess.Services
{
    public class PaymentDetailsService : IPaymentDetailsService
    {

        private IUnitOfWork _unitOfWork;
        private IMapper _paymentDetailsMapper;
        private IValidator<PaymentDetailsPostDTO> _postValidator;  
        private IValidator<PaymentDetailsPutDTO> _putValidator;

        public PaymentDetailsService(
            IUnitOfWork unitOfWork,
            IMapper paymentDetailsMapper
            )
        {
            _unitOfWork = unitOfWork;   
            _paymentDetailsMapper = paymentDetailsMapper;
        }

        public async Task<IEnumerable<PaymentDetailsGetDTO>> GetAllElements()
        {
            var paymentDetails = await _unitOfWork.PaymentDetailRepository.GetAllElements();
            var paymentDetailsDTO = paymentDetails.Select(paymentDetail => _paymentDetailsMapper.Map<PaymentDetailsGetDTO>(paymentDetail));
            return paymentDetailsDTO;
        }

        public async Task<PaymentDetailsGetDTO> AddElement(PaymentDetailsPostDTO t)
        {

            var validationResult = await _postValidator.ValidateAsync(t);
            if (!validationResult.IsValid) return null;

            var paymentDetails = _paymentDetailsMapper.Map<PaymentDetails>(t);

            await _unitOfWork.PaymentDetailRepository.AddElement(paymentDetails);
            await _unitOfWork.SaveChangesAsync();

            var paymentDetailsDTO = _paymentDetailsMapper.Map<PaymentDetailsGetDTO>(paymentDetails);
            return paymentDetailsDTO;
        }


        public async Task<PaymentDetailsGetDTO> EditPaymentDetails(PaymentDetailsPutDTO t)
        {

            var validationResult = await _putValidator.ValidateAsync(t);
            if (!validationResult.IsValid) return null;

            var paymentDetails = await _unitOfWork.PaymentDetailRepository.GetElementById(t.PaymentDetailId);
            if (paymentDetails == null) return null;

            paymentDetails = _paymentDetailsMapper.Map<PaymentDetailsPutDTO, PaymentDetails>(t, paymentDetails);

            _unitOfWork.PaymentDetailRepository.UpdateElement(paymentDetails);
            _unitOfWork.SaveChanges();

            var paymentDetailsDTO = _paymentDetailsMapper.Map<PaymentDetailsGetDTO>(paymentDetails);

            return paymentDetailsDTO;

        }

        public async Task<PaymentDetailsGetDTO> DeleteElement(int? id)
        {

            var paymentDetails = await _unitOfWork.PaymentDetailRepository.GetElementById(id);
            if (paymentDetails == null) return null;

            _unitOfWork.PaymentDetailRepository.DeleteElement(paymentDetails);
            _unitOfWork.SaveChanges();

            var paymentDetailsDTO = _paymentDetailsMapper.Map<PaymentDetailsGetDTO>(paymentDetails);
            return paymentDetailsDTO;
        }




    }
}
