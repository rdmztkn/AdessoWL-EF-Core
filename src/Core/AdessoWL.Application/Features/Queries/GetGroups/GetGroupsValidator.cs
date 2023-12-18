using FluentValidation;

namespace AdessoWL.Application.Features.Queries.GetGroups;
public class GetGroupsValidator : AbstractValidator<GetGroupsQuery>
{
    public GetGroupsValidator()
    {
        RuleFor(i => i.GroupNumber)
            .Must(i => i == 4 || i == 8)
            .WithMessage("Group number must be 4 or 8.");

        //RuleFor(i => i.FirstName)
        //    .NotEmpty()
        //    .WithMessage("First name is required.");

        //RuleFor(i => i.LastName)
        //    .NotEmpty()
        //    .WithMessage("Last name is required.");
    }
}
