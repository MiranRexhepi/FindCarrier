using FindCarrier.HttpRequests;
using FluentValidation;

namespace FindCarrier.Validators
{
    public class AddOrCreateUniversityRequestValidator : AbstractValidator<AddOrCreateUniversityRequest>
    {
        public AddOrCreateUniversityRequestValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Location).NotEmpty();
            RuleFor(x => x.Field).NotEmpty();
            RuleFor(x => x.SchoolType).NotEmpty();
            RuleFor(x => x.LogoURL).NotEmpty();
            RuleFor(x => x.WebURL).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}