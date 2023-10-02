using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Offer.Commands.UpdateOffer
{
    public class UpdateOfferValidator : AbstractValidator<UpdateOfferCommand>
    {
        public UpdateOfferValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(1500);

            RuleFor(x => x.Price)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
