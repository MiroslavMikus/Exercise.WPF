using FluentValidation;
using GalaSoft.MvvmLight;
using System;
using System.ComponentModel;
using System.Linq;

namespace Exercise.MVVMLight.Data
{
    /// <summary>
    /// Updating property will change state from unchanged to updated
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ValidObservableObject<T> : ObservableObject, IDataErrorInfo
    {
        public ValidObservableObject(IValidator<T> validator, ViewModelState initState = ViewModelState.Original)
        {
            _validator = validator;

            State = initState;

            PropertyChanged += (s, e) =>
            {
                AddState(ViewModelState.Updated);
            };
        }

        private ViewModelState _state;
        public ViewModelState State { get => _state; set => Set(ref _state, value); }
        protected void AddState(ViewModelState state) => State = State | state;
        protected void RemoveState(ViewModelState state) => State &= ~state;

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
                    AddState(ViewModelState.Valid);
                else
                    RemoveState(ViewModelState.Valid);
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
