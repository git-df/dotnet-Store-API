using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Order.Commands.AddOrder
{
    public class AddOrderValidator : AbstractValidator<AddOrderCommand>
    {
        public AddOrderValidator() 
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.City)
                .NotEmpty();

            RuleFor(x => x.StreetWithNumber)
                .NotEmpty();

            RuleFor(x => x.PhoneNumber)
                .NotEmpty();

            RuleFor(x => x.Country)
                .NotEmpty();

            RuleFor(x => x.PostalCode)
                .NotEmpty();
        }
    }
}
