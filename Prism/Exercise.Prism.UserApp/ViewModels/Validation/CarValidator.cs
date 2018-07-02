using Exercise.Prism.User.Data;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Prism.User.ViewModels.Validation
{
    public class CarValidator : AbstractValidator<CarViewModel>
    {
        public static Lazy<CarValidator> Singleton =
            new Lazy<CarValidator>(() => new CarValidator());

        private CarValidator()
        {
            RuleFor(x => x.CarId)
                .LessThan(10).WithMessage("ID should be less than 10");

            RuleFor(x => x.Color)
                .MinimumLength(3).WithMessage("Minimum length is 3 chars")
                .NotEmpty().WithMessage("Auto has a color!");

            RuleFor(x => x.BuyDate)
                .NotEmpty().WithMessage("Buy time is mandatory")
                .Must(a => a < DateTime.Now).WithMessage("Buy date have to be in past");
        }
    }
}
