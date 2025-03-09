using FluentValidation;
using ParkingUZ.DataAccess;

namespace ParkingUZ.Application.Validators
{
    public class UserForCreationDtoValidator : AbstractValidator<UserForCreationDTO>
    {
        public UserForCreationDtoValidator()
        {
            RuleFor(x => x.Name)
           .NotEmpty().WithMessage("Name cannot be empty")
           .Length(2, 50).WithMessage("Name must be between 2 and 50 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email cannot be empty")
                .EmailAddress().WithMessage("Invalid email format")
                .MaximumLength(100).WithMessage("Email must not exceed 100 characters");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("PhoneNumber cannot be empty")
                .MinimumLength(13).WithMessage("PhoneNumber must be at least 13 characters long")
                .Matches(@"^\+").WithMessage("PhoneNumber must start with '+'")
                .Matches(@"^\+\d+$").WithMessage("PhoneNumber must contain only digits after '+'");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password cannot be empty")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
                .Matches("[0-9]").WithMessage("Password must contain at least one number")
                .Matches("[^a-zA-Z0-9]").WithMessage
                ("Password must contain at least one special character");
        }
    }
}


