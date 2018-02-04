using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Prism.User.ViewModels.Validation
{
    public class UserDetailValidation : AbstractValidator<UserDetailViewModel>
    {
        public static Lazy<UserDetailValidation> Singleton = new Lazy<UserDetailValidation>(() => new UserDetailValidation());

        private UserDetailValidation()
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
