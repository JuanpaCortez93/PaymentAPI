using FluentValidation;
using PaymentAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.Models.FormatValidators
{
    public class PaymentDetailsPostFormatValidator : AbstractValidator<PaymentDetailsPostDTO>
    {
        public PaymentDetailsPostFormatValidator()
        {
            RuleFor(x => x.CardOwnerName).Length(2, 100).WithMessage("No more than 100 characters");
            RuleFor(x => x.CardNumber).NotEmpty().Must(w => w.Length == 16).WithMessage("Just 16 characters");
        }
    }
}
