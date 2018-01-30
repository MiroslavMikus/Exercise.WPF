using FluentValidation;
using FluentValidation.Internal;
using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Linq;

namespace Exercise.MVVM.Data
{
    public abstract class ValidObservableObject<T> : ObservableObject, IDataErrorInfo
    {
        public ValidObservableObject(IValidator<T> validator)
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

                return result.Errors.FirstOrDefault()?.ErrorMessage;
            }
        }

        private IValidator _validator;

        public string Error => "";
    }
}
