using FluentValidation;

namespace Toto.MovieInfo.ServiceModel.Validators
{
    public class ActorForCreateValidator : AbstractValidator<ActorForCreate>
    {
        public ActorForCreateValidator()
        {
            RuleFor(prop => prop.FirstName).NotEmpty();
            RuleFor(prop => prop.LastName).NotEmpty();
            RuleFor(prop => prop.Bio).NotEmpty();
            RuleFor(prop => prop.BirthDate).NotEmpty();
        }
    }
}
