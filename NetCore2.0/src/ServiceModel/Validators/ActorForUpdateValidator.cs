using FluentValidation;

namespace Toto.MovieInfo.ServiceModel.Validators
{
    public class ActorForUpdateValidator : AbstractValidator<ActorForUpdate>
    {
        public ActorForUpdateValidator()
        {
            RuleFor(prop => prop.FirstName).NotEmpty();
            RuleFor(prop => prop.LastName).NotEmpty();
            RuleFor(prop => prop.Bio).NotEmpty();
            RuleFor(prop => prop.BirthDate).NotEmpty();
        }
    }
}