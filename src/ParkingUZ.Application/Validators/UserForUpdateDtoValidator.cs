using FluentValidation;
using ParkingUZ.Application.DTO;

namespace ParkingUZ.Application.Validators
{
    public class UserForUpdateDtoValidator : AbstractValidator<UpdateUserDTO>
    {
        public UserForUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
           .MaximumLength(50).WithMessage("Name must not exceed 50 characters")
           .When(x => !string.IsNullOrEmpty(x.Name));

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Invalid email format")
                .MaximumLength(100).WithMessage("Email must not exceed 100 characters")
                .When(x => !string.IsNullOrEmpty(x.Email));

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("PhoneNumber cannot be empty")
                .MinimumLength(13).WithMessage("PhoneNumber must be at least 13 characters long")
                .Matches(@"^\+").WithMessage("PhoneNumber must start with '+'")
                .Matches(@"^\+\d+$").WithMessage("PhoneNumber must contain only digits after '+'");

            RuleFor(x => x.Password)
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
                .Matches("[0-9]").WithMessage("Password must contain at least one number")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character")
                .When(x => !string.IsNullOrEmpty(x.Password));
        }
    }
}
