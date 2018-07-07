using Exercise.MVVMLight.User;
using FluentValidation;
using System;

namespace Exercise.MVVMLight.Data
{
    public class UserValidator : AbstractValidator<UserViewModel>
    {
        public static Lazy<UserValidator> Singleton = new Lazy<UserValidator>(() => new UserValidator());

        // Private constructor forces you to access this class trought the lazy Singleton
        // this is just easy hack, in production please use some dependency injection container
        private UserValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .Length(3, 10).WithMessage($"First name have to be longer like 3 characters and shorter like 15 characters.");

            RuleFor(x => x.SecondName)
                .NotEmpty().WithMessage("Second name is required.")
                .Length(3, 10).WithMessage($"Second name have to be longer like 3 characters and shorter like 15 characters.");

            RuleFor(x => x.Age)
                .Must(x => x > 17).WithMessage("Age have to be greather like 17.")
                .Must(x => x < 80).WithMessage("User is too old.");
        }
    }
}
