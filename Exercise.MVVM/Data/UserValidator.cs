using FluentValidation;
using System;

namespace Exercise.MVVM.Data
{
    public class UserValidator : AbstractValidator<User>
    {
        public static Lazy<UserValidator> Singleton = new Lazy<UserValidator>(() => new UserValidator());
        private UserValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull().WithMessage("First name is required.")
                .Length(3, 10).WithMessage($"First name have to be longer like 3 characters and shorter like 15 characters.");

            RuleFor(x=>x.SecondName)
                .NotNull().WithMessage("Second name is required.")
                .Length(3, 10).WithMessage($"Second name have to be longer like 3 characters and shorter like 15 characters.");

            RuleFor(x => x.Age)
                .Must(x => x > 17).WithMessage("Age have to be greather like 17.")
                .Must(x => x < 80).WithMessage("User is too old.");
        }
    }
}
