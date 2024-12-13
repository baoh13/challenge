using FluentValidation;

namespace challenge_features.Queries.GetLatestOrder
{
    public class GetLatestOrderValidator: AbstractValidator<GetLatestOrderQuery>
    {
        public GetLatestOrderValidator()
        {
            RuleFor(c => c.User)
            .NotNull().WithMessage($"{nameof(GetLatestOrderQuery.User)} is required")
            .NotEmpty().WithMessage($"{nameof(GetLatestOrderQuery.User)} Must not be Empty");

            RuleFor(c => c.CustomerId)
            .NotNull().WithMessage($"{nameof(GetLatestOrderQuery.CustomerId)} is required")
            .NotEmpty().WithMessage($"{nameof(GetLatestOrderQuery.CustomerId)} Must not be Empty");
        }
    }
}
