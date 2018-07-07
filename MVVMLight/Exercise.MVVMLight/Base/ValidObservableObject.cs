using FluentValidation;
using GalaSoft.MvvmLight;
using System;
using System.ComponentModel;
using System.Linq;

namespace Exercise.MVVMLight.Data
{
    public abstract class ValidObservableObject<T> : ObservableObject, IDataErrorInfo
    {
        public ValidObservableObject(IValidator<T> validator, ViewModelState initState)
        {
            _validator = validator;

            State = initState;

            PropertyChanged += (s, e) =>
            {
                State |= ViewModelState.Updated;
            };
        }

        private ViewModelState _state;
        public ViewModelState State { get => _state; set => Set(ref _state, value); }
        private void AddIsValdState() => State = State | ViewModelState.Valid;
        private void RemoveIsValdState() => State &= ~ViewModelState.Valid;

        #region IDataErrorInfo
        private IValidator<T> _validator;

        public string this[string columnName]
        {
            get
            {
                var result = columnName.ValidateProperty(this, _validator);
                IsValid = result == string.Empty;
                return result;
            }
        }

        // getting value of this property will init new validation
        public bool IsValid
        {
            get
            {
                var result = _validator.Validate(this).IsValid;

                IsValid = result;

                return result;
            }
            set
            {
                if (value)
                    AddIsValdState();
                else
                    RemoveIsValdState();
            }
        }

        public string Error
        {
            get
            {
                var result = _validator.Validate(this);

                return result.Errors.CreateErrorMessage();
            }
        }

        public string[] Errors
        {
            get
            {
                var result = _validator.Validate(this);

                return result.Errors.Select(a => a.ErrorMessage).ToArray();
            }
        }
        #endregion
    }
}
