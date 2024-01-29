using FindCarrier.HttpRequests;
using FluentValidation;

namespace FindCarrier.Validators
{
    public class AddOrCreateJobRequestValidator : AbstractValidator<AddOrCreateJobRequest>
    {
        public AddOrCreateJobRequestValidator()
        {
            RuleFor(x => x.JobPosition).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Deadline).NotEmpty();
            RuleFor(x => x.JobTypeId).NotEmpty().IsInEnum();
            RuleFor(x => x.CompanyId).NotEmpty();
        }
    }
}
