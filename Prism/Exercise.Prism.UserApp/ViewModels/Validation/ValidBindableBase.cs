using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Results;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Prism.User.ViewModels.Validation
{
    public class ValidBindableBase<T> : BindableBase, IDataErrorInfo
    {
        public ValidBindableBase(IValidator<T> validator)
        {
            _validator = validator;
        }

        public string this[string columnName]
        {
            get
            {
                var properties = new[] { columnName };

                var context = new ValidationContext(this, new PropertyChain(), new MemberNameValidatorSelector(properties));

                var result = _validator.Validate(context);

                if (result.IsValid) return string.Empty;

                return CreateErrorMessage(result.Errors);
            }
        }

        private IValidator<T> _validator;

        public bool IsValid { get { return _validator.Validate(this).IsValid; } }

        public string Error
        {
            get
            {
                var result = _validator.Validate(this);
                return CreateErrorMessage(result.Errors);

            }
        }

        private string CreateErrorMessage(IList<ValidationFailure> errors)
        {
            // the property has only one error
            if (errors.Count == 1)
                return errors.FirstOrDefault()?.ErrorMessage;

            // the property has multiple error
            StringBuilder builder = new StringBuilder();

            foreach (var error in errors)
            {
                builder.AppendLine($"---- {errors.IndexOf(error) + 1 }. Message ----");
                builder.AppendLine(error.ErrorMessage);
            }

            return builder.ToString();
        }
    }
}
