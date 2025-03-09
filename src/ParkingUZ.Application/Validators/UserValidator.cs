using FluentValidation;
using ParkingUZ.Core.Entities;

namespace ParkingUZ.Application.Validators
{
    public class UserValidator : AbstractValidator<User>
    { 
        public UserValidator()
        {
            RuleFor(user => user)
                .NotEmpty();
        }
    }
}
