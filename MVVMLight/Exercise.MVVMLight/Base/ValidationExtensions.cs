using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise.MVVMLight.Data
{
    public static class ValidationExtensions
    {
        public static string CreateErrorMessage(this IList<ValidationFailure> errors)
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

        public static string ValidateProperty<T>(this string propertyName, object instanceToValidate, IValidator<T> validator)
        {
            var properties = new[] { propertyName };

            var context = new ValidationContext(instanceToValidate, new PropertyChain(), new MemberNameValidatorSelector(properties));

            var result = validator.Validate(context);

            if (result.IsValid) return string.Empty;

            return result.Errors.CreateErrorMessage();
        }
    }
}
