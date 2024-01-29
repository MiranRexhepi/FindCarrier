using FindCarrier.HttpRequests;
using FluentValidation;

namespace FindCarrier.Validators
{
    public class AddOrCreateCompanyRequestValidator : AbstractValidator<AddOrCreateCompanyRequest>
    {
        public AddOrCreateCompanyRequestValidator() 
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Location).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.Website).NotEmpty();
        }
    }
}