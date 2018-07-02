using Exercise.Prism.User.Data;
using Exercise.Prism.User.Data.Repository;
using Exercise.Prism.User.ViewModels.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Prism.User.ViewModels
{
    public class CarViewModel : ValidBindableBase<CarViewModel>
    {
        public Car localCar;

        public CarViewModel(Car data) : base(CarValidator.Singleton.Value)
        {
            localCar = data;
        }

        public int CarId
        {
            get => localCar.CarId;
            set { localCar.CarId = value; RaisePropertyChanged(); }
        }

        public string Color
        {
            get => localCar.Color;
            set { localCar.Color = value; RaisePropertyChanged(); }
        }

        public DateTime BuyDate
        {
            get => localCar.BuyDate;
            set { localCar.BuyDate = value; RaisePropertyChanged(); }
        }
    }
}
